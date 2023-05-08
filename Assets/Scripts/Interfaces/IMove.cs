namespace Asteroids
{
    public interface IMove
    {
        //float Speed { get; }
        //float CurrentSpeed { get; }
        void Move(float horizontal, float vertical, float deltaTime);
    }
}
