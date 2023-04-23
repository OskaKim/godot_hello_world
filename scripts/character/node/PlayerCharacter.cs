using Godot;
using System;

namespace Character
{
    public partial class PlayerCharacter : CharacterBody2D, IMovableCharacter
    {
        private int _speed = 200;
        private AnimatedSprite2D animatedSpriteNode;

        [Export]
        public int Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                model.Speed = value;
            }
        }

        private PlayerCharacterModel model = new PlayerCharacterModel();

        private Vector2 prevInputVelocity = Vector2.Zero;

        public override void _Ready()
        {
            model.Speed = Speed;
            animatedSpriteNode = GetNode<AnimatedSprite2D>("AnimatedSprite2D") as AnimatedSprite2D;
        }

        public override void _PhysicsProcess(double delta)
        {
            Velocity = CalcVelocity();
            bool isCollided = MoveAndSlide();

            var direction = model.GetDirectionFrom(Velocity);

            // todo : make this better with state runner or something
            if (direction == Vector2.Left)
            {
                animatedSpriteNode.Animation = "idle_left";
            }
            else if (direction == Vector2.Right)
            {
                animatedSpriteNode.Animation = "idle_right";
            }
            else if (direction == Vector2.Up)
            {
                animatedSpriteNode.Animation = "idle_up";
            }
            else if (direction == Vector2.Down)
            {
                animatedSpriteNode.Animation = "idle_down";
            }
            else
            {
                GD.PrintErr($"player animation of direction:{direction} has not expected");
            }
        }

        public Vector2 CalcVelocity()
        {
            return model.CalcVelocity(GetInput());
        }

        public Vector2 GetInput()
        {
            Vector2 _velocity = new Vector2();
            _velocity.X += Input.IsActionPressed("Right") ? 1 : 0;
            _velocity.X -= Input.IsActionPressed("Left") ? 1 : 0;
            _velocity.Y += Input.IsActionPressed("Down") ? 1 : 0;
            _velocity.Y -= Input.IsActionPressed("Up") ? 1 : 0;
            return _velocity;
        }
    }
}