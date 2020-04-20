using System;
namespace SecuresStd.Models
{
    public class Licence
    {
        public string id { get; set; }
        public string owner { get; set; }
        public string key { get; set; }
        public DateTime validFrom { get; set; }
        public DateTime expireAt { get; set; }
        public int deviceLimit { get; set; }
        public int sessionLimit { get; set; }
        public string[] tags { get; set; }
        public Session[] sessions { get; set; }
        public ProjectID project { get; set; }
    }

    public class LicenceiD
    {
        public string id { get; set; }
    }
}
