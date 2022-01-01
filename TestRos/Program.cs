using RosSharp.RosBridgeClient;
using System;
using Agv_msgs = RosSharp.RosBridgeClient.Messages.Agv;
using geometry_msgs = RosSharp.RosBridgeClient.Messages.Geometry;
namespace RosSharp.AgvTest
{
    public class Program
    {
        public class RosSocketConsoleTestProtocol
        {
            static readonly string uri = "ws://192.168.150.129:9090"; //Ros IP WebSocket协议 >>测试小乌龟

            static void Main(string[] args)
            {
                RosSocket rosSocket = new RosSocket(new RosBridgeClient.Protocols.WebSocketSharpProtocol(uri));

                geometry_msgs.Twist twist = new geometry_msgs.Twist();
                 string publication_id = rosSocket.Advertise<geometry_msgs.Twist>("/turtle1/cmd_vel");

                 Console.WriteLine("按下任意键开始...");
                 Console.ReadKey(true);
                 for (int i = 0; i < 10000000; i++)
                 {
                     twist.linear.x = 8f;
                     twist.linear.y = 10f;
                     twist.angular.z = 8f;
                     rosSocket.Publish(publication_id, twist);
                 }
                 Console.WriteLine(publication_id);
                 Console.WriteLine("按下任意键关闭...");
                 Console.ReadKey(true);
                 rosSocket.Unadvertise(publication_id);
                 rosSocket.Close();

                //订阅agv信息             
                string Subscription_id1 = rosSocket.Subscribe<Agv_msgs.BatteryInfo>("battery_info", SubscriptionHandler);
                Subscription_id1 = rosSocket.Subscribe<Agv_msgs.BatteryInfo>("battery_info", SubscriptionHandler);

               
            }
            private static void SubscriptionHandler(Agv_msgs.BatteryInfo message)
            {
                Console.WriteLine(message.Capacity);
                Console.WriteLine(message.Current);
                Console.WriteLine(message.Voletage);
                Console.WriteLine(message.Temperature);

            }
        }
    }
}
