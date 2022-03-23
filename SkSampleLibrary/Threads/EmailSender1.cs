using System;
using System.Threading;
using System.Threading.Tasks;

namespace SkSampleLibrary.Threads
{
    public class EmailSender1
    {
        public void SendEmail(EmailMessage message)
        {
            Task.Run(() =>
            {
                if (message == null)
                    throw new ArgumentNullException("message");

                Thread.Sleep(100);
                Console.WriteLine( $"Message has been sent. Message: {message}");
            });
        }
    }
}
