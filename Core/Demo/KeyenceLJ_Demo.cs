//----------------------------------------------------------------------------- 
// <copyright file="MainForm.cs" company="KEYENCE">
//	 Copyright (c) 2019 KEYENCE CORPORATION. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------- 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Lead.Tools.KeyenceLJ.Core.Resources;

namespace Lead.CPrim.PrimKeyenceLJ.Demo
{
	public partial class KeyenceLJ_Demo : Form
	{
		#region Constant
		private const uint NoErrorValue = 0u;
		private const int ProfileDataMinCount = 200;
		private const int DataCountInOneLine = 8;
		private const int NotAccessValue = 0;
		private const char NullChar = '\0';
		#endregion

		#region Enum

		/// <summary>
		/// Send command definition
		/// </summary>
		/// <remark>Defined for separate return code distinction</remark>
		private enum SendCommand
		{
			/// <summary>None</summary>
			None,
			/// <summary>Restart</summary>
			RebootController,
			/// <summary>Trigger</summary>
			Trigger,
			/// <summary>Start measurement</summary>
			StartMeasure,
			/// <summary>Stop measurement</summary>
			StopMeasure,
			/// <summary>Get profiles</summary>
			GetProfile,
			/// <summary>Get batch profiles</summary>
			GetBatchProfile,
			/// <summary>Initialize Ethernet high-speed data communication</summary>
			InitializeHighSpeedDataCommunication,
			/// <summary>Request preparation before starting high-speed data communication</summary>
			PreStartHighSpeedDataCommunication,
			/// <summary>Start high-speed data communication</summary>
			StartHighSpeedDataCommunication,
		}

		#endregion

		#region Field

		/// <summary>Ethernet settings structure </summary>
		private LJX8IF_ETHERNET_CONFIG _ethernetConfig;
		/// <summary>Current device ID</summary>
		private int _currentDeviceId;
		/// <summary>Send command</summary>
		private SendCommand _sendCommand;
		/// <summary>Callback function used during high-speed communication</summary>
		private HighSpeedDataCallBack _callback;
		/// <summary>Callback function used during high-speed communication (count only)</summary>
		private HighSpeedDataCallBack _callbackOnlyCount;
		/// <summary>Callback function used during high-speed communication (simple array)</summary>
		private HighSpeedDataCallBackForSimpleArray _callbackSimpleArray;
		/// <summary>Callback function used during high-speed communication (simple array) (count only)</summary>
		private HighSpeedDataCallBackForSimpleArray _callbackSimpleArrayOnlyCount;
		/// The following are maintained in arrays to support multiple controllers.
		/// <summary>Array of profile information structures</summary>
		private LJX8IF_PROFILE_INFO[] _profileInfo;
		/// <summary>Array of controller information</summary>
		private DeviceData[] _deviceData;
		/// <summary>Array of labels that indicate the controller status</summary>
		private Label[] _deviceStatusLabels;
		/// <summary>Array of labels that indicate the number of received profiles </summary>
		private Label[] _receivedProfileCountLabels;
		/// <summary>Array of value of receive buffer is full</summary>
		private static bool[] _isBufferFull = new bool[NativeMethods.DeviceCount];
		/// <summary>Array of value of stop processing has done by buffer full error</summary>
		private static bool[] _isStopCommunicationByError = new bool[NativeMethods.DeviceCount];

		#endregion

		#region Delegate
		private delegate void InvokeDelagate(); 
		#endregion

		#region Button for operating the DLL
		/// <summary>
		/// "Initialize" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonInitialize_Click(object sender, EventArgs e)
		{
			int rc = NativeMethods.LJX8IF_Initialize();
			AddLogResult(rc, DemoResource.IDS_INITIALIZE);
			
			for (int i = 0; i < _deviceData.Length; i++)
			{
				_deviceData[i].Status = DeviceStatus.NoConnection;
				_deviceStatusLabels[i].Text = _deviceData[i].GetStatusString();
				_receivedProfileCountLabels[i].Text = "0";
			}
		}

		/// <summary>
		/// "Finalize" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonFinalize_Click(object sender, EventArgs e)
		{
			int rc = NativeMethods.LJX8IF_Finalize();
			AddLogResult(rc, DemoResource.IDS_FINALIZE);
			for (int i = 0; i < _deviceData.Length; i++)
			{
				_deviceData[i].Status = DeviceStatus.NoConnection;
				_deviceStatusLabels[i].Text = _deviceData[i].GetStatusString();
				_receivedProfileCountLabels[i].Text = "0";
			}
		}

		/// <summary>
		/// "GetVersion" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonGetVersion_Click(object sender, EventArgs e)
		{
			AddLogResult((int)Rc.Ok, DemoResource.IDS_GET_VERSION);
			LJX8IF_VERSION_INFO versionInfo = NativeMethods.LJX8IF_GetVersion();
			string versionText = string.Format("{0}.{1}.{2}.{3}", versionInfo.nMajorNumber, versionInfo.nMinorNumber, versionInfo.nRevisionNumber, versionInfo.nBuildNumber);
			AddResult(@"Version", versionText);
		}
		#endregion

		#region Button for establishing and disconnecting the communication path with the controller

		/// <summary>
		/// "EthernetOpen" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonEthernetOpen_Click(object sender, EventArgs e)
		{
			using (OpenEthernetForm openEthernetForm = new OpenEthernetForm())
			{
				if (DialogResult.OK != openEthernetForm.ShowDialog()) return;

				LJX8IF_ETHERNET_CONFIG ethernetConfig = openEthernetForm.EthernetConfig;
				// @Point
				// # Enter the "_currentDeviceId" set here for the communication settings into the arguments of each DLL function.
				// # If you want to get data from multiple controllers, prepare and set multiple "_currentDeviceId" values,
				//   enter these values into the arguments of the DLL functions, and then use the functions.
				
				int rc = NativeMethods.LJX8IF_EthernetOpen(_currentDeviceId, ref ethernetConfig);
				AddLogResult(rc, DemoResource.IDS_ETHERNET_OPEN);

				if (rc == (int)Rc.Ok)
				{
					_deviceData[_currentDeviceId].Status = DeviceStatus.Ethernet;
					_deviceData[_currentDeviceId].EthernetConfig = ethernetConfig;
				}
				else
				{
					_deviceData[_currentDeviceId].Status = DeviceStatus.NoConnection;
				}
				_deviceStatusLabels[_currentDeviceId].Text = _deviceData[_currentDeviceId].GetStatusString();
				_receivedProfileCountLabels[_currentDeviceId].Text = "0";
			}
		}

		/// <summary>
		/// "CommunicationClose" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonCommClose_Click(object sender, EventArgs e)
		{
			int rc = NativeMethods.LJX8IF_CommunicationClose(_currentDeviceId);
			AddLogResult(rc, DemoResource.IDS_COMM_CLOSE);

			_deviceData[_currentDeviceId].Status = DeviceStatus.NoConnection;
			_deviceStatusLabels[_currentDeviceId].Text = _deviceData[_currentDeviceId].GetStatusString();
			_receivedProfileCountLabels[_currentDeviceId].Text = "0";
		}
		#endregion

		#region Buttons for controlling the system
		/// <summary>
		/// "RebootController" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonRebootController_Click(object sender, EventArgs e)
		{
			_sendCommand = SendCommand.RebootController;

			int rc = NativeMethods.LJX8IF_RebootController(_currentDeviceId);
			AddLogResult(rc, DemoResource.IDS_REBOOT_CONTROLLER);
		}

		/// <summary>
		/// "ReturnToFactorySetting" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonReturnToFactorySetting_Click(object sender, EventArgs e)
		{
			int rc = NativeMethods.LJX8IF_ReturnToFactorySetting(_currentDeviceId);
			AddLogResult(rc, DemoResource.IDS_RETURN_TO_FACTORY_SETTING);
		}

		/// <summary>
		/// "ControlLaser" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonControlLaser_Click(object sender, EventArgs e)
		{
			using (ControlLaserForm controlLaserForm = new ControlLaserForm())
			{
				if (DialogResult.OK != controlLaserForm.ShowDialog()) return;

				int rc = NativeMethods.LJX8IF_ControlLaser(_currentDeviceId, controlLaserForm.State);
				AddLogResult(rc, DemoResource.IDS_CONTROL_LASER);
			}

		}

		/// <summary>
		/// "GetError" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonGetError_Click(object sender, EventArgs e)
		{
			using (GetErrorForm getErrorForm = new GetErrorForm())
			{
				if (DialogResult.OK != getErrorForm.ShowDialog()) return;

				ushort[] errCode = new ushort[getErrorForm.ReceivedMax];
				using (PinnedObject pin = new PinnedObject(errCode))
				{
					byte errCount = 0;
					int rc = NativeMethods.LJX8IF_GetError(_currentDeviceId, getErrorForm.ReceivedMax, ref errCount, pin.Pointer);
					AddLogResult(rc, DemoResource.IDS_GET_ERROR);
					if (rc != (int)Rc.Ok) return;

					AddResult(@"ErrCount", errCount.ToString("d"));
					for (int i = 0; i < errCode.Length; i++)
					{
						AddResult(string.Format(@"ErrCode[{0}]",i), string.Format(@"0x{0}", errCode[i].ToString("x4")));
					}
				}
			}
		}

		/// <summary>
		/// "ClearError" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonClearError_Click(object sender, EventArgs e)
		{
			using (ClearErrorForm clearErrorForm = new ClearErrorForm())
			{
				if (DialogResult.OK != clearErrorForm.ShowDialog()) return;

				int rc = NativeMethods.LJX8IF_ClearError(_currentDeviceId, clearErrorForm.ErrCode);
				AddLogResult(rc, DemoResource.IDS_CLEAR_ERROR);
			}
		}

		/// <summary>
		/// "TRG_ERROR_RESET" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonTriggerErrorReset_Click(object sender, EventArgs e)
		{
			int rc = NativeMethods.LJX8IF_TrgErrorReset(_currentDeviceId);
			AddLogResult(rc, DemoResource.IDS_TRG_ERROR_RESET);
		}

		/// <summary>
		/// "GetTriggerAndPulseCount" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonGetTriggerAndPulseCount_Click(object sender, EventArgs e)
		{
			uint triggerCount = 0;
			int encoderCount = 0;
			int rc = NativeMethods.LJX8IF_GetTriggerAndPulseCount(_currentDeviceId, ref triggerCount, ref encoderCount);
			AddLogResult(rc, DemoResource.IDS_GET_TRIGGER_AND_PULSE_COUNT);

			if (rc != (int)Rc.Ok) return;
			AddResult(@"TriggerCount", triggerCount.ToString());
			AddResult(@"EncoderCount", encoderCount.ToString());
		}

		/// <summary>
		/// "GetHeadTemperature" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonGetHeadTemperature_Click(object sender, EventArgs e)
		{
			short sensorTemperature = 0;
			short processorTemperature = 0;
			short caseTemperature = 0;
			int rc = NativeMethods.LJX8IF_GetHeadTemperature(_currentDeviceId, ref sensorTemperature, ref processorTemperature, ref caseTemperature);
			AddLogResult(rc, DemoResource.IDS_GET_HEAD_TEMPERATURE);

			if (rc != (int)Rc.Ok) return;
			AddLog(Utility.ConvertHeadTemperatureLogString(sensorTemperature, processorTemperature, caseTemperature).ToString());

		}

		/// <summary>
		/// "GetSerialNumber" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonGetSerialNumber_Click(object sender, EventArgs e)
		{
			// serial number data length
			const int SerialNumberDataLength = 16;

			byte[] controllerSerialNumber = new byte[SerialNumberDataLength];
			byte[] headSerialNumber = new byte[SerialNumberDataLength];

			using (PinnedObject pinForControllerSerialNumber = new PinnedObject(controllerSerialNumber))
			using (PinnedObject pinForHeadSerialNumber = new PinnedObject(headSerialNumber))
			{
				int rc = NativeMethods.LJX8IF_GetSerialNumber(_currentDeviceId, pinForControllerSerialNumber.Pointer, pinForHeadSerialNumber.Pointer);
				AddLogResult(rc, DemoResource.IDS_GET_SERIAL_NUMBER);

				if (rc != (int)Rc.Ok) return;
				AddResult(@"Controller serial number", Encoding.ASCII.GetString(controllerSerialNumber).TrimEnd(NullChar));
				AddResult(@"Head serial number", Encoding.ASCII.GetString(headSerialNumber).TrimEnd(NullChar));
			}
		}

		/// <summary>
		/// "GetAttentionStatus" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonGetAttentionStatus_Click(object sender, EventArgs e)
		{
			ushort attentionStatusBinary = 0;
			int rc = NativeMethods.LJX8IF_GetAttentionStatus(_currentDeviceId, ref attentionStatusBinary);
			AddLogResult(rc, "GetAttentionStatus");

			if (rc != (int)Rc.Ok) return;
			const int attentionStatusBitLength = 16;
			string attentionStatusStrings = Convert.ToString(attentionStatusBinary, 2).PadLeft(attentionStatusBitLength, '0');
			StringBuilder binaryString = new StringBuilder();
			foreach (Match match in Regex.Matches(attentionStatusStrings, @"(\d{2})"))
			{
				binaryString.Append(" ");
				binaryString.Append(match.Value);
			}
			AddResult(@"AttentionStatus", binaryString.ToString());
		}
		#endregion

