using System.Collections.Generic;
using System.Threading;

namespace SkSampleLibrary.Timers
{
    public interface ITimer
    {
        event TimerCallback Tick;

        void Start(int initialDelay, int period);
        void Stop();
    }

    public class RealTimerWrapper : ITimer
    {
        Timer _timer;

        public event TimerCallback Tick;

        public RealTimerWrapper()
        {
            _timer = new Timer(timer_Callback, null, Timeout.Infinite, Timeout.Infinite);
        }

        public void Start(int initialDelay, int period)
        {
            _timer.Change(initialDelay, period);
        }

        public void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void timer_Callback(object state)
        {
            var tickEvent = this.Tick;
            if (tickEvent != null)
                tickEvent(null);
        }
    }

    public class TimerUser4
    {
        Queue<string> _messagesQueue;
        ITimer _timer;

        public string MessageText { get; private set; }

        public int WaitingMessageCount => _messagesQueue.Count;

        public TimerUser4(ITimer timer)
        {
            _timer = timer;
            _timer.Tick += timer_Tick;

            _messagesQueue = new Queue<string>();          
        }        

        public void Add(string message)
        {
            _messagesQueue.Enqueue(message);
        }

        public void Start()
        {
            _timer.Start(0, 100);
        }

        public void Stop()
        {
            _timer.Stop();
        }
       
        private void timer_Tick(object state)
        {
            if (_messagesQueue.Count > 0)
            {
                this.MessageText += _messagesQueue.Dequeue();
            }
        }
    }
}
