namespace OnPipe.Game
{
    using System;
    using OnPipe.Signal;
    using UnityEngine;

    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _yOffset = 0;
        private Transform _torus;

        private bool _isTracked;

        private void Awake()
        {
            SignalBus<SignalTorusLoaded, Torus>.Instance.Register(OnTorusLoaded);
            SignalBus<SignalWinGame>.Instance.Register(UnTracker);
            SignalBus<SignalRestartGame>.Instance.Register(Tracker);
            SignalBus<SignalNextLevel>.Instance.Register(Tracker);
        }

        private void Tracker() => _isTracked = true;
        private void UnTracker() => _isTracked = false;

        private void OnTorusLoaded(Torus obj)
        {
            _torus = obj.transform;
            _isTracked = true;
        }

        private void LateUpdate()
        {
            if (_torus == null || !_isTracked)
                return;
            transform.position = new Vector3(transform.position.x, _torus.position.y - _yOffset, transform.position.z);
        }
    }
}
