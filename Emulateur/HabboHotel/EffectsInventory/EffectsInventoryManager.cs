using Butterfly.Database.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace Butterfly.HabboHotel.EffectsInventory
{
    public class EffectsInventoryManager
    {
        private readonly List<int> Effects;
        private readonly List<int> EffectsStaff;

        public List<int> GetEffects()
        {
            return this.Effects;
        }

        public EffectsInventoryManager()
        {
            this.Effects = new List<int>();
            this.EffectsStaff = new List<int>();
        }

        public void Init()
        {
            this.Effects.Clear();
            this.EffectsStaff.Clear();

            using (IQueryAdapter dbClient = ButterflyEnvironment.GetDatabaseManager().GetQueryReactor())
            {
                dbClient.SetQuery("SELECT * FROM systeme_effects ORDER by id ASC");
                DataTable table = dbClient.GetTable();
                if (table == null)
                    return;

                foreach (DataRow dataRow in table.Rows)
                {
                    int EffectId = (int)dataRow["id"];
                    bool OnlyStaff = ButterflyEnvironment.EnumToBool((string)dataRow["only_staff"]);

                    if (OnlyStaff)
                    {
                        if (!this.EffectsStaff.Contains(EffectId))
                            this.EffectsStaff.Add(EffectId);
                    }
                    else
                    {
                        if (!this.Effects.Contains(EffectId))
                            this.Effects.Add(EffectId);
                    }
                }
            }
        }

        public bool EffectExist(int EffectId, bool Staff = false)
        {
            if (this.Effects.Contains(EffectId))
                return true;
            if (Staff && this.EffectsStaff.Contains(EffectId))
                return true;

            return false;
        }
    }
}
