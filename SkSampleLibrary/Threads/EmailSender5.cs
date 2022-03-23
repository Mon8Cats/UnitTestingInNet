using System;
using System.Threading;
using System.Threading.Tasks;

namespace SkSampleLibrary.Threads
{
    public class SendEmailOperation
    {
        public void Send(EmailMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            Thread.Sleep(100);
            Console.WriteLine($"Message has been sent. Message: {message}");
        }
    }

    public class EmailSender5
    {
        private readonly SendEmailOperation _sendEmailOperation;

        public EmailSender5(SendEmailOperation sendEmailOperation)
        {
            _sendEmailOperation = sendEmailOperation;
        }

        public void SendEmail(EmailMessage message)
        {
            Task.Run(() =>
            {
                _sendEmailOperation.Send(message);
            });
        }
    }
}