		#region Buttons for controlling measurements
		/// <summary>
		/// "Trigger" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonTrigger_Click(object sender, EventArgs e)
		{
			_sendCommand = SendCommand.Trigger;

			int rc = NativeMethods.LJX8IF_Trigger(_currentDeviceId);
			AddLogResult(rc, DemoResource.IDS_TRIGGER);
		}

		/// <summary>
		/// "StartMeasure" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonStartMeasure_Click(object sender, EventArgs e)
		{
			_sendCommand = SendCommand.StartMeasure;

			int rc = NativeMethods.LJX8IF_StartMeasure(_currentDeviceId);
			AddLogResult(rc, DemoResource.IDS_START_MEASURE);
		}

		/// <summary>
		/// "StopMeasure" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonStopMeasure_Click(object sender, EventArgs e)
		{
			_sendCommand = SendCommand.StopMeasure;

			int rc = NativeMethods.LJX8IF_StopMeasure(_currentDeviceId);
			AddLogResult(rc, DemoResource.IDS_STOP_MEASURE);
		}

		/// <summary>
		/// "ClearMemory" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonClearMemory_Click(object sender, EventArgs e)
		{
			int rc = NativeMethods.LJX8IF_ClearMemory(_currentDeviceId);
			AddLogResult(rc, DemoResource.IDS_CLEAR_MEMORY);
		}
		#endregion

		#region Buttons for modifying or reading settings
		/// <summary>
		/// "SetSetting" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonSetSetting_Click(object sender, EventArgs e)
		{
			using (SettingForm settingForm = new SettingForm(true))
			{
				if (DialogResult.OK != settingForm.ShowDialog()) return;
				using (PinnedObject pin = new PinnedObject(settingForm.Data))
				{
					LJX8IF_TARGET_SETTING targetSetting = settingForm.TargetSetting;
					uint error = 0;
					int rc = NativeMethods.LJX8IF_SetSetting(_currentDeviceId, settingForm.Depth, targetSetting,
						pin.Pointer, (uint)settingForm.Data.Length, ref error);
					// @Point
					// # There are three setting areas: a) the write settings area, b) the running area, and c) the save area.
					//   * Specify a) for the setting level when you want to change multiple settings. However, to reflect settings in the LJ-X operations, you have to call LJX8IF_ReflectSetting.
					//	 * Specify b) for the setting level when you want to change one setting but you don't mind if this setting is returned to its value prior to the change when the power is turned off.
					//	 * Specify c) for the setting level when you want to change one setting and you want this new value to be retained even when the power is turned off.

					// @Point
					//  As a usage example, we will show how to use SettingForm to configure settings such that sending a setting, with SettingForm using its initial values,
					//  will change the sampling period in the running area to "100 Hz."
					//  Also see the GetSetting function.

					AddLogResult(rc, DemoResource.IDS_SET_SETTING);
					if ((rc == (int)Rc.Ok) && (error != NoErrorValue)) 
					{
						AddError(error);
					}
				}
			}
		}

		/// <summary>
		/// "GetSetting" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonGetSetting_Click(object sender, EventArgs e)
		{
			using (SettingForm settingForm = new SettingForm(false))
			{
				if (DialogResult.OK != settingForm.ShowDialog()) return;

				byte[] data = new byte[settingForm.DataLength];
				using (PinnedObject pin = new PinnedObject(data))
				{
					LJX8IF_TARGET_SETTING targetSetting = settingForm.TargetSetting;
					int rc = NativeMethods.LJX8IF_GetSetting(_currentDeviceId, settingForm.Depth, targetSetting,
						pin.Pointer, (uint)settingForm.DataLength);
					// @Point
					//  We have prepared an object for reading the sampling period into the setting's initial value.
					//  Also see the SetSetting function.

					AddLogResult(rc, DemoResource.IDS_GET_SETTING);
					if (rc != (int)Rc.Ok) return;

					AddLog("\t    0  1  2  3  4  5  6  7");
					StringBuilder stringBuilder = new StringBuilder();
					// Get data display
					for (int i = 0; i < settingForm.DataLength; i++)
					{
						if ((i % DataCountInOneLine) == 0) stringBuilder.Append(string.Format("  [0x{0:x4}] ", i));

						stringBuilder.Append(string.Format("{0:x2} ", data[i]));
						if (((i % DataCountInOneLine) == DataCountInOneLine - 1) || (i == settingForm.DataLength - 1))
						{
							AddLog(stringBuilder.ToString());
							stringBuilder.Remove(0, stringBuilder.Length);
						}
					}
				}
			}
		}

		/// <summary>
		/// "InitializeSetting" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonInitializeSetting_Click(object sender, EventArgs e)
		{
			using (DepthProgramSelectForm depthProgramSelectForm = new DepthProgramSelectForm(true, true))
			{
				if (DialogResult.OK != depthProgramSelectForm.ShowDialog()) return;

				int rc = NativeMethods.LJX8IF_InitializeSetting(_currentDeviceId, depthProgramSelectForm.Depth, depthProgramSelectForm.Target);
				AddLogResult(rc, DemoResource.IDS_INITIALIZE_SETTING);
			}
		}

		/// <summary>
		/// "ReflectSetting" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonReflectSetting_Click(object sender, EventArgs e)
		{
			using (DepthProgramSelectForm depthProgramSelectForm = new DepthProgramSelectForm(true, false))
			{
				if (DialogResult.OK != depthProgramSelectForm.ShowDialog()) return;

				uint error = 0;
				int rc = NativeMethods.LJX8IF_ReflectSetting(_currentDeviceId, depthProgramSelectForm.Depth, ref error);
				
				AddLogResult(rc, DemoResource.IDS_UPDATE_SETTING);
				if ((rc == (int)Rc.Ok) && (error != NoErrorValue))
				{
					AddError(error);
				}
			}
		}

		/// <summary>
		/// "RewriteTemporarySetting" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonRewriteTemporarySetting_Click(object sender, EventArgs e)
		{
			using (DepthProgramSelectForm depthProgramSelectForm = new DepthProgramSelectForm(true, false))
			{
				if (DialogResult.OK != depthProgramSelectForm.ShowDialog()) return;

				int rc = NativeMethods.LJX8IF_RewriteTemporarySetting(_currentDeviceId, depthProgramSelectForm.Depth);
				AddLogResult(rc, DemoResource.IDS_REWRITE_TEMPORARY_SETTING);
			}
		}

		/// <summary>
		/// "CheckMemoryAccess" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonCheckMemoryAccess_Click(object sender, EventArgs e)
		{
			byte busy = 0;
			int rc = NativeMethods.LJX8IF_CheckMemoryAccess(_currentDeviceId, ref busy);
			AddLogResult(rc, DemoResource.IDS_CHECK_MEMORY_ACCESS);
			if (rc != (int)Rc.Ok) return;

			string displayText = busy != NotAccessValue ? @"  Accessing the save area" : @"  No access";
			AddLog(displayText);
		}

		/// <summary>
		/// "ChangeActiveProgram" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonChangeActiveProgram_Click(object sender, EventArgs e)
		{
			using (DepthProgramSelectForm depthProgramSelectForm = new DepthProgramSelectForm(false, true))
			{
				if (DialogResult.OK != depthProgramSelectForm.ShowDialog()) return;

				int rc = NativeMethods.LJX8IF_ChangeActiveProgram(_currentDeviceId, depthProgramSelectForm.Target);
				AddLogResult(rc, DemoResource.IDS_CHANGE_ACTIVE_PROGRAM);
			}
		}

		/// <summary>
		/// "GetActiveProgram" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonGetActiveProgram_Click(object sender, EventArgs e)
		{
			byte programNo = 0;
			int rc = NativeMethods.LJX8IF_GetActiveProgram(_currentDeviceId, ref programNo);
			AddLogResult(rc, DemoResource.IDS_GET_ACTIVE_PROGRAM);
			if (rc != (int)Rc.Ok) return;

			AddResult(@"ProgramNo", programNo.ToString());
		}
		#endregion

		#region Button for getting the measurement results

		/// <summary>
		/// "GetProfile" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonGetProfile_Click(object sender, EventArgs e)
		{
			_sendCommand = SendCommand.GetProfile;

			using (ProfileForm profileForm = new ProfileForm())
			{
				if (DialogResult.OK != profileForm.ShowDialog()) return;

				_deviceData[_currentDeviceId].ProfileData.Clear();
				
				uint oneProfileDataBufferSize = GetOneProfileDataSize();
				LJX8IF_GET_PROFILE_REQUEST request = profileForm.Request;
				uint dataSize = oneProfileDataBufferSize * request.byGetProfileCount;
				int[] profileData = new int[(int)dataSize / Marshal.SizeOf(typeof(int))];

				using (PinnedObject pin = new PinnedObject(profileData))
				{
					LJX8IF_GET_PROFILE_RESPONSE response = new LJX8IF_GET_PROFILE_RESPONSE();
					LJX8IF_PROFILE_INFO profileInfo = new LJX8IF_PROFILE_INFO();
					int rc = NativeMethods.LJX8IF_GetProfile(_currentDeviceId, ref request, ref response, ref profileInfo, pin.Pointer, dataSize);
					AddLogResult(rc, DemoResource.IDS_GET_PROFILE);
					if (rc != (int)Rc.Ok) return;

					// Response data display
					AddLog(Utility.ConvertProfileResponseToLogString(response).ToString());
					AddLog(Utility.ConvertProfileInfoToLogString(profileInfo).ToString());

					AnalyzeProfileData(response.byGetProfileCount, ref profileInfo, profileData);

					// Profile export
					ExportProfile();
				}
			}
		}

		/// <summary>
		/// "GetBatchProfile" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonGetBatchProfile_Click(object sender, EventArgs e)
		{
			_sendCommand = SendCommand.GetBatchProfile;

			using (GetBatchProfileForm getBatchProfileForm = new GetBatchProfileForm())
			{
				if (DialogResult.OK != getBatchProfileForm.ShowDialog()) return;

				_deviceData[_currentDeviceId].ProfileData.Clear();
				// Set the command function
				uint oneDataSize = GetOneProfileDataSize();
				LJX8IF_GET_BATCH_PROFILE_REQUEST request = getBatchProfileForm.Request;
				uint dataSize = oneDataSize * request.byGetProfileCount;
				int[] batchData = new int[(int)dataSize / Marshal.SizeOf(typeof(int))];

				using (PinnedObject pin = new PinnedObject(batchData))
				{
					LJX8IF_GET_BATCH_PROFILE_RESPONSE response = new LJX8IF_GET_BATCH_PROFILE_RESPONSE();
					LJX8IF_PROFILE_INFO profileInfo = new LJX8IF_PROFILE_INFO();
					// Send the command
					int rc = NativeMethods.LJX8IF_GetBatchProfile(_currentDeviceId, ref request, ref response, ref profileInfo, pin.Pointer, dataSize);
					// @Point
					// # When reading all the profiles from a single batch, the specified number of profiles may not be read.
					// # To read the remaining profiles after the first set of profiles have been read,
					//    set the specification method (byPositionMode)to 0x02, specify the batch number (dwGetBatchNo),
					//    and then set the number to start reading profiles from (dwGetProfNo) and the number of profiles to read (byGetProfileCount) to values 
					//    that specify a range of profiles that have not been read to read the profiles in order.
					// # For the basic code, see "_buttonGetBatchProfileEx_Click."

					// Result output
					AddLogResult(rc, DemoResource.IDS_GET_BATCH_PROFILE);
					if (rc != (int)Rc.Ok) return;

					// Response data display
					AddLog(Utility.ConvertBatchProfileResponseToLogString(response).ToString());
					AddLog(Utility.ConvertProfileInfoToLogString(profileInfo).ToString());

					AnalyzeProfileData(response.byGetProfileCount, ref profileInfo, batchData);

					// Profile export
					ExportProfile();
				}
			}
		}

		#endregion

