namespace OnPipe.Game.Command
{
    using UnityEngine;

    public class Move
    {
        protected IMoveable _obj;

        public Move(IMoveable obj)
        {
            _obj = obj;
        }
        
        public void MoveForward()
        {
            _obj.GetTransform().position += _obj.GetTransform().forward * _obj.GetSpeed() * Time.fixedDeltaTime;
        }

        public void MoveUp()
        {
            _obj.GetTransform().position += _obj.GetTransform().up * _obj.GetSpeed() * Time.fixedDeltaTime;
        }
    }
}
