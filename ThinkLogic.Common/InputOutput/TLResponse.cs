using System.Net;
using static ThinkLogic.Common.InputOutput.Message;

namespace ThinkLogic.Common.InputOutput
{
    public class TLResponse<T>
    {
        public HttpStatusCode? StatusCode { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();
        public T? Data { get; set; }
        public bool HasStopEventMessages => Messages.Exists(x => x.Type >= Message.MessageTypeEnum.Caution);
        public bool HasMessages => Messages.Count > 0;
        public bool HasMessageByType(MessageTypeEnum type) => Messages.Exists(x => x.Type == type);
    }
}