		#region Button for getting the measurement results (Simple array method)
		/// <summary>
		/// "GetBatchSimpleArray" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonGetBatchSimpleArray_Click(object sender, EventArgs e)
		{
			_sendCommand = SendCommand.GetBatchProfile;

			using (GetBatchProfileForm getBatchProfileForm = new GetBatchProfileForm())
			{
				getBatchProfileForm.Text = DemoResource.IDS_GET_BATCH_SIMPLE_ARRAY;
				if (DialogResult.OK != getBatchProfileForm.ShowDialog()) return;

				_deviceData[_currentDeviceId].SimpleArrayData.Clear();
				// Set the command function
				LJX8IF_GET_BATCH_PROFILE_REQUEST request = getBatchProfileForm.Request;
				LJX8IF_PROFILE_HEADER[] headerData = new LJX8IF_PROFILE_HEADER[request.byGetProfileCount];

				int dataSize = Define.MaxProfileCount * request.byGetProfileCount;
				// @Point
				// # "LJX8IF_GetBatchSimpleArray" API have no "dwDataSize" argument like "LJX8IF_GetBatchProfile".
				//    Memory access violation will occured when buffer size is smaller than received batch data.
				// # This sample allocate maximum profile width every time for simplify code.
				//    To reduce memory usage, remember latest profile information structure and use "nProfileDataCount" property to allocate buffer.

				ushort[] profileData = new ushort[dataSize];
				ushort[] luminanceData = new ushort[dataSize];

				using (PinnedObject profilePin = new PinnedObject(profileData))
				using (PinnedObject luminancePin = new PinnedObject(luminanceData))
				{
					int headerSize = Marshal.SizeOf(typeof(LJX8IF_PROFILE_HEADER));
					IntPtr headPtr = Marshal.AllocHGlobal(headerSize * request.byGetProfileCount);

					LJX8IF_GET_BATCH_PROFILE_RESPONSE response = new LJX8IF_GET_BATCH_PROFILE_RESPONSE();
					LJX8IF_PROFILE_INFO profileInfo = new LJX8IF_PROFILE_INFO();
					// Send the command
					int rc = NativeMethods.LJX8IF_GetBatchSimpleArray(_currentDeviceId, ref request, ref response, ref profileInfo, headPtr, profilePin.Pointer, luminancePin.Pointer);
					// @Point
					// # When reading all the profiles from a single batch, the specified number of profiles may not be read.
					// # To read the remaining profiles after the first set of profiles have been read,
					//    set the specification method (byPositionMode)to 0x02, specify the batch number (dwGetBatchNo),
					//    and then set the number to start reading profiles from (dwGetProfNo) and the number of profiles to read (byGetProfileCount) to values 
					//    that specify a range of profiles that have not been read to read the profiles in order.
					// # For the basic code, see "_buttonGetBatchProfileEx_Click."

					// Result output
					AddLogResult(rc, DemoResource.IDS_GET_BATCH_SIMPLE_ARRAY);
					if (rc != (int)Rc.Ok) return;

					for (int i = 0; i < response.byGetProfileCount; i++)
					{
						headerData[i] = (LJX8IF_PROFILE_HEADER)Marshal.PtrToStructure(headPtr + headerSize * i, typeof(LJX8IF_PROFILE_HEADER));
					}
					Marshal.FreeHGlobal(headPtr);

					// Response data display
					AddLog(Utility.ConvertBatchProfileResponseToLogString(response).ToString());
					AddLog(Utility.ConvertProfileInfoToLogString(profileInfo).ToString());

					_deviceData[_currentDeviceId].SimpleArrayData.DataWidth = profileInfo.nProfileDataCount;
					_deviceData[_currentDeviceId].SimpleArrayData.IsLuminanceEnable = profileInfo.byLuminanceOutput == 1;
					_deviceData[_currentDeviceId].SimpleArrayData.AddReceivedData(profilePin.Pointer, luminancePin.Pointer, response.byGetProfileCount);
				}
			}
		}

		/// <summary>
		/// "ShowBatchProfileImage" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonSaveAsBitmapFile_Click(object sender, EventArgs e)
		{
			int width = _deviceData[_currentDeviceId].SimpleArrayData.DataWidth;
			if (width == 0)
			{
				AddLog("No simple array data.");
				return;
			}

			if (_bitmapFileSave.ShowDialog(this) == DialogResult.Cancel) return;

			int profileHeight = (int)_deviceData[_currentDeviceId].SimpleArrayData.Count;
			bool result = _deviceData[_currentDeviceId].SimpleArrayData.SaveDataAsImages(_bitmapFileSave.FileName, 0, profileHeight);

			AddLog(result ? "Succeed to save image." : "Failed to save image.");
		}
		#endregion

		#region Buttons related to high-speed data communication

		/// <summary>
		/// "InitializeHighSpeedDataCommunication" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonInitializeHighSpeedDataCommunication_Click(object sender, EventArgs e)
		{
			_sendCommand = SendCommand.InitializeHighSpeedDataCommunication;

			using (HighSpeedInitializeForm highSpeedInitializeForm = new HighSpeedInitializeForm())
			{
				highSpeedInitializeForm.EthernetConfig = _deviceData[_currentDeviceId].EthernetConfig;
				
				if (DialogResult.OK != highSpeedInitializeForm.ShowDialog()) return;

				ThreadSafeBuffer.ClearBuffer(_currentDeviceId);  //Clear the retained profile data.
				_deviceData[_currentDeviceId].ProfileDataHighSpeed.Clear();
				_deviceData[_currentDeviceId].SimpleArrayDataHighSpeed.Clear();

				LJX8IF_ETHERNET_CONFIG ethernetConfig = highSpeedInitializeForm.EthernetConfig;
				int rc = NativeMethods.LJX8IF_InitializeHighSpeedDataCommunication(_currentDeviceId, ref ethernetConfig,
					highSpeedInitializeForm.HighSpeedPortNo, (_checkBoxOnlyProfileCount.Checked ? _callbackOnlyCount : _callback), 
					highSpeedInitializeForm.ProfileCount, (uint)_currentDeviceId);
				// @Point
				// # When the frequency of calls is low, the callback function may not be called once per specified number of profiles.
				// # The callback function is called when both of the following conditions are met.
				//   * There is one packet of received data.
				//   * The specified number of profiles have been received by the time the call frequency has been met.

				AddLogResult(rc, DemoResource.IDS_INITIALIZE_HIGH_SPEED_DATA_ETHERNET_COMMUNICATION);

				if (rc == (int)Rc.Ok)
				{
					_deviceData[_currentDeviceId].Status = DeviceStatus.EthernetFast;
					_deviceData[_currentDeviceId].EthernetConfig = ethernetConfig;
				}
				_deviceStatusLabels[_currentDeviceId].Text = _deviceData[_currentDeviceId].GetStatusString();
				_receivedProfileCountLabels[_currentDeviceId].Text = "0";
			}
		}

		/// <summary>
		/// "InitializeHighSpeed (SimpleArray)" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonInitializeHighSpeedDataCommunicationSimpleArray_Click(object sender, EventArgs e)
		{
			_sendCommand = SendCommand.InitializeHighSpeedDataCommunication;

			using (HighSpeedInitializeForm highSpeedInitializeForm = new HighSpeedInitializeForm())
			{
				highSpeedInitializeForm.Text = DemoResource.IDS_INITIALIZE_HIGH_SPEED_DATA_ETHERNET_COMMUNICATION_SIMPLE_ARRAY;
				highSpeedInitializeForm.EthernetConfig = _deviceData[_currentDeviceId].EthernetConfig;

				if (DialogResult.OK != highSpeedInitializeForm.ShowDialog()) return;

				ThreadSafeBuffer.ClearBuffer(_currentDeviceId);  //Clear the retained profile data.
				_deviceData[_currentDeviceId].ProfileDataHighSpeed.Clear();
				_deviceData[_currentDeviceId].SimpleArrayDataHighSpeed.Clear();

				LJX8IF_ETHERNET_CONFIG ethernetConfig = highSpeedInitializeForm.EthernetConfig;
				int rc = NativeMethods.LJX8IF_InitializeHighSpeedDataCommunicationSimpleArray(_currentDeviceId, ref ethernetConfig,
					highSpeedInitializeForm.HighSpeedPortNo, (_checkBoxOnlyProfileCount.Checked ? _callbackSimpleArrayOnlyCount : _callbackSimpleArray),
					highSpeedInitializeForm.ProfileCount, (uint)_currentDeviceId);
				// @Point
				// # When the frequency of calls is low, the callback function may not be called once per specified number of profiles.
				// # The callback function is called when both of the following conditions are met.
				//   * There is one packet of received data.
				//   * The specified number of profiles have been received by the time the call frequency has been met.

				AddLogResult(rc, DemoResource.IDS_INITIALIZE_HIGH_SPEED_DATA_ETHERNET_COMMUNICATION_SIMPLE_ARRAY);

				if (rc == (int)Rc.Ok)
				{
					_deviceData[_currentDeviceId].Status = DeviceStatus.EthernetFast;
					_deviceData[_currentDeviceId].EthernetConfig = ethernetConfig;
				}
				_deviceStatusLabels[_currentDeviceId].Text = _deviceData[_currentDeviceId].GetStatusString();
				_receivedProfileCountLabels[_currentDeviceId].Text = "0";
			}
		}

		/// <summary>
		/// "PreStartHighSpeedDataCommunication" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonPreStartHighSpeedDataCommunication_Click(object sender, EventArgs e)
		{
			_sendCommand = SendCommand.PreStartHighSpeedDataCommunication;

			using (PreStartHighSpeedForm preStartHighSpeedForm = new PreStartHighSpeedForm())
			{
				if (DialogResult.OK != preStartHighSpeedForm.ShowDialog()) return;

				LJX8IF_HIGH_SPEED_PRE_START_REQUEST request = preStartHighSpeedForm.Request;
				// @Point
				// # SendPosition is used to specify which profile to start sending data from during high-speed communication.
				// # When "Overwrite" is specified for the operation when memory full and 
				//   "0: From previous send complete position" is specified for the send start position,
				//    if the LJ-X continues to accumulate profiles, the LJ-X memory will become full,
				//    and the profile at the previous send complete position will be overwritten with a new profile.
				//    In this situation, because the profile at the previous send complete position is not saved, an error will occur.

				LJX8IF_PROFILE_INFO profileInfo = new LJX8IF_PROFILE_INFO();

				int rc = NativeMethods.LJX8IF_PreStartHighSpeedDataCommunication(_currentDeviceId, ref request, ref profileInfo);
				AddLogResult(rc, DemoResource.IDS_PRE_START_HIGH_SPEED_DATA_COMMUNICATION);
				if (rc != (int)Rc.Ok) return;

				// Response data display
				AddLog(Utility.ConvertProfileInfoToLogString(profileInfo).ToString());

				_deviceData[_currentDeviceId].SimpleArrayDataHighSpeed.Clear();
				_deviceData[_currentDeviceId].SimpleArrayDataHighSpeed.DataWidth = profileInfo.nProfileDataCount;
				_deviceData[_currentDeviceId].SimpleArrayDataHighSpeed.IsLuminanceEnable = profileInfo.byLuminanceOutput == 1;

				_profileInfo[_currentDeviceId] = profileInfo;
			}
		}

		/// <summary>
		/// "StartHighSpeedDataCommunication" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonStartHighSpeedDataCommunication_Click(object sender, EventArgs e)
		{
			_sendCommand = SendCommand.StartHighSpeedDataCommunication;

			ThreadSafeBuffer.ClearBuffer(_currentDeviceId);
			_deviceData[_currentDeviceId].ProfileDataHighSpeed.Clear();
			_isBufferFull[_currentDeviceId] = false;
			_isStopCommunicationByError[_currentDeviceId] = false;

			_receivedProfileCountLabels[_currentDeviceId].Text = "0";
			int rc = NativeMethods.LJX8IF_StartHighSpeedDataCommunication(_currentDeviceId);

			AddLogResult(rc, DemoResource.IDS_START_HIGH_SPEED_DATA_COMMUNICATION);
		}

		/// <summary>
		/// "StopHighSpeedDataCommunication" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonStopHighSpeedDataCommunication_Click(object sender, EventArgs e)
		{
			int rc = NativeMethods.LJX8IF_StopHighSpeedDataCommunication(_currentDeviceId);
			AddLogResult(rc, DemoResource.IDS_STOP_HIGH_SPEED_DATA_COMMUNICATION);
		}

		/// <summary>
		/// "FinalizeHighSpeedDataCommunication" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonFinalizeHighSpeedDataCommunication_Click(object sender, EventArgs e)
		{
			int rc = NativeMethods.LJX8IF_FinalizeHighSpeedDataCommunication(_currentDeviceId);
			AddLogResult(rc, DemoResource.IDS_FINALIZE_HIGH_SPEED_DATA_COMMUNICATION);

			switch (_deviceData[_currentDeviceId].Status)
			{
			case DeviceStatus.EthernetFast:
				LJX8IF_ETHERNET_CONFIG config = _deviceData[_currentDeviceId].EthernetConfig;
				_deviceData[_currentDeviceId].Status = DeviceStatus.Ethernet;
				_deviceData[_currentDeviceId].EthernetConfig = config;
				break;
			}
			_deviceStatusLabels[_currentDeviceId].Text = _deviceData[_currentDeviceId].GetStatusString();
			_receivedProfileCountLabels[_currentDeviceId].Text = "0";
		}
		#endregion

		#region Button for settings / results

		/// <summary>
		/// "Clear" button clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonLogClear_Click(object sender, EventArgs e)
		{
			_textBoxLog.Clear();
		}

