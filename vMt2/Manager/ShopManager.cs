using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Timers;
using vMt2.Models;
using vMt2.Packets;

namespace vMt2.Manager
{
    public class ShopManager
    {
        public bool IsSearchOpen { get; set; }
        internal CShopSearchQueryPacket SearchQuery { get; set; }
        internal List<SShopResultPacket> Results { get; } = new List<SShopResultPacket>();
        internal UInt32 Resultcount { get; set; }
        internal UInt32 CurrentOffset { get; set; }
        internal bool FetchAll { get; set; } = true;

        private readonly Timer timeoutTimer = new Timer(3000);

        private readonly VirtualClient virtualClient;
        public ShopManager(VirtualClient virtualClient)
        {
            this.virtualClient = virtualClient;
            timeoutTimer.Elapsed += TimeoutTimer_Elapsed;
            timeoutTimer.AutoReset = false;
        }

        public void AddItemToShop(byte sourceWindow, UInt16 sourceSlot, UInt32 destinationSlot, UInt64 price)
        {
            CShopAddItemPacket packet = new CShopAddItemPacket();
            packet.SourceInventory = sourceWindow;
            packet.SourceSlot = sourceSlot;
            packet.DestinationSlot = destinationSlot;
            packet.Price = price;
            virtualClient.SendPacket(packet);
        }

        public void WithdrawGold(UInt64 amount)
        {
            CShopWithdrawGoldPacket packet = new CShopWithdrawGoldPacket();
            packet.Amount = amount;
            virtualClient.SendPacket(packet);
        }

        private void TimeoutTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SearchFinished();
        }

        public void Buy(UInt32 shopId, UInt16 shopPosition)
        {
            CShopBuyPacket packet = new CShopBuyPacket();
            packet.ShopId = shopId;
            packet.ShopPosition = shopPosition;
            this.virtualClient.SendPacket(packet);
        }

        public void Sell(byte srcWindow, UInt16 srcSlot, UInt32 dstSlot, UInt64 price)
        {
            CShopAddItemPacket packet = new CShopAddItemPacket()
            {
                DestinationSlot = dstSlot,
                Price = price,
                SourceInventory = srcWindow,
                SourceSlot = srcSlot
            };
            virtualClient.SendPacket(packet);
        }

        public void Search(String itemname, bool fetchAll)
        {
            CShopSearchQueryPacket packet = new CShopSearchQueryPacket
            {
                Itemname = itemname
            };
            this.FetchAll = fetchAll;
            this.Results.Clear();
            this.Resultcount = 0;
            this.CurrentOffset = 0;
            IsSearchOpen = true;
            this.SearchQuery = packet;
            virtualClient.SendPacket(packet);
        }

        internal void ResultcountReceived(UInt32 resultcount)
        {
            this.Resultcount = resultcount;
            timeoutTimer.Start();
            virtualClient.Logger.LogInfo(resultcount + " search results");
            if (resultcount > 0)
                NextPage();
        }

        internal void ResultReceived(SShopResultPacket packet)
        {
            timeoutTimer.Stop();
            timeoutTimer.Start();
            if (IsSearchOpen == true)
            {
                lock (Results)
                    Results.Add(packet);
            }
            if (Results.Count % SearchQuery.PageSize == 0)
                NextPage();

            if (Results.Count >= Resultcount)
                SearchFinished();
        }

        private void SearchFinished()
        {
            timeoutTimer.Stop();
            IsSearchOpen = false;
            List<ShopSearchTuple> tuples = new List<ShopSearchTuple>(this.Results.Count);
            lock (Results)
            {
                foreach (SShopResultPacket resultPacket in Results)
                {
                    ShopSearchTuple tuple = new ShopSearchTuple()
                    {
                        Count = resultPacket.ItemCount,
                        ItemId = resultPacket.ItemId,
                        Price = resultPacket.Price,
                        ShopId = resultPacket.ShopId,
                        Seller = resultPacket.SellerName,
                        ShopPosition = resultPacket.ShopPosition
                    };
                    //using (MemoryStream ms = new MemoryStream())
                    //{
                    //    ms.Write(BitConverter.GetBytes(resultPacket.ItemCount), 0, sizeof(UInt32));
                    //    ms.Write(BitConverter.GetBytes(resultPacket.ItemId), 0, sizeof(UInt32));
                    //    ms.Write(BitConverter.GetBytes(resultPacket.ShopId), 0, sizeof(UInt32));
                    //    ms.Write(BitConverter.GetBytes(resultPacket.Price), 0, sizeof(UInt64));
                    //    ms.Write(BitConverter.GetBytes(resultPacket.ShopPosition), 0, sizeof(UInt16));
                    //    tuple.Hash = Convert.ToBase64String(ms.ToArray());
                    //}
                    tuples.Add(tuple);
                }
            }

            virtualClient.OnShopSearchFinished(tuples);
            virtualClient.Logger.LogInfo("Fetched " + Results.Count + " results");
        }

        private void NextPage()
        {
            if (Results.Count >= Resultcount)
                return;
            //virtualClient.Logger.LogInfo("Fetch " + Results.Count / SearchQuery.PageSize + " / " + Resultcount / SearchQuery.PageSize + " page");
            CShopGetResultsPacket packet = new CShopGetResultsPacket()
            {
                ResultOffset = CurrentOffset
            };
            CurrentOffset += SearchQuery.PageSize;
            virtualClient.SendPacket(packet);
        }

        public void GetPage(UInt32 offset)
        {
            CShopGetResultsPacket packet = new CShopGetResultsPacket()
            {
                ResultOffset = CurrentOffset
            };
            virtualClient.SendPacket(packet);
        }


    }
}
