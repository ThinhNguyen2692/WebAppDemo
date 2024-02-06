namespace WebAppDemo.Models
{
    public  class JwtSettings
    {
        public string Issuer { get; set; }
        public int ExpireMinutes { get; set; }
        public string Key { get; set; }
    }
}
