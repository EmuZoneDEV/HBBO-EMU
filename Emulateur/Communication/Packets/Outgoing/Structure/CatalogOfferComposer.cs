using Butterfly.HabboHotel.Catalog;
using Butterfly.HabboHotel.Catalog.Utilities;
using Butterfly.HabboHotel.Items;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    class CatalogOfferComposer : ServerPacket
    {
        public CatalogOfferComposer(CatalogItem Item)
            : base(ServerPacketHeader.CatalogOfferMessageComposer)
        {
            base.WriteInteger(Item.Id);
            base.WriteString(Item.Name);
            base.WriteBoolean(false);//IsRentable
            base.WriteInteger(Item.CostCredits);

            if (Item.CostDiamonds > 0)
            {
                base.WriteInteger(Item.CostDiamonds);
                base.WriteInteger(105); // Diamonds
            }
            else
            {
                base.WriteInteger(Item.CostDuckets);
                base.WriteInteger(0);
            }

            base.WriteBoolean(ItemUtility.CanGiftItem(Item));

            base.WriteInteger(string.IsNullOrEmpty(Item.Badge) || Item.Data.Type.ToString() == "b" ? 1 : 2);

            if (!string.IsNullOrEmpty(Item.Badge))
            {
                base.WriteString("b");
                base.WriteString(Item.Badge);
            }


            if (Item.Data.Type.ToString().ToLower() != "b")
            {
                base.WriteString(Item.Data.Type.ToString());
                base.WriteInteger(Item.Data.SpriteId);
                if (Item.Data.InteractionType == InteractionType.WALLPAPER || Item.Data.InteractionType == InteractionType.FLOOR || Item.Data.InteractionType == InteractionType.LANDSCAPE)
                {
                    base.WriteString(Item.Name.Split('_')[2]);
                }
                else if (Item.Data.InteractionType == InteractionType.bot)//Bots
                {
                    CatalogBot CatalogBot = null;
                    if (!ButterflyEnvironment.GetGame().GetCatalog().TryGetBot(Item.ItemId, out CatalogBot))
                        base.WriteString("hd-180-7.ea-1406-62.ch-210-1321.hr-831-49.ca-1813-62.sh-295-1321.lg-285-92");
                    else
                        base.WriteString(CatalogBot.Figure);
                }
                else
                {
                    base.WriteString("");
                }
                base.WriteInteger(Item.Amount);
                base.WriteBoolean(Item.IsLimited); // IsLimited
                if (Item.IsLimited)
                {
                    base.WriteInteger(Item.LimitedEditionStack);
                    base.WriteInteger(Item.LimitedEditionStack - Item.LimitedEditionSells);
                }
            }
            base.WriteInteger(0); //club_level
            base.WriteBoolean(ItemUtility.CanSelectAmount(Item));

            base.WriteBoolean(false);// TODO: Figure out
            base.WriteString("");//previewImage -> e.g; catalogue/pet_lion.png
        }
    }
}
