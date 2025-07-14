using System;

namespace AsteroidesSingleplayer
{
    public class Vector2
    {
        // propiedades
        public float X {get; set;}
        public float Y {get; set;}

        // construtor
        public Vector2(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        // construtor padrão
        public Vector2(): this(0,0) { }

        // operações de vetores 
        public Vector2 Add(Vector2 other)
        {
            return new Vector2(X + other.X, Y + other.Y);
        }

        public Vector2 Subtract(Vector2 other)
        {
            return new Vector2((X - other.X), (Y - other.Y));
        }

        public Vector2 Multiply(float scalar)
        {
            return new Vector2(X * scalar, Y * scalar);
        }

        public float Distance(Vector2 other)
        {
            float dx = X - other.X;
            float dy = Y - other.Y;
            
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        // the motherfucker toString
        public override string ToString()
        {
            return $"({X}, {Y})";
        }

    }
}