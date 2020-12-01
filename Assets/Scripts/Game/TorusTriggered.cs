namespace OnPipe.Game
{
    using OnPipe.Enum;
    using OnPipe.Signal;
    using UnityEngine;

    public class TorusTriggered : MonoBehaviour
    {
        [SerializeField] private Pipe _parentPipe = null;
        private bool _entred = false;
        private bool _exit = false;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !_entred)
            {
                SignalBus<SignalTorusTriggered, Pipe>.Instance.Fire(_parentPipe);
                _entred = true;
                _exit = false;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && !_exit)
            {
                SignalBus<SignalDestroyPipeInGame, Pipe>.Instance.Fire(_parentPipe);
                _exit = true;
                _entred = false;
            }
        }

    }
}
