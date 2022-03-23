using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkSampleLibrary.Threads
{
    public class EmailSender6
    {
        private readonly TaskScheduler _taskScheduler;

        public EmailSender6(TaskScheduler taskScheduler=null)
        {
            _taskScheduler = taskScheduler ?? TaskScheduler.Default;
        }

        public void SendEmail(EmailMessage message)
        {
            Task.Factory.StartNew(() =>
            {
                if (message == null)
                    throw new ArgumentNullException("message");

                Thread.Sleep(100);
                Console.WriteLine($"Message has been sent. Message: {message}");
            },
            CancellationToken.None,
            TaskCreationOptions.None,
            _taskScheduler);            
        }
    }
}
