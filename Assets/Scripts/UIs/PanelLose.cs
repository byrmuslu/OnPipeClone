﻿namespace OnPipe.UI.Panel
{
    using OnPipe.Signal;
    using UnityEngine;

    public class PanelLose : MyUI
    {
        private void Awake()
        {
            SignalBus<SignalGameLoaded>.Instance.Register(DeActive);
            SignalBus<SignalLoseGame>.Instance.Register(Active);
            SignalBus<SignalRestartGame>.Instance.Register(DeActive);
            SignalBus<SignalWinGame>.Instance.Register(DeActive);
        }
        
    }
}
