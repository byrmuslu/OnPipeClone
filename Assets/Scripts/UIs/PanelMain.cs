namespace OnPipe.UI.Panel
{
    using OnPipe.Signal;
    using UnityEngine;

    public class PanelMain : MyUI
    {
        private void Awake()
        {
            SignalBus<SignalRestartGame>.Instance.Register(Active);
            SignalBus<SignalLoseGame>.Instance.Register(DeActive);
            SignalBus<SignalWinGame>.Instance.Register(DeActive);
            SignalBus<SignalNextLevel>.Instance.Register(Active);
        }
    }
}
