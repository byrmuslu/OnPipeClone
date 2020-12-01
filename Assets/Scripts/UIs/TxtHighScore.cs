namespace OnPipe.UI.Text
{
    using UnityEngine;
    using UnityEngine.UI;
    using OnPipe.Signal;

    public class TxtHighScore : MyUI
    {
        [SerializeField] private Text _txtHighScore = null;

        private void Awake()
        {
            SignalBus<SignalHighScoreChanged, int>.Instance.Register(OnHighScoreChanged);
            SignalBus<SignalPlayGame>.Instance.Register(DeActive);
            SignalBus<SignalRestartGame>.Instance.Register(Active);
            SignalBus<SignalLoseGame>.Instance.Register(Active);
            SignalBus<SignalWinGame>.Instance.Register(Active);
        }
        
        private void OnHighScoreChanged(int obj)
        {
            _txtHighScore.text = obj.ToString();
        }
    }
}
