using System.Linq;

using Butterfly.HabboHotel.Items;
using Butterfly.HabboHotel.Catalog;
using Butterfly.HabboHotel.Catalog.Utilities;

namespace Butterfly.Communication.Packets.Outgoing.Structure
{
    public class CatalogPageComposer : ServerPacket
    {
        public CatalogPageComposer(CatalogPage Page, string CataMode, Core.Language Langue)
            : base(ServerPacketHeader.CatalogPageMessageComposer)
        {
            base.WriteInteger(Page.Id);
            base.WriteString(CataMode);
            base.WriteString(Page.Template);

            base.WriteInteger(Page.PageStrings1.Count);
            foreach (string s in Page.PageStrings1)
            {
                base.WriteString(s);
            }
            
            if (Page.GetPageStrings2ByLangue(Langue).Count == 1 && (Page.Template == "default_3x3" || Page.Template == "default_3x3_color_grouping") && string.IsNullOrEmpty(Page.GetPageStrings2ByLangue(Langue)[0]))
            {
                base.WriteInteger(1);
                base.WriteString(string.Format(ButterflyEnvironment.GetLanguageManager().TryGetValue("catalog.desc.default", Langue), Page.GetCaptionByLangue(Langue)));
            } else {
                base.WriteInteger(Page.GetPageStrings2ByLangue(Langue).Count);
                foreach (string s in Page.GetPageStrings2ByLangue(Langue))
                {
                    base.WriteString(s);
                }
            }

            if (!Page.Template.Equals("frontpage") && !Page.Template.Equals("club_buy"))
            {
                base.WriteInteger(Page.Items.Count);
                foreach (CatalogItem Item in Page.Items.Values)
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
            else
                base.WriteInteger(0);
            base.WriteInteger(-1);
            base.WriteBoolean(false);

            base.WriteInteger(ButterflyEnvironment.GetGame().GetCatalog().GetPromotions().ToList().Count);//Count
            foreach (CatalogPromotion Promotion in ButterflyEnvironment.GetGame().GetCatalog().GetPromotions().ToList())
            {
                base.WriteInteger(Promotion.Id);
                base.WriteString(Promotion.Title);
                base.WriteString(Promotion.Image);
                base.WriteInteger(Promotion.Unknown);
                base.WriteString(Promotion.PageLink);
                base.WriteInteger(Promotion.ParentId);
            }
        }
    }
}