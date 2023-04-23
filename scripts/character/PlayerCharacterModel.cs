using Godot;

namespace Character
{
    public class PlayerCharacterModel
    {
        private Vector2 prevInputVelocity = Vector2.Zero;
        public int Speed { private get; set; }

        public Vector2 CalcVelocity(Vector2 input)
        {
            var inputVelocity = input;

            // note : allow just one side of velocity(x or y)
            if (inputVelocity.X != 0 && inputVelocity.Y != 0)
            {
                // note : apply previous input velocity
                if (prevInputVelocity.X != 0) inputVelocity.Y = 0;
                else if (prevInputVelocity.Y != 0) inputVelocity.X = 0;
                else inputVelocity.Y = 0;
            }

            prevInputVelocity = inputVelocity;
            return inputVelocity.Normalized() * Speed;
        }

        public Vector2 GetDirectionFrom(Vector2 Velocity)
        {
            var result = Velocity.Normalized();
            return result;
        }
    }
}