		/// <summary>
		/// "..." button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonProfileFileSave_Click(object sender, EventArgs e)
		{
			if (_profileFileSave.ShowDialog(this) == DialogResult.Cancel) return;

			_textBoxProfileFilePath.Text = _profileFileSave.FileName;
			_textBoxProfileFilePath.SelectionStart = _textBoxProfileFilePath.Text.Length;
		}

		/// <summary>
		/// "..." button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonHighSpeedProfileFileSave_Click(object sender, EventArgs e)
		{
			if (_profileOrBitmapFileSave.ShowDialog(this) == DialogResult.Cancel) return;

			_textBoxHighSpeedProfileFilePath.Text = _profileOrBitmapFileSave.FileName;
			_textBoxHighSpeedProfileFilePath.SelectionStart = _textBoxHighSpeedProfileFilePath.Text.Length;
		}

		/// <summary>
		/// "Save the profile" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonSave_Click(object sender, EventArgs e)
		{
			int startIndex = (int)_numericUpDownProfileNo.Value;
			int dataCount = (int)_numericUpDownProfileSaveCount.Value;

			if (!(_deviceData[_currentDeviceId].ProfileDataHighSpeed.Count > startIndex && 
				dataCount <= (_deviceData[_currentDeviceId].ProfileDataHighSpeed.Count - startIndex)))
			{
				AddLog("There is no profile specified.");
				return;
			}

			List<ProfileData> result = new List<ProfileData>();
			for (int i = 0; i < dataCount; i++)
			{
				result.Add(_deviceData[_currentDeviceId].ProfileDataHighSpeed[startIndex + i]);
			}

			if (string.IsNullOrEmpty(_textBoxHighSpeedProfileFilePath.Text))
			{
				AddLog("Failed in exporting file. (File path is empty.)");
				return;
			}
			if (!DataExporter.SaveProfile(result, _textBoxHighSpeedProfileFilePath.Text, this))
			{
				AddLog("Failed in exporting file.");
				return;
			}
			AddLog("Saved");
		}

		/// <summary>
		/// "Save As Image File" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonHighSpeedSaveAsBitmapFile_Click(object sender, EventArgs e)
		{
			int width = _deviceData[_currentDeviceId].SimpleArrayDataHighSpeed.DataWidth;
			if (width == 0)
			{
				AddLog("No simple array data.");
				return;
			}

			if (string.IsNullOrEmpty(_textBoxHighSpeedProfileFilePath.Text))
			{
				AddLog("Failed to save image. (File path is empty.)");
				return;
			}
			
			Cursor.Current = Cursors.WaitCursor;

			int startIndex = (int)_numericUpDownProfileNo.Value;
			int dataCount = (int)_numericUpDownProfileSaveCount.Value;
			bool result = _deviceData[_currentDeviceId].SimpleArrayDataHighSpeed.SaveDataAsImages(_textBoxHighSpeedProfileFilePath.Text, startIndex, dataCount);

			AddLog(result ? "Succeed to save image." : "Failed to save image.");
		}

		#endregion

		#region Other event handlers
		protected override void OnShown(EventArgs e)
		{
			_labelBufferSizeValue.Text = GetBufferSizeText();
			base.OnShown(e);
		}

		/// <summary>
		/// "ID" option button (also known as a radio button) event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _rdDevice_CheckedChanged(object sender, EventArgs e)
		{
			_currentDeviceId = GetSelectedDeviceId();
			UpdateBatchSimpleArrayEnable();
		}
		
		/// <summary>
		/// Event handler for the timer used during high-speed communication
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _timerHighSpeedReceive_Tick(object sender, EventArgs e)
		{
			
			for (int i = 0; i < NativeMethods.DeviceCount; i++)
			{
				uint notify;
				int batchNo;
				if (_checkBoxUseSimpleArray.Checked)
				{                   
					// @Point
					// # Simple array data performed to conversion and storing on .
					_receivedProfileCountLabels[i].Text = _deviceData[i].SimpleArrayDataHighSpeed.Count.ToString();
					notify = _deviceData[i].SimpleArrayDataHighSpeed.Notify;
					batchNo = _deviceData[i].SimpleArrayDataHighSpeed.BatchNo;
				}
				else if (_checkBoxOnlyProfileCount.Checked)
				{
					_receivedProfileCountLabels[i].Text = ThreadSafeBuffer.GetCount(i, out notify, out batchNo).ToString();
				}
				else
				{
					List<int[]> data = ThreadSafeBuffer.Get(i, out notify, out batchNo);
					if (data.Count == 0 && notify == 0) continue;

					foreach (int[] profile in data)
					{
						if (_deviceData[i].ProfileDataHighSpeed.Count < Define.BufferFullCount)
						{
							_deviceData[i].ProfileDataHighSpeed.Add(new ProfileData(profile, _profileInfo[i]));
						}
					}
					_receivedProfileCountLabels[i].Text = (Convert.ToInt32(_receivedProfileCountLabels[i].Text) + data.Count).ToString();
				}

				if (notify == 0) continue;

				AddLog(string.Format("  notify[{0}] = {1,0:x8}\tbatch[{0}] = {2}", i, notify, batchNo));
			}

		}

		/// <summary>
		/// Event handler for the timer of buffer error check
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _timerBufferError_Tick(object sender, EventArgs e)
		{
			for (int i = 0; i < NativeMethods.DeviceCount; i++)
			{
				if ((_isBufferFull[i]) && (!_isStopCommunicationByError[i]))
				{
					_isStopCommunicationByError[i] = true;
					NativeMethods.LJX8IF_StopHighSpeedDataCommunication(i);
					NativeMethods.LJX8IF_FinalizeHighSpeedDataCommunication(i);
					Invoke(new InvokeDelagate(ShowBufferFullMessage));
				}
			}
		}

		/// <summary>
		/// "Timer start check box" event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _checkBoxStartTimer_CheckedChanged(object sender, EventArgs e)
		{
			bool isStart = _checkBoxStartTimer.Checked;
			if (isStart)
			{
				_timerHighSpeedReceive.Interval = (int)_numericUpDownInterval.Value;
				_timerHighSpeedReceive.Start();
			}
			else
			{
				_timerHighSpeedReceive.Stop();
			}
			_numericUpDownInterval.Enabled = !isStart;
			_checkBoxOnlyProfileCount.Enabled = !isStart;
		}

		private void _checkBoxOnlyProfileCountCheckedChanged(object sender, EventArgs e)
		{
			UpdateHighSpeedProfileSaveEnable();
		}

		private void _radioButtonLJHead_CheckedChanged(object sender, EventArgs e)
		{
			_labelBufferSizeValue.Text = GetBufferSizeText();

			UpdateBufferSizeSettingEnable();
		}

		private void BufferSizeSetting_SettingChanged(object sender, EventArgs e)
		{
			_labelBufferSizeValue.Text = GetBufferSizeText();
		}

		private string GetBufferSizeText()
		{
			if ((_radioButtonLJX.Checked) &&
				(GetIsLjxLuminanceOutputOn()) &&
				((Define.LjxHeadSamplingPeriod)_comboBoxLjxSamplingPeriod.SelectedValue == Define.LjxHeadSamplingPeriod.LjxHeadSamplingPeriod16KHz))
			{
				return "-----";
			}

			return GetOneProfileDataSize().ToString();
		}

		/// <summary>
		/// "Use Simple Array" event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _checkBoxUseSimpleArray_CheckedChanged(object sender, EventArgs e)
		{
			UpdateBatchSimpleArrayEnable();
		}

		#endregion

		#region Event handler(for combination-function)

		#region Initialization and Exit event handler
		/// <summary>
		/// "Communication establishment" button clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>Initialize the DLL, and then establish a Ethernet communication path.</remarks>
		private void _buttonEstablishCommunicationEx_Click(object sender, EventArgs e)
		{
			// Initialize the DLL
			Rc rc = (Rc)NativeMethods.LJX8IF_Initialize();
			if (!CheckReturnCode(rc)) return;

			// Open the communication path
			// Generate the settings for Ethernet communication.
			try
			{
				_ethernetConfig.abyIpAddress = Utility.GetIpAddressFromTextBox(_textBoxIpFirstSegment, _textBoxIpSecondSegment, _textBoxIpThirdSegment, _textBoxIpFourthSegment);
				_ethernetConfig.wPortNo = Convert.ToUInt16(_textBoxCommandPort.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message);
				return;
			}

			rc = (Rc)NativeMethods.LJX8IF_EthernetOpen(Define.DeviceId, ref _ethernetConfig);
			CheckReturnCode(rc);
		}

		/// <summary>
		/// "Communication finalization" button clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>Processing of the finalization of communication with the controller</remarks>
		private void _buttonTerminateCommunicationEx_Click(object sender, EventArgs e)
		{
			// Close the communication
			Rc rc = (Rc)NativeMethods.LJX8IF_CommunicationClose(Define.DeviceId);
			if (!CheckReturnCode(rc)) return;

			// Finalize the DLL
			rc = (Rc)NativeMethods.LJX8IF_Finalize();
			CheckReturnCode(rc);
		}

		#endregion

		#region Get measurement results event handler

		/// <summary>
		/// Browse ("...") button clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _buttonReferenceSavePathEx_Click(object sender, EventArgs e)
		{
			if (_profileFileSave.ShowDialog() != DialogResult.OK) return;
			_textBoxSavePath.Text = _profileFileSave.FileName;
		}

		/// <summary>
		/// "Get profiles" button clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// Get profiles, and then output profile data to file.
		/// </remarks>
		private void _buttonGetProfileEx_Click(object sender, EventArgs e)
		{
			using (ProgressForm progressForm = new ProgressForm())
			{
				Cursor.Current = Cursors.WaitCursor;

				progressForm.Status = Status.Communicating;
				progressForm.Show(this);
				progressForm.Refresh();

				LJX8IF_PROFILE_INFO profileInfo = new LJX8IF_PROFILE_INFO();
				LJX8IF_GET_PROFILE_RESPONSE response = new LJX8IF_GET_PROFILE_RESPONSE();
				LJX8IF_GET_PROFILE_REQUEST request = new LJX8IF_GET_PROFILE_REQUEST();
				request.byTargetBank = (byte)LJX8IF_PROFILE_BANK.LJX8IF_PROFILE_BANK_ACTIVE;
				request.byPositionMode = (byte)LJX8IF_PROFILE_POSITION.LJX8IF_PROFILE_POSITION_CURRENT;
				request.dwGetProfileNo = 0;
				request.byGetProfileCount = 10;
				request.byErase = 0;
				int profileDataSize = GetMaxProfileDataSize();
				int[] receiveBuffer = new int[GetAllDataSize(profileDataSize, request.byGetProfileCount)];
				// Get profiles.
				using (PinnedObject pin = new PinnedObject(receiveBuffer))
				{
					Rc rc = (Rc)NativeMethods.LJX8IF_GetProfile(Define.DeviceId, ref request, ref response, ref profileInfo, pin.Pointer,
						(uint)(receiveBuffer.Length * Marshal.SizeOf(typeof(int))));
					if (!CheckReturnCode(rc)) return;
				}

				// Output the data of each profile
				List<ProfileData> profileDataList = new List<ProfileData>();
				int unitSize = ProfileData.CalculateDataSize(profileInfo);
				for (int i = 0; i < response.byGetProfileCount; i++)
				{
					profileDataList.Add(new ProfileData(receiveBuffer, unitSize * i, profileInfo));
				}

				progressForm.Status = Status.Saving;
				progressForm.Refresh();

				// Save the file
				DataExporter.SaveProfile(profileDataList, _textBoxSavePath.Text, this);
			}
		}

