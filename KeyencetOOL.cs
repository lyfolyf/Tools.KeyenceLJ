
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Diagnostics;
using Lead.Tool.Interface;
using Lead.Tool.XML;
using Lead.Tool.CommonData_3D;

namespace Lead.CPrim.PrimKeyenceLJ
{
    public class KeyenceTool :ITool
    {
        private int _currentDeviceId = 0;
        private double _plotInterval = 0;//激光x轴点间距
        private List<ProfileData> _profileDatas = new List<ProfileData>();
        IToolState _State = IToolState.ToolMin;
        private List<int[]> _dataLaserA = new List<int[]>();
        private List<int[]> _dataLaserB = new List<int[]>();
        private static bool _bInited = false;

        private HighSpeedDataCallBack _callbackGetData;

        #region Private Feilds
        private Control _primDebugUI = null;

        private Control _primConfigUI = null;

        public KeyenceLJConfig _config = null;
        public string _Path = "";
        private Task _revTask = null;
        private bool _taskFlag = false;
        private bool _revFlag = false;
        private static DeviceData[] _deviceData;

        private List<int[]>[] _laserData;
        private int[] _laserDataCount;

        private LJX8IF_PROFILE_INFO[] _profileInfo;

        /// <summary>Array of value of receive buffer is full</summary>
        private static bool[] _isBufferFull = new bool[NativeMethods.DeviceCount];
        /// <summary>Array of value of stop processing has done by buffer full error</summary>
        private static bool[] _isStopCommunicationByError = new bool[NativeMethods.DeviceCount];

        private int[][] _segParts;
        #endregion

        #region Contructor

        public KeyenceTool()
        {
            _config = new KeyenceLJConfig();

            _primDebugUI = new PrimDebugControl();
            _primConfigUI = new PrimConfigControl(this);

            if (_deviceData == null)
            {
                _deviceData = new DeviceData[NativeMethods.DeviceCount];
            }

            _laserData = new List<int[]>[6];
            _laserDataCount = new int[6];
            _segParts = new int[6][];

            for (var i = 0; i < 6; i++)
            {
                _laserData[i] = new List<int[]>();
                for (var j = 0; j < PartNum[i]; j++)
                {
                    _segParts[i][j] = BatchPointNum[i] / PartNum[i];
                }
            }

            SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Other);
        }

