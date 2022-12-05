using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.CPrim.PrimKeyenceLJ.Demo;
using System.Threading;
using Lead.Tool.XML;

namespace Lead.CPrim.PrimKeyenceLJ
{
    public partial class PrimConfigControl : UserControl
    {
        private delegate void UpdatePrimConnState(PrimConnState state);
        private delegate void UpdatePrimRunState(PrimRunState state);

        private delegate void UpdateControl(int deviceId, object obj);
        private KeyenceTool _keyence;
        private TextBox[] _tbNameArray;
        private TextBox[] _tbIpArray;
        private TextBox[] _tbPortArray;
        private CheckBox[] _chkEnableArray;
        public PrimConfigControl()
        {
            InitializeComponent();

            _tbNameArray = new[] {tbName0, tbName1, tbName2, tbName3, tbName4, tbName5};
            _tbIpArray = new[]{tbIp0, tbIp1, tbIp2, tbIp3, tbIp4, tbIp5};
            _tbPortArray = new[] {tbPort0, tbPort1, tbPort2, tbPort3, tbPort4};
            _chkEnableArray = new[] {chkEnable0, chkEnable1, chkEnable2, chkEnable3, chkEnable4, chkEnable5};
        }
        public PrimConfigControl(KeyenceTool prim)
        {
            InitializeComponent();
            _keyence = prim;

            _tbNameArray = new[] { tbName0, tbName1, tbName2, tbName3, tbName4, tbName5 };
            _tbIpArray = new[] { tbIp0, tbIp1, tbIp2, tbIp3, tbIp4, tbIp5 };
            _tbPortArray = new[] { tbPort0, tbPort1, tbPort2, tbPort3, tbPort4 };
            _chkEnableArray = new[] { chkEnable0, chkEnable1, chkEnable2, chkEnable3, chkEnable4, chkEnable5 };
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            _keyence.PrimEnable = chkEnable.Checked;
            for (var i = 0; i < _tbNameArray.Length; i++)
            {
                _keyence.DeviceName[i] = _tbNameArray[i].Text;
            }

            for (var i = 0; i < _tbIpArray.Length; i++)
            {
                _keyence.IpAddress[i] = _tbIpArray[i].Text;
            }

            for (var i = 0; i < _tbPortArray.Length; i++)
            {
                int result;
                if (int.TryParse(_tbPortArray[i].Text, out result))
                {
                    _keyence.Port[i] = result;
                }
            }

            for (var i = 0; i < _chkEnableArray.Length; i++)
            {
                _keyence.DeviceEnable[i] = _chkEnableArray[i].Checked;
            }

            _keyence.Name = tTaskBoxName.Text;

            DeviceSelectedParamSave();

            XmlSerializerHelper.WriteXML(_keyence._config, _keyence._Path, typeof(KeyenceLJConfig));
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var connMsg = "";
            _keyence.Init();
            _keyence.Start();
            MessageBox.Show( "初始化成功");
            Cursor = Cursors.Default;
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var disConn = "";

            _keyence.Terminate();
            _keyence.IPrimDisConnect(ref disConn);
            MessageBox.Show("停止成功");
            Cursor = Cursors.Default;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            _keyence.Start();

            MessageBox.Show( "启动成功");
            Cursor = Cursors.Default;
        }
        
        private void PrimConfigControl_Load(object sender, EventArgs e)
        {
            chkEnable.Checked = _keyence.PrimEnable;
            tbDeviceCount.Text = _keyence.DeviceCount.ToString();
            for (var i = 0; i < _tbNameArray.Length; i++)
            {
                _tbNameArray[i].Text = _keyence.DeviceName[i];
            }

            for (var i = 0; i < _tbIpArray.Length; i++)
            {
                _tbIpArray[i].Text = _keyence.IpAddress[i];
            }

            for (var i = 0; i < _tbPortArray.Length; i++)
            {
                _tbPortArray[i].Text = _keyence.Port[i].ToString();
            }

            for (var i = 0; i < _chkEnableArray.Length; i++)
            {
                _chkEnableArray[i].Checked = _keyence.DeviceEnable[i];
            }

            tTaskBoxName.Text = _keyence.Name;

            cmbDeviceSelect.SelectedIndex = 0;
        }


