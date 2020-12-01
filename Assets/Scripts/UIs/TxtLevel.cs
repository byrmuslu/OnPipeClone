namespace OnPipe.UI.Text
{
    using OnPipe.Signal;
    using UnityEngine;
    using UnityEngine.UI;

    public class TxtLevel : MyUI
    {
        [SerializeField] private Text _txtLevel = null;

        private void Awake()
        {
            SignalBus<SignalCurrentLevelChanged, int>.Instance.Register(OnCurrentLevelChanged);
        }

        private void OnCurrentLevelChanged(int obj)
        {
            _txtLevel.text = obj.ToString();
        }
    }
}
