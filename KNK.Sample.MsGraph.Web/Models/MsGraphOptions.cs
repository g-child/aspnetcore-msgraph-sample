namespace KNK.Sample.MsGraph.Web.Models
{
    public class MsGraphOptions
    {
        public string Tenant { get; set; }

        public string AuthorityUri => RedirectUri + '/' + Tenant;

        public string RedirectUri { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}
