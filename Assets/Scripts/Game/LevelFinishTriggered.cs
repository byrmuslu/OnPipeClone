namespace OnPipe.Game
{
    using OnPipe.Signal;
    using UnityEngine;

    public class LevelFinishTriggered : MonoBehaviour
    {
        private bool _triggered = false;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !_triggered)
            {
                SignalBus<SignalWinGame>.Instance.Fire();
                _triggered = true;
                Invoke("TriggeredFalse", .25f);
            }
        }

        private void TriggeredFalse()
        {
            _triggered = false;
        }
    }
}
