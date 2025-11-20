using Nekoblocks.Core;
using Nekoblocks.Services;
using Jitter2.Dynamics.Constraints;
using Raylib_cs;
using System.Numerics;

namespace Nekoblocks.Game.Player;

/// <summary>
/// Local player class
/// </summary>
public class Player : GameObject
{
    public Camera3D Camera;
    public Character Character = new();
    private WorkspaceService workspaceService = ServiceManager.GetService<WorkspaceService>();
    public Player()
    {
        Name = "Player";
        SetParent(workspaceService.Workspace);
        Camera = new Camera3D()
        {
            Position = new Vector3(-20, 8, 10),
            Target = new Vector3(0, 4, 0),
            Up = new Vector3(0, 1, 0),
            FovY = 80.0f,
            Projection = CameraProjection.Perspective
        };
        Character.Transform.SetPosition(0, 10, 7);
        Character.Transform.Anchored = false;
        Character.SetParent(this);
    }
    public void Update()
    {
        Raylib.UpdateCamera(ref Camera, CameraMode.Free);
    }
}