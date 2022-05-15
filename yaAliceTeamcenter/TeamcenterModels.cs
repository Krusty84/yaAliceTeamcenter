using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TCUtils
{
    #region [.../Core-2011-06-Session/login]

    public class TeamcenterResponce
    {
        [JsonProperty(".QName")]
        public string QName { get; set; }

        public ServerInfo serverInfo { get; set; }
        public List<Query> queries { get; set; }
        public PartialErrors PartialErrors { get; set; }
        public int StatusCode { get; set; }
        public string AuthCookie { get; set; }
    }

    public class ServerInfo
    {
        public string DisplayVersion { get; set; }
        public string HostName { get; set; }
        public string Locale { get; set; }
        public string LogFile { get; set; }
        public string SiteLocale { get; set; }
        public string TcServerID { get; set; }
        public string UserID { get; set; }
        public string Version { get; set; }
    }

    public class Query
    {
        public string query { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class PartialErrors
    {
    }

    #endregion [.../Core-2011-06-Session/login]

    #region [...Core-2007-01-Session/getTCSessionInfo]

    public class TCSessionInfo
    {
        [JsonProperty(".QName")]
        public string QName { get; set; }

        public string serverVersion { get; set; }
        public string transientVolRootDir { get; set; }
        public bool isInV7Mode { get; set; }
        public int moduleNumber { get; set; }
        public bool bypass { get; set; }
        public bool journaling { get; set; }
        public bool appJournaling { get; set; }
        public bool secJournaling { get; set; }
        public bool admJournaling { get; set; }
        public bool privileged { get; set; }
        public bool isPartBOMUsageEnabled { get; set; }
        public bool isSubscriptionMgrEnabled { get; set; }
        public TCSessionExtraInfo extraInfo { get; set; }
    }

    public class TCSessionExtraInfo
    {
        public string DisplayVersion { get; set; }
        public string TCServerLocale { get; set; }
        public string TcServerEncoding { get; set; }
        public string TcServerID { get; set; }
        public string TransportSchema { get; set; }
        public string displayCurrentCountryPage { get; set; }
        public string hostName { get; set; }
        public string locationCodePref { get; set; }
        public string syslogFile { get; set; }
        public string systemType { get; set; }
    }

    #endregion [...Core-2007-01-Session/getTCSessionInfo]

    #region [.../Internal-AWS2-2019-06-Finder/performSearchViewModel4]

    public class ExistPRs
    {
        [JsonPropertyName("totalFound")]
        public int TotalFound { get; set; }

        [JsonPropertyName("totalLoaded")]
        public int TotalLoaded { get; set; }

        [JsonPropertyName("ServiceData")]
        public ServiceData ServiceData { get; set; }
    }

    public class ServiceData
    {
        [JsonPropertyName("plain")]
        public List<string> Plain { get; set; }

        [JsonPropertyName("modelObjects")]
        public Dictionary<string, ModelObject> ModelObjects { get; set; }
    }

    public partial class ModelObject
    {
        public string ObjectId { get; set; }
        public string Uid { get; set; }
        public string ClassName { get; set; }
        public string Type { get; set; }
        public Props Props { get; set; }
    }

    public class Props
    {
        public ItemRevisionId item_revision_id { get; set; }
        public ItemId item_id { get; set; }
        public ObjectDesc object_desc { get; set; }
        public ObjectName object_name { get; set; }
        public CreationDate creation_date { get; set; }
        public OwningUser owning_user { get; set; }
    }

    public class ItemRevisionId
    {
        public List<string> dbValues { get; set; }
        public List<string> uiValues { get; set; }
    }

    public class ObjectName
    {
        public List<string> dbValues { get; set; }
        public List<string> uiValues { get; set; }
    }

    public class ItemId
    {
        public List<string> dbValues { get; set; }
        public List<string> uiValues { get; set; }
    }

    public class ObjectDesc
    {
        public List<string> dbValues { get; set; }
        public List<string> uiValues { get; set; }
    }

    public class CreationDate
    {
        public List<DateTime> dbValues { get; set; }
        public List<string> uiValues { get; set; }
    }

    public class OwningUser
    {
        public List<string> dbValues { get; set; }
        public List<string> uiValues { get; set; }
    }

    #endregion [.../Internal-AWS2-2019-06-Finder/performSearchViewModel4]
}