namespace OnPipe.Signal
{
    using System;
    using System.Collections.Generic;

    public class SignalBus<T>
    {
        public static SignalBus<T> Instance { get; private set; } = new SignalBus<T>();
        private List<Action> _observer;
        private SignalBus()
        {
            _observer = new List<Action>();
        }

        public void Register(Action action)
        {
            if (_observer.Contains(action))
                return;
            _observer.Add(action);
        }

        public void UnRegister(Action action)
        {
            if (!_observer.Contains(action))
                return;
            _observer.Remove(action);
        }

        public void Fire()
        {
            for (int i = 0; i < _observer.Count; i++)
            {
                _observer[i]();
            }
        }
    }

    public class SignalBus<T,T1>
    {
        public static SignalBus<T,T1> Instance { get; private set; } = new SignalBus<T,T1>();
        private List<Action<T1>> _observer;
        private SignalBus()
        {
            _observer = new List<Action<T1>>();
        }

        public void Register(Action<T1> action)
        {
            if (_observer.Contains(action))
                return;
            _observer.Add(action);
        }

        public void UnRegister(Action<T1> action)
        {
            if (!_observer.Contains(action))
                return;
            _observer.Remove(action);
        }

        public void Fire(T1 t)
        {
            for (int i = 0; i < _observer.Count; i++)
            {
                _observer[i](t);
            }
        }
    }

    public class SignalBus<T, T1, T2>
    {
        public static SignalBus<T, T1, T2> Instance { get; private set; } = new SignalBus<T, T1, T2>();
        private List<Action<T1, T2>> _observer;
        private SignalBus()
        {
            _observer = new List<Action<T1,T2>>();
        }

        public void Register(Action<T1,T2> action)
        {
            if (_observer.Contains(action))
                return;
            _observer.Add(action);
        }

        public void UnRegister(Action<T1,T2> action)
        {
            if (!_observer.Contains(action))
                return;
            _observer.Remove(action);
        }

        public void Fire(T1 t, T2 t2)
        {
            for (int i = 0; i < _observer.Count; i++)
            {
                _observer[i](t,t2);
            }
        }
    }

    public class SignalBus<T, T1, T2, T3>
    {
        public static SignalBus<T, T1, T2, T3> Instance { get; private set; } = new SignalBus<T, T1, T2, T3>();
        private List<Action<T1, T2, T3>> _observer;
        private SignalBus()
        {
            _observer = new List<Action<T1, T2, T3>>();
        }

        public void Register(Action<T1, T2, T3> action)
        {
            if (_observer.Contains(action))
                return;
            _observer.Add(action);
        }

        public void UnRegister(Action<T1, T2, T3> action)
        {
            if (!_observer.Contains(action))
                return;
            _observer.Remove(action);
        }

        public void Fire(T1 t, T2 t2, T3 t3)
        {
            for (int i = 0; i < _observer.Count; i++)
            {
                _observer[i](t,t2,t3);
            }
        }
    }
    public class SignalBus<T, T1, T2, T3, T4>
    {
        public static SignalBus<T, T1, T2, T3, T4> Instance { get; private set; } = new SignalBus<T, T1, T2, T3, T4>();
        private List<Action<T1, T2, T3, T4>> _observer;
        private SignalBus()
        {
            _observer = new List<Action<T1, T2, T3, T4>>();
        }

        public void Register(Action<T1, T2, T3, T4> action)
        {
            if (_observer.Contains(action))
                return;
            _observer.Add(action);
        }

        public void UnRegister(Action<T1, T2, T3, T4> action)
        {
            if (!_observer.Contains(action))
                return;
            _observer.Remove(action);
        }

        public void Fire(T1 t, T2 t2, T3 t3, T4 t4)
        {
            for (int i = 0; i < _observer.Count; i++)
            {
                _observer[i](t,t2,t3,t4);
            }
        }
    }
    public class SignalBus<T, T1, T2, T3, T4, T5>
    {
        public static SignalBus<T, T1, T2, T3, T4, T5> Instance { get; private set; } = new SignalBus<T, T1, T2, T3, T4, T5>();
        private List<Action<T1, T2, T3, T4, T5>> _observer;
        private SignalBus()
        {
            _observer = new List<Action<T1, T2, T3, T4, T5>>();
        }

        public void Register(Action<T1, T2, T3, T4, T5> action)
        {
            if (_observer.Contains(action))
                return;
            _observer.Add(action);
        }

        public void UnRegister(Action<T1, T2, T3, T4, T5> action)
        {
            if (!_observer.Contains(action))
                return;
            _observer.Remove(action);
        }

        public void Fire(T1 t, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            for (int i = 0; i < _observer.Count; i++)
            {
                _observer[i](t,t2,t3,t4,t5);
            }
        }
    }
}
