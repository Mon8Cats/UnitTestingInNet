using System;
using System.Threading;
using System.Threading.Tasks;

namespace SkSampleLibrary.Threads
{
    public delegate void MessageEndHandler(EmailMessage message);
    public delegate void FailureHandler(EmailMessage message, Exception ex);

    public class EmailSender3
    {
        public event MessageEndHandler MessageSent;
        public event FailureHandler MessageFailed;

        public void SendEmail(EmailMessage message)
        {
            Task.Run(() =>
            {
                try
                {
                    if (message == null)
                        throw new ArgumentNullException("message");

                    Thread.Sleep(100);
                    Console.WriteLine($"Message has been sent. Message: {message}");

                    MessageSent?.Invoke(message);
                }
                catch(Exception ex)
                {
                    MessageFailed?.Invoke(message, ex);
                }
            });
        }
    }
}
