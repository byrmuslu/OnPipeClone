namespace OnPipe.Game
{
    using UnityEngine;

    public class Barrier : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed = 5f;

        private void Update()
        {
            transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime);
        }

    }
}
