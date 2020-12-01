namespace OnPipe.Game.Command
{
    using UnityEngine;

    public class ScaleIt
    {
        private IScaleable _obj;

        public ScaleIt(IScaleable obj)
        {
            _obj = obj;
        }

        public void ScaleUp()
        {
            _obj.GetTransform().localScale = Vector3.MoveTowards(_obj.GetTransform().localScale, (Vector3.one * _obj.GetMaxScale()), _obj.GetScaleSpeed() * Time.deltaTime);
        }

        public void ScaleDown()
        {
            _obj.GetTransform().localScale = Vector3.MoveTowards(_obj.GetTransform().localScale, (Vector3.one * _obj.GetMinScale()), _obj.GetScaleSpeed() * Time.deltaTime);
        }

    }
}
