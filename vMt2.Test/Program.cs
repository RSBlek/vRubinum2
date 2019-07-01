using System;
using System.Net;
using System.Text;
using vMt2.Encryption;
using System.Linq;

namespace vMt2.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            IPEndPoint authServer = new IPEndPoint(IPAddress.Parse("37.114.57.220"), 11000);
            IPEndPoint loginServer = new IPEndPoint(IPAddress.Parse("37.114.57.220"), 13010);
            //IPEndPoint gameServer = new IPEndPoint(IPAddress.Parse("37.114.57.220"), 13094);
            VirtualClient vc = new VirtualClient(authServer, loginServer, Encoding.UTF8.GetBytes("LV,ZEuzy5A_[{LF!"));
            vc.LoginSuccessCallback += Vc_LoginSuccessCallback;
            vc.LoginFailCallback += Vc_LoginFailCallback;
            vc.Login("hackxlawl", "asdasdasd");

            byte[] key = Encoding.UTF8.GetBytes("LV,ZEuzy5A_[{LF!");
            //byte[] enckey = new byte[] { 0x7D, 0x6E, 0x78, 0x5F, 0x82, 0x01, 0x9E, 0x5B, 0xCB, 0x2C, 0x75, 0x62, 0xEC, 0xF5, 0xCF, 0x7A };

            //byte[] key = CryptoUtils.GetKey_20050304Myevan();
            //byte[] decryptKey = TinyEncryptionAlgorithm.Encrypt(enckey, key);

            //byte[] data = { 0x95, 0x0C, 0x18, 0x3C, 0xE3, 0x19, 0xD7, 0x01 };


            ////TinyEncryptionAlgorithm tea = new TinyEncryptionAlgorithm();
            //byte[] de = TinyEncryptionAlgorithm.Decrypt(data, decryptKey);

            //Logger l = new Logger();
            //l.Log("hddmod", de);
            //Console.ReadLine();
        }

        private static void Vc_LoginFailCallback(VirtualClient virtualClient, LoginFailResult loginResult)
        {
            Console.WriteLine("Login failed: " + loginResult.LoginFailReason + " " + loginResult.Description ?? "");
        }

        private static void Vc_LoginSuccessCallback(VirtualClient virtualClient, LoginSuccessResult loginResult)
        {
            Console.Clear();
            Console.WriteLine("Login Success");
            Console.WriteLine();
            foreach(SelectCharacter c in loginResult.Characters)
            {
                Console.WriteLine("Name: " + c.Name);
                Console.WriteLine("Level: " + c.Level);
                Console.WriteLine("Race: " + c.Race);
                Console.WriteLine();
            }
            virtualClient.SelectCharacter(0);
        }
    }
}
