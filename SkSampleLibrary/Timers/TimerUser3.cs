using System.Collections.Generic;
using System.Threading;

namespace SkSampleLibrary.Timers
{
    public class FunctionalityClass
    {
        Queue<string> _messagesQueue;

        public string MessageText { get; private set; }

        public int WaitingMessageCount => _messagesQueue.Count;

        public FunctionalityClass()
        {
            _messagesQueue = new Queue<string>();
        }

        public void Add(string message)
        {
            _messagesQueue.Enqueue(message);
        }

        public void DoWork()
        {
            if (_messagesQueue.Count > 0)
            {
                this.MessageText += _messagesQueue.Dequeue();
            }
        }
    }

    public class TimerUser3
    {
        Timer _timer;
        FunctionalityClass _functionality;

        public TimerUser3(FunctionalityClass functionality)
        {
            _functionality = functionality;
            _timer = new Timer(timerTick, null, Timeout.Infinite, 100);
        }

        public void Add(string message)
        {
            _functionality.Add(message);
        }

        public void Start()
        {
            _timer.Change(0, 100);
        }

        public void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
        
        internal void timerTick(object state)
        {
            _functionality.DoWork();
        }
    }
}