		/// <summary>
		/// "Get batch profiles" button clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// Read one batch worth of committed profiles that have been acquired with batch measurement.
		/// </remarks>
		private void _buttonGetBatchProfileEx_Click(object sender, EventArgs e)
		{
			using (ProgressForm progressForm = new ProgressForm())
			{
				Cursor.Current = Cursors.WaitCursor;

				progressForm.Status = Status.Communicating;
				progressForm.Show(this);
				progressForm.Refresh();

				List<ProfileData> profileDataList = new List<ProfileData>();

				// Specify the target batch to get.
				LJX8IF_GET_BATCH_PROFILE_REQUEST request = new LJX8IF_GET_BATCH_PROFILE_REQUEST();
				request.byTargetBank = (byte)LJX8IF_PROFILE_BANK.LJX8IF_PROFILE_BANK_ACTIVE;
				request.byPositionMode = (byte)LJX8IF_BATCH_POSITION.LJX8IF_BATCH_POSITION_COMMITED;
				request.dwGetBatchNo = 0;
				request.dwGetProfileNo = 0;
				request.byGetProfileCount = byte.MaxValue;
				request.byErase = 0;

				int profileDataSize = GetMaxProfileDataSize();
				int[] receiveBuffer = new int[GetAllDataSize(profileDataSize, request.byGetProfileCount)];
				// Get profiles
				using (PinnedObject pin = new PinnedObject(receiveBuffer))
				{
					LJX8IF_GET_BATCH_PROFILE_RESPONSE response = new LJX8IF_GET_BATCH_PROFILE_RESPONSE();
					LJX8IF_PROFILE_INFO profileInfo = new LJX8IF_PROFILE_INFO();

					Rc rc = (Rc)NativeMethods.LJX8IF_GetBatchProfile(Define.DeviceId, ref request, ref response, ref profileInfo, pin.Pointer,
						(uint)(receiveBuffer.Length * Marshal.SizeOf(typeof(int))));
					// @Point
					// # When reading all the profiles from a single batch, the specified number of profiles may not be read.
					// # To read the remaining profiles after the first set of profiles have been read, set the specification method (byPositionMode)to 0x02, 
					//   specify the batch number (dwGetBatchNo), and then set the number to start reading profiles from (dwGetProfileNo) and 
					//   the number of profiles to read (byGetProfileCount) to values that specify a range of profiles that have not been read to read the profiles in order.
					// # In more detail, this process entails:
					//   * First configure reuestq as listed below and call this function again.
					//      byPositionMode = LJX8IF_BATCH_POSITION_SPEC
					//      dwGetBatchNo = batch number that was read
					//      byGetProfileCount = Profile number of unread in the batch
					//   * Furthermore, if all profiles in the batch are not read,update the starting position for reading profiles (request.dwGetProfileNo) and
					//     the number of profiles to read (request.byGetProfileCount), and then call LJX8IF_GetBatchProfile again. (Repeat this process until all the profiles have been read.)

					if (!CheckReturnCode(rc)) return;

					// Output the data of each profile
					int unitSize = ProfileData.CalculateDataSize(profileInfo);
					for (int i = 0; i < response.byGetProfileCount; i++)
					{
						profileDataList.Add(new ProfileData(receiveBuffer, unitSize * i, profileInfo));
					}

					// Get all profiles within the batch.
					request.byPositionMode = (byte)LJX8IF_BATCH_POSITION.LJX8IF_BATCH_POSITION_SPEC;
					request.dwGetBatchNo = response.dwGetBatchNo;
					while(response.dwGetBatchProfileCount != (response.dwGetBatchTopProfileNo + response.byGetProfileCount))
					{
						// Update the get profile position
						request.dwGetProfileNo = response.dwGetBatchTopProfileNo + response.byGetProfileCount;
						request.byGetProfileCount = (byte)Math.Min(byte.MaxValue, (response.dwCurrentBatchProfileCount - request.dwGetProfileNo));

						rc = (Rc)NativeMethods.LJX8IF_GetBatchProfile(Define.DeviceId, ref request, ref response, ref profileInfo, pin.Pointer,
							(uint)(receiveBuffer.Length * Marshal.SizeOf(typeof(int))));
						if (!CheckReturnCode(rc)) return;

						for (int i = 0; i < response.byGetProfileCount; i++)
						{
							profileDataList.Add(new ProfileData(receiveBuffer, unitSize * i, profileInfo));
						}
					}
				}

				progressForm.Status = Status.Saving;
				progressForm.Refresh();
				// Save the file
				DataExporter.SaveProfile(profileDataList, _textBoxSavePath.Text, this);
			}
		}

		#endregion

		#region Reading or writing settings for each program number event handler

