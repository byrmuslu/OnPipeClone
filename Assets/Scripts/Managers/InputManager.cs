namespace OnPipe.Manager
{
    using OnPipe.Signal;
    using UnityEngine;

    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }
        private void Awake()
        {
            if(Instance != null)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }

        private void Update()
        {
            if(Input.GetMouseButton(0))
            {
                SignalBus<SignalTouched, bool>.Instance.Fire(true);
            }
            else
            {
                SignalBus<SignalTouched, bool>.Instance.Fire(false);
            }
        }
    }
}
