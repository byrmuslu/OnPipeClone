namespace OnPipe.UI.Button
{
    using OnPipe.Signal;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class BtnNextLevel : MyUI, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            SignalBus<SignalNextLevel>.Instance.Fire();
        }
    }
}