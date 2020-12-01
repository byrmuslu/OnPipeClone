namespace OnPipe.UI.Panel
{
    using OnPipe.Signal;
    using UnityEngine;

    public class PanelWin : MyUI
    {
        private void Awake()
        {
            SignalBus<SignalGameLoaded>.Instance.Register(DeActive);
            SignalBus<SignalWinGame>.Instance.Register(Active);
            SignalBus<SignalRestartGame>.Instance.Register(DeActive);
            SignalBus<SignalNextLevel>.Instance.Register(DeActive);
        }
    }
}
