using System;

namespace Interfaces
{
    public interface IPlayerBehaviour
    {
        public event Action OnPushBall;
        public event Action OnBallScaleDown;
    }
}