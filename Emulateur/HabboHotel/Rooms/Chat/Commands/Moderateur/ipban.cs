using Butterfly.HabboHotel.GameClients;
            {
                return;
            }

                if (clientByUsername.GetHabbo().Rank > 5 && Session.GetHabbo().Rank < 13)
                {
                    ButterflyEnvironment.GetGame().GetClientManager().BanUser(Session, "Robot", (double)788922000, "Votre compte � �t� banni par s�curit�", false, false);
                }