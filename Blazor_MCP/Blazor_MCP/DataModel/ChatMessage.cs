namespace Blazor_MCP.DataModel
{
    public class ChatMessage
    {
        public string Sender { get; set; } // "User" or "AI"
        public string Message { get; set; }
        public bool Progressing { get; set; } // Indicates if the message is still being processed        
        public DateTime Timestamp { get; set; }
    }

    public class ChatResult
    {
        public string Result { get; set; }
        public string Emotion { get; set; }
    }
}
