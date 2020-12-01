namespace OnPipe.Game
{
    using OnPipe.Signal;
    using UnityEngine;

    public class StopTriggered : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SignalBus<SignalTorusStop>.Instance.Fire();
            }
        }
    }
}
