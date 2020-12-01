namespace OnPipe.UI.Button
{
    using OnPipe.Signal;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class BtnRestartGame : MyUI, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            SignalBus<SignalRestartGame>.Instance.Fire();
        }
    }
}
