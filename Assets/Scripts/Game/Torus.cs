namespace OnPipe.Game
{
    using OnPipe.Game.Command;
    using OnPipe.Signal;
    using UnityEngine;

    public class Torus : MonoBehaviour, IMoveable, IScaleable
    {
        [SerializeField] private Transform _startingPosition = null;
        [Space(10)]
        [SerializeField] private float _defaultSpeed = 0;
        [SerializeField] private float _defaultScaleSpeed = 0;
        [Space(10)]
        [SerializeField] private float _defaultMaxScale = 0;
        [SerializeField] private float _defaultMinScale = 0;


        private float _speed;
        private float _scaleSpeed;

        private float _maxScale;
        private float _minScale;

        private ICommand _moveUp;
        private ICommand _scaleUp;
        private ICommand _scaleDown;
        
        private void Awake()
        {
            Initialize();
        }

        private void Start()
        {
            SignalBus<SignalTorusLoaded, Torus>.Instance.Fire(this);
        }
        private void Initialize()
        {
            _speed = _defaultSpeed;
            _maxScale = _defaultMaxScale;
            _minScale = _defaultMinScale;
            var move = new Move(this);
            _moveUp = new Command<Move>(move, m => m.MoveUp());
            var scaleIt = new ScaleIt(this);
            _scaleUp = new Command<ScaleIt>(scaleIt, s => s.ScaleUp());
            _scaleDown = new Command<ScaleIt>(scaleIt, s => s.ScaleDown());
            SignalBus<SignalTouched, bool>.Instance.Register(OnTouched);
            SignalBus<SignalTorusTriggered, Pipe>.Instance.Register(OnPipeTriggered);
            SignalBus<SignalPlayGame>.Instance.Register(OnPlayGame);
            SignalBus<SignalLoseGame>.Instance.Register(OnLoseGame);
            SignalBus<SignalRestartGame>.Instance.Register(OnRestartGame);
            SignalBus<SignalWinGame>.Instance.Register(OnWinGame);
            SignalBus<SignalTorusStop>.Instance.Register(() => _speed = 0);
            SignalBus<SignalNextLevel>.Instance.Register(OnRestartGame);
        }


        #region Signal Actions

        private void OnWinGame()
        {
            _speed = _defaultSpeed * 5;
        }

        private void OnRestartGame()
        {
            transform.position = _startingPosition.position;
            _speed = _defaultSpeed;
            _scaleSpeed = 0;
            _minScale = _defaultMinScale;
            _maxScale = _defaultMaxScale;
            transform.localScale = Vector3.one * _defaultMaxScale;
        }

        private void OnLoseGame()
        {
            _scaleSpeed = 0;
            _speed = 0;
        }

        private void OnPlayGame()
        {    
            _scaleSpeed = _defaultScaleSpeed;
            _speed = _defaultSpeed;
        }

        private void OnPipeTriggered(Pipe obj)
        {
            _minScale = obj.GetScale();
        }

        private void OnTouched(bool isTouched)
        {
            if (!isTouched)
            {
                _scaleUp.Execute();
            }
            else
            {
                _scaleDown.Execute();
            }
        }
    
        #endregion

        private void FixedUpdate()
        {
            _moveUp.Execute();
        }

        #region Implementations

        public Transform GetTransform()
        {
            return transform;
        }

        public float GetSpeed()
        {
            return _speed;
        }

        public float GetScaleSpeed()
        {
            return _scaleSpeed;
        }

        public float GetMaxScale()
        {
            return _maxScale;
        }

        public float GetMinScale()
        {
            return _minScale;
        }

        #endregion
    }
}
