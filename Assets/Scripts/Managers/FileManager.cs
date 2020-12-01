using System;
using OnPipe.Game;
using OnPipe.Signal;
using UnityEngine;

namespace OnPipe.Manager
{
    public class FileManager : IFileManager
    {
        public static IFileManager Instance { get; private set; } = new FileManager();
        private PlayerData _playerData;
        private PlayerView _playerView;
        private FileManager() { }

        private void OnHighScoreChanged(int obj)
        {
            _playerData.highScore = obj;
            SavePlayer();
        }

        private void OnCurrentLevelChanged(int obj)
        {
            _playerData.currentLevel = obj;
            SavePlayer();
        }

        private void SavePlayer()
        {
            PlayerPrefs.SetString("PlayerData", JsonUtility.ToJson(_playerData));
        }

        public PlayerView GetPlayer()
        {
            if (_playerView != null)
                return _playerView;
            if (PlayerPrefs.HasKey("PlayerData"))
            {
                _playerData = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("PlayerData"));
            }
            else
            {
                _playerData = new PlayerData() { currentLevel = 0, highScore = 0 };
            }
            
            SignalBus<SignalCurrentLevelChanged, int>.Instance.Register(OnCurrentLevelChanged);
            SignalBus<SignalHighScoreChanged, int>.Instance.Register(OnHighScoreChanged);
            _playerView = new PlayerView(_playerData);
            return _playerView;
        }
    }
}
