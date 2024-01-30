using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMauiApp
{
    public class AlertMessageEventArgs : EventArgs
    {
        public string Title { get; }
        public string Message { get; }
        public string Cancel { get; }

        public AlertMessageEventArgs(string title, string message, string cancel)
        {
            Title = title;
            Message = message;
            Cancel = cancel;
        }
    }
}
