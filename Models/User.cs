using System;
namespace SecuresStd.Models
{
    public class User
    {
        public string id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public Limits limits { get; set; }

        public class Limits
        {
            public int projects { get; set; }
            public int licences { get; set; }
            public int presets { get; set; }
        }

    }

    public class UserID
    {
        public string id { get; set; }
    }
}
