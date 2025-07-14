using Monogame.Processing;
using AsteroidesSingleplayer;
using System;

public class AsteroidesSketch : Processing
{
    Ship ship;
    bool esquerda, direita, cima;
    PImage barcoSprite;
    List<Bullet> tiros = new List<Bullet>();

    public override void Setup()
    {
        size(2000, 1500);
        barcoSprite = loadImage("Assets/barco1.png");
        ship = new Ship(new Vector2(width / 2f, height / 2f));
    }

    public override void Draw()
    {
        Console.WriteLine("Sexo");
        background(0);
        Teclas();
        ship.HandleInput(esquerda, direita, cima);
        ship.Update();
        ship.Draw(this, barcoSprite);

        // Atualiza e desenha tiros
for (int i = tiros.Count - 1; i >= 0; i--)
{
    tiros[i].Update();
    tiros[i].Draw(this);

    // Remove tiro se sair da tela
    if (tiros[i].Position.X < 0 || tiros[i].Position.X > width ||
        tiros[i].Position.Y < 0 || tiros[i].Position.Y > height)
    {
        tiros.RemoveAt(i);
    }
}
    }

    void Teclas()
    {
        esquerda = false;
        direita = false;
        cima = false;

       if (!keyPressed) return;

        switch (keyCode)
        {
        case Microsoft.Xna.Framework.Input.Keys.Left: esquerda = true; break;
        case Microsoft.Xna.Framework.Input.Keys.Right: direita = true; break;
        case Microsoft.Xna.Framework.Input.Keys.Up: cima = true; break;
        case Microsoft.Xna.Framework.Input.Keys.Space:
        tiros.Add(new Bullet(ship.Position, ship.Rotation));
        break;
        }
    }

    [STAThread]
    static void Main()
    {
        using var jogo = new AsteroidesSketch();
        jogo.Run();
    }
} 