        public void SetPrimConnState(PrimConnState state)
        {
            if (tBoxConnState.InvokeRequired)
            {
                var update = new UpdatePrimConnState(SetPrimConnState);
                Invoke(update, state);
            }
            else
            {
                switch (state)
                {
                    case PrimConnState.UnConnected:
                        tBoxConnState.BackColor = Color.Khaki;
                        tBoxConnState.Text = "UnConnected";
                        btnInit.BackColor = Color.SkyBlue;
                        btnInit.Enabled = true;
                        break;
                    case PrimConnState.Connected:
                        tBoxConnState.BackColor = Color.LightGreen;
                        tBoxConnState.Text = "Connected";
                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        break;
                    case PrimConnState.Other:
                        tBoxConnState.BackColor = Color.Khaki;
                        tBoxConnState.Text = "UnConnected";
                        btnInit.BackColor = Color.SkyBlue;
                        btnInit.Enabled = true;
                        break;
                }
            }
        }

        public void SetPrimRunState(PrimRunState state)
        {
            if (tBoxRunState.InvokeRequired) //指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中
            {
                var update = new UpdatePrimRunState(SetPrimRunState);
                Invoke(update, state);
            }
            else
            {
                switch (state)
                {
                    case PrimRunState.Idle:
                        tBoxRunState.BackColor = Color.Khaki;
                        tBoxRunState.Text = "Idle";
                        break;
                    case PrimRunState.Running:
                        tBoxRunState.BackColor = Color.LightGreen;
                        tBoxRunState.Text = "Running";
                        btnStart.BackColor = Color.Gray;
                        btnStart.Enabled = false;
                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        btnStop.Enabled = true;
                        btnStop.BackColor = Color.SandyBrown;
                        break;
                    case PrimRunState.Stop:
                        tBoxRunState.BackColor = Color.Brown;
                        tBoxRunState.Text = "Stop";
                        btnStart.BackColor = Color.LightGreen;
                        btnStart.Enabled = true;
                        btnInit.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                        break;
                    case PrimRunState.Err:
                        tBoxRunState.BackColor = Color.SandyBrown;
                        tBoxRunState.Text = "Err";
                        break;
                    case PrimRunState.Other:
                        tBoxRunState.BackColor = Color.Khaki;
                        tBoxRunState.Text = "Idle";
                        btnStart.Enabled = false;
                        btnStart.BackColor = Color.Gray;
                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                        break;
                }
            }
        }

        private void btnOpenDemo_Click(object sender, EventArgs e)
        {
            var form = new KeyenceLJ_Demo();
            form.Show();
        }

        private void btnStartMeasure_Click(object sender, EventArgs e)
        {
            //Delete by Tony.Liu
            
            if (cmbDeviceSelect.SelectedIndex == -1)
            {
                return;
            }
            Cursor = Cursors.WaitCursor;

            _keyence.SetSegParam(cmbDeviceSelect.SelectedIndex, new[] { _keyence.BatchPointNum[cmbDeviceSelect.SelectedIndex] });

            var j = 0;
            while (!_keyence.AllLaserDataTransDone())
            {
                if (j++ > 30)
                {
                    break;
                }
                Thread.Sleep(1000);
            }

            _keyence.StopMeasure();
            _keyence.RestartHighCommunication(false);

            _keyence.StartMeasure(cmbDeviceSelect.SelectedIndex);

            Cursor = Cursors.Default;
            
        }

        private void btnStopMeasure_Click(object sender, EventArgs e)
        {
            if (cmbDeviceSelect.SelectedIndex != -1)
            {
                return;
            }
            Cursor = Cursors.WaitCursor;
            _keyence.StopMeasure(cmbDeviceSelect.SelectedIndex);
            Cursor = Cursors.Default;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //Delete by Tony.Liu
            /*
            if (cmbDeviceSelect.SelectedIndex != -1)
            {
                return;
            }
            _keyence.Get3dData(cmbDeviceSelect.SelectedIndex, 0);
            */
        }
        
