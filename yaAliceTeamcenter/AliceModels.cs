using System.Collections.Generic;
using yaAliceTeamcenter;

namespace yaAliceModelInOut
{
    #region [Запрос к Алисе]
    public class AliceRequest
    {
        private const string Version = "1.0";

        public Request request { get; set; }

        public Session session { get; set; }
    }

    public class Request
    {
        public string command { get; set; }
        public string original_utterance { get; set; }
        public string type { get; set; }

        public Nlu nlu { get; set; }

        public Request()
        {
            command = string.Empty;
            original_utterance = string.Empty;
        }
    }

    public class Nlu
    {
        public IList<string> tokens { get; set; }
        public IList<object> entities { get; set; }
        public Intents intents { get; set; }
    }

    public class Session
    {
        public int message_id { get; set; }
        public string session_id { get; set; }
        public string skill_id { get; set; }
        public string user_id { get; set; }
    }

    #endregion [Запрос к Алисе]

    #region [Ответы Алисы]
    public class AliceResponse
    {
        private const string Version = "1.0";

        public Response response { get; set; }
        public SessionResponse session { get; set; }

        public string version { get; set; }

        public AliceResponse()
        {
            response = new Response();
            session = new SessionResponse();
            version = Version;
        }
    }

    public class SessionResponse
    {
        public string session_id { get; set; }
        public int message_id { get; set; }
        public string user_id { get; set; }
    }

    public class Response
    {
        public string text { get; set; }
        public string tts { get; set; }
        public bool end_session { get; set; }

        public IList<Button> buttons { get; set; }

        public Response()
        {
            text = string.Empty;
            tts = string.Empty;
        }
    }

    public class Button
    {
        public string title { get; set; }
        public Payload payload { get; set; }
        public string url { get; set; }
        public bool hide { get; set; }
    }

    public class Payload
    {
        public string button01 { get; set; }
        public string button02 { get; set; }
    }
    #endregion [Ответы Алисы]
}