using Godot;

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
    }
}