        private void btnSaveTestReal_Click(object sender, EventArgs e)
        {
            //Delete by Tony.Liu
            /*
            if (cmbDeviceSelect.SelectedIndex != -1)
            {
                return;
            }
            var datas = _keyence.Get3dData(cmbDeviceSelect.SelectedIndex, 0);
            _keyence.Write3dDataToCsv(chkLine.Checked, "F:\\Save\\2.csv", datas);
            */
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            //Delete by Tony.Liu
            /*
            if (cmbDeviceSelect.SelectedIndex != -1)
            {
                for (var i = 0; i < _keyence.PartNum[cmbDeviceSelect.SelectedIndex]; i++)
                {
                    _keyence.Get3dData(cmbDeviceSelect.SelectedIndex, i, true, true, $@"F:\Save\{DateTime.Now:MM-dd_hh-mm}--{i}.csv");
                }
            }
            */
        }

        public void UpdateTrigCount(int deviceId, object obj)
        {
            if (tbTrigCount.InvokeRequired) //指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中
            {
                var update = new UpdateControl(UpdateTrigCount);
                BeginInvoke(update, deviceId, obj);
            }
            else
            {
                if (cmbDeviceSelect.SelectedIndex == deviceId)
                {
                    tbTrigCount.Text = obj.ToString();
                }
            }
        }
        public void UpdateDataCount(int deviceId, object obj)
        {
            if (tbDataCount.InvokeRequired) //指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中
            {
                var update = new UpdateControl(UpdateDataCount);
                BeginInvoke(update, deviceId, obj);
            }
            else
            {
                if (cmbDeviceSelect.SelectedIndex == deviceId)
                {
                    tbDataCount.Text = obj.ToString();
                }
            }
        }

        private void tbDeviceCount_TextChanged(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(tbDeviceCount.Text, out result))
            {
                _keyence.DeviceCount = result;
            }
        }

        private void cmbDeviceSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeviceSelect.SelectedIndex == -1)
            {
                return;
            }
            textBoxTrigCount.Text = _keyence.BatchPointNum[cmbDeviceSelect.SelectedIndex].ToString();
            tbInterValX.Text = _keyence.IntervalX[cmbDeviceSelect.SelectedIndex].ToString(CultureInfo.InvariantCulture);
            chkFlipDirection.Checked = _keyence.FlipDirection[cmbDeviceSelect.SelectedIndex] == 0 ? false : true;
            tbInterValY.Text = _keyence.IntervalY[cmbDeviceSelect.SelectedIndex].ToString(CultureInfo.InvariantCulture);
            tbRowPointNum.Text = _keyence.RowPointNum[cmbDeviceSelect.SelectedIndex].ToString(CultureInfo.InvariantCulture);
            tbPartNum.Text = _keyence.PartNum[cmbDeviceSelect.SelectedIndex].ToString(CultureInfo.InvariantCulture);
        }

        private void DeviceSelectedParamSave()
        {
            if (cmbDeviceSelect.SelectedIndex == -1)
            {
                return;
            }
            double d1;
            if (double.TryParse(tbInterValY.Text, out d1))
            {
                _keyence.IntervalY[cmbDeviceSelect.SelectedIndex] = d1;
            }
            int d2;
            if (int.TryParse(tbPartNum.Text, out d2))
            {
                _keyence.PartNum[cmbDeviceSelect.SelectedIndex] = d2;
            }
            int d3;
            if (int.TryParse(tbRowPointNum.Text, out d3))
            {
                _keyence.RowPointNum[cmbDeviceSelect.SelectedIndex] = d3;
            }
            int d4;
            if (int.TryParse(textBoxTrigCount.Text, out d4))
            {
                _keyence.BatchPointNum[cmbDeviceSelect.SelectedIndex] = d4;
            }
            double d5;
            if (double.TryParse(tbInterValX.Text, out d5))
            {
                _keyence.IntervalX[cmbDeviceSelect.SelectedIndex] = d5;
            }

            _keyence.FlipDirection[cmbDeviceSelect.SelectedIndex] = !chkFlipDirection.Checked ? 0 : 1;
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            int count = _keyence.GetBatchCount(cmbDeviceSelect.SelectedIndex);
            tbDataCount.Text = count.ToString();
        }

        private void cBoxUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxUpdate.Checked)
            {
                tmrUpdate.Start();
            }
            else
            {
                tmrUpdate.Stop();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _keyence.ClearBatch(cmbDeviceSelect.SelectedIndex);
        }
    }
}
