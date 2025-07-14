using System;

namespace AsteroidesSingleplayer
{

    public abstract class GameObject
    {
        // propiedades
        public Vector2 Position {get; set;}
        public Vector2 Velocity {get; set;}
        public float Size {get; set;}
        public bool IsActive {get; set;}

        // construtor
        protected GameObject(Vector2 position, float size)
        {
            Position = position;
            Size = size;
            Velocity = new Vector2(0,0);
            IsActive = true;
        }

        // metodos abstratos
        public abstract void Update();

        // metodo para atualizar a posição com base na velocity
        public virtual void UpdatePosition()
        {
            Position = Position.Add(Velocity);
        }

        // checar posição
        public virtual bool CheckCollision(GameObject other)
        {
            if (!IsActive || !other.IsActive) return false;

            float distance = Position.Distance(other.Position);
            float minDistance = Size + other.Size;

            return distance < minDistance;
        }

    }
}