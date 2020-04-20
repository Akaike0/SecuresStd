using System;
namespace SecuresStd.Models
{
    public class Project
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool online { get; set; }
        public Preset[] presets { get; set; }
        public Licence[] licences { get; set; }
        public LicenceiD lastLicence { get; set; }
        public UserID user { get; set; }
        public DateTime createdAt { get; set; }
    }

    public class ProjectID
    {
        public string id { get; set; }
    }
}
