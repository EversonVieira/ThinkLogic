namespace ThinkLogic.Common.InputOutput
{
    public class Message
    {
        public string? Code { get; set; }
        public string? Text { get; set; }
        public string? Title { get; set; }
        public MessageTypeEnum? Type { get; set; }
        public enum MessageTypeEnum
        {
            Information = 0,
            
            Created = 1,
            Updated = 2,
            Success = 3,

            Caution = 4,
            Validation = 5,
            Error = 6,
            Exception = 7,
        }
    }
}
