namespace OnPipe.Game
{
    using OnPipe.Util;
    using OnPipe.Constant;
    using OnPipe.Signal;
    using UnityEngine;

    public class Pipe : MonoBehaviour
    {
        [SerializeField] private Transform _endPoint = null;
        public Vector3 EndPoint { get => _endPoint.position; }
        [SerializeField] private GameObject[] _obstacles = null;
        [SerializeField] private bool _isFinishPipe = false;

        private bool _gameStarted;

        private void Awake()
        {
            SignalBus<SignalPlayGame>.Instance.Register(() => _gameStarted = true );
            SignalBus<SignalLoseGame>.Instance.Register(() => _gameStarted = false );
            SignalBus<SignalWinGame>.Instance.Register(() => _gameStarted = false);
        }

        private void OnEnable()
        {
            if (!_gameStarted)
            {
                foreach(GameObject obstacle in _obstacles)
                {
                    obstacle.SetActive(false);
                }
            }
            else
            {
                foreach(GameObject obstacle in _obstacles)
                {
                    if(Random.Range(0, Constant.ObstacleSpawnRate) == 0)
                    {
                        obstacle.SetActive(true);
                    }
                    else
                    {
                        obstacle.SetActive(false);
                    }
                }
            }
        }

        private void OnDisable()
        {
        }

        public void SetPosition(Pipe before = null)
        {
            if(before == null)
            {
                transform.position = Vector3.zero;
            }
            else
            {
                transform.position = before.EndPoint;
            }
        }
        
        public void Active()
        {
            SetScale();
            gameObject.SetActive(true);
        }

        public void DeActive()
        {
            gameObject.SetActive(false);
            if (!_isFinishPipe)
                SignalBus<SignalPipeDestroyed, Pipe>.Instance.Fire(this);
            else
                SignalBus<SignalFinishPipeDestroyed, Pipe>.Instance.Fire(this);
        }
        
        private void SetScale()
        {
            float scaleX = Util.GetRandomScaleValue();
            float scaleY = transform.localScale.y;
            float scaleZ = scaleX;
            transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        }
        
        public float GetScale()
        {
            return transform.localScale.x;
        }

    }
}
