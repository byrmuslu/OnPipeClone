namespace OnPipe.UI.Button
{
    using System;
    using OnPipe.Signal;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;


    public class BtnPlayGame : MyUI, IPointerDownHandler
    {
        [SerializeField] private Button _btnPlayGame = null;

        private void Awake()
        {
            SignalBus<SignalRestartGame>.Instance.Register(Active);
            SignalBus<SignalNextLevel>.Instance.Register(Active);
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            SignalBus<SignalPlayGame>.Instance.Fire();
            DeActive();
        }

        protected override void Active()
        {
            _btnPlayGame.gameObject.SetActive(true);
        }

        protected override void DeActive()
        {
            _btnPlayGame.gameObject.SetActive(false);
        }
    }
}
