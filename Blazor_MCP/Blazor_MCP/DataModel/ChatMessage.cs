namespace Blazor_MCP.DataModel
{
    public class ChatMessage
    {
        public string Sender { get; set; } // "User" or "AI"
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
