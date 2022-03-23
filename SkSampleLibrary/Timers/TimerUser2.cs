using System.Threading;
using System.Collections.Generic;

namespace SkSampleLibrary.Timers
{
    public interface ITimerCallback
    {
        void OnCallbackExecuted();
    }

    public class TimerUser2
    {
        Queue<string> _messagesQueue;

        Timer _timer;
        ITimerCallback _timerCallback;

        public string MessageText { get; private set; }

        public int WaitingMessageCount => _messagesQueue.Count;

        public TimerUser2()
        {
            _messagesQueue = new Queue<string>();
            _timer = new Timer(timerTick, null, Timeout.Infinite, 100);
        }

        public TimerUser2(ITimerCallback timerCallback) : this()
        {
            _timerCallback = timerCallback;
        }

        public void Add(string message)
        {
            _messagesQueue.Enqueue(message);
        }

        public void Start()
        {
            _timer.Change(0, 100);
        }

        public void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void timerTick(object state)
        {
            if (_messagesQueue.Count > 0)
            {
                this.MessageText += _messagesQueue.Dequeue();
            }

            if (_timerCallback != null)
                _timerCallback.OnCallbackExecuted();
        }
    }
}
