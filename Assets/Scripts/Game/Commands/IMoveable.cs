namespace OnPipe.Game.Command
{
    using UnityEngine;

    public interface IMoveable
    {
        Transform GetTransform();
        float GetSpeed();
    }
}
