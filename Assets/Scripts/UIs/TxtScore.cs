namespace OnPipe.UI.Text
{
    using UnityEngine;
    using UnityEngine.UI;
    using OnPipe.Signal;
    using System;

    public class TxtScore : MyUI
    {
        [SerializeField] private Text _txtScore = null;

        private void Awake()
        {
            SignalBus<SignalScoreChanged, int>.Instance.Register(OnScoreChanged);
            SignalBus<SignalRestartGame>.Instance.Register(DeActive);
            SignalBus<SignalPlayGame>.Instance.Register(Active);
            SignalBus<SignalLoseGame>.Instance.Register(Active);
            SignalBus<SignalGameLoaded>.Instance.Register(DeActive);
            SignalBus<SignalNextLevel>.Instance.Register(DeActive);
        }
        
        private void OnScoreChanged(int obj)
        {
            _txtScore.text = obj.ToString();
        }
    }
}
