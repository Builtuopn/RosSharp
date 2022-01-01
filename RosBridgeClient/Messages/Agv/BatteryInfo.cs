using Newtonsoft.Json;

namespace RosSharp.RosBridgeClient.Messages.Agv
{
    /// <summary>
    /// 电池信息
    /// </summary>
    public class BatteryInfo : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "agv_msgs/battery_info";

        public short Capacity;
        public short Voletage;
        public short Current;
        public short Temperature;
        public bool BatHighcolt;
        public bool BatLowvolt;
        public bool BatOvercharge;
        public bool BatOvercurrent;
        public bool BatCharge_Overtemp;
        public bool BatDiscgargeOvertemp;
        public bool BatChargeLowtemp;
        public bool BatDischargeLowtemp;

        public BatteryInfo()
        {
            Capacity = 0; //说明：电池电量信息，0 - 100，单位：百分比
            Voletage = 0;//说明：电池电压信息，电压，例：4868代表48.68V
            Current = 0;//说明：电池电流信息，电流，例：-为放电+为充电 -223代表-2.33A
            Temperature = 0;
            BatHighcolt = false;
            BatLowvolt = false;
            BatOvercharge = false;
            BatOvercharge = false;
            BatOvercurrent = false;
            BatCharge_Overtemp = false;
            BatDiscgargeOvertemp = false;
            BatChargeLowtemp = false;
            BatDischargeLowtemp = false;
        }
    }
}
