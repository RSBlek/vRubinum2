using System;
using System.Collections.Generic;
using System.Text;

namespace vMt2
{
    enum ClientPacketHeader : byte
    {
        HEADER_CG_CHARACTER_SELECT = 0x06,
        HEADER_CG_ENTER_GAME = 0x0A,
        HEADER_CG_ITEM_MOVE = 0x0D,
        HEADER_CG_ITEM_USE_TO_ITEM = 0x3C,
        HEADER_CG_SENTRY_PARAMETERS = 0x6C,
        HEADER_CG_LOGIN2 = 0x6D,
        HEADER_CG_LOGIN3 = 0x6F,
        HEADER_CG_SHOP_WITHDRAW_GOLD = 0x7D,
        HEADER_CG_SHOP_ADD_ITEM = 0x7B,
        HEADER_CG_SHOP_SEARCH_QUERY = 0xDC,
        HEADER_CG_SHOP_GET_RESULTS = 0xDD,
        HEADER_CG_SHOP_BUY = 0xDE,
        HEADER_CG_PONG = 0xFE,
        HEADER_CG_HANDSHAKE = 0xFF,
    }
}
