using System;
using Monogame.Processing;

namespace AsteroidesSingleplayer        
{
    public class Ship : GameObject
    {
        //propiedades - nave
        public float Rotation {get; set;}
        public float RotationSpeed {get; set;}
        public float Acceleration {get; set;}
        public float MaxSpeed { get; set;}

        // constructor
        public Ship(Vector2 position) : base(position, 20f) // tamanho da nave = 20
        {
            Rotation = 0f;
            RotationSpeed = 0.06f; // radianos por frame
            Acceleration = 0.2f;
            MaxSpeed = 2f;
            Velocity = new Vector2(0, 0);
        }

        // METODOS ABSTRATOS
        public override void Update()
        {
            UpdatePosition();
            
            //limite para velocidade maxima
            float currentSpeed = (float)Math.Sqrt(Velocity.X * Velocity.X + Velocity.Y * Velocity.Y);
            if (currentSpeed > MaxSpeed)
            {
                float scale = MaxSpeed / currentSpeed;
                Velocity = Velocity.Multiply(scale);
            }
        }

        // Desenha a nave usando sprite com rotação
       public void Draw(Processing g, PImage barcoSprite)
{
    g.pushMatrix();
    g.translate(Position.X, Position.Y);
    g.rotate(Rotation);
    g.image(barcoSprite, Position.X, Position.Y, 80, 80); // Centraliza a imagem no ponto da nave
    g.popMatrix();
    Console.WriteLine($"({Position.X}), ({Position.Y})");
}

        // Lê o teclado e atualiza rotação/velocidade usando flags booleanas
        public void HandleInput(bool esquerda, bool direita, bool cima)
        {
            Console.WriteLine($"c: {cima}, d: {direita}, e: {esquerda}");
            if (esquerda)
                Rotation -= RotationSpeed;
            if (direita)
                Rotation += RotationSpeed;
            if (cima)
            {
                Velocity.X += (float)Math.Sin(Rotation) * Acceleration;
                Velocity.Y -= (float)Math.Cos(Rotation) * Acceleration;
            }
        }
    }
}