namespace OnPipe.Manager
{
    using OnPipe.Factory;
    using OnPipe.Game;
    using OnPipe.Signal;
    using OnPipe.Constant;
    using System.Collections.Generic;
    using OnPipe.Enum;
    using System;

    public class LevelManager
    {
        public static LevelManager Instance { get; private set; } = new LevelManager();

        private IFactory<Pipe> _pipeFactory;
        private IFactory<Pipe> _finishPipeFactory;
        
        private Queue<Pipe> _mustDestroyPipes;

        private Pipe _lastPipe;

        private bool _isStarted;

        private int _counter;
        
        private LevelManager()
        {
            _pipeFactory = new Factory<Pipe, SignalPipeDestroyed>(Constant.PipePath);
            _finishPipeFactory = new Factory<Pipe, SignalFinishPipeDestroyed>(Constant.FinishPipePath);
            _mustDestroyPipes = new Queue<Pipe>();
        }
        
        public void Initialize()
        {
            SignalBus<SignalNextLevel>.Instance.Register(NewGame);
            SignalBus<SignalRestartGame>.Instance.Register(NewGame);
            SignalBus<SignalDestroyPipeInGame, Pipe>.Instance.Register(OnDestroyQueue);
            SignalBus<SignalPlayGame>.Instance.Register(() => _isStarted = true);
            for(int i = 0; i < Constant.PipeCount; i++)
            {
                AddNewPipe();
            }
        }

        private void OnDestroyQueue(Pipe obj)
        {
            if (_isStarted)
            {
                if(++_counter > Constant.LevelLength)
                {
                    Pipe finishPipe = _finishPipeFactory.GetObject();
                    finishPipe.SetPosition(_lastPipe);
                    finishPipe.Active();
                    _lastPipe = finishPipe;
                    _counter = 0;
                }
            }

            _mustDestroyPipes.Enqueue(obj);
            if(_mustDestroyPipes.Count > Constant.PipeSpawnDelayCount)
            {
                _mustDestroyPipes.Dequeue().DeActive();
                AddNewPipe();
            }
        }

        private void NewGame()
        {
            SignalBus<SignalDestroyPipeInGame>.Instance.Fire();
            _mustDestroyPipes.Clear();
            _lastPipe = null;
            _isStarted = false;
            _counter = 0;
            for (int i = 0; i < Constant.PipeCount; i++)
            {
                AddNewPipe();
            }
        }

        private void AddNewPipe()
        {
            Pipe newPipe = _pipeFactory.GetObject();
            newPipe.SetPosition(_lastPipe);
            newPipe.Active();
            _lastPipe = newPipe;
        }

    }
}
