namespace Lead.CPrim.PrimKeyenceLJ.Demo
{
	partial class KeyenceLJ_Demo
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}


		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this._buttonGetVersion = new System.Windows.Forms.Button();
            this._buttonFinalize = new System.Windows.Forms.Button();
            this._buttonInitialize = new System.Windows.Forms.Button();
            this._buttonCommClose = new System.Windows.Forms.Button();
            this._buttonEthernetOpen = new System.Windows.Forms.Button();
            this._groupBoxCommand = new System.Windows.Forms.GroupBox();
            this._groupBoxSetting = new System.Windows.Forms.GroupBox();
            this._buttonSetSetting = new System.Windows.Forms.Button();
            this._buttonGetSetting = new System.Windows.Forms.Button();
            this._buttonInitializeSetting = new System.Windows.Forms.Button();
            this._buttonUpdateSetting = new System.Windows.Forms.Button();
            this._buttonRewriteTemporarySetting = new System.Windows.Forms.Button();
            this._buttonCheckMemoryAccess = new System.Windows.Forms.Button();
            this._buttonGetActiveProgram = new System.Windows.Forms.Button();
            this._buttonChangeActiveProgram = new System.Windows.Forms.Button();
            this._groupBoxMeasurementControl = new System.Windows.Forms.GroupBox();
            this._buttonTrigger = new System.Windows.Forms.Button();
            this._buttonStartMeasure = new System.Windows.Forms.Button();
            this._buttonStopMeasure = new System.Windows.Forms.Button();
            this._buttonClearMemory = new System.Windows.Forms.Button();
            this._groupBoxSystemControl = new System.Windows.Forms.GroupBox();
            this._buttonGetAttentionStatus = new System.Windows.Forms.Button();
            this._buttonGetSerialNumber = new System.Windows.Forms.Button();
            this._buttonGetTriggerCount = new System.Windows.Forms.Button();
            this._buttonControlLaser = new System.Windows.Forms.Button();
            this._buttonGetHeadTemperature = new System.Windows.Forms.Button();
            this._buttonTriggerErrorReset = new System.Windows.Forms.Button();
            this._buttonRebootController = new System.Windows.Forms.Button();
            this._buttonReturnToFactorySetting = new System.Windows.Forms.Button();
            this._buttonGetError = new System.Windows.Forms.Button();
            this._buttonClearError = new System.Windows.Forms.Button();
            this._groupBoxHighSpeedData = new System.Windows.Forms.GroupBox();
            this._checkBoxUseSimpleArray = new System.Windows.Forms.CheckBox();
            this._numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this._checkBoxStartTimer = new System.Windows.Forms.CheckBox();
            this._buttonInitializeHighSpeedDataCommunicationSimpleArray = new System.Windows.Forms.Button();
            this._checkBoxOnlyProfileCount = new System.Windows.Forms.CheckBox();
            this._buttonInitializeHighSpeedDataCommunication = new System.Windows.Forms.Button();
            this._groupBoxHighSpeedExport = new System.Windows.Forms.GroupBox();
            this._buttonHighSpeedSaveAsBitmapFile = new System.Windows.Forms.Button();
            this._numericUpDownProfileSaveCount = new System.Windows.Forms.NumericUpDown();
            this._labelProfileSaveCount = new System.Windows.Forms.Label();
            this._numericUpDownProfileNo = new System.Windows.Forms.NumericUpDown();
            this._textBoxHighSpeedProfileFilePath = new System.Windows.Forms.TextBox();
            this._buttonHighSpeedSave = new System.Windows.Forms.Button();
            this._buttonHighSpeedProfileFileSave = new System.Windows.Forms.Button();
            this._labelIndexOfTheProfileToSave = new System.Windows.Forms.Label();
            this._labelHighSpeedSavePath = new System.Windows.Forms.Label();
            this._buttonPreStartHighSpeedDataCommunication = new System.Windows.Forms.Button();
            this._buttonFinalizeHighSpeedDataCommunication = new System.Windows.Forms.Button();
            this._buttonStartHighSpeedDataCommunication = new System.Windows.Forms.Button();
            this._buttonStopHighSpeedDataCommunication = new System.Windows.Forms.Button();
            this._groupBoxGetMeasurementResult = new System.Windows.Forms.GroupBox();
            this._textBoxProfileFilePath = new System.Windows.Forms.TextBox();
            this._buttonGetProfile = new System.Windows.Forms.Button();
            this._buttonProfileFileSave = new System.Windows.Forms.Button();
            this._buttonGetBatchProfile = new System.Windows.Forms.Button();
            this._groupBoxOperations = new System.Windows.Forms.GroupBox();
            this._groupBoxLog = new System.Windows.Forms.GroupBox();
            this._textBoxLog = new System.Windows.Forms.TextBox();
            this._buttonLogClear = new System.Windows.Forms.Button();
            this._groupBoxBufferSize = new System.Windows.Forms.GroupBox();
            this._panelHeadType = new System.Windows.Forms.Panel();
            this._radioButtonLJVB = new System.Windows.Forms.RadioButton();
            this._radioButtonLJX = new System.Windows.Forms.RadioButton();
            this._radioButtonLJV = new System.Windows.Forms.RadioButton();
            this._groupBoxBufferSizeResult = new System.Windows.Forms.GroupBox();
            this._labelBufferSizeValue = new System.Windows.Forms.Label();
            this._labelOneProfileByteSize = new System.Windows.Forms.Label();
            this._panelLjxSetting = new System.Windows.Forms.Panel();
            this._comboBoxLjxMeasureX = new System.Windows.Forms.ComboBox();
            this._labelLjxMeasureX = new System.Windows.Forms.Label();
            this._comboBoxLjxThinningX = new System.Windows.Forms.ComboBox();
            this._labelLjxThinningX = new System.Windows.Forms.Label();
            this._comboBoxLjxLuminanceOutput = new System.Windows.Forms.ComboBox();
            this._labelLjxLuminanceOutput = new System.Windows.Forms.Label();
            this._comboBoxLjxSamplingPeriod = new System.Windows.Forms.ComboBox();
            this._labelLjxSamplingPeriodNote = new System.Windows.Forms.Label();
            this._labelLjxSampling = new System.Windows.Forms.Label();
            this._panelLjvSetting = new System.Windows.Forms.Panel();
            this._comboBoxLjvMeasureX = new System.Windows.Forms.ComboBox();
            this._comboBoxLjvThinningX = new System.Windows.Forms.ComboBox();
            this._comboBoxLjvBinning = new System.Windows.Forms.ComboBox();
            this._labelLjvMeasureX = new System.Windows.Forms.Label();
            this._labelLjvThinningX = new System.Windows.Forms.Label();
            this._labelLjvBinning = new System.Windows.Forms.Label();
            this._profileFileSave = new System.Windows.Forms.SaveFileDialog();
            this._timerHighSpeedReceive = new System.Windows.Forms.Timer(this.components);
            this._labelReceiveProfileCount0 = new System.Windows.Forms.Label();
            this._radioButtonDevice0 = new System.Windows.Forms.RadioButton();
            this._radioButtonDevice2 = new System.Windows.Forms.RadioButton();
            this._radioButtonDevice1 = new System.Windows.Forms.RadioButton();
            this._panelDeviceId = new System.Windows.Forms.Panel();
            this._labelDeviceStatus5 = new System.Windows.Forms.Label();
            this._labelDeviceStatus4 = new System.Windows.Forms.Label();
            this._radioButtonDevice5 = new System.Windows.Forms.RadioButton();
            this._radioButtonDevice4 = new System.Windows.Forms.RadioButton();
            this._panelNumberOfReceivedProfiles = new System.Windows.Forms.Panel();
            this._labelReceiveProfileCount5 = new System.Windows.Forms.Label();
            this._labelReceiveProfileCount4 = new System.Windows.Forms.Label();
            this._labelReceiveProfileCount3 = new System.Windows.Forms.Label();
            this._labelNumberOfReceivedProfiles = new System.Windows.Forms.Label();
            this._labelReceiveProfileCount1 = new System.Windows.Forms.Label();
            this._labelReceiveProfileCount2 = new System.Windows.Forms.Label();
            this._labelState = new System.Windows.Forms.Label();
            this._labelId = new System.Windows.Forms.Label();
            this._labelDeviceStatus3 = new System.Windows.Forms.Label();
            this._labelDeviceStatus2 = new System.Windows.Forms.Label();
            this._labelDeviceStatus1 = new System.Windows.Forms.Label();
            this._labelDeviceStatus0 = new System.Windows.Forms.Label();
            this._radioButtonDevice3 = new System.Windows.Forms.RadioButton();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._tabSimpleFunctionSample = new System.Windows.Forms.TabPage();
            this._groupBoxReadingProfiles = new System.Windows.Forms.GroupBox();
            this._groupBoxGetDataSimpleArray = new System.Windows.Forms.GroupBox();
            this._buttonSaveAsBitmapFile = new System.Windows.Forms.Button();
            this._buttonGetBatchSimpleArray = new System.Windows.Forms.Button();
            this._groupBoxSettingResult = new System.Windows.Forms.GroupBox();
            this._labelConectedDevice = new System.Windows.Forms.Label();
            this._tabCombinationSample = new System.Windows.Forms.TabPage();
            this._groupBoxProgram = new System.Windows.Forms.GroupBox();
            this._buttonUploadProgram = new System.Windows.Forms.Button();
            this._buttonDownloadProgram = new System.Windows.Forms.Button();
            this._labelSelectProgram = new System.Windows.Forms.Label();
            this._comboBoxSelectProgram = new System.Windows.Forms.ComboBox();
            this._groupBoxHighSpeed = new System.Windows.Forms.GroupBox();
            this._textBoxCallbackFrequency = new System.Windows.Forms.TextBox();
            this._textBoxStartProfileNo = new System.Windows.Forms.TextBox();
            this._labelReceiveProfileCount = new System.Windows.Forms.Label();
            this._labelCallbackFrequency = new System.Windows.Forms.Label();
            this._buttonTerminateHighSpeedCommunication = new System.Windows.Forms.Button();
            this._labelHighSpeedStartNo = new System.Windows.Forms.Label();
            this._labelReceiveCount = new System.Windows.Forms.Label();
            this._buttonBeginHighSpeedDataCommunication = new System.Windows.Forms.Button();
            this._groupBoxGetData = new System.Windows.Forms.GroupBox();
            this._groupBoxGetProfile = new System.Windows.Forms.GroupBox();
            this._buttonReferenceSavePath = new System.Windows.Forms.Button();
            this._buttonGetBatchProfileData = new System.Windows.Forms.Button();
            this._buttonGetProfileData = new System.Windows.Forms.Button();
            this._textBoxSavePath = new System.Windows.Forms.TextBox();
            this._labelProfilesSavePath = new System.Windows.Forms.Label();
            this._groupBoxBaseOperation = new System.Windows.Forms.GroupBox();
            this._panelCommunicationDevice = new System.Windows.Forms.Panel();
            this._groupBoxEthernetSetting = new System.Windows.Forms.GroupBox();
            this._textBoxIpFirstSegment = new System.Windows.Forms.TextBox();
            this._textBoxIpFourthSegment = new System.Windows.Forms.TextBox();
            this._textBoxIpSecondSegment = new System.Windows.Forms.TextBox();
            this._labelHighSpeedPort = new System.Windows.Forms.Label();
            this._textBoxIpThirdSegment = new System.Windows.Forms.TextBox();
            this._labelIpSeparator3 = new System.Windows.Forms.Label();
            this._labelIpSeparator2 = new System.Windows.Forms.Label();
            this._textBoxHighSpeedPort = new System.Windows.Forms.TextBox();
            this._labelIpSeparator1 = new System.Windows.Forms.Label();
            this._textBoxCommandPort = new System.Windows.Forms.TextBox();
            this._labelIpAddress = new System.Windows.Forms.Label();
            this._labelCommandPort = new System.Windows.Forms.Label();
            this._buttonTerminateCommunication = new System.Windows.Forms.Button();
            this._buttonEstablishCommunication = new System.Windows.Forms.Button();
            this._timerHighSpeed = new System.Windows.Forms.Timer(this.components);
            this._timerBufferError = new System.Windows.Forms.Timer(this.components);
            this._bitmapFileSave = new System.Windows.Forms.SaveFileDialog();
            this._profileOrBitmapFileSave = new System.Windows.Forms.SaveFileDialog();
            this._groupBoxCommand.SuspendLayout();
            this._groupBoxSetting.SuspendLayout();
            this._groupBoxMeasurementControl.SuspendLayout();
            this._groupBoxSystemControl.SuspendLayout();
            this._groupBoxHighSpeedData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownInterval)).BeginInit();
            this._groupBoxHighSpeedExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownProfileSaveCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownProfileNo)).BeginInit();
            this._groupBoxGetMeasurementResult.SuspendLayout();
            this._groupBoxOperations.SuspendLayout();
            this._groupBoxLog.SuspendLayout();
            this._groupBoxBufferSize.SuspendLayout();
            this._panelHeadType.SuspendLayout();
            this._groupBoxBufferSizeResult.SuspendLayout();
            this._panelLjxSetting.SuspendLayout();
            this._panelLjvSetting.SuspendLayout();
            this._panelDeviceId.SuspendLayout();
            this._panelNumberOfReceivedProfiles.SuspendLayout();
            this._tabControl.SuspendLayout();
            this._tabSimpleFunctionSample.SuspendLayout();
            this._groupBoxReadingProfiles.SuspendLayout();
            this._groupBoxGetDataSimpleArray.SuspendLayout();
            this._groupBoxSettingResult.SuspendLayout();
            this._tabCombinationSample.SuspendLayout();
            this._groupBoxProgram.SuspendLayout();
            this._groupBoxHighSpeed.SuspendLayout();
            this._groupBoxGetData.SuspendLayout();
            this._groupBoxGetProfile.SuspendLayout();
            this._groupBoxBaseOperation.SuspendLayout();
            this._panelCommunicationDevice.SuspendLayout();
            this._groupBoxEthernetSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonGetVersion
            // 
            this._buttonGetVersion.Location = new System.Drawing.Point(151, 14);
            this._buttonGetVersion.Name = "_buttonGetVersion";
            this._buttonGetVersion.Size = new System.Drawing.Size(70, 23);
            this._buttonGetVersion.TabIndex = 2;
            this._buttonGetVersion.Text = "GetVersion";
            this._buttonGetVersion.UseVisualStyleBackColor = true;
            this._buttonGetVersion.Click += new System.EventHandler(this._buttonGetVersion_Click);
            // 
            // _buttonFinalize
            // 
            this._buttonFinalize.Location = new System.Drawing.Point(79, 14);
            this._buttonFinalize.Name = "_buttonFinalize";
            this._buttonFinalize.Size = new System.Drawing.Size(70, 23);
            this._buttonFinalize.TabIndex = 1;
            this._buttonFinalize.Text = "Finalize";
            this._buttonFinalize.UseVisualStyleBackColor = true;
            this._buttonFinalize.Click += new System.EventHandler(this._buttonFinalize_Click);
            // 
            // _buttonInitialize
            // 
            this._buttonInitialize.Location = new System.Drawing.Point(8, 14);
            this._buttonInitialize.Name = "_buttonInitialize";
            this._buttonInitialize.Size = new System.Drawing.Size(70, 23);
            this._buttonInitialize.TabIndex = 0;
            this._buttonInitialize.Text = "Initialize";
            this._buttonInitialize.UseVisualStyleBackColor = true;
            this._buttonInitialize.Click += new System.EventHandler(this._buttonInitialize_Click);
            // 
            // _buttonCommClose
            // 
            this._buttonCommClose.BackColor = System.Drawing.Color.LightGray;
            this._buttonCommClose.Location = new System.Drawing.Point(17, 107);
            this._buttonCommClose.Name = "_buttonCommClose";
            this._buttonCommClose.Size = new System.Drawing.Size(90, 40);
            this._buttonCommClose.TabIndex = 2;
            this._buttonCommClose.Text = "Communication\r\nClose";
            this._buttonCommClose.UseVisualStyleBackColor = false;
            this._buttonCommClose.Click += new System.EventHandler(this._buttonCommClose_Click);
            // 
            // _buttonEthernetOpen
            // 
            this._buttonEthernetOpen.BackColor = System.Drawing.Color.LightGray;
            this._buttonEthernetOpen.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonEthernetOpen.Location = new System.Drawing.Point(17, 65);
            this._buttonEthernetOpen.Name = "_buttonEthernetOpen";
            this._buttonEthernetOpen.Size = new System.Drawing.Size(90, 40);
            this._buttonEthernetOpen.TabIndex = 1;
            this._buttonEthernetOpen.Text = "EthernetOpen";
            this._buttonEthernetOpen.UseVisualStyleBackColor = false;
            this._buttonEthernetOpen.Click += new System.EventHandler(this._buttonEthernetOpen_Click);
            // 
            // _groupBoxCommand
            // 
            this._groupBoxCommand.Controls.Add(this._groupBoxSetting);
            this._groupBoxCommand.Controls.Add(this._groupBoxMeasurementControl);
            this._groupBoxCommand.Controls.Add(this._groupBoxSystemControl);
            this._groupBoxCommand.Location = new System.Drawing.Point(3, 219);
            this._groupBoxCommand.Name = "_groupBoxCommand";
            this._groupBoxCommand.Size = new System.Drawing.Size(446, 329);
            this._groupBoxCommand.TabIndex = 1;
            this._groupBoxCommand.TabStop = false;
            this._groupBoxCommand.Text = "Communication command";
            // 
            // _groupBoxSetting
            // 
            this._groupBoxSetting.Controls.Add(this._buttonSetSetting);
            this._groupBoxSetting.Controls.Add(this._buttonGetSetting);
            this._groupBoxSetting.Controls.Add(this._buttonInitializeSetting);
            this._groupBoxSetting.Controls.Add(this._buttonUpdateSetting);
            this._groupBoxSetting.Controls.Add(this._buttonRewriteTemporarySetting);
            this._groupBoxSetting.Controls.Add(this._buttonCheckMemoryAccess);
            this._groupBoxSetting.Controls.Add(this._buttonGetActiveProgram);
            this._groupBoxSetting.Controls.Add(this._buttonChangeActiveProgram);
            this._groupBoxSetting.Location = new System.Drawing.Point(5, 222);
            this._groupBoxSetting.Name = "_groupBoxSetting";
            this._groupBoxSetting.Size = new System.Drawing.Size(432, 98);
            this._groupBoxSetting.TabIndex = 2;
            this._groupBoxSetting.TabStop = false;
            this._groupBoxSetting.Text = "Functions related to modifying or reading settings";
            // 
            // _buttonSetSetting
            // 
            this._buttonSetSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._buttonSetSetting.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonSetSetting.Location = new System.Drawing.Point(5, 16);
            this._buttonSetSetting.Name = "_buttonSetSetting";
            this._buttonSetSetting.Size = new System.Drawing.Size(136, 23);
            this._buttonSetSetting.TabIndex = 0;
            this._buttonSetSetting.Text = "SetSetting";
            this._buttonSetSetting.UseVisualStyleBackColor = false;
            this._buttonSetSetting.Click += new System.EventHandler(this._buttonSetSetting_Click);
            // 
            // _buttonGetSetting
            // 
            this._buttonGetSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._buttonGetSetting.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonGetSetting.Location = new System.Drawing.Point(147, 16);
            this._buttonGetSetting.Name = "_buttonGetSetting";
            this._buttonGetSetting.Size = new System.Drawing.Size(136, 23);
            this._buttonGetSetting.TabIndex = 1;
            this._buttonGetSetting.Text = "GetSetting";
            this._buttonGetSetting.UseVisualStyleBackColor = false;
            this._buttonGetSetting.Click += new System.EventHandler(this._buttonGetSetting_Click);
            // 
            // _buttonInitializeSetting
            // 
            this._buttonInitializeSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._buttonInitializeSetting.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonInitializeSetting.Location = new System.Drawing.Point(288, 16);
            this._buttonInitializeSetting.Name = "_buttonInitializeSetting";
            this._buttonInitializeSetting.Size = new System.Drawing.Size(136, 23);
            this._buttonInitializeSetting.TabIndex = 2;
            this._buttonInitializeSetting.Text = "InitializeSetting";
            this._buttonInitializeSetting.UseVisualStyleBackColor = false;
            this._buttonInitializeSetting.Click += new System.EventHandler(this._buttonInitializeSetting_Click);
            // 
            // _buttonUpdateSetting
            // 
            this._buttonUpdateSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._buttonUpdateSetting.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonUpdateSetting.Location = new System.Drawing.Point(5, 42);
            this._buttonUpdateSetting.Name = "_buttonUpdateSetting";
            this._buttonUpdateSetting.Size = new System.Drawing.Size(136, 23);
            this._buttonUpdateSetting.TabIndex = 3;
            this._buttonUpdateSetting.Text = "ReflectSetting";
            this._buttonUpdateSetting.UseVisualStyleBackColor = false;
            this._buttonUpdateSetting.Click += new System.EventHandler(this._buttonReflectSetting_Click);
            // 
            // _buttonRewriteTemporarySetting
            // 
            this._buttonRewriteTemporarySetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._buttonRewriteTemporarySetting.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonRewriteTemporarySetting.Location = new System.Drawing.Point(147, 42);
            this._buttonRewriteTemporarySetting.Name = "_buttonRewriteTemporarySetting";
            this._buttonRewriteTemporarySetting.Size = new System.Drawing.Size(136, 23);
            this._buttonRewriteTemporarySetting.TabIndex = 4;
            this._buttonRewriteTemporarySetting.Text = "RewriteTemporarySetting";
            this._buttonRewriteTemporarySetting.UseVisualStyleBackColor = false;
            this._buttonRewriteTemporarySetting.Click += new System.EventHandler(this._buttonRewriteTemporarySetting_Click);
            // 
            // _buttonCheckMemoryAccess
            // 
            this._buttonCheckMemoryAccess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._buttonCheckMemoryAccess.Location = new System.Drawing.Point(288, 42);
            this._buttonCheckMemoryAccess.Name = "_buttonCheckMemoryAccess";
            this._buttonCheckMemoryAccess.Size = new System.Drawing.Size(136, 23);
            this._buttonCheckMemoryAccess.TabIndex = 5;
            this._buttonCheckMemoryAccess.Text = "CheckMemoryAccess";
            this._buttonCheckMemoryAccess.UseVisualStyleBackColor = false;
            this._buttonCheckMemoryAccess.Click += new System.EventHandler(this._buttonCheckMemoryAccess_Click);
            // 
            // _buttonGetActiveProgram
            // 
            this._buttonGetActiveProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._buttonGetActiveProgram.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonGetActiveProgram.Location = new System.Drawing.Point(147, 68);
            this._buttonGetActiveProgram.Name = "_buttonGetActiveProgram";
            this._buttonGetActiveProgram.Size = new System.Drawing.Size(136, 23);
            this._buttonGetActiveProgram.TabIndex = 7;
            this._buttonGetActiveProgram.Text = "GetActiveProgram";
            this._buttonGetActiveProgram.UseVisualStyleBackColor = false;
            this._buttonGetActiveProgram.Click += new System.EventHandler(this._buttonGetActiveProgram_Click);
            // 
            // _buttonChangeActiveProgram
            // 
            this._buttonChangeActiveProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._buttonChangeActiveProgram.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonChangeActiveProgram.Location = new System.Drawing.Point(5, 68);
            this._buttonChangeActiveProgram.Name = "_buttonChangeActiveProgram";
            this._buttonChangeActiveProgram.Size = new System.Drawing.Size(136, 23);
            this._buttonChangeActiveProgram.TabIndex = 6;
            this._buttonChangeActiveProgram.Text = "ChangeActiveProgram";
            this._buttonChangeActiveProgram.UseVisualStyleBackColor = false;
            this._buttonChangeActiveProgram.Click += new System.EventHandler(this._buttonChangeActiveProgram_Click);
            // 
            // _groupBoxMeasurementControl
            // 
            this._groupBoxMeasurementControl.Controls.Add(this._buttonTrigger);
            this._groupBoxMeasurementControl.Controls.Add(this._buttonStartMeasure);
            this._groupBoxMeasurementControl.Controls.Add(this._buttonStopMeasure);
            this._groupBoxMeasurementControl.Controls.Add(this._buttonClearMemory);
            this._groupBoxMeasurementControl.Location = new System.Drawing.Point(5, 146);
            this._groupBoxMeasurementControl.Name = "_groupBoxMeasurementControl";
            this._groupBoxMeasurementControl.Size = new System.Drawing.Size(432, 70);
            this._groupBoxMeasurementControl.TabIndex = 1;
            this._groupBoxMeasurementControl.TabStop = false;
            this._groupBoxMeasurementControl.Text = "Measurement control";
            // 
            // _buttonTrigger
            // 
            this._buttonTrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this._buttonTrigger.Location = new System.Drawing.Point(4, 15);
            this._buttonTrigger.Name = "_buttonTrigger";
            this._buttonTrigger.Size = new System.Drawing.Size(136, 23);
            this._buttonTrigger.TabIndex = 0;
            this._buttonTrigger.Text = "Trigger";
            this._buttonTrigger.UseVisualStyleBackColor = false;
            this._buttonTrigger.Click += new System.EventHandler(this._buttonTrigger_Click);
            // 
            // _buttonStartMeasure
            // 
            this._buttonStartMeasure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this._buttonStartMeasure.Location = new System.Drawing.Point(146, 15);
            this._buttonStartMeasure.Name = "_buttonStartMeasure";
            this._buttonStartMeasure.Size = new System.Drawing.Size(136, 23);
            this._buttonStartMeasure.TabIndex = 1;
            this._buttonStartMeasure.Text = "StartMeasure";
            this._buttonStartMeasure.UseVisualStyleBackColor = false;
            this._buttonStartMeasure.Click += new System.EventHandler(this._buttonStartMeasure_Click);
            // 
            // _buttonStopMeasure
            // 
            this._buttonStopMeasure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this._buttonStopMeasure.Location = new System.Drawing.Point(288, 15);
            this._buttonStopMeasure.Name = "_buttonStopMeasure";
            this._buttonStopMeasure.Size = new System.Drawing.Size(136, 23);
            this._buttonStopMeasure.TabIndex = 2;
            this._buttonStopMeasure.Text = "StopMeasure";
            this._buttonStopMeasure.UseVisualStyleBackColor = false;
            this._buttonStopMeasure.Click += new System.EventHandler(this._buttonStopMeasure_Click);
            // 
            // _buttonClearMemory
            // 
            this._buttonClearMemory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this._buttonClearMemory.Location = new System.Drawing.Point(4, 41);
            this._buttonClearMemory.Name = "_buttonClearMemory";
            this._buttonClearMemory.Size = new System.Drawing.Size(136, 23);
            this._buttonClearMemory.TabIndex = 3;
            this._buttonClearMemory.Text = "ClearMemory";
            this._buttonClearMemory.UseVisualStyleBackColor = false;
            this._buttonClearMemory.Click += new System.EventHandler(this._buttonClearMemory_Click);
            // 
            // _groupBoxSystemControl
            // 
            this._groupBoxSystemControl.Controls.Add(this._buttonGetAttentionStatus);
            this._groupBoxSystemControl.Controls.Add(this._buttonGetSerialNumber);
            this._groupBoxSystemControl.Controls.Add(this._buttonGetTriggerCount);
            this._groupBoxSystemControl.Controls.Add(this._buttonControlLaser);
            this._groupBoxSystemControl.Controls.Add(this._buttonGetHeadTemperature);
            this._groupBoxSystemControl.Controls.Add(this._buttonTriggerErrorReset);
            this._groupBoxSystemControl.Controls.Add(this._buttonRebootController);
            this._groupBoxSystemControl.Controls.Add(this._buttonReturnToFactorySetting);
            this._groupBoxSystemControl.Controls.Add(this._buttonGetError);
            this._groupBoxSystemControl.Controls.Add(this._buttonClearError);
            this._groupBoxSystemControl.Location = new System.Drawing.Point(5, 17);
            this._groupBoxSystemControl.Name = "_groupBoxSystemControl";
            this._groupBoxSystemControl.Size = new System.Drawing.Size(432, 123);
            this._groupBoxSystemControl.TabIndex = 0;
            this._groupBoxSystemControl.TabStop = false;
            this._groupBoxSystemControl.Text = "System control";
            // 
            // _buttonGetAttentionStatus
            // 
            this._buttonGetAttentionStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._buttonGetAttentionStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonGetAttentionStatus.Location = new System.Drawing.Point(4, 95);
            this._buttonGetAttentionStatus.Name = "_buttonGetAttentionStatus";
            this._buttonGetAttentionStatus.Size = new System.Drawing.Size(136, 23);
            this._buttonGetAttentionStatus.TabIndex = 9;
            this._buttonGetAttentionStatus.Text = "GetAttentionStatus";
            this._buttonGetAttentionStatus.UseVisualStyleBackColor = false;
            this._buttonGetAttentionStatus.Click += new System.EventHandler(this._buttonGetAttentionStatus_Click);
            // 
            // _buttonGetSerialNumber
            // 
            this._buttonGetSerialNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._buttonGetSerialNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonGetSerialNumber.Location = new System.Drawing.Point(288, 68);
            this._buttonGetSerialNumber.Name = "_buttonGetSerialNumber";
            this._buttonGetSerialNumber.Size = new System.Drawing.Size(136, 23);
            this._buttonGetSerialNumber.TabIndex = 8;
            this._buttonGetSerialNumber.Text = "GetSerialNumber";
            this._buttonGetSerialNumber.UseVisualStyleBackColor = false;
            this._buttonGetSerialNumber.Click += new System.EventHandler(this._buttonGetSerialNumber_Click);
            // 
            // _buttonGetTriggerCount
            // 
            this._buttonGetTriggerCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._buttonGetTriggerCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonGetTriggerCount.Location = new System.Drawing.Point(4, 68);
            this._buttonGetTriggerCount.Name = "_buttonGetTriggerCount";
            this._buttonGetTriggerCount.Size = new System.Drawing.Size(136, 23);
            this._buttonGetTriggerCount.TabIndex = 6;
            this._buttonGetTriggerCount.Text = "GetTriggerAndPulseCount";
            this._buttonGetTriggerCount.UseVisualStyleBackColor = false;
            this._buttonGetTriggerCount.Click += new System.EventHandler(this._buttonGetTriggerAndPulseCount_Click);
            // 
            // _buttonControlLaser
            // 
            this._buttonControlLaser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._buttonControlLaser.Location = new System.Drawing.Point(288, 16);
            this._buttonControlLaser.Name = "_buttonControlLaser";
            this._buttonControlLaser.Size = new System.Drawing.Size(136, 23);
            this._buttonControlLaser.TabIndex = 2;
            this._buttonControlLaser.Text = "ControlLaser";
            this._buttonControlLaser.UseVisualStyleBackColor = false;
            this._buttonControlLaser.Click += new System.EventHandler(this._buttonControlLaser_Click);
            // 
            // _buttonGetHeadTemperature
            // 
            this._buttonGetHeadTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._buttonGetHeadTemperature.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonGetHeadTemperature.Location = new System.Drawing.Point(146, 68);
            this._buttonGetHeadTemperature.Name = "_buttonGetHeadTemperature";
            this._buttonGetHeadTemperature.Size = new System.Drawing.Size(136, 23);
            this._buttonGetHeadTemperature.TabIndex = 7;
            this._buttonGetHeadTemperature.Text = "GetHeadTemperature";
            this._buttonGetHeadTemperature.UseVisualStyleBackColor = false;
            this._buttonGetHeadTemperature.Click += new System.EventHandler(this._buttonGetHeadTemperature_Click);
            // 
            // _buttonTriggerErrorReset
            // 
            this._buttonTriggerErrorReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._buttonTriggerErrorReset.Location = new System.Drawing.Point(288, 42);
            this._buttonTriggerErrorReset.Name = "_buttonTriggerErrorReset";
            this._buttonTriggerErrorReset.Size = new System.Drawing.Size(136, 23);
            this._buttonTriggerErrorReset.TabIndex = 5;
            this._buttonTriggerErrorReset.Text = "TRG_ERROR_RESET";
            this._buttonTriggerErrorReset.UseVisualStyleBackColor = false;
            this._buttonTriggerErrorReset.Click += new System.EventHandler(this._buttonTriggerErrorReset_Click);
            // 
            // _buttonRebootController
            // 
            this._buttonRebootController.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._buttonRebootController.Location = new System.Drawing.Point(4, 16);
            this._buttonRebootController.Name = "_buttonRebootController";
            this._buttonRebootController.Size = new System.Drawing.Size(136, 23);
            this._buttonRebootController.TabIndex = 0;
            this._buttonRebootController.Text = "RebootController";
            this._buttonRebootController.UseVisualStyleBackColor = false;
            this._buttonRebootController.Click += new System.EventHandler(this._buttonRebootController_Click);
            // 
            // _buttonReturnToFactorySetting
            // 
            this._buttonReturnToFactorySetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._buttonReturnToFactorySetting.Location = new System.Drawing.Point(146, 16);
            this._buttonReturnToFactorySetting.Name = "_buttonReturnToFactorySetting";
            this._buttonReturnToFactorySetting.Size = new System.Drawing.Size(136, 23);
            this._buttonReturnToFactorySetting.TabIndex = 1;
            this._buttonReturnToFactorySetting.Text = "ReturnToFactorySetting";
            this._buttonReturnToFactorySetting.UseVisualStyleBackColor = false;
            this._buttonReturnToFactorySetting.Click += new System.EventHandler(this._buttonReturnToFactorySetting_Click);
            // 
            // _buttonGetError
            // 
            this._buttonGetError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._buttonGetError.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonGetError.Location = new System.Drawing.Point(4, 42);
            this._buttonGetError.Name = "_buttonGetError";
            this._buttonGetError.Size = new System.Drawing.Size(136, 23);
            this._buttonGetError.TabIndex = 3;
            this._buttonGetError.Text = "GetError";
            this._buttonGetError.UseVisualStyleBackColor = false;
            this._buttonGetError.Click += new System.EventHandler(this._buttonGetError_Click);
            // 
            // _buttonClearError
            // 
            this._buttonClearError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._buttonClearError.Location = new System.Drawing.Point(146, 42);
            this._buttonClearError.Name = "_buttonClearError";
            this._buttonClearError.Size = new System.Drawing.Size(136, 23);
            this._buttonClearError.TabIndex = 4;
            this._buttonClearError.Text = "ClearError";
            this._buttonClearError.UseVisualStyleBackColor = false;
            this._buttonClearError.Click += new System.EventHandler(this._buttonClearError_Click);
            // 
            // _groupBoxHighSpeedData
            // 
            this._groupBoxHighSpeedData.Controls.Add(this._checkBoxUseSimpleArray);
            this._groupBoxHighSpeedData.Controls.Add(this._numericUpDownInterval);
            this._groupBoxHighSpeedData.Controls.Add(this._checkBoxStartTimer);
            this._groupBoxHighSpeedData.Controls.Add(this._buttonInitializeHighSpeedDataCommunicationSimpleArray);
            this._groupBoxHighSpeedData.Controls.Add(this._checkBoxOnlyProfileCount);
            this._groupBoxHighSpeedData.Controls.Add(this._buttonInitializeHighSpeedDataCommunication);
            this._groupBoxHighSpeedData.Controls.Add(this._groupBoxHighSpeedExport);
            this._groupBoxHighSpeedData.Controls.Add(this._buttonPreStartHighSpeedDataCommunication);
            this._groupBoxHighSpeedData.Controls.Add(this._buttonFinalizeHighSpeedDataCommunication);
            this._groupBoxHighSpeedData.Controls.Add(this._buttonStartHighSpeedDataCommunication);
            this._groupBoxHighSpeedData.Controls.Add(this._buttonStopHighSpeedDataCommunication);
            this._groupBoxHighSpeedData.Location = new System.Drawing.Point(6, 276);
            this._groupBoxHighSpeedData.Name = "_groupBoxHighSpeedData";
            this._groupBoxHighSpeedData.Size = new System.Drawing.Size(529, 197);
            this._groupBoxHighSpeedData.TabIndex = 3;
            this._groupBoxHighSpeedData.TabStop = false;
            this._groupBoxHighSpeedData.Text = "High-speed data communication related functions";
            // 
            // _checkBoxUseSimpleArray
            // 
            this._checkBoxUseSimpleArray.AutoSize = true;
            this._checkBoxUseSimpleArray.Checked = true;
            this._checkBoxUseSimpleArray.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxUseSimpleArray.Location = new System.Drawing.Point(6, 18);
            this._checkBoxUseSimpleArray.Name = "_checkBoxUseSimpleArray";
            this._checkBoxUseSimpleArray.Size = new System.Drawing.Size(101, 16);
            this._checkBoxUseSimpleArray.TabIndex = 0;
            this._checkBoxUseSimpleArray.Text = "Use Simple Array";
            this._checkBoxUseSimpleArray.UseVisualStyleBackColor = true;
            this._checkBoxUseSimpleArray.CheckedChanged += new System.EventHandler(this._checkBoxUseSimpleArray_CheckedChanged);
            // 
            // _numericUpDownInterval
            // 
            this._numericUpDownInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._numericUpDownInterval.Location = new System.Drawing.Point(321, 19);
            this._numericUpDownInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._numericUpDownInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._numericUpDownInterval.Name = "_numericUpDownInterval";
            this._numericUpDownInterval.Size = new System.Drawing.Size(50, 20);
            this._numericUpDownInterval.TabIndex = 8;
            this._numericUpDownInterval.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // _checkBoxStartTimer
            // 
            this._checkBoxStartTimer.AutoSize = true;
            this._checkBoxStartTimer.Location = new System.Drawing.Point(207, 20);
            this._checkBoxStartTimer.Name = "_checkBoxStartTimer";
            this._checkBoxStartTimer.Size = new System.Drawing.Size(87, 16);
            this._checkBoxStartTimer.TabIndex = 7;
            this._checkBoxStartTimer.Text = "Start the timer";
            this._checkBoxStartTimer.UseVisualStyleBackColor = true;
            this._checkBoxStartTimer.CheckedChanged += new System.EventHandler(this._checkBoxStartTimer_CheckedChanged);
            // 
            // _buttonInitializeHighSpeedDataCommunicationSimpleArray
            // 
            this._buttonInitializeHighSpeedDataCommunicationSimpleArray.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this._buttonInitializeHighSpeedDataCommunicationSimpleArray.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonInitializeHighSpeedDataCommunicationSimpleArray.Location = new System.Drawing.Point(5, 64);
            this._buttonInitializeHighSpeedDataCommunicationSimpleArray.Name = "_buttonInitializeHighSpeedDataCommunicationSimpleArray";
            this._buttonInitializeHighSpeedDataCommunicationSimpleArray.Size = new System.Drawing.Size(195, 23);
            this._buttonInitializeHighSpeedDataCommunicationSimpleArray.TabIndex = 2;
            this._buttonInitializeHighSpeedDataCommunicationSimpleArray.Text = "InitializeHighSpeed(SimpleArray)";
            this._buttonInitializeHighSpeedDataCommunicationSimpleArray.UseVisualStyleBackColor = false;
            this._buttonInitializeHighSpeedDataCommunicationSimpleArray.Click += new System.EventHandler(this._buttonInitializeHighSpeedDataCommunicationSimpleArray_Click);
            // 
            // _checkBoxOnlyProfileCount
            // 
            this._checkBoxOnlyProfileCount.Location = new System.Drawing.Point(207, 42);
            this._checkBoxOnlyProfileCount.Name = "_checkBoxOnlyProfileCount";
            this._checkBoxOnlyProfileCount.Size = new System.Drawing.Size(228, 22);
            this._checkBoxOnlyProfileCount.TabIndex = 9;
            this._checkBoxOnlyProfileCount.Text = "Count only the number of received profiles.";
            this._checkBoxOnlyProfileCount.UseVisualStyleBackColor = true;
            this._checkBoxOnlyProfileCount.CheckedChanged += new System.EventHandler(this._checkBoxOnlyProfileCountCheckedChanged);
            // 
            // _buttonInitializeHighSpeedDataCommunication
            // 
            this._buttonInitializeHighSpeedDataCommunication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this._buttonInitializeHighSpeedDataCommunication.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonInitializeHighSpeedDataCommunication.Location = new System.Drawing.Point(5, 40);
            this._buttonInitializeHighSpeedDataCommunication.Name = "_buttonInitializeHighSpeedDataCommunication";
            this._buttonInitializeHighSpeedDataCommunication.Size = new System.Drawing.Size(195, 23);
            this._buttonInitializeHighSpeedDataCommunication.TabIndex = 1;
            this._buttonInitializeHighSpeedDataCommunication.Text = "InitializeHighSpeedDataCommunication";
            this._buttonInitializeHighSpeedDataCommunication.UseVisualStyleBackColor = false;
            this._buttonInitializeHighSpeedDataCommunication.Click += new System.EventHandler(this._buttonInitializeHighSpeedDataCommunication_Click);
            // 
            // _groupBoxHighSpeedExport
            // 
            this._groupBoxHighSpeedExport.Controls.Add(this._buttonHighSpeedSaveAsBitmapFile);
            this._groupBoxHighSpeedExport.Controls.Add(this._numericUpDownProfileSaveCount);
            this._groupBoxHighSpeedExport.Controls.Add(this._labelProfileSaveCount);
            this._groupBoxHighSpeedExport.Controls.Add(this._numericUpDownProfileNo);
            this._groupBoxHighSpeedExport.Controls.Add(this._textBoxHighSpeedProfileFilePath);
            this._groupBoxHighSpeedExport.Controls.Add(this._buttonHighSpeedSave);
            this._groupBoxHighSpeedExport.Controls.Add(this._buttonHighSpeedProfileFileSave);
            this._groupBoxHighSpeedExport.Controls.Add(this._labelIndexOfTheProfileToSave);
            this._groupBoxHighSpeedExport.Controls.Add(this._labelHighSpeedSavePath);
            this._groupBoxHighSpeedExport.Location = new System.Drawing.Point(207, 70);
            this._groupBoxHighSpeedExport.Name = "_groupBoxHighSpeedExport";
            this._groupBoxHighSpeedExport.Size = new System.Drawing.Size(317, 121);
            this._groupBoxHighSpeedExport.TabIndex = 10;
            this._groupBoxHighSpeedExport.TabStop = false;
            this._groupBoxHighSpeedExport.Text = "Save the results file";
            // 
            // _buttonHighSpeedSaveAsBitmapFile
            // 
            this._buttonHighSpeedSaveAsBitmapFile.Location = new System.Drawing.Point(166, 92);
            this._buttonHighSpeedSaveAsBitmapFile.Name = "_buttonHighSpeedSaveAsBitmapFile";
            this._buttonHighSpeedSaveAsBitmapFile.Size = new System.Drawing.Size(127, 23);
            this._buttonHighSpeedSaveAsBitmapFile.TabIndex = 8;
            this._buttonHighSpeedSaveAsBitmapFile.Text = "Save As Image File";
            this._buttonHighSpeedSaveAsBitmapFile.UseVisualStyleBackColor = true;
            this._buttonHighSpeedSaveAsBitmapFile.Click += new System.EventHandler(this._buttonHighSpeedSaveAsBitmapFile_Click);
            // 
            // _numericUpDownProfileSaveCount
            // 
            this._numericUpDownProfileSaveCount.Location = new System.Drawing.Point(223, 67);
            this._numericUpDownProfileSaveCount.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this._numericUpDownProfileSaveCount.Name = "_numericUpDownProfileSaveCount";
            this._numericUpDownProfileSaveCount.Size = new System.Drawing.Size(64, 20);
            this._numericUpDownProfileSaveCount.TabIndex = 6;
            this._numericUpDownProfileSaveCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _labelProfileSaveCount
            // 
            this._labelProfileSaveCount.AutoSize = true;
            this._labelProfileSaveCount.Location = new System.Drawing.Point(6, 69);
            this._labelProfileSaveCount.Name = "_labelProfileSaveCount";
            this._labelProfileSaveCount.Size = new System.Drawing.Size(123, 12);
            this._labelProfileSaveCount.TabIndex = 5;
            this._labelProfileSaveCount.Text = "Number of profiles to save";
            // 
            // _numericUpDownProfileNo
            // 
            this._numericUpDownProfileNo.Location = new System.Drawing.Point(223, 43);
            this._numericUpDownProfileNo.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this._numericUpDownProfileNo.Name = "_numericUpDownProfileNo";
            this._numericUpDownProfileNo.Size = new System.Drawing.Size(64, 20);
            this._numericUpDownProfileNo.TabIndex = 4;
            // 
            // _textBoxHighSpeedProfileFilePath
            // 
            this._textBoxHighSpeedProfileFilePath.Location = new System.Drawing.Point(90, 19);
            this._textBoxHighSpeedProfileFilePath.Name = "_textBoxHighSpeedProfileFilePath";
            this._textBoxHighSpeedProfileFilePath.Size = new System.Drawing.Size(197, 20);
            this._textBoxHighSpeedProfileFilePath.TabIndex = 1;
            // 
            // _buttonHighSpeedSave
            // 
            this._buttonHighSpeedSave.Location = new System.Drawing.Point(26, 92);
            this._buttonHighSpeedSave.Name = "_buttonHighSpeedSave";
            this._buttonHighSpeedSave.Size = new System.Drawing.Size(127, 23);
            this._buttonHighSpeedSave.TabIndex = 7;
            this._buttonHighSpeedSave.Text = "Save the profile";
            this._buttonHighSpeedSave.UseVisualStyleBackColor = true;
            this._buttonHighSpeedSave.Click += new System.EventHandler(this._buttonSave_Click);
            // 
            // _buttonHighSpeedProfileFileSave
            // 
            this._buttonHighSpeedProfileFileSave.Location = new System.Drawing.Point(288, 17);
            this._buttonHighSpeedProfileFileSave.Name = "_buttonHighSpeedProfileFileSave";
            this._buttonHighSpeedProfileFileSave.Size = new System.Drawing.Size(25, 22);
            this._buttonHighSpeedProfileFileSave.TabIndex = 2;
            this._buttonHighSpeedProfileFileSave.Text = "...";
            this._buttonHighSpeedProfileFileSave.UseVisualStyleBackColor = true;
            this._buttonHighSpeedProfileFileSave.Click += new System.EventHandler(this._buttonHighSpeedProfileFileSave_Click);
            // 
            // _labelIndexOfTheProfileToSave
            // 
            this._labelIndexOfTheProfileToSave.AutoSize = true;
            this._labelIndexOfTheProfileToSave.Location = new System.Drawing.Point(6, 45);
            this._labelIndexOfTheProfileToSave.Name = "_labelIndexOfTheProfileToSave";
            this._labelIndexOfTheProfileToSave.Size = new System.Drawing.Size(126, 12);
            this._labelIndexOfTheProfileToSave.TabIndex = 3;
            this._labelIndexOfTheProfileToSave.Text = "Index of the profile to save";
            // 
            // _labelHighSpeedSavePath
            // 
            this._labelHighSpeedSavePath.AutoSize = true;
            this._labelHighSpeedSavePath.Location = new System.Drawing.Point(6, 22);
            this._labelHighSpeedSavePath.Name = "_labelHighSpeedSavePath";
            this._labelHighSpeedSavePath.Size = new System.Drawing.Size(78, 12);
            this._labelHighSpeedSavePath.TabIndex = 0;
            this._labelHighSpeedSavePath.Text = "Save destination";
            // 
            // _buttonPreStartHighSpeedDataCommunication
            // 
            this._buttonPreStartHighSpeedDataCommunication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this._buttonPreStartHighSpeedDataCommunication.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonPreStartHighSpeedDataCommunication.Location = new System.Drawing.Point(5, 88);
            this._buttonPreStartHighSpeedDataCommunication.Name = "_buttonPreStartHighSpeedDataCommunication";
            this._buttonPreStartHighSpeedDataCommunication.Size = new System.Drawing.Size(195, 23);
            this._buttonPreStartHighSpeedDataCommunication.TabIndex = 3;
            this._buttonPreStartHighSpeedDataCommunication.Text = "PreStartHighSpeedDataCommunication";
            this._buttonPreStartHighSpeedDataCommunication.UseVisualStyleBackColor = false;
            this._buttonPreStartHighSpeedDataCommunication.Click += new System.EventHandler(this._buttonPreStartHighSpeedDataCommunication_Click);
            // 
            // _buttonFinalizeHighSpeedDataCommunication
            // 
            this._buttonFinalizeHighSpeedDataCommunication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this._buttonFinalizeHighSpeedDataCommunication.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonFinalizeHighSpeedDataCommunication.Location = new System.Drawing.Point(5, 159);
            this._buttonFinalizeHighSpeedDataCommunication.Name = "_buttonFinalizeHighSpeedDataCommunication";
            this._buttonFinalizeHighSpeedDataCommunication.Size = new System.Drawing.Size(195, 23);
            this._buttonFinalizeHighSpeedDataCommunication.TabIndex = 6;
            this._buttonFinalizeHighSpeedDataCommunication.Text = "FinalizeHighSpeedDataCommunication";
            this._buttonFinalizeHighSpeedDataCommunication.UseVisualStyleBackColor = false;
            this._buttonFinalizeHighSpeedDataCommunication.Click += new System.EventHandler(this._buttonFinalizeHighSpeedDataCommunication_Click);
            // 
            // _buttonStartHighSpeedDataCommunication
            // 
            this._buttonStartHighSpeedDataCommunication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this._buttonStartHighSpeedDataCommunication.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonStartHighSpeedDataCommunication.Location = new System.Drawing.Point(5, 112);
            this._buttonStartHighSpeedDataCommunication.Name = "_buttonStartHighSpeedDataCommunication";
            this._buttonStartHighSpeedDataCommunication.Size = new System.Drawing.Size(195, 23);
            this._buttonStartHighSpeedDataCommunication.TabIndex = 4;
            this._buttonStartHighSpeedDataCommunication.Text = "StartHighSpeedDataCommunication";
            this._buttonStartHighSpeedDataCommunication.UseVisualStyleBackColor = false;
            this._buttonStartHighSpeedDataCommunication.Click += new System.EventHandler(this._buttonStartHighSpeedDataCommunication_Click);
            // 
            // _buttonStopHighSpeedDataCommunication
            // 
            this._buttonStopHighSpeedDataCommunication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this._buttonStopHighSpeedDataCommunication.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonStopHighSpeedDataCommunication.Location = new System.Drawing.Point(5, 135);
            this._buttonStopHighSpeedDataCommunication.Name = "_buttonStopHighSpeedDataCommunication";
            this._buttonStopHighSpeedDataCommunication.Size = new System.Drawing.Size(195, 23);
            this._buttonStopHighSpeedDataCommunication.TabIndex = 5;
            this._buttonStopHighSpeedDataCommunication.Text = "StopHighSpeedDataCommunication";
            this._buttonStopHighSpeedDataCommunication.UseVisualStyleBackColor = false;
            this._buttonStopHighSpeedDataCommunication.Click += new System.EventHandler(this._buttonStopHighSpeedDataCommunication_Click);
            // 
            // _groupBoxGetMeasurementResult
            // 
            this._groupBoxGetMeasurementResult.Controls.Add(this._textBoxProfileFilePath);
            this._groupBoxGetMeasurementResult.Controls.Add(this._buttonGetProfile);
            this._groupBoxGetMeasurementResult.Controls.Add(this._buttonProfileFileSave);
            this._groupBoxGetMeasurementResult.Controls.Add(this._buttonGetBatchProfile);
            this._groupBoxGetMeasurementResult.Location = new System.Drawing.Point(6, 171);
            this._groupBoxGetMeasurementResult.Name = "_groupBoxGetMeasurementResult";
            this._groupBoxGetMeasurementResult.Size = new System.Drawing.Size(529, 45);
            this._groupBoxGetMeasurementResult.TabIndex = 1;
            this._groupBoxGetMeasurementResult.TabStop = false;
            this._groupBoxGetMeasurementResult.Text = "Get measurement results";
            // 
            // _textBoxProfileFilePath
            // 
            this._textBoxProfileFilePath.Location = new System.Drawing.Point(290, 18);
            this._textBoxProfileFilePath.Name = "_textBoxProfileFilePath";
            this._textBoxProfileFilePath.Size = new System.Drawing.Size(210, 20);
            this._textBoxProfileFilePath.TabIndex = 2;
            // 
            // _buttonGetProfile
            // 
            this._buttonGetProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._buttonGetProfile.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonGetProfile.Location = new System.Drawing.Point(6, 16);
            this._buttonGetProfile.Name = "_buttonGetProfile";
            this._buttonGetProfile.Size = new System.Drawing.Size(136, 23);
            this._buttonGetProfile.TabIndex = 0;
            this._buttonGetProfile.Text = "GetProfile";
            this._buttonGetProfile.UseVisualStyleBackColor = false;
            this._buttonGetProfile.Click += new System.EventHandler(this._buttonGetProfile_Click);
            // 
            // _buttonProfileFileSave
            // 
            this._buttonProfileFileSave.Location = new System.Drawing.Point(500, 16);
            this._buttonProfileFileSave.Name = "_buttonProfileFileSave";
            this._buttonProfileFileSave.Size = new System.Drawing.Size(25, 22);
            this._buttonProfileFileSave.TabIndex = 3;
            this._buttonProfileFileSave.Text = "...";
            this._buttonProfileFileSave.UseVisualStyleBackColor = true;
            this._buttonProfileFileSave.Click += new System.EventHandler(this._buttonProfileFileSave_Click);
            // 
            // _buttonGetBatchProfile
            // 
            this._buttonGetBatchProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._buttonGetBatchProfile.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonGetBatchProfile.Location = new System.Drawing.Point(148, 16);
            this._buttonGetBatchProfile.Name = "_buttonGetBatchProfile";
            this._buttonGetBatchProfile.Size = new System.Drawing.Size(136, 23);
            this._buttonGetBatchProfile.TabIndex = 1;
            this._buttonGetBatchProfile.Text = "GetBatchProfile";
            this._buttonGetBatchProfile.UseVisualStyleBackColor = false;
            this._buttonGetBatchProfile.Click += new System.EventHandler(this._buttonGetBatchProfile_Click);
            // 
            // _groupBoxOperations
            // 
            this._groupBoxOperations.Controls.Add(this._buttonInitialize);
            this._groupBoxOperations.Controls.Add(this._buttonGetVersion);
            this._groupBoxOperations.Controls.Add(this._buttonFinalize);
            this._groupBoxOperations.Location = new System.Drawing.Point(9, 15);
            this._groupBoxOperations.Name = "_groupBoxOperations";
            this._groupBoxOperations.Size = new System.Drawing.Size(239, 42);
            this._groupBoxOperations.TabIndex = 0;
            this._groupBoxOperations.TabStop = false;
            this._groupBoxOperations.Text = "Operations for the DLL";
            // 
            // _groupBoxLog
            // 
            this._groupBoxLog.Controls.Add(this._textBoxLog);
            this._groupBoxLog.Controls.Add(this._buttonLogClear);
            this._groupBoxLog.Location = new System.Drawing.Point(416, 7);
            this._groupBoxLog.Name = "_groupBoxLog";
            this._groupBoxLog.Size = new System.Drawing.Size(569, 202);
            this._groupBoxLog.TabIndex = 5;
            this._groupBoxLog.TabStop = false;
            this._groupBoxLog.Text = "Operation result log";
            // 
            // _textBoxLog
            // 
            this._textBoxLog.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._textBoxLog.Location = new System.Drawing.Point(10, 14);
            this._textBoxLog.Multiline = true;
            this._textBoxLog.Name = "_textBoxLog";
            this._textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._textBoxLog.Size = new System.Drawing.Size(493, 182);
            this._textBoxLog.TabIndex = 0;
            this._textBoxLog.WordWrap = false;
            // 
            // _buttonLogClear
            // 
            this._buttonLogClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._buttonLogClear.Location = new System.Drawing.Point(509, 16);
            this._buttonLogClear.Name = "_buttonLogClear";
            this._buttonLogClear.Size = new System.Drawing.Size(54, 23);
            this._buttonLogClear.TabIndex = 1;
            this._buttonLogClear.Text = "Clear";
            this._buttonLogClear.UseVisualStyleBackColor = true;
            this._buttonLogClear.Click += new System.EventHandler(this._buttonLogClear_Click);
            // 
            // _groupBoxBufferSize
            // 
            this._groupBoxBufferSize.Controls.Add(this._panelHeadType);
            this._groupBoxBufferSize.Controls.Add(this._groupBoxBufferSizeResult);
            this._groupBoxBufferSize.Controls.Add(this._panelLjxSetting);
            this._groupBoxBufferSize.Controls.Add(this._panelLjvSetting);
            this._groupBoxBufferSize.Location = new System.Drawing.Point(6, 19);
            this._groupBoxBufferSize.Name = "_groupBoxBufferSize";
            this._groupBoxBufferSize.Size = new System.Drawing.Size(529, 152);
            this._groupBoxBufferSize.TabIndex = 0;
            this._groupBoxBufferSize.TabStop = false;
            this._groupBoxBufferSize.Text = "Buffer size setting *Match the setting of the controller with this application";
            // 
            // _panelHeadType
            // 
            this._panelHeadType.Controls.Add(this._radioButtonLJVB);
            this._panelHeadType.Controls.Add(this._radioButtonLJX);
            this._panelHeadType.Controls.Add(this._radioButtonLJV);
            this._panelHeadType.Location = new System.Drawing.Point(5, 14);
            this._panelHeadType.Name = "_panelHeadType";
            this._panelHeadType.Size = new System.Drawing.Size(441, 18);
            this._panelHeadType.TabIndex = 0;
            // 
            // _radioButtonLJVB
            // 
            this._radioButtonLJVB.AutoSize = true;
            this._radioButtonLJVB.Location = new System.Drawing.Point(276, 1);
            this._radioButtonLJVB.Name = "_radioButtonLJVB";
            this._radioButtonLJVB.Size = new System.Drawing.Size(48, 16);
            this._radioButtonLJVB.TabIndex = 2;
            this._radioButtonLJVB.Text = "LJ-VB";
            this._radioButtonLJVB.UseVisualStyleBackColor = true;
            this._radioButtonLJVB.CheckedChanged += new System.EventHandler(this._radioButtonLJHead_CheckedChanged);
            // 
            // _radioButtonLJX
            // 
            this._radioButtonLJX.AutoSize = true;
            this._radioButtonLJX.Checked = true;
            this._radioButtonLJX.Location = new System.Drawing.Point(12, 1);
            this._radioButtonLJX.Name = "_radioButtonLJX";
            this._radioButtonLJX.Size = new System.Drawing.Size(42, 16);
            this._radioButtonLJX.TabIndex = 0;
            this._radioButtonLJX.TabStop = true;
            this._radioButtonLJX.Text = "LJ-X";
            this._radioButtonLJX.UseVisualStyleBackColor = true;
            this._radioButtonLJX.CheckedChanged += new System.EventHandler(this._radioButtonLJHead_CheckedChanged);
            // 
            // _radioButtonLJV
            // 
            this._radioButtonLJV.AutoSize = true;
            this._radioButtonLJV.Location = new System.Drawing.Point(228, 1);
            this._radioButtonLJV.Name = "_radioButtonLJV";
            this._radioButtonLJV.Size = new System.Drawing.Size(42, 16);
            this._radioButtonLJV.TabIndex = 1;
            this._radioButtonLJV.Text = "LJ-V";
            this._radioButtonLJV.UseVisualStyleBackColor = true;
            this._radioButtonLJV.CheckedChanged += new System.EventHandler(this._radioButtonLJHead_CheckedChanged);
            // 
            // _groupBoxBufferSizeResult
            // 
            this._groupBoxBufferSizeResult.Controls.Add(this._labelBufferSizeValue);
            this._groupBoxBufferSizeResult.Controls.Add(this._labelOneProfileByteSize);
            this._groupBoxBufferSizeResult.Location = new System.Drawing.Point(360, 107);
            this._groupBoxBufferSizeResult.Name = "_groupBoxBufferSizeResult";
            this._groupBoxBufferSizeResult.Size = new System.Drawing.Size(167, 42);
            this._groupBoxBufferSizeResult.TabIndex = 2;
            this._groupBoxBufferSizeResult.TabStop = false;
            this._groupBoxBufferSizeResult.Text = "Buffer size to be secured";
            // 
            // _labelBufferSizeValue
            // 
            this._labelBufferSizeValue.Font = new System.Drawing.Font("Tahoma", 7.5F, System.Drawing.FontStyle.Bold);
            this._labelBufferSizeValue.Location = new System.Drawing.Point(18, 18);
            this._labelBufferSizeValue.Name = "_labelBufferSizeValue";
            this._labelBufferSizeValue.Size = new System.Drawing.Size(50, 16);
            this._labelBufferSizeValue.TabIndex = 0;
            this._labelBufferSizeValue.Text = "25628";
            this._labelBufferSizeValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labelOneProfileByteSize
            // 
            this._labelOneProfileByteSize.AutoSize = true;
            this._labelOneProfileByteSize.Location = new System.Drawing.Point(71, 20);
            this._labelOneProfileByteSize.Name = "_labelOneProfileByteSize";
            this._labelOneProfileByteSize.Size = new System.Drawing.Size(74, 12);
            this._labelOneProfileByteSize.TabIndex = 1;
            this._labelOneProfileByteSize.Text = "byte per profile";
            // 
            // _panelLjxSetting
            // 
            this._panelLjxSetting.Controls.Add(this._comboBoxLjxMeasureX);
            this._panelLjxSetting.Controls.Add(this._labelLjxMeasureX);
            this._panelLjxSetting.Controls.Add(this._comboBoxLjxThinningX);
            this._panelLjxSetting.Controls.Add(this._labelLjxThinningX);
            this._panelLjxSetting.Controls.Add(this._comboBoxLjxLuminanceOutput);
            this._panelLjxSetting.Controls.Add(this._labelLjxLuminanceOutput);
            this._panelLjxSetting.Controls.Add(this._comboBoxLjxSamplingPeriod);
            this._panelLjxSetting.Controls.Add(this._labelLjxSamplingPeriodNote);
            this._panelLjxSetting.Controls.Add(this._labelLjxSampling);
            this._panelLjxSetting.Location = new System.Drawing.Point(5, 33);
            this._panelLjxSetting.Name = "_panelLjxSetting";
            this._panelLjxSetting.Size = new System.Drawing.Size(214, 116);
            this._panelLjxSetting.TabIndex = 1;
            // 
            // _comboBoxLjxMeasureX
            // 
            this._comboBoxLjxMeasureX.DisplayMember = "Key";
            this._comboBoxLjxMeasureX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxLjxMeasureX.FormattingEnabled = true;
            this._comboBoxLjxMeasureX.Location = new System.Drawing.Point(139, 0);
            this._comboBoxLjxMeasureX.Name = "_comboBoxLjxMeasureX";
            this._comboBoxLjxMeasureX.Size = new System.Drawing.Size(70, 20);
            this._comboBoxLjxMeasureX.TabIndex = 1;
            this._comboBoxLjxMeasureX.ValueMember = "Value";
            // 
            // _labelLjxMeasureX
            // 
            this._labelLjxMeasureX.AutoSize = true;
            this._labelLjxMeasureX.Location = new System.Drawing.Point(5, 4);
            this._labelLjxMeasureX.Name = "_labelLjxMeasureX";
            this._labelLjxMeasureX.Size = new System.Drawing.Size(129, 12);
            this._labelLjxMeasureX.TabIndex = 0;
            this._labelLjxMeasureX.Text = "Measurement range (X axis)";
            // 
            // _comboBoxLjxThinningX
            // 
            this._comboBoxLjxThinningX.DisplayMember = "Key";
            this._comboBoxLjxThinningX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxLjxThinningX.FormattingEnabled = true;
            this._comboBoxLjxThinningX.Location = new System.Drawing.Point(139, 24);
            this._comboBoxLjxThinningX.Name = "_comboBoxLjxThinningX";
            this._comboBoxLjxThinningX.Size = new System.Drawing.Size(70, 20);
            this._comboBoxLjxThinningX.TabIndex = 3;
            this._comboBoxLjxThinningX.ValueMember = "Value";
            // 
            // _labelLjxThinningX
            // 
            this._labelLjxThinningX.AutoSize = true;
            this._labelLjxThinningX.Location = new System.Drawing.Point(5, 28);
            this._labelLjxThinningX.Name = "_labelLjxThinningX";
            this._labelLjxThinningX.Size = new System.Drawing.Size(81, 12);
            this._labelLjxThinningX.TabIndex = 2;
            this._labelLjxThinningX.Text = "Thinning (X axis)";
            // 
            // _comboBoxLjxLuminanceOutput
            // 
            this._comboBoxLjxLuminanceOutput.DisplayMember = "Key";
            this._comboBoxLjxLuminanceOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxLjxLuminanceOutput.FormattingEnabled = true;
            this._comboBoxLjxLuminanceOutput.Location = new System.Drawing.Point(139, 48);
            this._comboBoxLjxLuminanceOutput.Name = "_comboBoxLjxLuminanceOutput";
            this._comboBoxLjxLuminanceOutput.Size = new System.Drawing.Size(70, 20);
            this._comboBoxLjxLuminanceOutput.TabIndex = 5;
            this._comboBoxLjxLuminanceOutput.ValueMember = "Value";
            // 
            // _labelLjxLuminanceOutput
            // 
            this._labelLjxLuminanceOutput.AutoSize = true;
            this._labelLjxLuminanceOutput.Location = new System.Drawing.Point(5, 52);
            this._labelLjxLuminanceOutput.Name = "_labelLjxLuminanceOutput";
            this._labelLjxLuminanceOutput.Size = new System.Drawing.Size(86, 12);
            this._labelLjxLuminanceOutput.TabIndex = 4;
            this._labelLjxLuminanceOutput.Text = "Luminance output";
            // 
            // _comboBoxLjxSamplingPeriod
            // 
            this._comboBoxLjxSamplingPeriod.DisplayMember = "Key";
            this._comboBoxLjxSamplingPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxLjxSamplingPeriod.FormattingEnabled = true;
            this._comboBoxLjxSamplingPeriod.Location = new System.Drawing.Point(139, 72);
            this._comboBoxLjxSamplingPeriod.Name = "_comboBoxLjxSamplingPeriod";
            this._comboBoxLjxSamplingPeriod.Size = new System.Drawing.Size(70, 20);
            this._comboBoxLjxSamplingPeriod.TabIndex = 7;
            this._comboBoxLjxSamplingPeriod.ValueMember = "Value";
            // 
            // _labelLjxSamplingPeriodNote
            // 
            this._labelLjxSamplingPeriodNote.AutoSize = true;
            this._labelLjxSamplingPeriodNote.Location = new System.Drawing.Point(26, 94);
            this._labelLjxSamplingPeriodNote.Name = "_labelLjxSamplingPeriodNote";
            this._labelLjxSamplingPeriodNote.Size = new System.Drawing.Size(184, 12);
            this._labelLjxSamplingPeriodNote.TabIndex = 8;
            this._labelLjxSamplingPeriodNote.Text = "*Sampling period affects binning setting";
            // 
            // _labelLjxSampling
            // 
            this._labelLjxSampling.AutoSize = true;
            this._labelLjxSampling.Location = new System.Drawing.Point(5, 76);
            this._labelLjxSampling.Name = "_labelLjxSampling";
            this._labelLjxSampling.Size = new System.Drawing.Size(78, 12);
            this._labelLjxSampling.TabIndex = 6;
            this._labelLjxSampling.Text = "Sampling period";
            // 
            // _panelLjvSetting
            // 
            this._panelLjvSetting.Controls.Add(this._comboBoxLjvMeasureX);
            this._panelLjvSetting.Controls.Add(this._comboBoxLjvThinningX);
            this._panelLjvSetting.Controls.Add(this._comboBoxLjvBinning);
            this._panelLjvSetting.Controls.Add(this._labelLjvMeasureX);
            this._panelLjvSetting.Controls.Add(this._labelLjvThinningX);
            this._panelLjvSetting.Controls.Add(this._labelLjvBinning);
            this._panelLjvSetting.Location = new System.Drawing.Point(222, 33);
            this._panelLjvSetting.Name = "_panelLjvSetting";
            this._panelLjvSetting.Size = new System.Drawing.Size(224, 75);
            this._panelLjvSetting.TabIndex = 5;
            // 
            // _comboBoxLjvMeasureX
            // 
            this._comboBoxLjvMeasureX.DisplayMember = "Key";
            this._comboBoxLjvMeasureX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxLjvMeasureX.FormattingEnabled = true;
            this._comboBoxLjvMeasureX.Location = new System.Drawing.Point(141, 0);
            this._comboBoxLjvMeasureX.Name = "_comboBoxLjvMeasureX";
            this._comboBoxLjvMeasureX.Size = new System.Drawing.Size(70, 20);
            this._comboBoxLjvMeasureX.TabIndex = 1;
            this._comboBoxLjvMeasureX.ValueMember = "Value";
            // 
            // _comboBoxLjvThinningX
            // 
            this._comboBoxLjvThinningX.DisplayMember = "Key";
            this._comboBoxLjvThinningX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxLjvThinningX.FormattingEnabled = true;
            this._comboBoxLjvThinningX.Location = new System.Drawing.Point(141, 24);
            this._comboBoxLjvThinningX.Name = "_comboBoxLjvThinningX";
            this._comboBoxLjvThinningX.Size = new System.Drawing.Size(70, 20);
            this._comboBoxLjvThinningX.TabIndex = 3;
            this._comboBoxLjvThinningX.ValueMember = "Value";
            // 
            // _comboBoxLjvBinning
            // 
            this._comboBoxLjvBinning.DisplayMember = "Key";
            this._comboBoxLjvBinning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxLjvBinning.FormattingEnabled = true;
            this._comboBoxLjvBinning.Location = new System.Drawing.Point(141, 48);
            this._comboBoxLjvBinning.Name = "_comboBoxLjvBinning";
            this._comboBoxLjvBinning.Size = new System.Drawing.Size(70, 20);
            this._comboBoxLjvBinning.TabIndex = 5;
            this._comboBoxLjvBinning.ValueMember = "Value";
            // 
            // _labelLjvMeasureX
            // 
            this._labelLjvMeasureX.AutoSize = true;
            this._labelLjvMeasureX.Location = new System.Drawing.Point(5, 4);
            this._labelLjvMeasureX.Name = "_labelLjvMeasureX";
            this._labelLjvMeasureX.Size = new System.Drawing.Size(129, 12);
            this._labelLjvMeasureX.TabIndex = 0;
            this._labelLjvMeasureX.Text = "Measurement range (X axis)";
            // 
            // _labelLjvThinningX
            // 
            this._labelLjvThinningX.AutoSize = true;
            this._labelLjvThinningX.Location = new System.Drawing.Point(5, 28);
            this._labelLjvThinningX.Name = "_labelLjvThinningX";
            this._labelLjvThinningX.Size = new System.Drawing.Size(81, 12);
            this._labelLjvThinningX.TabIndex = 2;
            this._labelLjvThinningX.Text = "Thinning (X axis)";
            // 
            // _labelLjvBinning
            // 
            this._labelLjvBinning.AutoSize = true;
            this._labelLjvBinning.Location = new System.Drawing.Point(5, 52);
            this._labelLjvBinning.Name = "_labelLjvBinning";
            this._labelLjvBinning.Size = new System.Drawing.Size(39, 12);
            this._labelLjvBinning.TabIndex = 4;
            this._labelLjvBinning.Text = "Binning";
            // 
            // _profileFileSave
            // 
            this._profileFileSave.Filter = "Profile (*.csv)|*.csv";
            this._profileFileSave.OverwritePrompt = false;
            // 
            // _timerHighSpeedReceive
            // 
            this._timerHighSpeedReceive.Interval = 500;
            this._timerHighSpeedReceive.Tick += new System.EventHandler(this._timerHighSpeedReceive_Tick);
            // 
            // _labelReceiveProfileCount0
            // 
            this._labelReceiveProfileCount0.AutoSize = true;
            this._labelReceiveProfileCount0.BackColor = System.Drawing.Color.Transparent;
            this._labelReceiveProfileCount0.Location = new System.Drawing.Point(3, 23);
            this._labelReceiveProfileCount0.Name = "_labelReceiveProfileCount0";
            this._labelReceiveProfileCount0.Size = new System.Drawing.Size(10, 12);
            this._labelReceiveProfileCount0.TabIndex = 1;
            this._labelReceiveProfileCount0.Text = "0";
            // 
            // _radioButtonDevice0
            // 
            this._radioButtonDevice0.AutoSize = true;
            this._radioButtonDevice0.Checked = true;
            this._radioButtonDevice0.Location = new System.Drawing.Point(8, 25);
            this._radioButtonDevice0.Name = "_radioButtonDevice0";
            this._radioButtonDevice0.Size = new System.Drawing.Size(28, 16);
            this._radioButtonDevice0.TabIndex = 2;
            this._radioButtonDevice0.TabStop = true;
            this._radioButtonDevice0.Tag = "0";
            this._radioButtonDevice0.Text = "&0";
            this._radioButtonDevice0.UseVisualStyleBackColor = true;
            this._radioButtonDevice0.CheckedChanged += new System.EventHandler(this._rdDevice_CheckedChanged);
            // 
            // _radioButtonDevice2
            // 
            this._radioButtonDevice2.AutoSize = true;
            this._radioButtonDevice2.Location = new System.Drawing.Point(8, 59);
            this._radioButtonDevice2.Name = "_radioButtonDevice2";
            this._radioButtonDevice2.Size = new System.Drawing.Size(28, 16);
            this._radioButtonDevice2.TabIndex = 6;
            this._radioButtonDevice2.Tag = "2";
            this._radioButtonDevice2.Text = "&2";
            this._radioButtonDevice2.UseVisualStyleBackColor = true;
            this._radioButtonDevice2.CheckedChanged += new System.EventHandler(this._rdDevice_CheckedChanged);
            // 
            // _radioButtonDevice1
            // 
            this._radioButtonDevice1.AutoSize = true;
            this._radioButtonDevice1.Location = new System.Drawing.Point(8, 42);
            this._radioButtonDevice1.Name = "_radioButtonDevice1";
            this._radioButtonDevice1.Size = new System.Drawing.Size(28, 16);
            this._radioButtonDevice1.TabIndex = 4;
            this._radioButtonDevice1.Tag = "1";
            this._radioButtonDevice1.Text = "&1";
            this._radioButtonDevice1.UseVisualStyleBackColor = true;
            this._radioButtonDevice1.CheckedChanged += new System.EventHandler(this._rdDevice_CheckedChanged);
            // 
            // _panelDeviceId
            // 
            this._panelDeviceId.BackColor = System.Drawing.Color.DarkGray;
            this._panelDeviceId.Controls.Add(this._labelDeviceStatus5);
            this._panelDeviceId.Controls.Add(this._labelDeviceStatus4);
            this._panelDeviceId.Controls.Add(this._radioButtonDevice5);
            this._panelDeviceId.Controls.Add(this._radioButtonDevice4);
            this._panelDeviceId.Controls.Add(this._panelNumberOfReceivedProfiles);
            this._panelDeviceId.Controls.Add(this._labelState);
            this._panelDeviceId.Controls.Add(this._labelId);
            this._panelDeviceId.Controls.Add(this._labelDeviceStatus3);
            this._panelDeviceId.Controls.Add(this._labelDeviceStatus2);
            this._panelDeviceId.Controls.Add(this._labelDeviceStatus1);
            this._panelDeviceId.Controls.Add(this._labelDeviceStatus0);
            this._panelDeviceId.Controls.Add(this._radioButtonDevice3);
            this._panelDeviceId.Controls.Add(this._radioButtonDevice2);
            this._panelDeviceId.Controls.Add(this._radioButtonDevice1);
            this._panelDeviceId.Controls.Add(this._radioButtonDevice0);
            this._panelDeviceId.Location = new System.Drawing.Point(116, 72);
            this._panelDeviceId.Name = "_panelDeviceId";
            this._panelDeviceId.Size = new System.Drawing.Size(271, 135);
            this._panelDeviceId.TabIndex = 4;
            this._panelDeviceId.Tag = "";
            // 
            // _labelDeviceStatus5
            // 
            this._labelDeviceStatus5.AutoSize = true;
            this._labelDeviceStatus5.Location = new System.Drawing.Point(47, 111);
            this._labelDeviceStatus5.Name = "_labelDeviceStatus5";
            this._labelDeviceStatus5.Size = new System.Drawing.Size(65, 12);
            this._labelDeviceStatus5.TabIndex = 13;
            this._labelDeviceStatus5.Text = "Unconnected";
            // 
            // _labelDeviceStatus4
            // 
            this._labelDeviceStatus4.AutoSize = true;
            this._labelDeviceStatus4.Location = new System.Drawing.Point(47, 95);
            this._labelDeviceStatus4.Name = "_labelDeviceStatus4";
            this._labelDeviceStatus4.Size = new System.Drawing.Size(65, 12);
            this._labelDeviceStatus4.TabIndex = 11;
            this._labelDeviceStatus4.Text = "Unconnected";
            // 
            // _radioButtonDevice5
            // 
            this._radioButtonDevice5.AutoSize = true;
            this._radioButtonDevice5.Location = new System.Drawing.Point(8, 107);
            this._radioButtonDevice5.Name = "_radioButtonDevice5";
            this._radioButtonDevice5.Size = new System.Drawing.Size(28, 16);
            this._radioButtonDevice5.TabIndex = 12;
            this._radioButtonDevice5.Tag = "5";
            this._radioButtonDevice5.Text = "&5";
            this._radioButtonDevice5.UseVisualStyleBackColor = true;
            this._radioButtonDevice5.CheckedChanged += new System.EventHandler(this._rdDevice_CheckedChanged);
            // 
            // _radioButtonDevice4
            // 
            this._radioButtonDevice4.AutoSize = true;
            this._radioButtonDevice4.Location = new System.Drawing.Point(8, 90);
            this._radioButtonDevice4.Name = "_radioButtonDevice4";
            this._radioButtonDevice4.Size = new System.Drawing.Size(28, 16);
            this._radioButtonDevice4.TabIndex = 10;
            this._radioButtonDevice4.Tag = "4";
            this._radioButtonDevice4.Text = "&4";
            this._radioButtonDevice4.UseVisualStyleBackColor = true;
            this._radioButtonDevice4.CheckedChanged += new System.EventHandler(this._rdDevice_CheckedChanged);
            // 
            // _panelNumberOfReceivedProfiles
            // 
            this._panelNumberOfReceivedProfiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._panelNumberOfReceivedProfiles.Controls.Add(this._labelReceiveProfileCount5);
            this._panelNumberOfReceivedProfiles.Controls.Add(this._labelReceiveProfileCount4);
            this._panelNumberOfReceivedProfiles.Controls.Add(this._labelReceiveProfileCount3);
            this._panelNumberOfReceivedProfiles.Controls.Add(this._labelNumberOfReceivedProfiles);
            this._panelNumberOfReceivedProfiles.Controls.Add(this._labelReceiveProfileCount0);
            this._panelNumberOfReceivedProfiles.Controls.Add(this._labelReceiveProfileCount1);
            this._panelNumberOfReceivedProfiles.Controls.Add(this._labelReceiveProfileCount2);
            this._panelNumberOfReceivedProfiles.Location = new System.Drawing.Point(195, 5);
            this._panelNumberOfReceivedProfiles.Name = "_panelNumberOfReceivedProfiles";
            this._panelNumberOfReceivedProfiles.Size = new System.Drawing.Size(73, 126);
            this._panelNumberOfReceivedProfiles.TabIndex = 59;
            // 
            // _labelReceiveProfileCount5
            // 
            this._labelReceiveProfileCount5.AutoSize = true;
            this._labelReceiveProfileCount5.BackColor = System.Drawing.Color.Transparent;
            this._labelReceiveProfileCount5.Location = new System.Drawing.Point(3, 106);
            this._labelReceiveProfileCount5.Name = "_labelReceiveProfileCount5";
            this._labelReceiveProfileCount5.Size = new System.Drawing.Size(10, 12);
            this._labelReceiveProfileCount5.TabIndex = 6;
            this._labelReceiveProfileCount5.Text = "0";
            // 
            // _labelReceiveProfileCount4
            // 
            this._labelReceiveProfileCount4.AutoSize = true;
            this._labelReceiveProfileCount4.BackColor = System.Drawing.Color.Transparent;
            this._labelReceiveProfileCount4.Location = new System.Drawing.Point(3, 89);
            this._labelReceiveProfileCount4.Name = "_labelReceiveProfileCount4";
            this._labelReceiveProfileCount4.Size = new System.Drawing.Size(10, 12);
            this._labelReceiveProfileCount4.TabIndex = 5;
            this._labelReceiveProfileCount4.Text = "0";
            // 
            // _labelReceiveProfileCount3
            // 
            this._labelReceiveProfileCount3.AutoSize = true;
            this._labelReceiveProfileCount3.BackColor = System.Drawing.Color.Transparent;
            this._labelReceiveProfileCount3.Location = new System.Drawing.Point(3, 71);
            this._labelReceiveProfileCount3.Name = "_labelReceiveProfileCount3";
            this._labelReceiveProfileCount3.Size = new System.Drawing.Size(10, 12);
            this._labelReceiveProfileCount3.TabIndex = 4;
            this._labelReceiveProfileCount3.Text = "0";
            // 
            // _labelNumberOfReceivedProfiles
            // 
            this._labelNumberOfReceivedProfiles.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelNumberOfReceivedProfiles.Location = new System.Drawing.Point(1, 1);
            this._labelNumberOfReceivedProfiles.Name = "_labelNumberOfReceivedProfiles";
            this._labelNumberOfReceivedProfiles.Size = new System.Drawing.Size(70, 13);
            this._labelNumberOfReceivedProfiles.TabIndex = 0;
            this._labelNumberOfReceivedProfiles.Text = "Received";
            // 
            // _labelReceiveProfileCount1
            // 
            this._labelReceiveProfileCount1.AutoSize = true;
            this._labelReceiveProfileCount1.BackColor = System.Drawing.Color.Transparent;
            this._labelReceiveProfileCount1.Location = new System.Drawing.Point(3, 40);
            this._labelReceiveProfileCount1.Name = "_labelReceiveProfileCount1";
            this._labelReceiveProfileCount1.Size = new System.Drawing.Size(10, 12);
            this._labelReceiveProfileCount1.TabIndex = 2;
            this._labelReceiveProfileCount1.Text = "0";
            // 
            // _labelReceiveProfileCount2
            // 
            this._labelReceiveProfileCount2.AutoSize = true;
            this._labelReceiveProfileCount2.BackColor = System.Drawing.Color.Transparent;
            this._labelReceiveProfileCount2.Location = new System.Drawing.Point(3, 57);
            this._labelReceiveProfileCount2.Name = "_labelReceiveProfileCount2";
            this._labelReceiveProfileCount2.Size = new System.Drawing.Size(10, 12);
            this._labelReceiveProfileCount2.TabIndex = 3;
            this._labelReceiveProfileCount2.Text = "0";
            // 
            // _labelState
            // 
            this._labelState.AutoSize = true;
            this._labelState.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelState.Location = new System.Drawing.Point(42, 5);
            this._labelState.Name = "_labelState";
            this._labelState.Size = new System.Drawing.Size(111, 13);
            this._labelState.TabIndex = 1;
            this._labelState.Text = "State (IP address)";
            // 
            // _labelId
            // 
            this._labelId.AutoSize = true;
            this._labelId.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelId.Location = new System.Drawing.Point(19, 5);
            this._labelId.Name = "_labelId";
            this._labelId.Size = new System.Drawing.Size(20, 13);
            this._labelId.TabIndex = 0;
            this._labelId.Text = "ID";
            // 
            // _labelDeviceStatus3
            // 
            this._labelDeviceStatus3.AutoSize = true;
            this._labelDeviceStatus3.Location = new System.Drawing.Point(47, 77);
            this._labelDeviceStatus3.Name = "_labelDeviceStatus3";
            this._labelDeviceStatus3.Size = new System.Drawing.Size(65, 12);
            this._labelDeviceStatus3.TabIndex = 9;
            this._labelDeviceStatus3.Text = "Unconnected";
            // 
            // _labelDeviceStatus2
            // 
            this._labelDeviceStatus2.AutoSize = true;
            this._labelDeviceStatus2.Location = new System.Drawing.Point(47, 59);
            this._labelDeviceStatus2.Name = "_labelDeviceStatus2";
            this._labelDeviceStatus2.Size = new System.Drawing.Size(65, 12);
            this._labelDeviceStatus2.TabIndex = 7;
            this._labelDeviceStatus2.Text = "Unconnected";
            // 
            // _labelDeviceStatus1
            // 
            this._labelDeviceStatus1.AutoSize = true;
            this._labelDeviceStatus1.Location = new System.Drawing.Point(47, 44);
            this._labelDeviceStatus1.Name = "_labelDeviceStatus1";
            this._labelDeviceStatus1.Size = new System.Drawing.Size(65, 12);
            this._labelDeviceStatus1.TabIndex = 5;
            this._labelDeviceStatus1.Text = "Unconnected";
            // 
            // _labelDeviceStatus0
            // 
            this._labelDeviceStatus0.AutoSize = true;
            this._labelDeviceStatus0.Location = new System.Drawing.Point(47, 28);
            this._labelDeviceStatus0.Name = "_labelDeviceStatus0";
            this._labelDeviceStatus0.Size = new System.Drawing.Size(65, 12);
            this._labelDeviceStatus0.TabIndex = 3;
            this._labelDeviceStatus0.Text = "Unconnected";
            // 
            // _radioButtonDevice3
            // 
            this._radioButtonDevice3.AutoSize = true;
            this._radioButtonDevice3.Location = new System.Drawing.Point(8, 73);
            this._radioButtonDevice3.Name = "_radioButtonDevice3";
            this._radioButtonDevice3.Size = new System.Drawing.Size(28, 16);
            this._radioButtonDevice3.TabIndex = 8;
            this._radioButtonDevice3.Tag = "3";
            this._radioButtonDevice3.Text = "&3";
            this._radioButtonDevice3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this._radioButtonDevice3.UseVisualStyleBackColor = true;
            this._radioButtonDevice3.CheckedChanged += new System.EventHandler(this._rdDevice_CheckedChanged);
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._tabSimpleFunctionSample);
            this._tabControl.Controls.Add(this._tabCombinationSample);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.Location = new System.Drawing.Point(0, 0);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(1008, 729);
            this._tabControl.TabIndex = 0;
            // 
            // _tabSimpleFunctionSample
            // 
            this._tabSimpleFunctionSample.BackColor = System.Drawing.Color.Linen;
            this._tabSimpleFunctionSample.Controls.Add(this._groupBoxReadingProfiles);
            this._tabSimpleFunctionSample.Controls.Add(this._groupBoxSettingResult);
            this._tabSimpleFunctionSample.Controls.Add(this._groupBoxCommand);
            this._tabSimpleFunctionSample.Location = new System.Drawing.Point(4, 21);
            this._tabSimpleFunctionSample.Name = "_tabSimpleFunctionSample";
            this._tabSimpleFunctionSample.Padding = new System.Windows.Forms.Padding(3);
            this._tabSimpleFunctionSample.Size = new System.Drawing.Size(1000, 704);
            this._tabSimpleFunctionSample.TabIndex = 0;
            this._tabSimpleFunctionSample.Text = "[DLL functions] Simple function sample";
            // 
            // _groupBoxReadingProfiles
            // 
            this._groupBoxReadingProfiles.Controls.Add(this._groupBoxGetDataSimpleArray);
            this._groupBoxReadingProfiles.Controls.Add(this._groupBoxGetMeasurementResult);
            this._groupBoxReadingProfiles.Controls.Add(this._groupBoxBufferSize);
            this._groupBoxReadingProfiles.Controls.Add(this._groupBoxHighSpeedData);
            this._groupBoxReadingProfiles.Location = new System.Drawing.Point(455, 219);
            this._groupBoxReadingProfiles.Name = "_groupBoxReadingProfiles";
            this._groupBoxReadingProfiles.Size = new System.Drawing.Size(539, 482);
            this._groupBoxReadingProfiles.TabIndex = 2;
            this._groupBoxReadingProfiles.TabStop = false;
            this._groupBoxReadingProfiles.Text = "Communication command (reading profiles)";
            // 
            // _groupBoxGetDataSimpleArray
            // 
            this._groupBoxGetDataSimpleArray.Controls.Add(this._buttonSaveAsBitmapFile);
            this._groupBoxGetDataSimpleArray.Controls.Add(this._buttonGetBatchSimpleArray);
            this._groupBoxGetDataSimpleArray.Location = new System.Drawing.Point(6, 222);
            this._groupBoxGetDataSimpleArray.Name = "_groupBoxGetDataSimpleArray";
            this._groupBoxGetDataSimpleArray.Size = new System.Drawing.Size(529, 48);
            this._groupBoxGetDataSimpleArray.TabIndex = 2;
            this._groupBoxGetDataSimpleArray.TabStop = false;
            this._groupBoxGetDataSimpleArray.Text = "Get measurement results (Simple array method)";
            // 
            // _buttonSaveAsBitmapFile
            // 
            this._buttonSaveAsBitmapFile.Location = new System.Drawing.Point(398, 19);
            this._buttonSaveAsBitmapFile.Name = "_buttonSaveAsBitmapFile";
            this._buttonSaveAsBitmapFile.Size = new System.Drawing.Size(127, 23);
            this._buttonSaveAsBitmapFile.TabIndex = 1;
            this._buttonSaveAsBitmapFile.Text = "Save As Image File";
            this._buttonSaveAsBitmapFile.UseVisualStyleBackColor = true;
            this._buttonSaveAsBitmapFile.Click += new System.EventHandler(this._buttonSaveAsBitmapFile_Click);
            // 
            // _buttonGetBatchSimpleArray
            // 
            this._buttonGetBatchSimpleArray.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._buttonGetBatchSimpleArray.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonGetBatchSimpleArray.Location = new System.Drawing.Point(148, 19);
            this._buttonGetBatchSimpleArray.Name = "_buttonGetBatchSimpleArray";
            this._buttonGetBatchSimpleArray.Size = new System.Drawing.Size(136, 23);
            this._buttonGetBatchSimpleArray.TabIndex = 0;
            this._buttonGetBatchSimpleArray.Text = "GetBatchSimpleArray";
            this._buttonGetBatchSimpleArray.UseVisualStyleBackColor = false;
            this._buttonGetBatchSimpleArray.Click += new System.EventHandler(this._buttonGetBatchSimpleArray_Click);
            // 
            // _groupBoxSettingResult
            // 
            this._groupBoxSettingResult.Controls.Add(this._buttonCommClose);
            this._groupBoxSettingResult.Controls.Add(this._labelConectedDevice);
            this._groupBoxSettingResult.Controls.Add(this._buttonEthernetOpen);
            this._groupBoxSettingResult.Controls.Add(this._groupBoxLog);
            this._groupBoxSettingResult.Controls.Add(this._groupBoxOperations);
            this._groupBoxSettingResult.Controls.Add(this._panelDeviceId);
            this._groupBoxSettingResult.Location = new System.Drawing.Point(3, 2);
            this._groupBoxSettingResult.Name = "_groupBoxSettingResult";
            this._groupBoxSettingResult.Size = new System.Drawing.Size(991, 215);
            this._groupBoxSettingResult.TabIndex = 0;
            this._groupBoxSettingResult.TabStop = false;
            this._groupBoxSettingResult.Text = "Connection / Result";
            // 
            // _labelConectedDevice
            // 
            this._labelConectedDevice.AutoSize = true;
            this._labelConectedDevice.Location = new System.Drawing.Point(114, 57);
            this._labelConectedDevice.Name = "_labelConectedDevice";
            this._labelConectedDevice.Size = new System.Drawing.Size(131, 12);
            this._labelConectedDevice.TabIndex = 3;
            this._labelConectedDevice.Text = "Controller connection status";
            // 
            // _tabCombinationSample
            // 
            this._tabCombinationSample.BackColor = System.Drawing.Color.AliceBlue;
            this._tabCombinationSample.Controls.Add(this._groupBoxProgram);
            this._tabCombinationSample.Controls.Add(this._groupBoxHighSpeed);
            this._tabCombinationSample.Controls.Add(this._groupBoxGetData);
            this._tabCombinationSample.Controls.Add(this._groupBoxBaseOperation);
            this._tabCombinationSample.Location = new System.Drawing.Point(4, 21);
            this._tabCombinationSample.Name = "_tabCombinationSample";
            this._tabCombinationSample.Padding = new System.Windows.Forms.Padding(3);
            this._tabCombinationSample.Size = new System.Drawing.Size(1000, 704);
            this._tabCombinationSample.TabIndex = 1;
            this._tabCombinationSample.Text = "[DLL functions] Combination function sample";
            // 
            // _groupBoxProgram
            // 
            this._groupBoxProgram.Controls.Add(this._buttonUploadProgram);
            this._groupBoxProgram.Controls.Add(this._buttonDownloadProgram);
            this._groupBoxProgram.Controls.Add(this._labelSelectProgram);
            this._groupBoxProgram.Controls.Add(this._comboBoxSelectProgram);
            this._groupBoxProgram.Location = new System.Drawing.Point(28, 194);
            this._groupBoxProgram.Name = "_groupBoxProgram";
            this._groupBoxProgram.Size = new System.Drawing.Size(441, 114);
            this._groupBoxProgram.TabIndex = 1;
            this._groupBoxProgram.TabStop = false;
            this._groupBoxProgram.Text = "Sending or receiving settings for each program number";
            // 
            // _buttonUploadProgram
            // 
            this._buttonUploadProgram.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._buttonUploadProgram.Location = new System.Drawing.Point(19, 59);
            this._buttonUploadProgram.Name = "_buttonUploadProgram";
            this._buttonUploadProgram.Size = new System.Drawing.Size(189, 23);
            this._buttonUploadProgram.TabIndex = 2;
            this._buttonUploadProgram.Text = "Sending settings (PC -> LJ)";
            this._buttonUploadProgram.UseVisualStyleBackColor = true;
            this._buttonUploadProgram.Click += new System.EventHandler(this._buttonSetSettingEx_Click);
            // 
            // _buttonDownloadProgram
            // 
            this._buttonDownloadProgram.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._buttonDownloadProgram.Location = new System.Drawing.Point(218, 59);
            this._buttonDownloadProgram.Name = "_buttonDownloadProgram";
            this._buttonDownloadProgram.Size = new System.Drawing.Size(189, 23);
            this._buttonDownloadProgram.TabIndex = 3;
            this._buttonDownloadProgram.Text = "Receiving settings (LJ -> PC)";
            this._buttonDownloadProgram.UseVisualStyleBackColor = true;
            this._buttonDownloadProgram.Click += new System.EventHandler(this._buttonGetSettingEx_Click);
            // 
            // _labelSelectProgram
            // 
            this._labelSelectProgram.AutoSize = true;
            this._labelSelectProgram.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._labelSelectProgram.Location = new System.Drawing.Point(17, 30);
            this._labelSelectProgram.Name = "_labelSelectProgram";
            this._labelSelectProgram.Size = new System.Drawing.Size(90, 12);
            this._labelSelectProgram.TabIndex = 0;
            this._labelSelectProgram.Text = "Select the program";
            // 
            // _comboBoxSelectProgram
            // 
            this._comboBoxSelectProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxSelectProgram.FormattingEnabled = true;
            this._comboBoxSelectProgram.Items.AddRange(new object[] {
            "Environment",
            "Common",
            "Program0",
            "Program1",
            "Program2",
            "Program3",
            "Program4",
            "Program5",
            "Program6",
            "Program7",
            "Program8",
            "Program9",
            "Program10",
            "Program11",
            "Program12",
            "Program13",
            "Program14",
            "Program15"});
            this._comboBoxSelectProgram.Location = new System.Drawing.Point(130, 29);
            this._comboBoxSelectProgram.Name = "_comboBoxSelectProgram";
            this._comboBoxSelectProgram.Size = new System.Drawing.Size(101, 20);
            this._comboBoxSelectProgram.TabIndex = 1;
            // 
            // _groupBoxHighSpeed
            // 
            this._groupBoxHighSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._groupBoxHighSpeed.Controls.Add(this._textBoxCallbackFrequency);
            this._groupBoxHighSpeed.Controls.Add(this._textBoxStartProfileNo);
            this._groupBoxHighSpeed.Controls.Add(this._labelReceiveProfileCount);
            this._groupBoxHighSpeed.Controls.Add(this._labelCallbackFrequency);
            this._groupBoxHighSpeed.Controls.Add(this._buttonTerminateHighSpeedCommunication);
            this._groupBoxHighSpeed.Controls.Add(this._labelHighSpeedStartNo);
            this._groupBoxHighSpeed.Controls.Add(this._labelReceiveCount);
            this._groupBoxHighSpeed.Controls.Add(this._buttonBeginHighSpeedDataCommunication);
            this._groupBoxHighSpeed.Location = new System.Drawing.Point(485, 195);
            this._groupBoxHighSpeed.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._groupBoxHighSpeed.Name = "_groupBoxHighSpeed";
            this._groupBoxHighSpeed.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._groupBoxHighSpeed.Size = new System.Drawing.Size(440, 113);
            this._groupBoxHighSpeed.TabIndex = 3;
            this._groupBoxHighSpeed.TabStop = false;
            this._groupBoxHighSpeed.Text = "High-speed data communication";
            // 
            // _textBoxCallbackFrequency
            // 
            this._textBoxCallbackFrequency.Location = new System.Drawing.Point(338, 50);
            this._textBoxCallbackFrequency.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._textBoxCallbackFrequency.Name = "_textBoxCallbackFrequency";
            this._textBoxCallbackFrequency.Size = new System.Drawing.Size(45, 20);
            this._textBoxCallbackFrequency.TabIndex = 5;
            this._textBoxCallbackFrequency.Text = "10";
            // 
            // _textBoxStartProfileNo
            // 
            this._textBoxStartProfileNo.Location = new System.Drawing.Point(338, 23);
            this._textBoxStartProfileNo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._textBoxStartProfileNo.Name = "_textBoxStartProfileNo";
            this._textBoxStartProfileNo.Size = new System.Drawing.Size(45, 20);
            this._textBoxStartProfileNo.TabIndex = 2;
            this._textBoxStartProfileNo.Text = "2";
            // 
            // _labelReceiveProfileCount
            // 
            this._labelReceiveProfileCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._labelReceiveProfileCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._labelReceiveProfileCount.Location = new System.Drawing.Point(305, 79);
            this._labelReceiveProfileCount.Name = "_labelReceiveProfileCount";
            this._labelReceiveProfileCount.Size = new System.Drawing.Size(78, 17);
            this._labelReceiveProfileCount.TabIndex = 7;
            this._labelReceiveProfileCount.Text = "123456789";
            this._labelReceiveProfileCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _labelCallbackFrequency
            // 
            this._labelCallbackFrequency.AutoSize = true;
            this._labelCallbackFrequency.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._labelCallbackFrequency.Location = new System.Drawing.Point(107, 47);
            this._labelCallbackFrequency.Name = "_labelCallbackFrequency";
            this._labelCallbackFrequency.Size = new System.Drawing.Size(149, 12);
            this._labelCallbackFrequency.TabIndex = 4;
            this._labelCallbackFrequency.Text = "Callback function call frequency";
            // 
            // _buttonTerminateHighSpeedCommunication
            // 
            this._buttonTerminateHighSpeedCommunication.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._buttonTerminateHighSpeedCommunication.Location = new System.Drawing.Point(6, 50);
            this._buttonTerminateHighSpeedCommunication.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._buttonTerminateHighSpeedCommunication.Name = "_buttonTerminateHighSpeedCommunication";
            this._buttonTerminateHighSpeedCommunication.Size = new System.Drawing.Size(75, 23);
            this._buttonTerminateHighSpeedCommunication.TabIndex = 3;
            this._buttonTerminateHighSpeedCommunication.Text = "Finalize ";
            this._buttonTerminateHighSpeedCommunication.UseVisualStyleBackColor = true;
            this._buttonTerminateHighSpeedCommunication.Click += new System.EventHandler(this._buttonTerminateHighSpeedCommunication_Click);
            // 
            // _labelHighSpeedStartNo
            // 
            this._labelHighSpeedStartNo.AutoSize = true;
            this._labelHighSpeedStartNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._labelHighSpeedStartNo.Location = new System.Drawing.Point(107, 23);
            this._labelHighSpeedStartNo.Name = "_labelHighSpeedStartNo";
            this._labelHighSpeedStartNo.Size = new System.Drawing.Size(88, 12);
            this._labelHighSpeedStartNo.TabIndex = 1;
            this._labelHighSpeedStartNo.Text = "Send start position";
            // 
            // _labelReceiveCount
            // 
            this._labelReceiveCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._labelReceiveCount.Location = new System.Drawing.Point(107, 71);
            this._labelReceiveCount.Name = "_labelReceiveCount";
            this._labelReceiveCount.Size = new System.Drawing.Size(192, 25);
            this._labelReceiveCount.TabIndex = 6;
            this._labelReceiveCount.Text = "Number of received \r\nhigh-speed communication profiles";
            // 
            // _buttonBeginHighSpeedDataCommunication
            // 
            this._buttonBeginHighSpeedDataCommunication.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._buttonBeginHighSpeedDataCommunication.Location = new System.Drawing.Point(6, 18);
            this._buttonBeginHighSpeedDataCommunication.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._buttonBeginHighSpeedDataCommunication.Name = "_buttonBeginHighSpeedDataCommunication";
            this._buttonBeginHighSpeedDataCommunication.Size = new System.Drawing.Size(75, 23);
            this._buttonBeginHighSpeedDataCommunication.TabIndex = 0;
            this._buttonBeginHighSpeedDataCommunication.Text = "Start";
            this._buttonBeginHighSpeedDataCommunication.UseVisualStyleBackColor = true;
            this._buttonBeginHighSpeedDataCommunication.Click += new System.EventHandler(this._buttonBeginHighSpeedDataCommunication_Click);
            // 
            // _groupBoxGetData
            // 
            this._groupBoxGetData.Controls.Add(this._groupBoxGetProfile);
            this._groupBoxGetData.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this._groupBoxGetData.Location = new System.Drawing.Point(485, 6);
            this._groupBoxGetData.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._groupBoxGetData.Name = "_groupBoxGetData";
            this._groupBoxGetData.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._groupBoxGetData.Size = new System.Drawing.Size(441, 179);
            this._groupBoxGetData.TabIndex = 2;
            this._groupBoxGetData.TabStop = false;
            this._groupBoxGetData.Text = "Get measurement results";
            // 
            // _groupBoxGetProfile
            // 
            this._groupBoxGetProfile.Controls.Add(this._buttonReferenceSavePath);
            this._groupBoxGetProfile.Controls.Add(this._buttonGetBatchProfileData);
            this._groupBoxGetProfile.Controls.Add(this._buttonGetProfileData);
            this._groupBoxGetProfile.Controls.Add(this._textBoxSavePath);
            this._groupBoxGetProfile.Controls.Add(this._labelProfilesSavePath);
            this._groupBoxGetProfile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._groupBoxGetProfile.Location = new System.Drawing.Point(6, 18);
            this._groupBoxGetProfile.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._groupBoxGetProfile.Name = "_groupBoxGetProfile";
            this._groupBoxGetProfile.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._groupBoxGetProfile.Size = new System.Drawing.Size(427, 145);
            this._groupBoxGetProfile.TabIndex = 0;
            this._groupBoxGetProfile.TabStop = false;
            this._groupBoxGetProfile.Text = "Get profiles";
            // 
            // _buttonReferenceSavePath
            // 
            this._buttonReferenceSavePath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._buttonReferenceSavePath.Location = new System.Drawing.Point(391, 19);
            this._buttonReferenceSavePath.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._buttonReferenceSavePath.Name = "_buttonReferenceSavePath";
            this._buttonReferenceSavePath.Size = new System.Drawing.Size(30, 23);
            this._buttonReferenceSavePath.TabIndex = 2;
            this._buttonReferenceSavePath.Text = "...";
            this._buttonReferenceSavePath.UseVisualStyleBackColor = true;
            this._buttonReferenceSavePath.Click += new System.EventHandler(this._buttonReferenceSavePathEx_Click);
            // 
            // _buttonGetBatchProfileData
            // 
            this._buttonGetBatchProfileData.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this._buttonGetBatchProfileData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._buttonGetBatchProfileData.Location = new System.Drawing.Point(219, 48);
            this._buttonGetBatchProfileData.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._buttonGetBatchProfileData.Name = "_buttonGetBatchProfileData";
            this._buttonGetBatchProfileData.Size = new System.Drawing.Size(201, 23);
            this._buttonGetBatchProfileData.TabIndex = 4;
            this._buttonGetBatchProfileData.Text = "Get batch profiles";
            this._buttonGetBatchProfileData.UseVisualStyleBackColor = true;
            this._buttonGetBatchProfileData.Click += new System.EventHandler(this._buttonGetBatchProfileEx_Click);
            // 
            // _buttonGetProfileData
            // 
            this._buttonGetProfileData.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this._buttonGetProfileData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._buttonGetProfileData.Location = new System.Drawing.Point(6, 48);
            this._buttonGetProfileData.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._buttonGetProfileData.Name = "_buttonGetProfileData";
            this._buttonGetProfileData.Size = new System.Drawing.Size(201, 23);
            this._buttonGetProfileData.TabIndex = 3;
            this._buttonGetProfileData.Text = "Get profiles";
            this._buttonGetProfileData.UseVisualStyleBackColor = true;
            this._buttonGetProfileData.Click += new System.EventHandler(this._buttonGetProfileEx_Click);
            // 
            // _textBoxSavePath
            // 
            this._textBoxSavePath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._textBoxSavePath.Location = new System.Drawing.Point(103, 23);
            this._textBoxSavePath.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._textBoxSavePath.Name = "_textBoxSavePath";
            this._textBoxSavePath.Size = new System.Drawing.Size(283, 21);
            this._textBoxSavePath.TabIndex = 1;
            // 
            // _labelProfilesSavePath
            // 
            this._labelProfilesSavePath.AutoSize = true;
            this._labelProfilesSavePath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._labelProfilesSavePath.Location = new System.Drawing.Point(6, 27);
            this._labelProfilesSavePath.Name = "_labelProfilesSavePath";
            this._labelProfilesSavePath.Size = new System.Drawing.Size(56, 13);
            this._labelProfilesSavePath.TabIndex = 0;
            this._labelProfilesSavePath.Text = "Save path";
            // 
            // _groupBoxBaseOperation
            // 
            this._groupBoxBaseOperation.Controls.Add(this._panelCommunicationDevice);
            this._groupBoxBaseOperation.Controls.Add(this._buttonTerminateCommunication);
            this._groupBoxBaseOperation.Controls.Add(this._buttonEstablishCommunication);
            this._groupBoxBaseOperation.Location = new System.Drawing.Point(28, 6);
            this._groupBoxBaseOperation.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._groupBoxBaseOperation.Name = "_groupBoxBaseOperation";
            this._groupBoxBaseOperation.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._groupBoxBaseOperation.Size = new System.Drawing.Size(441, 179);
            this._groupBoxBaseOperation.TabIndex = 0;
            this._groupBoxBaseOperation.TabStop = false;
            this._groupBoxBaseOperation.Text = "Establish/disconnect the communication path with the controller";
            // 
            // _panelCommunicationDevice
            // 
            this._panelCommunicationDevice.Controls.Add(this._groupBoxEthernetSetting);
            this._panelCommunicationDevice.Location = new System.Drawing.Point(6, 49);
            this._panelCommunicationDevice.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._panelCommunicationDevice.Name = "_panelCommunicationDevice";
            this._panelCommunicationDevice.Size = new System.Drawing.Size(418, 120);
            this._panelCommunicationDevice.TabIndex = 2;
            // 
            // _groupBoxEthernetSetting
            // 
            this._groupBoxEthernetSetting.Controls.Add(this._textBoxIpFirstSegment);
            this._groupBoxEthernetSetting.Controls.Add(this._textBoxIpFourthSegment);
            this._groupBoxEthernetSetting.Controls.Add(this._textBoxIpSecondSegment);
            this._groupBoxEthernetSetting.Controls.Add(this._labelHighSpeedPort);
            this._groupBoxEthernetSetting.Controls.Add(this._textBoxIpThirdSegment);
            this._groupBoxEthernetSetting.Controls.Add(this._labelIpSeparator3);
            this._groupBoxEthernetSetting.Controls.Add(this._labelIpSeparator2);
            this._groupBoxEthernetSetting.Controls.Add(this._textBoxHighSpeedPort);
            this._groupBoxEthernetSetting.Controls.Add(this._labelIpSeparator1);
            this._groupBoxEthernetSetting.Controls.Add(this._textBoxCommandPort);
            this._groupBoxEthernetSetting.Controls.Add(this._labelIpAddress);
            this._groupBoxEthernetSetting.Controls.Add(this._labelCommandPort);
            this._groupBoxEthernetSetting.Location = new System.Drawing.Point(23, 11);
            this._groupBoxEthernetSetting.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._groupBoxEthernetSetting.Name = "_groupBoxEthernetSetting";
            this._groupBoxEthernetSetting.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._groupBoxEthernetSetting.Size = new System.Drawing.Size(374, 84);
            this._groupBoxEthernetSetting.TabIndex = 0;
            this._groupBoxEthernetSetting.TabStop = false;
            this._groupBoxEthernetSetting.Text = "Ethernet";
            // 
            // _textBoxIpFirstSegment
            // 
            this._textBoxIpFirstSegment.Location = new System.Drawing.Point(229, 11);
            this._textBoxIpFirstSegment.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._textBoxIpFirstSegment.Name = "_textBoxIpFirstSegment";
            this._textBoxIpFirstSegment.Size = new System.Drawing.Size(25, 20);
            this._textBoxIpFirstSegment.TabIndex = 1;
            this._textBoxIpFirstSegment.Text = "192";
            // 
            // _textBoxIpFourthSegment
            // 
            this._textBoxIpFourthSegment.Location = new System.Drawing.Point(328, 11);
            this._textBoxIpFourthSegment.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._textBoxIpFourthSegment.Name = "_textBoxIpFourthSegment";
            this._textBoxIpFourthSegment.Size = new System.Drawing.Size(25, 20);
            this._textBoxIpFourthSegment.TabIndex = 7;
            this._textBoxIpFourthSegment.Text = "1";
            // 
            // _textBoxIpSecondSegment
            // 
            this._textBoxIpSecondSegment.Location = new System.Drawing.Point(262, 11);
            this._textBoxIpSecondSegment.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._textBoxIpSecondSegment.Name = "_textBoxIpSecondSegment";
            this._textBoxIpSecondSegment.Size = new System.Drawing.Size(25, 20);
            this._textBoxIpSecondSegment.TabIndex = 3;
            this._textBoxIpSecondSegment.Text = "168";
            // 
            // _labelHighSpeedPort
            // 
            this._labelHighSpeedPort.AutoSize = true;
            this._labelHighSpeedPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._labelHighSpeedPort.Location = new System.Drawing.Point(15, 60);
            this._labelHighSpeedPort.Name = "_labelHighSpeedPort";
            this._labelHighSpeedPort.Size = new System.Drawing.Size(216, 12);
            this._labelHighSpeedPort.TabIndex = 10;
            this._labelHighSpeedPort.Text = "TCP port number (high-speed communication)";
            // 
            // _textBoxIpThirdSegment
            // 
            this._textBoxIpThirdSegment.Location = new System.Drawing.Point(295, 11);
            this._textBoxIpThirdSegment.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._textBoxIpThirdSegment.Name = "_textBoxIpThirdSegment";
            this._textBoxIpThirdSegment.Size = new System.Drawing.Size(25, 20);
            this._textBoxIpThirdSegment.TabIndex = 5;
            this._textBoxIpThirdSegment.Text = "0";
            // 
            // _labelIpSeparator3
            // 
            this._labelIpSeparator3.AutoSize = true;
            this._labelIpSeparator3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._labelIpSeparator3.Location = new System.Drawing.Point(320, 18);
            this._labelIpSeparator3.Name = "_labelIpSeparator3";
            this._labelIpSeparator3.Size = new System.Drawing.Size(8, 12);
            this._labelIpSeparator3.TabIndex = 6;
            this._labelIpSeparator3.Text = ".";
            // 
            // _labelIpSeparator2
            // 
            this._labelIpSeparator2.AutoSize = true;
            this._labelIpSeparator2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._labelIpSeparator2.Location = new System.Drawing.Point(288, 18);
            this._labelIpSeparator2.Name = "_labelIpSeparator2";
            this._labelIpSeparator2.Size = new System.Drawing.Size(8, 12);
            this._labelIpSeparator2.TabIndex = 4;
            this._labelIpSeparator2.Text = ".";
            // 
            // _textBoxHighSpeedPort
            // 
            this._textBoxHighSpeedPort.Location = new System.Drawing.Point(295, 56);
            this._textBoxHighSpeedPort.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._textBoxHighSpeedPort.Name = "_textBoxHighSpeedPort";
            this._textBoxHighSpeedPort.Size = new System.Drawing.Size(59, 20);
            this._textBoxHighSpeedPort.TabIndex = 11;
            this._textBoxHighSpeedPort.Text = "24692";
            // 
            // _labelIpSeparator1
            // 
            this._labelIpSeparator1.AutoSize = true;
            this._labelIpSeparator1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._labelIpSeparator1.Location = new System.Drawing.Point(254, 18);
            this._labelIpSeparator1.Name = "_labelIpSeparator1";
            this._labelIpSeparator1.Size = new System.Drawing.Size(8, 12);
            this._labelIpSeparator1.TabIndex = 2;
            this._labelIpSeparator1.Text = ".";
            // 
            // _textBoxCommandPort
            // 
            this._textBoxCommandPort.Location = new System.Drawing.Point(295, 36);
            this._textBoxCommandPort.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._textBoxCommandPort.Name = "_textBoxCommandPort";
            this._textBoxCommandPort.Size = new System.Drawing.Size(59, 20);
            this._textBoxCommandPort.TabIndex = 9;
            this._textBoxCommandPort.Text = "24691";
            // 
            // _labelIpAddress
            // 
            this._labelIpAddress.AutoSize = true;
            this._labelIpAddress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._labelIpAddress.Location = new System.Drawing.Point(15, 17);
            this._labelIpAddress.Name = "_labelIpAddress";
            this._labelIpAddress.Size = new System.Drawing.Size(52, 12);
            this._labelIpAddress.TabIndex = 0;
            this._labelIpAddress.Text = "IP address";
            // 
            // _labelCommandPort
            // 
            this._labelCommandPort.AutoSize = true;
            this._labelCommandPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._labelCommandPort.Location = new System.Drawing.Point(15, 39);
            this._labelCommandPort.Name = "_labelCommandPort";
            this._labelCommandPort.Size = new System.Drawing.Size(84, 12);
            this._labelCommandPort.TabIndex = 8;
            this._labelCommandPort.Text = "TCP port number";
            // 
            // _buttonTerminateCommunication
            // 
            this._buttonTerminateCommunication.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._buttonTerminateCommunication.Location = new System.Drawing.Point(207, 18);
            this._buttonTerminateCommunication.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._buttonTerminateCommunication.Name = "_buttonTerminateCommunication";
            this._buttonTerminateCommunication.Size = new System.Drawing.Size(196, 23);
            this._buttonTerminateCommunication.TabIndex = 1;
            this._buttonTerminateCommunication.Text = "Communication finalization";
            this._buttonTerminateCommunication.UseVisualStyleBackColor = true;
            this._buttonTerminateCommunication.Click += new System.EventHandler(this._buttonTerminateCommunicationEx_Click);
            // 
            // _buttonEstablishCommunication
            // 
            this._buttonEstablishCommunication.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._buttonEstablishCommunication.Location = new System.Drawing.Point(6, 18);
            this._buttonEstablishCommunication.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._buttonEstablishCommunication.Name = "_buttonEstablishCommunication";
            this._buttonEstablishCommunication.Size = new System.Drawing.Size(196, 23);
            this._buttonEstablishCommunication.TabIndex = 0;
            this._buttonEstablishCommunication.Text = "Communication establishment";
            this._buttonEstablishCommunication.UseVisualStyleBackColor = true;
            this._buttonEstablishCommunication.Click += new System.EventHandler(this._buttonEstablishCommunicationEx_Click);
            // 
            // _timerHighSpeed
            // 
            this._timerHighSpeed.Interval = 200;
            this._timerHighSpeed.Tick += new System.EventHandler(this._timerHighSpeed_Tick);
            // 
            // _timerBufferError
            // 
            this._timerBufferError.Enabled = true;
            this._timerBufferError.Interval = 500;
            this._timerBufferError.Tick += new System.EventHandler(this._timerBufferError_Tick);
            // 
            // _bitmapFileSave
            // 
            this._bitmapFileSave.Filter = "Bitmap (*.bmp)|*.bmp|TIFF (*.tif;*.tiff)|*.tif;*.tiff|all files (*.*)|*.*";
            this._bitmapFileSave.OverwritePrompt = false;
            // 
            // _profileOrBitmapFileSave
            // 
            this._profileOrBitmapFileSave.Filter = "Profile (*.csv)|*.csv|Bitmap (*.bmp)|*.bmp|TIFF (*.tif;*.tiff)|*.tif;*.tiff|all f" +
    "iles (*.*)|*.*";
            this._profileOrBitmapFileSave.OverwritePrompt = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this._tabControl);
            this.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "DLL Function Sample";
            this._groupBoxCommand.ResumeLayout(false);
            this._groupBoxSetting.ResumeLayout(false);
            this._groupBoxMeasurementControl.ResumeLayout(false);
            this._groupBoxSystemControl.ResumeLayout(false);
            this._groupBoxHighSpeedData.ResumeLayout(false);
            this._groupBoxHighSpeedData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownInterval)).EndInit();
            this._groupBoxHighSpeedExport.ResumeLayout(false);
            this._groupBoxHighSpeedExport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownProfileSaveCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownProfileNo)).EndInit();
            this._groupBoxGetMeasurementResult.ResumeLayout(false);
            this._groupBoxGetMeasurementResult.PerformLayout();
            this._groupBoxOperations.ResumeLayout(false);
            this._groupBoxLog.ResumeLayout(false);
            this._groupBoxLog.PerformLayout();
            this._groupBoxBufferSize.ResumeLayout(false);
            this._panelHeadType.ResumeLayout(false);
            this._panelHeadType.PerformLayout();
            this._groupBoxBufferSizeResult.ResumeLayout(false);
            this._groupBoxBufferSizeResult.PerformLayout();
            this._panelLjxSetting.ResumeLayout(false);
            this._panelLjxSetting.PerformLayout();
            this._panelLjvSetting.ResumeLayout(false);
            this._panelLjvSetting.PerformLayout();
            this._panelDeviceId.ResumeLayout(false);
            this._panelDeviceId.PerformLayout();
            this._panelNumberOfReceivedProfiles.ResumeLayout(false);
            this._panelNumberOfReceivedProfiles.PerformLayout();
            this._tabControl.ResumeLayout(false);
            this._tabSimpleFunctionSample.ResumeLayout(false);
            this._groupBoxReadingProfiles.ResumeLayout(false);
            this._groupBoxGetDataSimpleArray.ResumeLayout(false);
            this._groupBoxSettingResult.ResumeLayout(false);
            this._groupBoxSettingResult.PerformLayout();
            this._tabCombinationSample.ResumeLayout(false);
            this._groupBoxProgram.ResumeLayout(false);
            this._groupBoxProgram.PerformLayout();
            this._groupBoxHighSpeed.ResumeLayout(false);
            this._groupBoxHighSpeed.PerformLayout();
            this._groupBoxGetData.ResumeLayout(false);
            this._groupBoxGetProfile.ResumeLayout(false);
            this._groupBoxGetProfile.PerformLayout();
            this._groupBoxBaseOperation.ResumeLayout(false);
            this._panelCommunicationDevice.ResumeLayout(false);
            this._groupBoxEthernetSetting.ResumeLayout(false);
            this._groupBoxEthernetSetting.PerformLayout();
            this.ResumeLayout(false);

		}

		private System.Windows.Forms.Button _buttonGetVersion;
		private System.Windows.Forms.Button _buttonFinalize;
		private System.Windows.Forms.Button _buttonInitialize;
		private System.Windows.Forms.Button _buttonCommClose;
		private System.Windows.Forms.Button _buttonEthernetOpen;
		private System.Windows.Forms.GroupBox _groupBoxCommand;
		private System.Windows.Forms.Button _buttonStopMeasure;
		private System.Windows.Forms.Button _buttonStartMeasure;
		private System.Windows.Forms.Button _buttonTrigger;
		private System.Windows.Forms.Button _buttonClearError;
		private System.Windows.Forms.Button _buttonGetError;
		private System.Windows.Forms.Button _buttonReturnToFactorySetting;
		private System.Windows.Forms.Button _buttonRebootController;
		private System.Windows.Forms.Button _buttonGetBatchProfile;
		private System.Windows.Forms.Button _buttonGetProfile;
		private System.Windows.Forms.Button _buttonChangeActiveProgram;
		private System.Windows.Forms.Button _buttonUpdateSetting;
		private System.Windows.Forms.Button _buttonCheckMemoryAccess;
		private System.Windows.Forms.Button _buttonSetSetting;
		private System.Windows.Forms.Button _buttonGetSetting;
		private System.Windows.Forms.Button _buttonClearMemory;
		private System.Windows.Forms.Button _buttonRewriteTemporarySetting;
		private System.Windows.Forms.Button _buttonInitializeHighSpeedDataCommunication;
		private System.Windows.Forms.Button _buttonPreStartHighSpeedDataCommunication;
		private System.Windows.Forms.Button _buttonStartHighSpeedDataCommunication;
		private System.Windows.Forms.Button _buttonFinalizeHighSpeedDataCommunication;
		private System.Windows.Forms.Button _buttonStopHighSpeedDataCommunication;
		private System.Windows.Forms.Button _buttonGetActiveProgram;
		private System.Windows.Forms.GroupBox _groupBoxLog;
		private System.Windows.Forms.Button _buttonLogClear;
		private System.Windows.Forms.TextBox _textBoxLog;
		private System.Windows.Forms.Button _buttonInitializeSetting;
		private System.Windows.Forms.GroupBox _groupBoxBufferSize;
		private System.Windows.Forms.GroupBox _groupBoxHighSpeedExport;
		private System.Windows.Forms.TextBox _textBoxHighSpeedProfileFilePath;
		private System.Windows.Forms.Button _buttonHighSpeedProfileFileSave;
		private System.Windows.Forms.SaveFileDialog _profileFileSave;
		private System.Windows.Forms.Button _buttonHighSpeedSave;
		private System.Windows.Forms.Label _labelHighSpeedSavePath;
		private System.Windows.Forms.NumericUpDown _numericUpDownProfileNo;
		private System.Windows.Forms.Label _labelIndexOfTheProfileToSave;
		private System.Windows.Forms.Timer _timerHighSpeedReceive;
		private System.Windows.Forms.Label _labelReceiveProfileCount0;
		private System.Windows.Forms.RadioButton _radioButtonDevice0;
		private System.Windows.Forms.RadioButton _radioButtonDevice2;
		private System.Windows.Forms.RadioButton _radioButtonDevice1;
		private System.Windows.Forms.Panel _panelDeviceId;
		private System.Windows.Forms.Label _labelId;
		private System.Windows.Forms.Label _labelDeviceStatus2;
		private System.Windows.Forms.Label _labelDeviceStatus1;
		private System.Windows.Forms.Label _labelDeviceStatus0;
		private System.Windows.Forms.Label _labelReceiveProfileCount2;
		private System.Windows.Forms.Label _labelReceiveProfileCount1;
		private System.Windows.Forms.Panel _panelNumberOfReceivedProfiles;
		private System.Windows.Forms.Label _labelNumberOfReceivedProfiles;
		private System.Windows.Forms.Label _labelState;
		private System.Windows.Forms.CheckBox _checkBoxOnlyProfileCount;
		private System.Windows.Forms.CheckBox _checkBoxStartTimer;
		private System.Windows.Forms.NumericUpDown _numericUpDownInterval;
		private System.Windows.Forms.TabControl _tabControl;
		private System.Windows.Forms.TabPage _tabSimpleFunctionSample;
		private System.Windows.Forms.TabPage _tabCombinationSample;
		private System.Windows.Forms.GroupBox _groupBoxSettingResult;
		private System.Windows.Forms.GroupBox _groupBoxOperations;
		private System.Windows.Forms.GroupBox _groupBoxSystemControl;
		private System.Windows.Forms.GroupBox _groupBoxMeasurementControl;
		private System.Windows.Forms.GroupBox _groupBoxSetting;
		private System.Windows.Forms.GroupBox _groupBoxGetMeasurementResult;
		private System.Windows.Forms.GroupBox _groupBoxHighSpeedData;
		private System.Windows.Forms.GroupBox _groupBoxHighSpeed;
		private System.Windows.Forms.TextBox _textBoxCallbackFrequency;
		private System.Windows.Forms.TextBox _textBoxStartProfileNo;
		private System.Windows.Forms.Label _labelReceiveProfileCount;
		private System.Windows.Forms.Label _labelCallbackFrequency;
		private System.Windows.Forms.Label _labelHighSpeedStartNo;
		private System.Windows.Forms.Label _labelReceiveCount;
		private System.Windows.Forms.Button _buttonTerminateHighSpeedCommunication;
		private System.Windows.Forms.Button _buttonBeginHighSpeedDataCommunication;
		private System.Windows.Forms.GroupBox _groupBoxGetData;
		private System.Windows.Forms.GroupBox _groupBoxGetProfile;
		private System.Windows.Forms.Button _buttonReferenceSavePath;
		private System.Windows.Forms.Button _buttonGetBatchProfileData;
		private System.Windows.Forms.Button _buttonGetProfileData;
		private System.Windows.Forms.TextBox _textBoxSavePath;
		private System.Windows.Forms.Label _labelProfilesSavePath;
		private System.Windows.Forms.GroupBox _groupBoxBaseOperation;
		private System.Windows.Forms.Panel _panelCommunicationDevice;
		private System.Windows.Forms.GroupBox _groupBoxEthernetSetting;
		private System.Windows.Forms.TextBox _textBoxIpFirstSegment;
		private System.Windows.Forms.TextBox _textBoxIpFourthSegment;
		private System.Windows.Forms.TextBox _textBoxIpSecondSegment;
		private System.Windows.Forms.TextBox _textBoxIpThirdSegment;
		private System.Windows.Forms.Label _labelIpSeparator3;
		private System.Windows.Forms.Label _labelIpSeparator2;
		private System.Windows.Forms.Label _labelHighSpeedPort;
		private System.Windows.Forms.TextBox _textBoxHighSpeedPort;
		private System.Windows.Forms.Label _labelIpSeparator1;
		private System.Windows.Forms.TextBox _textBoxCommandPort;
		private System.Windows.Forms.Label _labelIpAddress;
		private System.Windows.Forms.Label _labelCommandPort;
		private System.Windows.Forms.Button _buttonTerminateCommunication;
		private System.Windows.Forms.Button _buttonEstablishCommunication;
		private System.Windows.Forms.GroupBox _groupBoxProgram;
		private System.Windows.Forms.Button _buttonUploadProgram;
		private System.Windows.Forms.Button _buttonDownloadProgram;
		private System.Windows.Forms.Label _labelSelectProgram;
		private System.Windows.Forms.ComboBox _comboBoxSelectProgram;
		private System.Windows.Forms.Label _labelConectedDevice;
		private System.Windows.Forms.Label _labelDeviceStatus3;
		private System.Windows.Forms.RadioButton _radioButtonDevice3;
		private System.Windows.Forms.Label _labelReceiveProfileCount3;
		private System.Windows.Forms.Label _labelDeviceStatus4;
		private System.Windows.Forms.RadioButton _radioButtonDevice5;
		private System.Windows.Forms.RadioButton _radioButtonDevice4;
		private System.Windows.Forms.Label _labelDeviceStatus5;
		private System.Windows.Forms.Label _labelReceiveProfileCount5;
		private System.Windows.Forms.Label _labelReceiveProfileCount4;
		private System.Windows.Forms.Timer _timerHighSpeed;
		private System.Windows.Forms.Button _buttonGetTriggerCount;
		private System.Windows.Forms.Button _buttonGetHeadTemperature;
		private System.Windows.Forms.Button _buttonControlLaser;
		private System.Windows.Forms.Button _buttonTriggerErrorReset;
		private System.Windows.Forms.Panel _panelLjvSetting;
		private System.Windows.Forms.RadioButton _radioButtonLJV;
		private System.Windows.Forms.RadioButton _radioButtonLJX;
		private System.Windows.Forms.Label _labelOneProfileByteSize;
		private System.Windows.Forms.GroupBox _groupBoxReadingProfiles;
		private System.Windows.Forms.Panel _panelLjxSetting;
		private System.Windows.Forms.GroupBox _groupBoxBufferSizeResult;
		private System.Windows.Forms.Label _labelBufferSizeValue;
		private System.Windows.Forms.ComboBox _comboBoxLjxMeasureX;
		private System.Windows.Forms.Label _labelLjxMeasureX;
		private System.Windows.Forms.ComboBox _comboBoxLjxThinningX;
		private System.Windows.Forms.Label _labelLjxThinningX;
		private System.Windows.Forms.ComboBox _comboBoxLjxLuminanceOutput;
		private System.Windows.Forms.Label _labelLjxLuminanceOutput;
		private System.Windows.Forms.ComboBox _comboBoxLjxSamplingPeriod;
		private System.Windows.Forms.Label _labelLjxSamplingPeriodNote;
		private System.Windows.Forms.Label _labelLjxSampling;
		private System.Windows.Forms.Label _labelLjvMeasureX;
		private System.Windows.Forms.Label _labelLjvThinningX;
		private System.Windows.Forms.Label _labelLjvBinning;
		private System.Windows.Forms.ComboBox _comboBoxLjvMeasureX;
		private System.Windows.Forms.ComboBox _comboBoxLjvThinningX;
		private System.Windows.Forms.ComboBox _comboBoxLjvBinning;
		private System.Windows.Forms.Panel _panelHeadType;
		private System.Windows.Forms.Timer _timerBufferError;
		private System.Windows.Forms.NumericUpDown _numericUpDownProfileSaveCount;
		private System.Windows.Forms.Label _labelProfileSaveCount;
		private System.Windows.Forms.Button _buttonGetSerialNumber;
		private System.Windows.Forms.Button _buttonGetAttentionStatus;
		private System.Windows.Forms.RadioButton _radioButtonLJVB;
		private System.Windows.Forms.TextBox _textBoxProfileFilePath;
		private System.Windows.Forms.Button _buttonProfileFileSave;
		private System.Windows.Forms.Button _buttonInitializeHighSpeedDataCommunicationSimpleArray;
		private System.Windows.Forms.GroupBox _groupBoxGetDataSimpleArray;
		private System.Windows.Forms.Button _buttonSaveAsBitmapFile;
		private System.Windows.Forms.Button _buttonGetBatchSimpleArray;
		private System.Windows.Forms.CheckBox _checkBoxUseSimpleArray;
		private System.Windows.Forms.Button _buttonHighSpeedSaveAsBitmapFile;
        private System.Windows.Forms.SaveFileDialog _bitmapFileSave;
        private System.Windows.Forms.SaveFileDialog _profileOrBitmapFileSave;
    }
}

