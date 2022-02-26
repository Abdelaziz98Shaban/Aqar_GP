namespace Aqar_GP.Helpers
{
    public class JWT
    {
        public int Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int DurationInDays { get; set; }
    }
}
