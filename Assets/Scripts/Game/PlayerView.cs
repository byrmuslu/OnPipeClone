using System;
using OnPipe.Signal;

namespace OnPipe.Game
{
    public class PlayerView
    {
        private int _currentLevel;
        public int CurrentLevel
        {
            get => _currentLevel;
            set
            {
                if(value != _currentLevel)
                {
                    _currentLevel = value;
                    SignalBus<SignalCurrentLevelChanged, int>.Instance.Fire(value);
                }
            }
        }
        private int _highScore;
        public int HighScore
        {
            get => _highScore;
            set
            {
                if(value != _highScore)
                {
                    _highScore = value;
                    SignalBus<SignalHighScoreChanged, int>.Instance.Fire(value);
                }
            }
        }
        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                if(_score != value)
                {
                    _score = value;
                    SignalBus<SignalScoreChanged, int>.Instance.Fire(value);
                    if(value > HighScore)
                    {
                        HighScore = value;
                    }
                }
            }
        }
        
        public PlayerView(PlayerData playerData)
        {
            CurrentLevel = playerData.currentLevel;
            HighScore = playerData.highScore;
            Score = 0;
        }

        public void Initialize()
        {
            SignalBus<SignalScoreIncrease>.Instance.Register(OnScoreIncreased);
            SignalBus<SignalScoreIncrease, int>.Instance.Register(OnScoreIncreased);
            SignalBus<SignalRestartGame>.Instance.Register(() => Score = 0 );
            SignalBus<SignalNextLevel>.Instance.Register(() => CurrentLevel++ );
        }

        private void OnScoreIncreased()
        {
            Score++;
        }

        private void OnScoreIncreased(int amount)
        {
            Score += amount;
        }
    }
}
