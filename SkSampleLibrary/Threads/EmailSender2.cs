using System;
using System.Threading;
using System.Threading.Tasks;

namespace SkSampleLibrary.Threads
{
    public class EmailSender2
    {
        public void SendEmail(EmailMessage message)
        {
            Task.Run(() =>
            {
                SendEmailInternal(message);
            });
        }

        public void SendEmailInternal(EmailMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            Thread.Sleep(100);
            Console.WriteLine($"Message has been sent. Message: {message}");
        }
    }
}
