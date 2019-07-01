using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Timers;
using vMt2;
using vMt2.Encryption;
using vMt2.Models;

namespace vRubinum2.Test
{
    class Program
    {
        private static Timer timer = new Timer(10);
        private static List<ItemStat> itemStats;
        private static VirtualClient vc;
        private static int maxDss = 0;
        private static int c = 0;
        static void Main(string[] args)
        {
            //IPEndPoint authServer = new IPEndPoint(IPAddress.Parse("37.114.57.220"), 11000);
            //IPEndPoint loginServer = new IPEndPoint(IPAddress.Parse("37.114.57.220"), 13030);

            IPEndPoint authServer = new IPEndPoint(IPAddress.Parse("149.202.214.144"), 11000);
            IPEndPoint loginServer = new IPEndPoint(IPAddress.Parse("149.202.214.144"), 13010);

            VirtualClient virtualClient = new VirtualClient(authServer, loginServer, Encoding.UTF8.GetBytes("LV,ZEuzy5A_[{LF!"));
            virtualClient.LoginSuccessCallback += VirtualClient_LoginSuccessCallback;
            virtualClient.LoginFailCallback += VirtualClient_LoginFailCallback;
            virtualClient.ShopSearchFinishedCallback += VirtualClient_ShopSearchFinishedCallback;
            virtualClient.ItemSlotChangedCallback += VirtualClient_ItemSlotChangedCallback;
            virtualClient.Logger.LogLevel = LogLevel.Info;
            virtualClient.Login("testbenutzername", "testpasswort");
            vc = virtualClient;
            timer.Elapsed += Timer_Elapsed;
            while (true)
            {
                Console.ReadLine();
            }


           

            //Decrypt output from smartsniff with this code.

            //byte[] defkey = Encoding.UTF8.GetBytes("LV,ZEuzy5A_[{LF!");
            //byte[] enkey = new byte[] { 0xB1, 0x5A, 0xF7, 0x21, 0xE2, 0x2B, 0x63, 0x76, 0x26, 0x3F, 0xD6, 0x68, 0x8F, 0x0D, 0xCC, 0x49 };
            ////byte[] enkey = new byte[] { 0xAA, 0xAA, 0xAA, 0xAA, 0xBB, 0xBB, 0xBB, 0xBB, 0xCC, 0xCC, 0xCC, 0xCC, 0xDD, 0xDD, 0xDD, 0xDD };
            //byte[] chinakey = CryptoUtils.GetKey_20050304Myevan();
            //byte[] dekey = TinyEncryptionAlgorithm.Encrypt(enkey, chinakey);

            //while (true)
            //{
            //    String input;
            //    byte[] bytes = new byte[0];
            //    do
            //    {
            //        input = Console.ReadLine();
            //        if (String.IsNullOrWhiteSpace(input))
            //            break;
            //        String line = input.Substring(10);
            //        int endpos = line.IndexOf("   ");
            //        line = line.Substring(0, endpos);
            //        String hex = line.Replace(" ", "");
            //        byte[] b = Enumerable.Range(0, hex.Length)
            //             .Where(x => x % 2 == 0)
            //             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
            //             .ToArray();
            //        bytes = bytes.Concat(b).ToArray();
            //    } while (input.Length > 0);

            //    byte[] dec = TinyEncryptionAlgorithm.Decrypt(bytes, defkey);

            //    Logger l = new Logger();
            //    l.LogInfo("Input: ", dec);
            //    Console.ReadLine();
            //}



        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            c++;
            timer.Stop();
            if (c % 100 == 0)
                Console.WriteLine(c);

            if(itemStats.Any(x => x.Type == vMt2.Enums.ItemStatType.AverageDamage))
            {
                ItemStat iss = itemStats.Where(x => x.Type == vMt2.Enums.ItemStatType.AverageDamage).FirstOrDefault();
                if(iss.Value > maxDss)
                {
                    Console.WriteLine("Max: " + iss.Value);
                    maxDss = iss.Value;
                }
            }

            if (!itemStats.Any(x => x.Type == vMt2.Enums.ItemStatType.AverageDamage && x.Value > 50))
                vc.InventoryManager.UseItemToItem(1, 1, 1, 0);
        }

        private static void VirtualClient_ItemSlotChangedCallback(VirtualClient virtualClient, byte window, UInt16 slot, SlotItem slotItem)
        {
            if (!(window == 1 && slot == 0))
                return;
            itemStats = slotItem.ItemStats;
            timer.Stop();
            timer.Start();
        }

        private static void VirtualClient_LoginFailCallback(VirtualClient virtualClient, LoginFailResult loginResult)
        {
            Console.WriteLine("Login failed");
        }

        private static void VirtualClient_ShopSearchFinishedCallback(VirtualClient virtualClient, List<ShopSearchTuple> tuples)
        {
            virtualClient.ShopManager.Buy(0x086c04, 1);
            //DateTime now = DateTime.Now;
            //virtualClient.Logger.LogLevel = LogLevel.Info;
            //if (tuples == null || tuples.Count == 0)
            //    return;

            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //int c = 0;



            //using (ShopContext context = new ShopContext())
            //{
            //    HashSet<String> allHashes = context.ShopItems.Select(x => x.Hash).ToHashSet();
            //    List<ShopSearchTuple> newTuples = tuples.Where(x => !allHashes.Contains(x.Hash)).ToList();
            //    foreach (ShopSearchTuple tuple in newTuples)
            //    {
            //        c++;
            //        ShopItem shopItem = new ShopItem()
            //        {
            //            Count = tuple.Count,
            //            Hash = tuple.Hash,
            //            ItemId = tuple.ItemId,
            //            UnitPrice = tuple.Price / tuple.Count,
            //            Seller = tuple.Seller,
            //            ShopId = tuple.ShopId,
            //            ShopPosition = tuple.ShopPosition,
            //        };
            //        context.ShopItems.Add(shopItem);
            //    }
            //    context.SaveChanges();
            //}
            //sw.Stop();
            //Console.WriteLine("Added " + c + " items to db in " + sw.ElapsedMilliseconds);


        }

        private static void VirtualClient_LoginSuccessCallback(VirtualClient virtualClient, LoginSuccessResult loginResult)
        {
            Console.Clear();
            virtualClient.SelectCharacter(0);
        }
    }
}
