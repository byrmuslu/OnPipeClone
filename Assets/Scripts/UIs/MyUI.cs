namespace OnPipe.UI
{
    using UnityEngine;

    public class MyUI : MonoBehaviour
    {
        protected virtual void Active()
        {
            gameObject.SetActive(true);
        }

        protected virtual void DeActive()
        {
            gameObject.SetActive(false);
        }
    }
}
