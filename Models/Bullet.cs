using System;
using Monogame.Processing;

namespace AsteroidesSingleplayer
{
    public class Bullet
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public float Speed = 10f;
        public bool IsActive = true;

        public Bullet(Vector2 startPosition, float rotation)
        {
            Position = new Vector2(startPosition.X, startPosition.Y);
            Velocity = new Vector2(
                (float)Math.Sin(rotation) * Speed,
                -(float)Math.Cos(rotation) * Speed
            );
        }

        public void Update()
        {
            Position = Position.Add(Velocity);
        }

        public void Draw(Processing g)
        {
            g.fill(255, 255, 0);
            g.ellipse(Position.X, Position.Y, 8, 8);
        }
    }
}