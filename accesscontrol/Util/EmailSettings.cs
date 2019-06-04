namespace accesscontrol.Util
{
    public class EmailSettings
    {
        public string SmtpClient { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string From { get; set; }
        public string Password { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}