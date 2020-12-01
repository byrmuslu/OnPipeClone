namespace OnPipe.Game.Command
{
    using UnityEngine;

    public interface IScaleable
    {
        Transform GetTransform();
        float GetScaleSpeed();
        float GetMaxScale();
        float GetMinScale();
    }
}