		/// <summary>
		/// "Sending settings (PC -> LJ)" button clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>Send settings in the file to the controller</remarks>
		private void _buttonSetSettingEx_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog dialog = new OpenFileDialog())
			{
				if (dialog.ShowDialog() != DialogResult.OK) return;

				if (!File.Exists(dialog.FileName))
				{
					ShowNgMessage();
					return;
				}

				UInt32 dataSize = GetSelectedProgramDataSize();

				// Allocate buffer
				byte[] receiveBuffer = new byte[(int)dataSize];
				// Load program data
				using (FileStream fileStream = new FileStream(dialog.FileName, FileMode.Open))
				{
					//Validate file
					if (fileStream.Length != dataSize)
					{
						MessageBox.Show(this, "File size is not match.");
						ShowNgMessage();
						return;
					}
					using (BinaryReader reader = new BinaryReader(fileStream))
					{
						reader.Read(receiveBuffer, 0, (int)dataSize);
					}
				}

				using (PinnedObject pin = new PinnedObject(receiveBuffer))
				{
					// Upload
					uint error = 0;
					// Parameter
					LJX8IF_TARGET_SETTING target = GetSelectedProgramTargetSetting();

					Rc rc = (Rc)NativeMethods.LJX8IF_SetSetting(Define.DeviceId, (byte)LJX8IF_SETTING_DEPTH.LJX8IF_SETTING_DEPTH_RUNNING, target, pin.Pointer, dataSize, ref error);
					ShowProcessingResultMessage(rc);
				}
			}
		}

		/// <summary>
		/// "Receiving settings (LJ -> PC)" button clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>Receive settings from the controller, and then write these settings to the file</remarks>
		private void _buttonGetSettingEx_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog dialog = new SaveFileDialog())
			{
				if (dialog.ShowDialog() != DialogResult.OK) return;

				UInt32 dataSize = GetSelectedProgramDataSize(); // Environment:60, Common:20, Program number:528
																// Allocate buffer
				byte[] receiveBuffer = new byte[(int)dataSize];
				using (PinnedObject pin = new PinnedObject(receiveBuffer))
				{
					//Parameter
					LJX8IF_TARGET_SETTING target = GetSelectedProgramTargetSetting();
					// Download
					Rc rc = (Rc)NativeMethods.LJX8IF_GetSetting(Define.DeviceId, (byte)LJX8IF_SETTING_DEPTH.LJX8IF_SETTING_DEPTH_RUNNING, target, pin.Pointer, dataSize);
					if (rc != (int)Rc.Ok)
					{
						ShowNgMessage();
						return;
					}

				}
				// Save program data
				using (FileStream filestream = new FileStream(dialog.FileName, FileMode.Create))
				using (BinaryWriter writer = new BinaryWriter(filestream))
				{
					writer.Write(receiveBuffer);
				}
				ShowSuccessMessage();
			}
		}
		#endregion

		#region High-speed data communication event handler
		/// <summary>
		/// High-speed data communication "Start" button clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>Perform the preparations for starting high-speed data communication, and then start high-speed data communication.</remarks>
		private void _buttonBeginHighSpeedDataCommunication_Click(object sender, EventArgs e)
		{
			_timerHighSpeed.Stop();

			// Stop and finalize high-speed data communication.
			Rc rc = (Rc)NativeMethods.LJX8IF_StopHighSpeedDataCommunication(Define.DeviceId);
			if (!CheckReturnCode(rc)) return;
			rc = (Rc)NativeMethods.LJX8IF_FinalizeHighSpeedDataCommunication(Define.DeviceId);
			if (!CheckReturnCode(rc)) return;

			// Initialize the data.
			ThreadSafeBuffer.ClearBuffer(Define.DeviceId);

			// Initialize the high-speed communication path
			// High-speed communication start preparations
			LJX8IF_HIGH_SPEED_PRE_START_REQUEST request = new LJX8IF_HIGH_SPEED_PRE_START_REQUEST();
			try
			{
				// Generate the settings for Ethernet communication.
				_ethernetConfig.abyIpAddress = Utility.GetIpAddressFromTextBox(_textBoxIpFirstSegment, _textBoxIpSecondSegment, _textBoxIpThirdSegment, _textBoxIpFourthSegment);
				_ethernetConfig.wPortNo = Convert.ToUInt16(_textBoxCommandPort.Text);

				ushort highSpeedPortNo = Convert.ToUInt16(_textBoxHighSpeedPort.Text);

				uint profileCount = Convert.ToUInt32(_textBoxCallbackFrequency.Text);
				uint threadId = Define.DeviceId;
				// Initialize Ethernet high-speed data communication
				rc = (Rc)NativeMethods.LJX8IF_InitializeHighSpeedDataCommunication(Define.DeviceId, ref _ethernetConfig,
					highSpeedPortNo, _callback, profileCount, threadId);
				
				if (!CheckReturnCode(rc)) return;

				request.bySendPosition = Convert.ToByte(_textBoxStartProfileNo.Text);
			}
			catch (FormatException exception)
			{
				MessageBox.Show(this, exception.Message);
				return;
			}
			catch (OverflowException ex)
			{
				MessageBox.Show(this, ex.Message);
				return;
			}

			// High-speed data communication start preparations
			LJX8IF_PROFILE_INFO profileInfo = new LJX8IF_PROFILE_INFO();
			rc = (Rc)NativeMethods.LJX8IF_PreStartHighSpeedDataCommunication(Define.DeviceId, ref request, ref profileInfo);
			if (!CheckReturnCode(rc)) return;

			// Start high-speed data communication.
			rc = (Rc)NativeMethods.LJX8IF_StartHighSpeedDataCommunication(Define.DeviceId);
			if (!CheckReturnCode(rc)) return;

			_labelReceiveProfileCount.Text = "0";
			_timerHighSpeed.Start();
		}

		/// <summary>
		/// High-speed data communication "Finalize" button clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>Stop high-speed data communication and perform high-speed data communication finalization processing.</remarks>
		private void _buttonTerminateHighSpeedCommunication_Click(object sender, EventArgs e)
		{
			// Stop high-speed data communication.
			Rc rc = (Rc)NativeMethods.LJX8IF_StopHighSpeedDataCommunication(Define.DeviceId);
			if (!CheckReturnCode(rc)) return;

			// Finalize high-speed data communication.
			rc = (Rc)NativeMethods.LJX8IF_FinalizeHighSpeedDataCommunication(Define.DeviceId);
			CheckReturnCode(rc);
		}

		/// <summary>
		/// Timer event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _timerHighSpeed_Tick(object sender, EventArgs e)
		{
			uint notify;
			int batchNo;
			List<int[]> data = ThreadSafeBuffer.Get(Define.DeviceId, out notify, out batchNo);

			int count = data.Count;
			_labelReceiveProfileCount.Text = (Convert.ToUInt32(_labelReceiveProfileCount.Text) + count).ToString();

			if ((uint)(notify & 0xFFFF) != 0)
			{
				// If the lower 16 bits of the notification are not 0, high-speed communication was interrupted, so stop the timer.
				_timerHighSpeed.Stop();
				MessageBox.Show(this, string.Format("Finalize communication :Notify = 0x{0:x8}", notify));
			}

			if ((uint)(notify & 0x10000) != 0)
			{
				// A descriptor is included here if processing when batch measurement is finished is required.
			}
		}
		
		#endregion

		#endregion

		#region Method(for single-function)

		/// <summary>
		/// Constructor
		/// </summary>
		public KeyenceLJ_Demo()
		{
			InitializeComponent();

			// Field initialization
			_sendCommand = SendCommand.None;
			_deviceData = new DeviceData[NativeMethods.DeviceCount];
			_callback = ReceiveHighSpeedData;
			_callbackOnlyCount = CountProfileReceive;
			_callbackSimpleArray = ReceiveHighSpeedSimpleArray;
			_callbackSimpleArrayOnlyCount = CountSimpleArrayReceive;
			_deviceStatusLabels = new Label[] {
				_labelDeviceStatus0, _labelDeviceStatus1, _labelDeviceStatus2,
				_labelDeviceStatus3, _labelDeviceStatus4, _labelDeviceStatus5};

			_receivedProfileCountLabels = new Label[] {
				_labelReceiveProfileCount0, _labelReceiveProfileCount1, _labelReceiveProfileCount2,
				_labelReceiveProfileCount3, _labelReceiveProfileCount4, _labelReceiveProfileCount5};

			for (int i = 0; i < NativeMethods.DeviceCount; i++)
			{
				_deviceData[i] = new DeviceData();
				_deviceStatusLabels[i].Text = _deviceData[i].GetStatusString();
				_receivedProfileCountLabels[i].Text = "0";
			}
			_profileInfo = new LJX8IF_PROFILE_INFO[NativeMethods.DeviceCount];

			// Communication button comment setting
			SetCommandButtonString();

			// Control initialization
			InitializeLjxControlValue();
			InitializeLjvControlValue();

			_comboBoxLjxMeasureX.SelectedIndexChanged += BufferSizeSetting_SettingChanged;
			_comboBoxLjxThinningX.SelectedIndexChanged += BufferSizeSetting_SettingChanged;
			_comboBoxLjxSamplingPeriod.SelectedIndexChanged += BufferSizeSetting_SettingChanged;
			_comboBoxLjxLuminanceOutput.SelectedIndexChanged += BufferSizeSetting_SettingChanged;
			_comboBoxLjvMeasureX.SelectedIndexChanged += BufferSizeSetting_SettingChanged;
			_comboBoxLjvBinning.SelectedIndexChanged += BufferSizeSetting_SettingChanged;
			_comboBoxLjvThinningX.SelectedIndexChanged += BufferSizeSetting_SettingChanged;

			_comboBoxSelectProgram.SelectedIndex = 2;

			UpdateBufferSizeSettingEnable();
			UpdateBatchSimpleArrayEnable();

			UpdateHighSpeedProfileSaveEnable();
		}

		/// <summary>
		/// AnalyzeProfileData
		/// </summary>
		/// <param name="profileCount">Number of profiles that were read</param>
		/// <param name="profileInfo">Profile information structure</param>
		/// <param name="profileData">Acquired profile data</param>
		private void AnalyzeProfileData(int profileCount, ref LJX8IF_PROFILE_INFO profileInfo, int[] profileData)
		{
			int dataUnit = ProfileData.CalculateDataSize(profileInfo);
			AnalyzeProfileData(profileCount, ref profileInfo, profileData, 0, dataUnit);
		}

		/// <summary>
		/// AnalyzeProfileData
		/// </summary>
		/// <param name="profileCount">Number of profiles that were read</param>
		/// <param name="profileInfo">Profile information structure</param>
		/// <param name="profileData">Acquired profile data</param>
		/// <param name="startProfileIndex">Start position of the profiles to copy</param>
		/// <param name="dataUnit">Profile data size</param>
		private void AnalyzeProfileData(int profileCount, ref LJX8IF_PROFILE_INFO profileInfo, int[] profileData, int startProfileIndex, int dataUnit)
		{
			int readProfileDataSize = ProfileData.CalculateDataSize(profileInfo);
			int[] tempReceiveProfileData = new int[readProfileDataSize];

			// Profile data retention
			for (int i = 0; i < profileCount; i++)
			{
				Array.Copy(profileData, (startProfileIndex + i * dataUnit), tempReceiveProfileData, 0, readProfileDataSize);

				_deviceData[_currentDeviceId].ProfileData.Add(new ProfileData(tempReceiveProfileData, profileInfo));
			}
		}

		/// <summary>
		///Save Profile in file.
		/// </summary>
		private void ExportProfile()
		{
			if (string.IsNullOrEmpty(_textBoxProfileFilePath.Text))
			{
				AddLog("Failed in exporting file. (File path is empty.)");
				return;
			}

			bool isSuccess = DataExporter.SaveProfile(_deviceData[_currentDeviceId].ProfileData, _textBoxProfileFilePath.Text, this);
			if (!isSuccess)
			{
				AddLog("Failed in exporting file.");
				return;
			}
			AddLog("Saved");
		}


		/// <summary>
		/// Get whole data size
		/// </summary>
		/// <param name="profileDataSize">profile data size</param>
		/// <param name="dataCount">data count</param>
		/// <returns></returns>
		private static int GetAllDataSize(int profileDataSize, byte dataCount)
		{
			return profileDataSize * dataCount;
		}

		/// <summary>
		/// Get max profile data size
		/// </summary>
		/// <returns>max data size</returns>
		private static int GetMaxProfileDataSize()
		{
			return (Define.MaxProfileCount * ProfileData.MULTIPLE_VALUE_FOR_LUMINANCE_OUTPUT) +
				   (Marshal.SizeOf(typeof(LJX8IF_PROFILE_HEADER)) + Marshal.SizeOf(typeof(LJX8IF_PROFILE_FOOTER))) / Marshal.SizeOf(typeof(int));
		}

		/// <summary>
		/// Get the profile data size
		/// </summary>
		/// <returns>Data size of one profile (in units of bytes)</returns>
		private uint GetOneProfileDataSize()
		{
			// X Direction Data Count
			int xDirectionDataCount = GetXDirectionDataCount();

			// Buffer size (in units of bytes)
			uint oneProfileBufferSize = 0;

			// Number of headers
			oneProfileBufferSize += ((uint)(xDirectionDataCount));

			//in units of bytes
			oneProfileBufferSize *= (uint)Marshal.SizeOf(typeof(uint));

			// Add Sizes of the header and footer structures
			oneProfileBufferSize += (uint)Marshal.SizeOf(typeof(LJX8IF_PROFILE_HEADER));
			oneProfileBufferSize += (uint)Marshal.SizeOf(typeof(LJX8IF_PROFILE_FOOTER));

			return oneProfileBufferSize;
		}

		/// <summary>
		/// Get X Direction Data Count
		/// </summary>
		/// <returns>X Direction Data Count</returns>
		private int GetXDirectionDataCount()
		{
			return _radioButtonLJX.Checked ? GetLjxXDirectionDataCount() : GetLjvXDirectionDataCount();
		}

		/// <summary>
		/// Get X Direction Data Count of LJ-X Head
		/// </summary>
		/// <returns>X Direction Data Count</returns>
		private int GetLjxXDirectionDataCount()
		{
			int multipleValueForLuminanceOutput = GetIsLjxLuminanceOutputOn() ? ProfileData.MULTIPLE_VALUE_FOR_LUMINANCE_OUTPUT : 1;
			return GetLjxProfileCount() * multipleValueForLuminanceOutput;
		}

		/// <summary>
		/// Get Profile Count of LJ-X Head
		/// </summary>
		/// <returns>Profile Count</returns>
		private int GetLjxProfileCount()
		{
			bool isXBinningOn = GetIsLjxXBinningOn();
			int dividedValue = isXBinningOn ? 2 : 1;
			int profileDataCount = (int)_comboBoxLjxMeasureX.SelectedValue / (int)_comboBoxLjxThinningX.SelectedValue / dividedValue;
			return Math.Max(ProfileDataMinCount, profileDataCount);
		}

		/// <summary>
		/// Get Luminance output is On
		/// </summary>
		/// <returns>True: Luminance output is on/ False: Luminance output is off</returns>
		private bool GetIsLjxLuminanceOutputOn()
		{
			return (Define.LuminanceOutput)_comboBoxLjxLuminanceOutput.SelectedValue == Define.LuminanceOutput.LuminanceOutputOn;
		}

		/// <summary>
		/// Get X binning On of LJ-X Head
		/// </summary>
		/// <returns>True:X Binning is on/ False: X binning is off</returns>
		private bool GetIsLjxXBinningOn()
		{
			if ((GetIsLjxLuminanceOutputOn()) &&
				((Define.LjxHeadSamplingPeriod)_comboBoxLjxSamplingPeriod.SelectedValue == Define.LjxHeadSamplingPeriod.LjxHeadSamplingPeriod8KHz))
			{
				return true;
			}
			if (!GetIsLjxLuminanceOutputOn() &&
				((Define.LjxHeadSamplingPeriod)_comboBoxLjxSamplingPeriod.SelectedValue == Define.LjxHeadSamplingPeriod.LjxHeadSamplingPeriod16KHz))
			{
				return true;
			}

			return false;
		}


		/// <summary>
		/// Get X Direction Data Count of LJ-V Head
		/// </summary>
		/// <returns>X Direction Data Count</returns>
		private int GetLjvXDirectionDataCount()
		{
			int multipleValueForLuminanceOutput = GetIsLjvLuminanceOutputOn() ? ProfileData.MULTIPLE_VALUE_FOR_LUMINANCE_OUTPUT : 1;
			return GetLjvProfileCount() * multipleValueForLuminanceOutput;
		}

		/// <summary>
		/// Get Profile Count of LJ-V Head
		/// </summary>
		/// <returns></returns>
		private int GetLjvProfileCount()
		{
			int profileDataCountBeforeThinning = (int) _comboBoxLjvMeasureX.SelectedValue / (int) _comboBoxLjvBinning.SelectedValue;
			if ((int) _comboBoxLjvThinningX.SelectedValue == Define.ThinningXOff)
			{
				return profileDataCountBeforeThinning;
			}
			int halfProfileDataCount = profileDataCountBeforeThinning / 2;
			if ((int) _comboBoxLjvThinningX.SelectedValue == Define.ThinningX2)
			{
				return ProfileDataMinCount <= halfProfileDataCount ? halfProfileDataCount : profileDataCountBeforeThinning;
			}
			//In the thinning 4 case
			if (halfProfileDataCount < ProfileDataMinCount)
			{
				return profileDataCountBeforeThinning;
			}
			int quarterProfileDataCount = profileDataCountBeforeThinning / 4;
			return ProfileDataMinCount <= quarterProfileDataCount ? quarterProfileDataCount : halfProfileDataCount;
		}

		/// <summary>
		/// Get Luminance output is On
		/// </summary>
		/// <returns>True: Luminance output is on/ False: Luminance output is off</returns>
		private bool GetIsLjvLuminanceOutputOn()
		{
			return _radioButtonLJVB.Checked;
		}


		private void UpdateBufferSizeSettingEnable()
		{
			bool isLjxSettingSelected = _radioButtonLJX.Checked;
			_panelLjxSetting.Enabled = isLjxSettingSelected;
			_panelLjvSetting.Enabled = !isLjxSettingSelected;
		}

		private void UpdateHighSpeedProfileSaveEnable()
		{
			bool isOnlyProfileCountChecked = _checkBoxOnlyProfileCount.Checked;
			bool isUseSimpleArray = _checkBoxUseSimpleArray.Checked;

			_textBoxHighSpeedProfileFilePath.Enabled = !isOnlyProfileCountChecked;
			_numericUpDownProfileNo.Enabled = !isOnlyProfileCountChecked;
			_numericUpDownProfileSaveCount.Enabled = !isOnlyProfileCountChecked;
			_buttonHighSpeedSave.Enabled = !isOnlyProfileCountChecked && !isUseSimpleArray;
			_buttonHighSpeedProfileFileSave.Enabled = !isOnlyProfileCountChecked;
			_buttonHighSpeedSaveAsBitmapFile.Enabled = !isOnlyProfileCountChecked && isUseSimpleArray;
		}

		/// <summary>
		/// Method that is called from the DLL as a callback function
		/// </summary>
		/// <param name="buffer">Leading pointer of the received data</param>
		/// <param name="size">Size in units of bytes of one profile</param>
		/// <param name="count">Number of profiles</param>
		/// <param name="notify">Completion flag</param>
		/// <param name="user">Thread ID (value passed during initialization)</param>
		private static void ReceiveHighSpeedData(IntPtr buffer, uint size, uint count, uint notify, uint user)
		{
			// @Point
			// Take care to only implement storing profile data in a thread save buffer in the callback function.
			// As the thread used to call the callback function is the same as the thread used to receive data,
			// the processing time of the callback function affects the speed at which data is received,
			// and may stop communication from being performed properly in some environments.

			uint profileSize = (uint)(size / Marshal.SizeOf(typeof(int)));
			List<int[]> receiveBuffer = new List<int[]>();
			int[] bufferArray = new int[(int)(profileSize * count)];
			Marshal.Copy(buffer, bufferArray, 0, (int)(profileSize * count));

			// Profile data retention
			for (int i = 0; i < (int)count; i++)
			{
				int[] oneProfile = new int[(int)profileSize];
				Array.Copy(bufferArray, i * profileSize, oneProfile, 0, profileSize);
				receiveBuffer.Add(oneProfile);
			}

			if (ThreadSafeBuffer.GetBufferDataCount((int)user) + receiveBuffer.Count < Define.BufferFullCount)
			{
				ThreadSafeBuffer.Add((int)user, receiveBuffer, notify);
			}
			else
			{
				_isBufferFull[(int)user] = true;
			}
		}

		/// <summary>
		/// Method that is called from the DLL as a callback function
		/// </summary>
		/// <param name="buffer">Leading pointer of the received data</param>
		/// <param name="size">Size in units of bytes of one profile</param>
		/// <param name="count">Number of profiles</param>
		/// <param name="notify">Completion flag</param>
		/// <param name="user">Thread ID (value passed during initialization)</param>
		private static void CountProfileReceive(IntPtr buffer, uint size, uint count, uint notify, uint user)
		{
			// @Point
			// Take care to only implement storing profile data in a thread save buffer in the callback function.
			// As the thread used to call the callback function is the same as the thread used to receive data,
			// the processing time of the callback function affects the speed at which data is received,
			// and may stop communication from being performed properly in some environments.

			ThreadSafeBuffer.AddCount((int)user, count, notify);
		}

		/// <summary>
		/// Method that is called from the DLL as a callback function
		/// </summary>
		/// <param name="headBuffer">A pointer to the buffer that stores the header data array</param>
		/// <param name="profileBuffer">A pointer to the buffer that stores the profile data array</param>
		/// <param name="luminanceBuffer">A pointer to the buffer that stores the luminance profile data array</param>
		/// <param name="isLuminanceEnable">The value indicating whether luminance data output is enable or not</param>
		/// <param name="profileSize">The data count of one profile</param>
		/// <param name="count">Number of profiles</param>
		/// <param name="notify">Completion flag</param>
		/// <param name="user">Thread ID (value passed during initialization)</param>
		private void ReceiveHighSpeedSimpleArray(IntPtr headBuffer, IntPtr profileBuffer, IntPtr luminanceBuffer, uint isLuminanceEnable, uint profileSize, uint count, uint notify, uint user)
		{
			// @Point
			// Take care to only implement storing profile data in a thread save buffer in the callback function.
			// As the thread used to call the callback function is the same as the thread used to receive data,
			// the processing time of the callback function affects the speed at which data is received,
			// and may stop communication from being performed properly in some environments.

			_isBufferFull[(int)user] = _deviceData[(int)user].SimpleArrayDataHighSpeed.AddReceivedData(profileBuffer, luminanceBuffer, count);
			_deviceData[(int)user].SimpleArrayDataHighSpeed.Notify = notify;
		}

		/// <summary>
		/// Method that is called from the DLL as a callback function
		/// </summary>
		/// <param name="headBuffer">A pointer to the buffer that stores the header data array</param>
		/// <param name="profileBuffer">A pointer to the buffer that stores the profile data array</param>
		/// <param name="luminanceBuffer">A pointer to the buffer that stores the luminance profile data array</param>
		/// <param name="isLuminanceEnable">The value indicating whether luminance data output is enable or not</param>
		/// <param name="profileSize">The data count of one profile</param>
		/// <param name="count">Number of profiles</param>
		/// <param name="notify">Completion flag</param>
		/// <param name="user">Thread ID (value passed during initialization)</param>
		private void CountSimpleArrayReceive(IntPtr headBuffer, IntPtr profileBuffer, IntPtr luminanceBuffer, uint isLuminanceEnable, uint profileSize, uint count, uint notify, uint user)
		{
			// @Point
			// Take care to only implement storing profile data in a thread save buffer in the callback function.
			// As the thread used to call the callback function is the same as the thread used to receive data,
			// the processing time of the callback function affects the speed at which data is received,
			// and may stop communication from being performed properly in some environments.
			_deviceData[(int)user].SimpleArrayDataHighSpeed.Count += count;
			_deviceData[(int)user].SimpleArrayDataHighSpeed.Notify = notify;
		}
		
		/// <summary>
		/// Get the ID of the selected device.
		/// </summary>
		/// <returns>Device ID</returns>
		private int GetSelectedDeviceId()
		{
			foreach (Control control in _panelDeviceId.Controls)
			{
				RadioButton rd = control as RadioButton;
				if ((rd == null) || (!rd.Checked))continue;

				return Convert.ToInt32(rd.Tag);
			}

			return -1;
		}


		/// <summary>
		/// Communication button string setting
		/// </summary>
		private void SetCommandButtonString()
		{
			// Set the communication button comment here to match it with the log output string.
			_buttonGetVersion.Text = DemoResource.IDS_GET_VERSION;
			_buttonFinalize.Text = DemoResource.IDS_FINALIZE;
			_buttonInitialize.Text = DemoResource.IDS_INITIALIZE;
			_buttonCommClose.Text = DemoResource.IDS_COMM_CLOSE;
			_buttonEthernetOpen.Text = DemoResource.IDS_ETHERNET_OPEN;
			_buttonGetActiveProgram.Text = DemoResource.IDS_GET_ACTIVE_PROGRAM;
			_buttonFinalizeHighSpeedDataCommunication.Text = DemoResource.IDS_FINALIZE_HIGH_SPEED_DATA_COMMUNICATION;
			_buttonStopHighSpeedDataCommunication.Text = DemoResource.IDS_STOP_HIGH_SPEED_DATA_COMMUNICATION;
			_buttonStartHighSpeedDataCommunication.Text = DemoResource.IDS_START_HIGH_SPEED_DATA_COMMUNICATION;
			_buttonPreStartHighSpeedDataCommunication.Text = DemoResource.IDS_PRE_START_HIGH_SPEED_DATA_COMMUNICATION;
			_buttonInitializeHighSpeedDataCommunication.Text = DemoResource.IDS_INITIALIZE_HIGH_SPEED_DATA_ETHERNET_COMMUNICATION;
			_buttonRewriteTemporarySetting.Text = DemoResource.IDS_REWRITE_TEMPORARY_SETTING;
			_buttonGetBatchProfile.Text = DemoResource.IDS_GET_BATCH_PROFILE;
			_buttonGetProfile.Text = DemoResource.IDS_GET_PROFILE;
			_buttonChangeActiveProgram.Text = DemoResource.IDS_CHANGE_ACTIVE_PROGRAM;
			_buttonUpdateSetting.Text = DemoResource.IDS_UPDATE_SETTING;
			_buttonCheckMemoryAccess.Text = DemoResource.IDS_CHECK_MEMORY_ACCESS;
			_buttonSetSetting.Text = DemoResource.IDS_SET_SETTING;
			_buttonGetSetting.Text = DemoResource.IDS_GET_SETTING;
			_buttonClearMemory.Text = DemoResource.IDS_CLEAR_MEMORY;
			_buttonStopMeasure.Text = DemoResource.IDS_STOP_MEASURE;
			_buttonStartMeasure.Text = DemoResource.IDS_START_MEASURE;
			_buttonTrigger.Text = DemoResource.IDS_TRIGGER;
			_buttonClearError.Text = DemoResource.IDS_CLEAR_ERROR;
			_buttonGetError.Text = DemoResource.IDS_GET_ERROR;
			_buttonReturnToFactorySetting.Text = DemoResource.IDS_RETURN_TO_FACTORY_SETTING;
			_buttonRebootController.Text = DemoResource.IDS_REBOOT_CONTROLLER;
		}

		/// <summary>
		/// Set Value of LJ-X setting control 
		/// </summary>
		private void InitializeLjxControlValue()
		{
			_comboBoxLjxMeasureX.DataSource = GetLjxHeadMeasureRangeList();
			_comboBoxLjxMeasureX.DisplayMember = "Key";
			_comboBoxLjxMeasureX.ValueMember = "Value";
			_comboBoxLjxThinningX.DataSource = GetThinningX();
			_comboBoxLjxThinningX.DisplayMember = "Key";
			_comboBoxLjxThinningX.ValueMember = "Value";
			_comboBoxLjxSamplingPeriod.DataSource = GetLjxSamplingPeriodRangeList();
			_comboBoxLjxSamplingPeriod.DisplayMember = "Key";
			_comboBoxLjxSamplingPeriod.ValueMember = "Value";
			_comboBoxLjxLuminanceOutput.DataSource = GetLjxLuminanceOutput();
			_comboBoxLjxLuminanceOutput.DisplayMember = "Key";
			_comboBoxLjxLuminanceOutput.ValueMember = "Value";
			_comboBoxLjxMeasureX.SelectedValue = Define.LjxHeadMeasureRangeFull;
			_comboBoxLjxSamplingPeriod.SelectedValue = Define.LjxHeadSamplingPeriod.LjxHeadSamplingPeriod1KHz;
			_comboBoxLjxThinningX.SelectedValue = Define.ThinningXOff;
			_comboBoxLjxLuminanceOutput.SelectedValue = Define.LuminanceOutput.LuminanceOutputOn;
		}


		/// <summary>
		/// Set Value of LJ-V setting control 
		/// </summary>
		private void InitializeLjvControlValue()
		{
			_comboBoxLjvMeasureX.DataSource = GetLjvMeasureRangeList();
			_comboBoxLjvBinning.DataSource = GetLjvBinning();
			_comboBoxLjvThinningX.DataSource = GetThinningX();

			_comboBoxLjvMeasureX.SelectedValue = Define.MeasureRangeFull;
			_comboBoxLjvBinning.SelectedValue = Define.ReceivedBinningOff;
			_comboBoxLjvThinningX.SelectedValue = Define.ThinningXOff;
		}

		/// <summary>
		/// Get the measurement range of LJ-X Head.
		/// </summary>
		/// <returns>List used as the combo box data source</returns>
		private List<DictionaryEntry> GetLjxHeadMeasureRangeList()
		{
			List<DictionaryEntry> list = new List<DictionaryEntry>()
			{
				(new DictionaryEntry(DemoResource.IDS_MEASURE_RANGE_FULL, Define.LjxHeadMeasureRangeFull)),
				(new DictionaryEntry(DemoResource.IDS_MEASURE_RANGE_THREE_FOURTHS, Define.LjxHeadMeasureRangeThreeFourth)),
				(new DictionaryEntry(DemoResource.IDS_MEASURE_RANGE_HALF, Define.LjxHeadMeasureRangeHalf)),
				(new DictionaryEntry(DemoResource.IDS_MEASURE_RANGE_QUARTER, Define.LjxHeadMeasureRangeQuarter))
			};
			return list;
		}

		/// <summary>
		/// Get the light reception characteristic luminance output list of LJ-X Head.
		/// </summary>
		/// <returns>List used as the combo box data source</returns>
		private List<DictionaryEntry> GetLjxLuminanceOutput()
		{
			List<DictionaryEntry> list = new List<DictionaryEntry>()
			{
				(new DictionaryEntry(DemoResource.IDS_ON, Define.LuminanceOutput.LuminanceOutputOn)),
				(new DictionaryEntry(DemoResource.IDS_OFF, Define.LuminanceOutput.LuminanceOutputOff))

			};
			return list;
		}

		/// <summary>
		/// Get the sampling period of LJ-X Head.
		/// </summary>
		/// <returns>List used as the combo box data source</returns>
		private List<DictionaryEntry> GetLjxSamplingPeriodRangeList()
		{
			List<DictionaryEntry> list = new List<DictionaryEntry>()
			{
				(new DictionaryEntry(DemoResource.IDS_SAMPLING_PERIOD_10Hz, Define.LjxHeadSamplingPeriod.LjxHeadSamplingPeriod10Hz)),
				(new DictionaryEntry(DemoResource.IDS_SAMPLING_PERIOD_20Hz, Define.LjxHeadSamplingPeriod.LjxHeadSamplingPeriod20Hz)),
				(new DictionaryEntry(DemoResource.IDS_SAMPLING_PERIOD_50Hz, Define.LjxHeadSamplingPeriod.LjxHeadSamplingPeriod50Hz)),
				(new DictionaryEntry(DemoResource.IDS_SAMPLING_PERIOD_100Hz, Define.LjxHeadSamplingPeriod.LjxHeadSamplingPeriod100Hz)),
				(new DictionaryEntry(DemoResource.IDS_SAMPLING_PERIOD_200Hz, Define.LjxHeadSamplingPeriod.LjxHeadSamplingPeriod200Hz)),
				(new DictionaryEntry(DemoResource.IDS_SAMPLING_PERIOD_500Hz, Define.LjxHeadSamplingPeriod.LjxHeadSamplingPeriod500Hz)),
				(new DictionaryEntry(DemoResource.IDS_SAMPLING_PERIOD_1kHz, Define.LjxHeadSamplingPeriod.LjxHeadSamplingPeriod1KHz)),
				(new DictionaryEntry(DemoResource.IDS_SAMPLING_PERIOD_2kHz, Define.LjxHeadSamplingPeriod.LjxHeadSamplingPeriod2KHz)),
				(new DictionaryEntry(DemoResource.IDS_SAMPLING_PERIOD_4kHz, Define.LjxHeadSamplingPeriod.LjxHeadSamplingPeriod4KHz)),
				(new DictionaryEntry(DemoResource.IDS_SAMPLING_PERIOD_8kHz, Define.LjxHeadSamplingPeriod.LjxHeadSamplingPeriod8KHz)),
				(new DictionaryEntry(DemoResource.IDS_SAMPLING_PERIOD_16kHz, Define.LjxHeadSamplingPeriod.LjxHeadSamplingPeriod16KHz))
			};
			return list;
		}

		/// <summary>
		/// Get the light reception characteristic Thinning X list.
		/// </summary>
		/// <returns>List used as the combo box data source</returns>
		private List<DictionaryEntry> GetThinningX()
		{
			List<DictionaryEntry> list = new List<DictionaryEntry>()
			{
				(new DictionaryEntry(DemoResource.IDS_THINNING_X_OFF, Define.ThinningXOff)),
				(new DictionaryEntry(DemoResource.IDS_THINNING_X_2, Define.ThinningX2)),
				(new DictionaryEntry(DemoResource.IDS_THINNING_X_4, Define.ThinningX4))
			};
			return list;
		}

		/// <summary>
		/// Get the measurement range of LJ-V Head.
		/// </summary>
		/// <returns>List used as the combo box data source</returns>
		private List<DictionaryEntry> GetLjvMeasureRangeList()
		{
			List<DictionaryEntry> list = new List<DictionaryEntry>();
			list.Add(new DictionaryEntry(DemoResource.IDS_MEASURE_RANGE_FULL, Define.MeasureRangeFull));
			list.Add(new DictionaryEntry(DemoResource.IDS_MEASURE_RANGE_MIDDLE, Define.MeasureRangeMiddle));
			list.Add(new DictionaryEntry(DemoResource.IDS_MEASURE_RANGE_SMALL, Define.MeasureRangeSmall));
			return list;
		}

		/// <summary>
		/// Get the light reception characteristic binning list of LJ-V Head.
		/// </summary>
		/// <returns>List used as the combo box data source</returns>
		private List<DictionaryEntry> GetLjvBinning()
		{
			List<DictionaryEntry> list = new List<DictionaryEntry>();
			list.Add(new DictionaryEntry(DemoResource.IDS_OFF, Define.ReceivedBinningOff));
			list.Add(new DictionaryEntry(DemoResource.IDS_ON, Define.ReceivedBinningOn));
			return list;
		}

		/// <summary>
		/// Show buffer full message
		/// </summary>
		private void ShowBufferFullMessage()
		{
			MessageBox.Show(this, "Receive buffer is full.");
		}

		private void UpdateBatchSimpleArrayEnable()
		{
			Color colorEnabled = Color.FromArgb(255, 192, 218, 255);
			Color colorDisabled = Color.LightGray;


			bool isUseSimpleArray = _checkBoxUseSimpleArray.Checked;
			bool isOnlyProfileCountChecked = _checkBoxOnlyProfileCount.Checked;

			_buttonInitializeHighSpeedDataCommunication.Enabled = !isUseSimpleArray;
			_buttonInitializeHighSpeedDataCommunication.BackColor = !isUseSimpleArray ? colorEnabled : colorDisabled;
			_buttonInitializeHighSpeedDataCommunicationSimpleArray.Enabled = isUseSimpleArray;
			_buttonInitializeHighSpeedDataCommunicationSimpleArray.BackColor = isUseSimpleArray ? colorEnabled : colorDisabled;

			_buttonHighSpeedSave.Enabled = !isUseSimpleArray && !isOnlyProfileCountChecked;
			_buttonHighSpeedSaveAsBitmapFile.Enabled = isUseSimpleArray && !isOnlyProfileCountChecked;
		}
		#endregion

		#region Log output

		/// <summary>
		/// Log output
		/// </summary>
		/// <param name="strLog">Output log</param>
		private void AddLog(string strLog)
		{
			_textBoxLog.AppendText(strLog + Environment.NewLine);
			_textBoxLog.SelectionStart = _textBoxLog.Text.Length;
			_textBoxLog.Focus();
			_textBoxLog.ScrollToCaret();
		}

		/// <summary>
		/// command result output
		/// </summary>
		/// <param name="item">item name</param>
		/// <param name="value">value</param>
		private void AddResult(string item, string value)
		{
			AddLog(string.Format(DemoResource.IDS_COMMAND_RESULT_FORMAT, item, value));
		}


		/// <summary>
		/// Communication command result log output
		/// </summary>
		/// <param name="rc">Return code from the DLL</param>
		/// <param name="commandName">Command name to be output in the log</param>
		private void AddLogResult(int rc, string commandName)
		{
			if (rc == (int)Rc.Ok)
			{
				AddLog(string.Format(DemoResource.IDS_LOG_FORMAT, commandName, DemoResource.IDS_RESULT_OK, rc));
			}
			else
			{
				AddLog(string.Format(DemoResource.IDS_LOG_FORMAT, commandName, DemoResource.IDS_RESULT_NG, rc));
				AddErrorLog(rc);
			}
		}

		/// <summary>
		/// Error log output
		/// </summary>
		/// <param name="rc">Return code</param>
		private void AddErrorLog(int rc)
		{
			if (rc < 0x8000)
			{
				// Common return code
				CommonErrorLog(rc);
			}
			else
			{
				// Controller return code
				if (ControllerErrorLog(rc))
				{
					return;
				}

				// Individual return code
				IndividualErrorLog(rc);
			}
		}

		/// <summary>
		/// Add Error
		/// </summary>
		/// <param name="error"></param>
		private void AddError(uint error)
		{
			_textBoxLog.AppendText("  ErrorCode : 0x" + error.ToString("x8") + Environment.NewLine);
			_textBoxLog.SelectionStart = _textBoxLog.Text.Length;
			_textBoxLog.Focus();
			_textBoxLog.ScrollToCaret();
		}

		/// <summary>
		/// Common return code log output
		/// </summary>
		/// <param name="rc">Return code</param>
		private void CommonErrorLog(int rc)
		{
			switch (rc)
			{
				case (int)Rc.Ok:
					AddLog(string.Format(DemoResource.IDS_RC_FORMAT, DemoResource.IDS_RC_OK));
					break;
				case (int)Rc.ErrOpenDevice:
					AddLog(string.Format(DemoResource.IDS_RC_FORMAT, DemoResource.IDS_RC_ERR_OPEN_DEVICE));
					break;
				case (int)Rc.ErrNoDevice:
					AddLog(string.Format(DemoResource.IDS_RC_FORMAT, DemoResource.IDS_RC_ERR_NO_DEVICE));
					break;
				case (int)Rc.ErrSend:
					AddLog(string.Format(DemoResource.IDS_RC_FORMAT, DemoResource.IDS_RC_ERR_SEND));
					break;
				case (int)Rc.ErrReceive:
					AddLog(string.Format(DemoResource.IDS_RC_FORMAT, DemoResource.IDS_RC_ERR_RECEIVE));
					break;
				case (int)Rc.ErrTimeout:
					AddLog(string.Format(DemoResource.IDS_RC_FORMAT, DemoResource.IDS_RC_ERR_TIMEOUT));
					_deviceData[_currentDeviceId].Status = DeviceStatus.NoConnection;
					_deviceStatusLabels[_currentDeviceId].Text = _deviceData[_currentDeviceId].GetStatusString();
					_receivedProfileCountLabels[_currentDeviceId].Text = "0";
					break;
				case (int)Rc.ErrParameter:
					AddLog(string.Format(DemoResource.IDS_RC_FORMAT, DemoResource.IDS_RC_ERR_PARAMETER));
					break;
				case (int)Rc.ErrNomemory:
					AddLog(string.Format(DemoResource.IDS_RC_FORMAT, DemoResource.IDS_RC_ERR_NOMEMORY));
					break;
				case (int)Rc.ErrHispeedNoDevice:
					AddLog(string.Format(DemoResource.IDS_RC_FORMAT, DemoResource.IDS_RC_ERR_HISPEED_NO_DEVICE));
					break;
				case (int)Rc.ErrHispeedOpenYet:
					AddLog(string.Format(DemoResource.IDS_RC_FORMAT, DemoResource.IDS_RC_ERR_HISPEED_OPEN_YET));
					break;
				case (int)Rc.ErrBufferShort:
					AddLog(string.Format(DemoResource.IDS_RC_FORMAT, DemoResource.IDS_RC_ERR_BUFFER_SHORT));
					break;
				default:
					AddLog(string.Format(DemoResource.IDS_NOT_DEFINE_FROMAT, rc));
					break;
			}
		}

		/// <summary>
		/// Individual return code log output
		/// </summary>
		/// <param name="rc">Return code</param>
		private void IndividualErrorLog(int rc)
		{
			switch (_sendCommand)
			{
				case SendCommand.RebootController:
					{
						switch (rc)
						{
							case 0x80A0:
								AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"Accessing the save area"));
								break;
							default:
								AddLog(string.Format(DemoResource.IDS_NOT_DEFINE_FROMAT, rc));
								break;
						}
					}
					break;
				case SendCommand.Trigger:
					{
						switch (rc)
						{
							case 0x8080:
								AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"The trigger mode is not [external trigger]"));
								break;
							default:
								AddLog(string.Format(DemoResource.IDS_NOT_DEFINE_FROMAT, rc));
								break;
						}
					}
					break;
				case SendCommand.StartMeasure:
				case SendCommand.StopMeasure:
					{
						switch (rc)
						{
							case 0x8080:
								AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"Batch measurements are off or several controller Sync function is Sync Slave"));
								break;
							case 0x80A0:
								AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"Batch measurement start or stop processing could not be performed because laser off by command or the LASER_ON terminal is off"));
								break;
							default:
								AddLog(string.Format(DemoResource.IDS_NOT_DEFINE_FROMAT, rc));
								break;
						}
					}
					break;
				case SendCommand.GetProfile:
					{
						switch (rc)
						{
							case 0x8081:
								AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"Batch measurements on"));
								break;
							case 0x80A0:
								AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"No profile data"));
								break;
							default:
								AddLog(string.Format(DemoResource.IDS_NOT_DEFINE_FROMAT, rc));
								break;
						}
					}
					break;
				case SendCommand.GetBatchProfile:
					{
						switch (rc)
						{
							case 0x8081:
								AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"Batch measurements off"));
								break;
							case 0x80A0:
								AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"No batch data (batch measurements not run even once)"));
								break;
							default:
								AddLog(string.Format(DemoResource.IDS_NOT_DEFINE_FROMAT, rc));
								break;
						}
					}
					break;
				case SendCommand.InitializeHighSpeedDataCommunication:
					{
						switch (rc)
						{
							case 0x80A1:
								AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"Already performing high-speed communication error (for high-speed communication)"));
								break;
							default:
								AddLog(string.Format(DemoResource.IDS_NOT_DEFINE_FROMAT, rc));
								break;
						}
					}
					break;
				case SendCommand.PreStartHighSpeedDataCommunication:
				case SendCommand.StartHighSpeedDataCommunication:
					{
						switch (rc)
						{
							case 0x8081:
								AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"The data specified as the send start position does not exist"));
								break;
							case 0x80A0:
								AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"A high-speed data communication connection was not established"));
								break;
							case 0x80A1:
								AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"Already performing high-speed communication error (for high-speed communication)"));
								break;
							case 0x80A2:
								AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"Command code does not match (for high-speed communication)"));
								break;
							case 0x80A3:
								AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"Start code does not match (for high-speed communication)"));
								break;
							case 0x80A4:
								AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"The send target data was cleared"));
								break;
							default:
								AddLog(string.Format(DemoResource.IDS_NOT_DEFINE_FROMAT, rc));
								break;
						}
					}
					break;
				default:
					AddLog(string.Format(DemoResource.IDS_NOT_DEFINE_FROMAT, rc));
					break;
			}
		}

		/// <summary>
		/// Controller return code log output
		/// </summary>
		/// <param name="rc">ReturnCode</param>
		/// <returns>Processing continuation condition(True:stop)</returns>
		private bool ControllerErrorLog(int rc)
		{
			switch (rc)
			{
				case 0x8011:
					return true;
				case 0x8021:
					AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"Controller model difference"));
					return true;
				case 0x8031:
					AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"Undefined command"));
					return true;
				case 0x8032:
					AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"Command length error"));
					return true;
				case 0x8041:
					AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"Controller status error"));
					return true;
				case 0x8042:
					AddLog(string.Format(DemoResource.IDS_RC_FORMAT, @"Controller parameter error"));
					return true;
			}
			return false;
		}

		#endregion

		#region Method(for combination-function)
		/// <summary>
		/// Create program download/upload parameters depends on combobox selection.
		/// </summary>
		/// <returns>Setting item structure</returns>
		private LJX8IF_TARGET_SETTING GetSelectedProgramTargetSetting()
		{
			LJX8IF_TARGET_SETTING setting;
			setting.byCategory = 0xFF;	  // means all parameter
			setting.byItem = 0x00;
			setting.reserve = 0;
			setting.byTarget1 = 0;		  // This is used when you want to set a setting item in greater detail
			setting.byTarget2 = 0;
			setting.byTarget3 = 0;
			setting.byTarget4 = 0;

			if (_comboBoxSelectProgram.SelectedIndex == 0)
			{
				setting.byType = (byte)SettingType.Environment;
			}
			else if (_comboBoxSelectProgram.SelectedIndex == 1)
			{
				setting.byType = (byte)SettingType.Common;
			}
			else
			{
				setting.byType = (byte)(SettingType)((int)SettingType.Program00 + (_comboBoxSelectProgram.SelectedIndex - 2));
			}

			return setting;
		}


		/// <summary>
		/// GetSelectedProgramDataSize
		/// </summary>
		/// <returns>Program settings size</returns>
		private UInt32 GetSelectedProgramDataSize()
		{
			if (_comboBoxSelectProgram.SelectedIndex == 0) return NativeMethods.EnvironmentSettingSize;
			if (_comboBoxSelectProgram.SelectedIndex == 1) return NativeMethods.CommonSettingSize;
			return NativeMethods.ProgramSettingSize;
		}

		/// <summary>
		/// Return code check
		/// </summary>
		/// <param name="rc">Return code</param>
		/// <returns>Is the return code OK?</returns>
		/// <remarks>If the return code is not OK, display a message and return false.</remarks>
		private bool CheckReturnCode(Rc rc)
		{
			if (rc == Rc.Ok) return true;
			MessageBox.Show(this, string.Format("Error: 0x{0,8:x}", rc));
			return false;
		}

		/// <summary>
		/// Show processing result message
		/// </summary>
		/// <param name="rc">return code</param>
		private void ShowProcessingResultMessage(Rc rc)
		{
			if (rc == (int)Rc.Ok)
			{
				ShowSuccessMessage();
			}
			else
			{
				ShowNgMessage();
			}
		}


		/// <summary>
		/// Show success message
		/// </summary>
		private void ShowSuccessMessage()
		{
			MessageBox.Show(this, "Success!");
		}

		/// <summary>
		/// Show NG message
		/// </summary>
		private void ShowNgMessage()
		{
			MessageBox.Show(this, "NG!!");
		}




		#endregion
	}
}
