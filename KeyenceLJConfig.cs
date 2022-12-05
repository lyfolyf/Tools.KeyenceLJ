using System;

namespace Lead.CPrim.PrimKeyenceLJ
{
    public enum PrimRunState
    {
        Idle,
        Running,
        Suspend,
        Stop,
        Err,
        Other = 100
    }
    public enum PrimConnState
    {
        Connected,
        UnConnected,
        Other = 100
    }
    public class KeyenceLJConfig
    {
        #region Override IPrim's Property
        public string Name { set; get; }
        public string PrimTypeName { set; get; }
        public Guid Id { set; get; }
        public Type ChildType { set; get; }

        public PrimConnState PrimConnStat  { set; get; }
        public PrimRunState PrimRunStat { set; get; }
        public bool PrimSimulator { set; get; }
        public bool PrimDebug { set; get; }
        public bool PrimEnable { set; get; }
        public bool LogEnable { get; set; }
        #endregion
        public int DeviceCount { set; get; } = 0;
        public string[] DeviceName { set; get; }
        public string[] IpAddress { set; get; }
        public int[] Port { set; get; }
        public bool[] DeviceEnable { set; get; }
        public int[] BatchPointNum { set; get; }
        public int[] SensorSelect { set; get; }//0代表A激光头、1代表B激光头
        public double[] IntervalY { set; get; }
        public double[] IntervalX { set; get; }
        public int[] FlipDirection { set; get; }//设置x轴加载方向 0：从小到大 1：从大到小
        public int[] PartNum { set; get; }    //产品分割个数
        public int[] RowPointNum { get; set; }

        public KeyenceLJConfig()
        {
            Name = "";
            PrimTypeName = $@"KeyenceLJ";
            Id = Guid.NewGuid();
            PrimConnStat = PrimConnState.Other;
            PrimRunStat = PrimRunState.Other;
            PrimSimulator = false;
            PrimDebug = false;
            PrimEnable = true;
            LogEnable = true;

            DeviceCount = 1;
            DeviceName = new string[6];
            IpAddress = new string[6];
            Port = new int[6];
            DeviceEnable = new bool[6];
            BatchPointNum = new int[6];
            SensorSelect = new int[6];
            IntervalX = new double[6];
            IntervalY = new double[6];
            FlipDirection = new int[6];
            PartNum = new int[6];
            RowPointNum = new int[6];
        }
    }
}
