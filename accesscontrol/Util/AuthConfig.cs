using Microsoft.IdentityModel.Tokens;

namespace accesscontrol.Util
{
    public class AuthConfig
    {

        public string SigningKey
        {
            get { return signingKey; }
            set { signingKey = value; }
        }


        public string Audience
        {
            get { return audience; }
            set { audience = value; }
        }

        public string Issuer
        {
            get { return issuer; }
            set { issuer = value; }
        }

        private string issuer { get; set; }
        private string audience { get; set; }
        private string signingKey { get; set; }

        public SymmetricSecurityKey SymmetricSigningKey
        {
            get { return new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(this.SigningKey)); }
        }
    }
}