        public KeyenceTool(string Name, string Path)
        {
            if (Path != null)
            {
                _config = XmlSerializerHelper.ReadXML(Path, typeof(KeyenceLJConfig)) as KeyenceLJConfig;
            }
            else
            {
                _config = new KeyenceLJConfig();
            }
            _Path = Path;
            _primDebugUI = new PrimDebugControl();
            _primConfigUI = new PrimConfigControl(this);

            if (_deviceData == null)
            {
                _deviceData = new DeviceData[NativeMethods.DeviceCount];
            }


            _laserData = new List<int[]>[DeviceCount];
            _laserDataCount = new int[6];
            _segParts = new int[DeviceCount][];
            for (var i = 0; i < DeviceCount; i++)
            {
                _laserData[i] = new List<int[]>();
                _segParts[i] = new int[PartNum[i]];
                for (var j = 0; j < PartNum[i]; j++)
                {
                    _segParts[i][j] = BatchPointNum[i] / PartNum[i];
                }
            }

            SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Other);
        }
        #endregion

        #region Override IPrim's Feilds and Property
        public string Name
        {
            set { _config.Name = value; }
            get { return _config.Name; }
        }

        public string PrimTypeName
        {
            set { _config.PrimTypeName = value; }
            get { return _config.PrimTypeName; }
        }

        public Guid Id
        {
            set { _config.Id = value; }
            get { return _config.Id; }
        }

        public Type ChildType
        {
            set { _config.ChildType = value; }
            get { return _config.ChildType; }
        }

        public PrimConnState PrimConnStat
        {
            set { _config.PrimConnStat = value; }
            get { return _config.PrimConnStat; }
        }

        public PrimRunState PrimRunStat
        {
            set { _config.PrimRunStat = value; }
            get { return _config.PrimRunStat; }
        }

        public bool PrimSimulator
        {
            set { _config.PrimSimulator = value; }
            get { return _config.PrimSimulator; }
        }

        public bool PrimDebug
        {
            set { _config.PrimDebug = value; }
            get { return _config.PrimDebug; }
        }

        public bool PrimEnable
        {
            set { _config.PrimEnable = value; }
            get { return _config.PrimEnable; }
        }


        public IToolState State => _State;

        public Control ConfigUI => _primConfigUI;

        public Control DebugUI => _primDebugUI;

        public bool LogEnable
        {
            get {return _config.LogEnable; }
            set { _config.LogEnable = value; }
        }
        #endregion

        #region Override IPrimKeyenceLJ's property
        public int DeviceCount
        {
            set { _config.DeviceCount = value; }
            get { return _config.DeviceCount; }
        }

        public string[] DeviceName
        {
            set { _config.DeviceName = value; }
            get { return _config.DeviceName; }
        }
        public string[] IpAddress
        {
            set { _config.IpAddress = value; }
            get { return _config.IpAddress; }
        }
        public int[] Port
        {
            set { _config.Port = value; }
            get { return _config.Port; }
        }

        public bool[] DeviceEnable
        {
            set { _config.DeviceEnable = value; }
            get { return _config.DeviceEnable; }
        }

        public int[] BatchPointNum
        {
            set { _config.BatchPointNum = value; }
            get { return _config.BatchPointNum; }
        }
        public int[] SensorSelect
        {
            set { _config.SensorSelect = value; }
            get { return _config.SensorSelect; }
        }
        public double[] IntervalY
        {
            set { _config.IntervalY = value; }
            get { return _config.IntervalY; }
        }
        public double[] IntervalX
        {
            set { _config.IntervalX = value; }
            get { return _config.IntervalX; }
        }
        public int[] RowPointNum
        {
            set { _config.RowPointNum = value; }
            get { return _config.RowPointNum; }
        }
        public int[] FlipDirection
        {
            set { _config.FlipDirection = value; }
            get { return _config.FlipDirection; }
        }

        public int[] PartNum
        {
            set { _config.PartNum = value; }
            get { return _config.PartNum; }
        }

        public string ConnInfo { get; set; }


        #endregion

        #region Override IPrim's Function

        public void Init()
        {
            if (_bInited)
            {
                return ;
            }
            var iRet = NativeMethods.LJX8IF_Initialize();
            for (var i = 0; i < _deviceData.Length; i++)
            {
                _deviceData[i] = new DeviceData { Status = DeviceStatus.NoConnection };
            }

            _bInited = true;

            _State = IToolState.ToolInit;
            return ;
        }

        public void Start()
        {
            var iRet = 0;

            if (PrimConnStat == PrimConnState.Connected) 
            { return ; }

            _callbackGetData = new HighSpeedDataCallBack(GetDataThread);

            var ipStr = new string[IpAddress.Length][];
            for (var i = 0; i < IpAddress.Length; i++)
            {
                ipStr[i] = IpAddress[i].Split('.');
            }
            var ethernetConfig = new LJX8IF_ETHERNET_CONFIG[DeviceCount];

            var connectRet = new int[DeviceCount];
            for (var i = 0; i < DeviceCount; i++)
            {
                ethernetConfig[i].abyIpAddress = new byte[4];
                ethernetConfig[i].wPortNo = Convert.ToUInt16(Port[i]);
                for (var j = 0; j < 4; j++)
                {
                    ethernetConfig[i].abyIpAddress[j] = Convert.ToByte(ipStr[i][j]);
                }

                if (DeviceEnable[i])
                {
                    connectRet[i] = NativeMethods.LJX8IF_EthernetOpen(i, ref ethernetConfig[i]);
                    if (connectRet[i] == (int)Rc.Ok)
                    {
                        _deviceData[i].Status = DeviceStatus.Ethernet;
                        _deviceData[i].EthernetConfig = ethernetConfig[i];
                    }
                }
                else
                {
                    connectRet[i] = 0;
                }

            }

            var allConnOk = true;
            for (var i = 0; i < connectRet.Length; i++)
            {
                if (connectRet[i] != 0)
                {
                    _deviceData[i].Status = DeviceStatus.NoConnection;
                    allConnOk = false;
                }

                if (DeviceEnable[i])
                {
                }
            }

            if (allConnOk)
            {
                SetConn_RunState(PrimConnState.Connected, PrimRunState.Stop);
            }
            else
            {
                throw new Exception("Not allConnOk") ;
            }

            var setHighRet = new bool[DeviceCount];
            string errorCode;
            for (var i = 0; i < DeviceCount; i++)
            {
                setHighRet[i] = SetLaserHightSpeedParam(i, BatchPointNum[i], out errorCode);
            }

            var re = setHighRet.All(p => p) ? 0 : -10;

            if (re != 0)
            {
                throw new Exception("setHighRet !=0");
            }
            if (PrimRunStat == PrimRunState.Running)
            {
                return ;
            }

            if (_revTask == null)
            {
                //_revTask = new Task(() => CycleRev());
                //_revTask.Start();
            }

            _taskFlag = true;
            _revFlag = true;
            var allInitHighOk = true;
            for (var i = 0; i < DeviceCount; i++)
            {
                if (InitHighSpeedCommunication(i) != 0)
                {
                    allInitHighOk = false;
                }
                ;
            }
            SetRunState(allInitHighOk ? PrimRunState.Running : PrimRunState.Err);

            _State = IToolState.ToolRunning;

        }

        public bool GetPointsCount(int deviceId, int index)
        {
            if (PrimRunStat != PrimRunState.Running || PrimConnStat != PrimConnState.Connected)
            {
                return false;
            }

            var needCount = GetNeedCount(deviceId, index);

            if (_laserDataCount[deviceId] >= needCount)
            {
                return true;
            }

            if (index == _segParts[deviceId].Length - 1 && _laserDataCount[deviceId] < needCount)
            {
                var i = 0;
                while (true)
                {
                    if (_laserDataCount[deviceId] >= needCount - 1)
                    {
                        //SpinWait.SpinUntil(() => false, 100);
                        break;
                    }
                    if (i++ > 100)
                    {
                        break;
                    }
                    SpinWait.SpinUntil(() => false, 100);
                }

                return true;
            }

            return false;
        }
        public bool GetPointsCount(int deviceId, int index, int needCount)
        {
            if (PrimRunStat != PrimRunState.Running || PrimConnStat != PrimConnState.Connected)
            {
                return false;
            }

            if (_laserDataCount[deviceId] >= needCount)
            {
                return true;
            }

            if (index == _segParts[deviceId].Length - 1 && _laserDataCount[deviceId] < needCount)
            {
                var i = 0;
                while (true)
                {
                    if (_laserDataCount[deviceId] >= needCount - 1)
                    {
                        //SpinWait.SpinUntil(() => false, 100);
                        break;
                    }
                    if (i++ > 100)
                    {
                        break;
                    }
                    SpinWait.SpinUntil(() => false, 100);
                }

                return true;
            }

            return false;
        }
        private int GetStartIndex(int deviceId, int index)
        {
            var needCount = 0;
            if (index > 0)
            {
                for (var i = 0; i < index; i++)
                {
                    needCount += _segParts[deviceId][i];
                }
            }
            return needCount;
        }
        private int GetNeedCount(int deviceId, int index)
        {
            var needCount = 0;
            for (var i = 0; i <= index; i++)
            {
                needCount += _segParts[deviceId][i];
            }
            return needCount;
        }

        public void Terminate()
        {

            for (var i = 0; i < DeviceCount; i++)
            {
                if (!DeviceEnable[i])
                {
                    continue;
                }
                CloseHighSpeedCommunication(i);
                string errorCode;
                StopMeasureProfile(i, out errorCode);
            }

            _revFlag = false;
            _taskFlag = false;
            _revTask = null;

            SetRunState(PrimRunState.Stop);

            _State = IToolState.ToolTerminate;
        }

        public int IPrimDisConnect(ref string result)
        {
            var iRet = 0;

            var allDisConn = true;
            for (var i = 0; i < DeviceCount; i++)
            {
                if (!DeviceEnable[i])
                {
                    continue;
                }
                if (NativeMethods.LJX8IF_CommunicationClose(i) != 0)
                {
                    allDisConn = false;
                }
            }

            if (allDisConn)
            {
                SetConnState(PrimConnState.UnConnected);
            }
            else
            {
                SetRunState(PrimRunState.Err);
            }

            return iRet;
        }

        public int IPrimDispose()
        {
            var iRet = 0;
            Terminate();
            var disConn = "";
            IPrimDisConnect(ref disConn);
            _primConfigUI.Dispose();
            return iRet;
        }
        #endregion

        #region Override PrimKeyenceLJ's Function

        #region Delete by Tony.Liu
        /*
        public XDPOINT[,] GetXdPointData(int deviceId, int index)
        {
            if (PrimRunStat != PrimRunState.Running || PrimConnStat != PrimConnState.Connected)
            {
                return null;
            }
            var startIndex = GetStartIndex(deviceId, index);
            var points = new XDPOINT[_segParts[deviceId][index], _laserData[deviceId][startIndex].Length];

            for (var i = 0; i < points.GetLength(0); i++)
            {
                for (var j = 0; j < points.GetLength(1); j++)
                {
                    points[i, j].y = (0 + IntervalY[deviceId] * i);  //触发间隔
                    points[i, j].x = IntervalX[deviceId] * (points.GetLength(1) - 1) - IntervalX[deviceId] * j;//7020--10微米
                    points[i, j].z = _laserData[deviceId][startIndex + i][RowPointNum[deviceId] - 1 - j] / 100000.0;
                }
            }

            return points;
        }
        public KeyPoint[,] GetBatch(int deviceId, int index, double intervalY = 0, double intervalX = 0)
        {
            if (PrimRunStat != PrimRunState.Running || PrimConnStat != PrimConnState.Connected)
            {
                return null;
            }

            KeyPoint[,] laserPoints;
            var startIndex = GetStartIndex(deviceId, index);
            
            if (_laserDataCount[deviceId] <= startIndex)
            {
                laserPoints = new KeyPoint[_segParts[deviceId][index], RowPointNum[index]];
                Log.Info(211, $@"LaserData{deviceId}{index}:StartIndex--{startIndex}--exception", LogClassification.VisioPrim, Name);
            }
            else
            {
                laserPoints = new KeyPoint[_segParts[deviceId][index], _laserData[deviceId][startIndex].Length];
            }

            //点间距，若实参>0,则采用实参的值，否则采用congfig设置的值
            var realIntervalX = intervalX <= 0 ? IntervalX[deviceId] : intervalX;
            var realIntervalY = intervalY <= 0 ? IntervalY[deviceId] : intervalY;
            var i = 0;
            var j = 0;
            try
            {
                for (i = 0; i < laserPoints.GetLength(0); i++)
                {
                    for (j = 0; j < laserPoints.GetLength(1); j++)
                    {
                        laserPoints[i, j] = new KeyPoint { Y = (0 + realIntervalY * i) };
                        if (FlipDirection[deviceId] == 0)
                        {
                            laserPoints[i, j].X = 0 + realIntervalX * j;
                        }
                        else
                        {
                            laserPoints[i, j].X = realIntervalX * (laserPoints.GetLength(1) - 1) - j * realIntervalX;
                        }
                        if (_laserDataCount[deviceId] > startIndex)
                        {
                            laserPoints[i, j].Z = _laserData[deviceId][startIndex + i][RowPointNum[deviceId] - 1 - j] / 100000.0;
                        }
                        else
                        {
                            laserPoints[i, j].Z = -999.999;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($@"i-{i},j-{j}");
                throw new Exception(ex.Message);
                Log.Info(19491001, $@"GetBatch--i-{i},j-{j} Error:{ex.Message}", LogClassification.VisioPrim, Name);
                //throw;
            }
            //_laserData[deviceId][index].Clear();
            // _laserData[deviceId][index] = new List<int[]>();
            return laserPoints;
        }
        public List<List<PointFS>> Get3DPointCloud(int deviceId, int index, double intervalY = 0, double intervalX = 0)
        {
            if (PrimRunStat != PrimRunState.Running || PrimConnStat != PrimConnState.Connected)
            {
                return null;
            }

            var startIndex = GetStartIndex(deviceId, index);
            int length0;
            int length1;
            if (_laserDataCount[deviceId] <= startIndex)
            {
                length0 = _segParts[deviceId][index];
                length1 = RowPointNum[index];
                Log.Info(211, $@"LaserData{deviceId}{index}:StartIndex--{startIndex}--exception", LogClassification.VisioPrim, Name);
            }
            else
            {
                length0 = _segParts[deviceId][index];
                length1 = _laserData[deviceId][startIndex].Length;
            }

            //点间距，若实参>0,则采用实参的值，否则采用congfig设置的值
            var realIntervalX = intervalX <= 0 ? IntervalX[deviceId] : intervalX;
            var realIntervalY = intervalY <= 0 ? IntervalY[deviceId] : intervalY;
            var i = 0;
            var j = 0;
            List<List<PointFS>> pointFsListVzac;
            try
            {
                pointFsListVzac = new List<List<PointFS>>();
                for (i = 0; i < length0; i++)
                {
                    var line = new List<PointFS>();
                    for (j = 0; j < length1; j++)
                    {
                        var p = new PointFS
                        {
                            Y = 0 + realIntervalY * i,
                            Intensity = 0
                        };

                        if (FlipDirection[deviceId] == 0)
                        {
                            p.X = 0 + realIntervalX * j;
                        }
                        else
                        {
                            p.X = realIntervalX * (length1 - 1) - j * realIntervalX;
                        }

                        if (_laserDataCount[deviceId] > startIndex)
                        {
                            p.Z = _laserData[deviceId][startIndex + i][RowPointNum[deviceId] - 1 - j] / 100000.0;
                        }
                        else
                        {
                            p.Z = -999.999;
                        }
                        line.Add(p);
                    }
                    pointFsListVzac.Add(line);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($@"i-{i},j-{j}");
                throw new Exception(ex.Message);
                Log.Info(19491001, $@"GetBatch--i-{i},j-{j} Error:{ex.Message}", LogClassification.VisioPrim, Name);
                //throw;
            }

            return pointFsListVzac;
        }
        public List<List<PointFS>> Get3dData(int deviceId, int index)
        {
            var timeoutS = 500;
            var t = 0;
            
            Debug.WriteLine($@"DeviceID:{deviceId}, Index: {index} Get3dData 开始： " + DateTimeOffset.Now.LocalDateTime.ToString("HH:mm:ss.fff"));
            var needCount = GetNeedCount(deviceId, index);
            do
            {
                if (t++ > timeoutS)
                {
                    break;
                }
                SpinWait.SpinUntil(() => t > timeoutS, 100);

            } while (!GetPointsCount(deviceId, index, needCount));

            
            Debug.WriteLine($@"DeviceID:{deviceId}, Index: {index} GetBatch 开始： " + DateTimeOffset.Now.LocalDateTime.ToString("HH:mm:ss.fff"));
           
            var pointFsListVzac = Get3DPointCloud(deviceId, index);
           
            Debug.WriteLine($@"DeviceID:{deviceId}, Index: {index} Get3dData 结束： " + DateTimeOffset.Now.LocalDateTime.ToString("HH:mm:ss.fff"));
            return pointFsListVzac;
        }
        public List<List<PointFS>> Get3dData(int deviceId, int index, bool isSave, bool asyncMode, string saveFilePath)
        {
            var pointFsListVzac = Get3dData(deviceId, index);
            if (pointFsListVzac == null)
            {
                return null;
            }

            if (isSave)
            {
                Action dataSave = () =>
                {
                    Write3dDataToCsv(true, saveFilePath, pointFsListVzac);
                };
                if (asyncMode)
                {
                    dataSave.BeginInvoke(null, null);
                }
                else
                {
                    dataSave.Invoke();
                }
            }
            return pointFsListVzac;
        }
        
        public void Write3dDataToCsv(bool line, string fileName, List<List<PointFS>> datas)
        {
            var dirPath = fileName?.Substring(0, fileName.LastIndexOf(@"\"));
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            var sw = new StreamWriter(fs, new System.Text.UnicodeEncoding());
            if (line)
            {
                foreach (var item in datas)
                {
                    foreach (var item1 in item)
                    {
                        sw.Write($"{item1.X},{item1.Y},{item1.Z},");
                    }
                    sw.Write("\r\n");
                }
                sw.Flush();
                sw.Close();
            }
            else
            {
                sw = new StreamWriter(fs, new System.Text.UnicodeEncoding());
                var text0 = new StringBuilder();
                foreach (var item in datas)
                {
                    foreach (var item1 in item)
                    {
                        text0.Clear();
                        text0.Append($"{item1.X},{item1.Y},{item1.Z}\r\n");
                        sw.Write(text0);
                    }
                }
                sw.Flush();
                sw.Close();
            }
            fs.Close();
        }
        public bool AllLaserDataTransDone()
        {
            var timeoutS = 10;
            var t = 0;

            //while (t++ < timeoutS)
            //{
            //    SpinWait.SpinUntil(() => false, 200);
            //    var allCleared = true;
            //    for (var i = 0; i < DeviceCount; i++)
            //    {
            //        for (var j = 0; j < PartNum[i]; j++)
            //        {
            //            if (_laserData[i].Count > 0)
            //            {
            //                allCleared = false;
            //                continue;
            //            }
            //        }
            //    }
            
            //    if (allCleared || !_taskFlag)
            //    {
            //        return true;
            //    }
            //}
            Log.Info(123, $@"CountCallBack:0-{_laserDataCount[0]},1-{_laserDataCount[1]},2-{_laserDataCount[2]}", LogClassification.VisioPrim, Name);
            //if (t > timeoutS)
            {
                for (var i = 0; i < DeviceCount; i++)
                {
                    if (_laserData[i].Count > 0)
                    {
                        _laserData[i] = new List<int[]>();
                        _laserDataCount[i] = 0;
                    }
                }
                return true;
            }
        }
        */
        #endregion

        public bool AllLaserDataTransDone()
        {
            return true;
            throw new NotImplementedException();
        }
        public void ClearScanResult()
        {
            int deviceId = 0;
            _laserData[deviceId].Clear();
        }

        //public List<List<FSPoint>> GetScanResult()
        //{
        //    int deviceId = 0;
        //    List<List<FSPoint>> ScanResult = new List<List<FSPoint>>();

        //    for (int i = 0; i < _laserData[deviceId].Count; i++)
        //    {
        //        ScanResult.Add(new List<FSPoint>());
        //        for (int j = 0; j < _laserData[deviceId][i].Length; j++)
        //        {
        //            ScanResult[i].Add(new FSPoint() { Z = _laserData[deviceId][i][j] });
        //        }
        //    }

        //    return ScanResult;
        //}

        public List<int[]> GetScanResult()
        {
            int deviceId = 0;
            int count = _laserData.Length;
            if(deviceId < count)
            {
                return _laserData[deviceId];
            }

            return null;
        }

        public int GetBatchCount(int deviceId)
        {
            int count = _laserDataCount.Length;
            if (deviceId < count)
            {
                return _laserDataCount[deviceId];
            }

            return -1;
        }

        public int ClearBatch(int deviceId)
        {
            int count = _laserData.Length;
            if (deviceId < count)
            {
                _laserData[deviceId] = new List<int[]>();
                _laserDataCount[deviceId] = 0;            
                return 0;
            }

            return -1;
        }

        public int StartMeasure(int deviceId)
        {
            if (PrimRunStat != PrimRunState.Running || PrimConnStat != PrimConnState.Connected || deviceId < 0)
            {
                return -1;
            }
            string errorCode;
            return StartMeasureProfile(deviceId, out errorCode) ? 0 : -10;
        }
        public int StopMeasure(int deviceId)
        {
            if (PrimRunStat != PrimRunState.Running || PrimConnStat != PrimConnState.Connected || deviceId < 0)
            {
                return -1;
            }
            string errorCode;
            return StopMeasureProfile(deviceId, out errorCode) ? 0 : -10;
        }
        public int StartMeasure()
        {
            if (PrimRunStat != PrimRunState.Running || PrimConnStat != PrimConnState.Connected)
            {
                return -1;
            }

            var iRet = new int[DeviceCount];
            for (var i = 0; i < DeviceCount; i++)
            {
                iRet[i] = StartMeasure(i);
            }

            for (int i = 0; i < 3; i++)
            {
                _laserDataCount[i] = 0;
            }
            return iRet.All(p => p == 0) ? 0 : -10;
        }
        public int StopMeasure()
        {
            if (PrimRunStat != PrimRunState.Running || PrimConnStat != PrimConnState.Connected)
            {
                return -1;
            }

            var iRet = new int[DeviceCount];
            for (var i = 0; i < DeviceCount; i++)
            {
                iRet[i] = StopMeasure(i);
            }
            ((PrimConfigControl)_primConfigUI).UpdateTrigCount(0, 0);
            ((PrimConfigControl)_primConfigUI).UpdateDataCount(0, 0);

            
            return iRet.All(p => p == 0) ? 0 : -10;
        }
        public int RestartHighCommunication(bool asyncMode)
        {
            Action reStart = () =>
            {
                for (var i = 0; i < DeviceCount; i++)
                {
                    RestartHighCommunication(i);
                }
            };
            if (asyncMode)
            {
                reStart.BeginInvoke(null, null);
            }
            else
            {
                reStart.Invoke();
            }

            return 0;
        }

        public int RestartHighCommunication(bool asyncMode, int deviceId)
        {
            Action reStart = () =>
            {

                    RestartHighCommunication(deviceId);
            };
            if (asyncMode)
            {
                reStart.BeginInvoke(null, null);
            }
            else
            {
                reStart.Invoke();
            }

            return 0;
        }
        public void GetDataThread(IntPtr buffer, uint size, uint count, uint notify, uint user)
        {
            var profileSize = (uint)(size / Marshal.SizeOf(typeof(int)));
            var bufferArray = new int[(int)(profileSize * count)];

            Marshal.Copy(buffer, bufferArray, 0, (int)(profileSize * count));
            for (var i = 0; i < (int)count; i++)
            {
                var a = new int[RowPointNum[user]];
                Array.Copy(bufferArray, i * profileSize + 6, a, 0, RowPointNum[user]);
                _laserData[user].Add(a);
            }
            _laserDataCount[user] += (int)count;


           ((PrimConfigControl)_primConfigUI).UpdateDataCount((int)user, _laserDataCount[user]);
        }

        private bool SetLaserHightSpeedParam(int deviceId, int trigNum, out string errorCode)
        {
            if (!DeviceEnable[deviceId])
            {
                errorCode = "";
                return true;
            }
            //设置KJ[0]批处理点数
            if (!SetBatchProflilePointNUM(deviceId, trigNum, out errorCode))
            {
                return false;
            }
            return ClearMemoryProfileData(deviceId) == 0;
        }
        private int InitHighSpeedCommunication(int deviceId)
        {
            if (InitializeHighSpeedDataCommunication(deviceId) != 0)
            {
                return -1;
            }

            if (PreStartHighSpeedDataCommunication(deviceId) != 0)
            {
                return -2;
            }

            if (StartHighSpeedDataCommunication(deviceId) != 0)
            {
                return -3;
            }

            return 0;
        }

        private int CloseHighSpeedCommunication(int deviceId)
        {
            if (StopHighSpeedDataCommunication(deviceId) != 0)
            {
                return -1;
            }

            if (FinalizeHighSpeedDataCommunication(deviceId) != 0)
            {
                return -2;
            }

            return 0;
        }
        private int InitializeHighSpeedDataCommunication(int deviceId)
        {
            if (deviceId < 0)
            {
                return -1;
            }

            StopHighSpeedCommunication(deviceId);

            _deviceData[deviceId].ProfileDataHighSpeed.Clear();
            _deviceData[deviceId].SimpleArrayDataHighSpeed.Clear();

            var ipStr = IpAddress[deviceId].Split('.');
            var ethernetConfig = new LJX8IF_ETHERNET_CONFIG { abyIpAddress = new byte[4] };
            for (var i = 0; i <= 3; i++)
            {
                ethernetConfig.abyIpAddress[i] = Convert.ToByte(ipStr[i]);
            }
            ethernetConfig.wPortNo = Convert.ToUInt16(Port[deviceId]);
            var rc = NativeMethods.LJX8IF_InitializeHighSpeedDataCommunication(deviceId, ref ethernetConfig, (ushort)(Port[deviceId] + 1), _callbackGetData, 400, (uint)deviceId);
            // @Point
            // # When the frequency of calls is low, the callback function may not be called once per specified number of profiles.
            // # The callback function is called when both of the following conditions are met.
            //   * There is one packet of received data.
            //   * The specified number of profiles have been received by the time the call frequency has been met.

            if (rc == (int)Rc.Ok)
            {
                _deviceData[deviceId].Status = DeviceStatus.EthernetFast;
                _deviceData[deviceId].EthernetConfig = ethernetConfig;
            }

            return rc;
        }
        private int PreStartHighSpeedDataCommunication(int deviceId)
        {
            // @Point
            // # SendPosition is used to specify which profile to start sending data from during high-speed communication.
            // # When "Overwrite" is specified for the operation when memory full and 
            //   "0: From previous send complete position" is specified for the send start position,
            //    if the LJ-X continues to accumulate profiles, the LJ-X memory will become full,
            //    and the profile at the previous send complete position will be overwritten with a new profile.
            //    In this situation, because the profile at the previous send complete position is not saved, an error will occur.

            var profileInfo = new LJX8IF_PROFILE_INFO();
            var request = new LJX8IF_HIGH_SPEED_PRE_START_REQUEST { bySendPosition = 2 };

            var rc = NativeMethods.LJX8IF_PreStartHighSpeedDataCommunication(deviceId, ref request, ref profileInfo);
            if (rc != (int)Rc.Ok) return rc;

            _deviceData[deviceId].SimpleArrayDataHighSpeed.Clear();
            _deviceData[deviceId].SimpleArrayDataHighSpeed.DataWidth = profileInfo.nProfileDataCount;
            _deviceData[deviceId].SimpleArrayDataHighSpeed.IsLuminanceEnable = profileInfo.byLuminanceOutput == 1;

            if (_profileInfo == null)
            {
                _profileInfo = new LJX8IF_PROFILE_INFO[NativeMethods.DeviceCount];
            }
            _profileInfo[deviceId] = profileInfo;

            return rc;
        }
        private int StartHighSpeedDataCommunication(int deviceId)
        {
            _deviceData[deviceId].ProfileDataHighSpeed.Clear();
            _isBufferFull[deviceId] = false;
            _isStopCommunicationByError[deviceId] = false;

            return NativeMethods.LJX8IF_StartHighSpeedDataCommunication(deviceId);
        }

        private int StopHighSpeedDataCommunication(int deviceId)
        {
            return NativeMethods.LJX8IF_StopHighSpeedDataCommunication(deviceId);
        }
        private int FinalizeHighSpeedDataCommunication(int deviceId)
        {
            var rc = NativeMethods.LJX8IF_FinalizeHighSpeedDataCommunication(deviceId);

            switch (_deviceData[deviceId].Status)
            {
                case DeviceStatus.EthernetFast:
                    LJX8IF_ETHERNET_CONFIG config = _deviceData[deviceId].EthernetConfig;
                    _deviceData[deviceId].Status = DeviceStatus.Ethernet;
                    _deviceData[deviceId].EthernetConfig = config;
                    break;
            }

            return rc;
        }

        public int SetBatchNum(int deviceId, int batchNum)
        {
            var iRet = 0;

            if (batchNum < 0) { return -1; }
            BatchPointNum[deviceId] = batchNum;

            return iRet;
        }

        public int SetSegParam(int deviceId, int[] segParams)
        {
            if (deviceId < 0 || deviceId > 5)
            {
                return -10;
            }

            _revFlag = false;
            PartNum[deviceId] = segParams.Length;
            _laserData[deviceId] = new List<int[]>();
            _laserDataCount = new int[6];
            _segParts[deviceId] = new int[segParams.Length];
            for (var i = 0; i < segParams.Length; i++)
            {
                _segParts[deviceId][i] = segParams[i];
            }

            _revFlag = true;
            return 0;
        }
        public int ClearMemoryProfileData(int deviceId)
        {
            if (!DeviceEnable[deviceId])
            {
                return 0;
            }
            return NativeMethods.LJX8IF_ClearMemory(deviceId);
        }

        public int RestartHighCommunication(int deviceId)
        {
            StopHighSpeedDataCommunication(deviceId);
            FinalizeHighSpeedDataCommunication(deviceId);
            NativeMethods.LJX8IF_CommunicationClose(deviceId);

            var ipStr = IpAddress[deviceId].Split('.');
            var ethernetConfig = new LJX8IF_ETHERNET_CONFIG
            {
                abyIpAddress = new byte[4],
                wPortNo = Convert.ToUInt16(Port[deviceId])
            };
            for (var j = 0; j < 4; j++)
            {
                ethernetConfig.abyIpAddress[j] = Convert.ToByte(ipStr[j]);
            }

            if (NativeMethods.LJX8IF_EthernetOpen(deviceId, ref ethernetConfig) == (int)Rc.Ok)
            {
                _deviceData[deviceId].Status = DeviceStatus.Ethernet;
                _deviceData[deviceId].EthernetConfig = ethernetConfig;
            }

            InitializeHighSpeedDataCommunication(deviceId);
            PreStartHighSpeedDataCommunication(deviceId);
            StartHighSpeedDataCommunication(deviceId);

            return 0;
        }
        public bool SetBatchProflilePointNUM(int nCurrentDeviceId, int nBatchNum, out string errorCode)
        {
            errorCode = "";
            var targetSetting = new LJX8IF_TARGET_SETTING();
            var settingData = new byte[NativeMethods.ProgramSettingSize];
            try
            {
                targetSetting.byType = (byte)0x10;
                targetSetting.byCategory = (byte)0x0;
                targetSetting.byItem = (byte)0xA;
                targetSetting.byTarget1 = (byte)0x0;
                targetSetting.byTarget2 = (byte)0x0;
                targetSetting.byTarget3 = (byte)0x0;
                targetSetting.byTarget4 = (byte)0x0;

                settingData[0] = (byte)0x3;//初始化可不要
                var trimChars = new char[] { ' ', ',' };
                //把个数转成16进制
                var strNum0X = nBatchNum.ToString("x4");//X4就是4位16进制
                strNum0X.Trim();
                //把16进制转成字节数组 byte ,byte  a.Remove(0, a.Length - 2);最后2位
                strNum0X = strNum0X.Substring(strNum0X.Length - 2, 2) + "," + strNum0X.Substring(strNum0X.Length - 4, 2);//从前面开始截取2个字符
                //
                var trimStr = strNum0X.Trim(trimChars);
                if (trimStr.Length > 0)
                {
                    var aSrc = trimStr.Split(',');
                    if (aSrc.Length > 0)
                    {
                        settingData = Array.ConvertAll<string, byte>(aSrc,
                            s => Convert.ToByte(s, 16));
                    }
                }
                Array.Resize(ref settingData, 2);//amount of data byte;

            }
            catch (Exception ex)
            {
                errorCode = nCurrentDeviceId + ":" + ex.Message;
                return false;
            }

            using (var pin = new PinnedObject(settingData))
            {
                uint dwError = 0;
                byte Depth = 0x01;
                var rc = NativeMethods.LJX8IF_SetSetting(nCurrentDeviceId, Depth, targetSetting,
                    pin.Pointer, 2, ref dwError);

                if (rc != (int)Rc.Ok)
                {
                    errorCode = $"KJ[{nCurrentDeviceId:d}]-[设置BatchProfile点数] : NG";
                    if (rc < 0x8000)
                    {
                        // Common return code
                        var errorCode2 = "";
                        errorCode = errorCode + errorCode2;
                    }
                    return false;
                }
            }
            return true;
        }

        public bool StartMeasureProfile(int nCurrentDeviceId, out string errorCode)
        {
            int rc;
            errorCode = "";
            rc = NativeMethods.LJX8IF_StartMeasure(nCurrentDeviceId);
            if (rc == (int)Rc.Ok)
            {
                return true;
            }
            else
            {
                errorCode = $"KJ[{nCurrentDeviceId:d}]-[Start_Measure] : NG(0x{rc:x4})";
                if (rc < 0x8000)
                {
                    // Common return code
                    string errorCode2;
                    CommonErrorLog(rc, out  errorCode2);
                    errorCode = errorCode + errorCode2;
                }
                return false;
            }
        }
        public bool StopMeasureProfile(int nCurrentDeviceId, out string errorCode)
        {
            errorCode = "";
            var rc = NativeMethods.LJX8IF_StopMeasure(nCurrentDeviceId);
            if (rc == (int)Rc.Ok)
            {
                //_laserData[nCurrentDeviceId].Clear();
                return true;
            }
            else
            {
                errorCode = $"KJ[{nCurrentDeviceId:d}]-[Stop_Measure] : NG(0x{rc:x4})";
                if (rc < 0x8000)
                {
                    // Common return code
                    var errorCode2 = "";
                    CommonErrorLog(rc, out errorCode2);
                    errorCode = errorCode + errorCode2;
                }
                return false;
            }
        }

        public void StopHighSpeedCommunication(int nCurrentDeviceId)
        {
            NativeMethods.LJX8IF_StopHighSpeedDataCommunication(nCurrentDeviceId);
            NativeMethods.LJX8IF_FinalizeHighSpeedDataCommunication(nCurrentDeviceId);
        }

        private void CommonErrorLog(int rc, out string errorCode)
        {
            errorCode = "";
            switch (rc)
            {
                case (int)Rc.Ok:
                    errorCode = "-> Normal termination";
                    break;
                case (int)Rc.ErrOpenDevice:
                    errorCode = "-> Failed to open the device";
                    break;
                case (int)Rc.ErrNoDevice:
                    errorCode = "-> Device not open";
                    break;
                case (int)Rc.ErrSend:
                    errorCode = "-> Command send error";
                    break;
                case (int)Rc.ErrReceive:
                    errorCode = "-> Response reception error";
                    break;
                case (int)Rc.ErrTimeout:
                    errorCode = "-> Time out";
                    break;
                case (int)Rc.ErrParameter:
                    errorCode = "-> Parameter error";
                    break;
                case (int)Rc.ErrNomemory:
                    errorCode = "-> No free space";
                    break;
                default:
                    errorCode = $"＃Undefined RC(0x{rc:X4})";
                    break;
            }
        }

        public void SetFlip(int deviceId, int dir)
        {
            if (deviceId < 0)
            {
                return;
            }
            FlipDirection[deviceId] = dir;
        }
        #endregion

        #region Others

        public void SetConn_RunState(PrimConnState conn, PrimRunState run)
        {
            PrimConnStat = conn;
            PrimRunStat = run;
            ((PrimConfigControl)_primConfigUI).SetPrimConnState(conn);
            ((PrimConfigControl)_primConfigUI).SetPrimRunState(run);
        }
        public void SetConnState(PrimConnState conn)
        {
            PrimConnStat = conn;
            ((PrimConfigControl)_primConfigUI).SetPrimConnState(conn);
        }
        public void SetRunState(PrimRunState run)
        {
            PrimRunStat = run;
            ((PrimConfigControl)_primConfigUI).SetPrimRunState(run);
        }


        #endregion
    }
}
