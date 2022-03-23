using System;
using System.Threading;
using System.Threading.Tasks;

namespace SkSampleLibrary.Threads
{
    public interface IThreadCallback
    {
        void OnMessageSent(EmailMessage message);
        void OnFailure(EmailMessage message, Exception ex);
    }

    public class EmailSender4
    {
        private readonly IThreadCallback _callback;

        public EmailSender4(IThreadCallback callback=null)
        {
            _callback = callback;
        }

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

                    _callback?.OnMessageSent(message);
                }
                catch(Exception ex)
                {
                    _callback?.OnFailure(message, ex);
                }
            });
        }
    }
}
