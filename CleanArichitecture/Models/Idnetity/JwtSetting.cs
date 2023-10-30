namespace CleanArichitecture.Application.Models.Idnetity
{
    public class JwtSetting
    {
        public string Key { get; set; }
        public string IsSure { get; set; }
        public string Audience { get; set; }
        public string DurationInMinutes { get; set; }
    }
}