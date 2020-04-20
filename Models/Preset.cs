using System;
namespace SecuresStd.Models
{
    public class Preset
    {
        public string id { get; set; }
        public string name { get; set; }
        public int expireTime { get; set; }
        public string expireFormat { get; set; }
        public int deviceLimit { get; set; }
        public int sessionLimit { get; set; }
        public string[] tags { get; set; }
        public ProjectID project { get; set; }
    }

    public class PresetID
    {
        public string id { get; set; }
    }
}
