using System.Diagnostics;
using System.Dynamic;
using System.Numerics;
using Gorge.World;
using Raylib_cs;

namespace Gorge.World;

public class Part : WorldObject
{
    public bool Anchored = false;
    public Material Material;
    public Model Model;
    public enum PartType
    {
        Brick,
    }
    public PartType type;


    public Part(PartType type = PartType.Brick, Vector3? position = null, Quaternion? rotation = null, Vector3? scale = null)
    {
        Name = "Part";
        this.type = type;

        position ??= new Vector3(1, 1, 1);
        rotation ??= Quaternion.Zero;
        scale ??= new Vector3(4, 1, 2);

        Transform.Position = position.Value;
        Transform.Rotation = rotation.Value;
        Transform.Scale = scale.Value;

        RegenerateModel();
    }

    protected override void OnTransformChanged()
    {
        base.OnTransformChanged();
        RegenerateModel();
    }

    public void RegenerateModel()
    {
        switch (type)
        {
            case PartType.Brick:
                Model = Raylib.LoadModelFromMesh(Raylib.GenMeshCube(Transform.Scale.X / 5, Transform.Scale.Y / 5, Transform.Scale.Z / 5));
                Log.LogDebug("AEEEE" + Transform.Scale.ToString());
                break;
        }

        Texture2D texture = Raylib.LoadTexture
        Raylib.SetMaterialTexture(ref Model, 0, MaterialMapIndex.Albedo, ref texture);
    }
}