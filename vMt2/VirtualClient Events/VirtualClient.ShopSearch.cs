using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using vMt2.Models;
using vMt2.Packets;

namespace vMt2
{
    public partial class VirtualClient
    {
        public delegate void ShopSearchFinishedDelegate(VirtualClient virtualClient, List<ShopSearchTuple> tuples);
        public event ShopSearchFinishedDelegate ShopSearchFinishedCallback;

        internal void OnShopSearchFinished(List<ShopSearchTuple> tuples)
        {
            Task.Run(() => {
                ShopSearchFinishedCallback?.Invoke(this, tuples);
            });
        }

    }
}
