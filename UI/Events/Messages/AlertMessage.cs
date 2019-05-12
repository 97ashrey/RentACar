using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Events.Messages
{
    public class AlertMessage : IApplicationEvent
    {
        public enum MessageType
        {
            Success,
            Error,
            Warning
        }

        public string Message { get; private set; }
        public MessageType Type { get; private set; }

        public AlertMessage(MessageType type, string message)
        {
            Message = message;
            Type = type;
        }
    }
}
