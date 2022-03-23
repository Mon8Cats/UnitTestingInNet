using System.Threading;

namespace SkSampleLibrary.Timers
{
    public class TimerUser1
    {
        Timer _timer;

        public int SpinCount { get; private set; }

        public TimerUser1()
        {
            _timer = new Timer(timerTick, null, Timeout.Infinite, 100);
        }

        public void Start()
        {
            _timer.Change(0, 100);
        }

        public void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
        
        public void timerTick(object state)
        {
            SpinCount += 1;
        }               
    }
}
