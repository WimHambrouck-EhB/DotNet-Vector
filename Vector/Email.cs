using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    class Email
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public List<string> To { get; set; }
        public DateTime Received { get; set; }

        public override string ToString()
        {
            return $"From: {From}\n" +
                $"To: {string.Join(", ", To)}\n" +
                $"Received: {Received}\n\n" +
                $"{Body}";

        }
    }
}
