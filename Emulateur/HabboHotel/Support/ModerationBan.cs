// Type: Butterfly.HabboHotel.Support.ModerationBan





namespace Butterfly.HabboHotel.Support
{
    public struct ModerationBan
  {
    public ModerationBanType Type;
    public double Expire;

    public bool Expired
    {
      get
      {
        return (double) ButterflyEnvironment.GetUnixTimestamp() >= this.Expire;
      }
    }

    public ModerationBan(ModerationBanType Type, double Expire)
    {
      this.Type = Type;
      this.Expire = Expire;
    }
  }
}
