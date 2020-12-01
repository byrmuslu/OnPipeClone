namespace OnPipe.Manager
{
    using OnPipe.Enum;
    using OnPipe.Factory;
    using OnPipe.Game;
    using OnPipe.Signal;
    using OnPipe.Constant;
    using UnityEngine;
    using System;

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public PlayerView Player { get; private set; }

        private void Awake()
        {
            if(Instance != null)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }
        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            Player = FileManager.Instance.GetPlayer();
            Player.Initialize();
            LevelManager.Instance.Initialize();
            SignalBus<SignalGameLoaded>.Instance.Fire();
            SignalBus<SignalDestroyPipeInGame>.Instance.Register(() => { foreach (Pipe pipe in FindObjectsOfType<Pipe>()) { Destroy(pipe.gameObject); } });
            SignalBus<SignalVibrate>.Instance.Register(() => Handheld.Vibrate() );
        }
        
    }
}
