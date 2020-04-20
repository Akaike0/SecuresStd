using System.Collections.Generic;
using SecuresStd.Models;

namespace SecuresStd.API
{
    public class Responses
    {
        public class IProjectsResponse
        {
            public List<Project> Projects { get; set; }
        }

        public class IUseAPIResponse
        {
            public User user { get; set; }
        }

        public class IValidateLicenceResponse
        {
            public bool validateLicence { get; set; }
        }

        public class IStartSessionResponse
        {
            public StartSession startSession { get; set; }
            public class StartSession
            {
                public bool success { get; set; }
                public string msg { get; set; }
                public string sessionID { get; set; }
                public string deviceID { get; set; }
            }
        }

        public class IValidateSessionResponse
        {
            public bool validateSession { get; set; }
        }

        public class IGetLicenceByKeyResponse
        {
            public Licence licenceByKey { get; set; }
        }

        public class ICreateLicenceResponse
        {
            public Licence createLicence { get; set; }
        }

        public class IDeleteLicenceResponse
        {
            public bool deleteLicence { get; set; }
        }

        public class IUpdateLicenceResponse
        {
            public bool updateLicence { get; set; }
        }

        public class ICreatePresetResponse
        {
            public Preset createPreset { get; set; }
        }

        public class IUpdatePresetResponse
        {
            public bool updatePreset { get; set; }
        }

        public class IDeletePresetResponse
        {
            public bool deletePreset { get; set; }
        }
    }
}