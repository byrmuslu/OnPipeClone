namespace OnPipe.Game
{
    using OnPipe.Enum;
    using OnPipe.Signal;
    using UnityEngine;

    public class Obstacle : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                SignalBus<SignalLoseGame>.Instance.Fire();
                SignalBus<SignalVibrate>.Instance.Fire();
            }
        }
    }
}
