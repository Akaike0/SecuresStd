using System;
namespace SecuresStd.Models
{
    public class Session
    {
        public string id { get; set; }
        public string sessionID { get; set; }
        public string device { get; set; }
        public LicenceiD licence { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
