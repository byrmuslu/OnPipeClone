namespace OnPipe.Game
{
    using OnPipe.Factory;
    using OnPipe.Signal;
    using OnPipe.Constant;
    using System.Collections.Generic;
    using UnityEngine;

    public class FallObject : MonoBehaviour
    {
        [SerializeField] private Animator _anim = null;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _anim.SetTrigger("Triggered");
                SignalBus<SignalVibrate>.Instance.Fire();
                SignalBus<SignalScoreIncrease>.Instance.Fire();
                GetComponent<Collider>().enabled = false;
                Invoke("ColliderActivate", .5f);
            }
        }
        
        private void ColliderActivate()
        {
            GetComponent<Collider>().enabled = true;
        }

    }
}
