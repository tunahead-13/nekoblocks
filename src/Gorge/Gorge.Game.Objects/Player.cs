using Raylib_cs;
using System.Numerics;

namespace Gorge.Game.Objects;

public class Player : GameObject
{
    public Camera3D Camera;
    public Part[] bodyParts =
    {
        new Part(Part.PartType.Brick)
    };

    public void Start()
    {
        Name = "Player";
        Camera = new Camera3D()
        {
            Position = new Vector3(-20, 8, 10),
            Target = new Vector3(0, 4, 0),
            Up = new Vector3(0, 1, 0),
            FovY = 80.0f,
            Projection = CameraProjection.Perspective
        };
    }

    public void Update()
    {
        Raylib.UpdateCamera(ref Camera, CameraMode.Free);
    }
}