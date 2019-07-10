using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boris_Client.Models
{
    public class ChatMessage
    {
        public ChatMessage(string sender, string message)
        {
            Sender = sender;
            Message = message;
        }

        public string Message { get; set; }
        public string Sender { get; set; }
    }
}
