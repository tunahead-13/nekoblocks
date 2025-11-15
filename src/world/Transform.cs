using System.Diagnostics;
using System.Numerics;

namespace Gorge.World;

// This should really be moved somewhere else
public class Transform
{
    public Vector3 Position { get; internal set; }
    public Quaternion Rotation { get; internal set; }
    public Vector3 Scale { get; internal set; }

    public event Action<Transform>? PositionChanged;
    public event Action<Transform>? RotationChanged;
    public event Action<Transform>? ScaleChanged;

    public static void QuaternionToAxisAngle(Quaternion q, out Vector3 axis, out float angleDegs)
    {
        var x = q.X;
        var y = q.Y;
        var z = q.Z;
        var w = q.W;

        var len = (float)Math.Sqrt(x * x + y * y + z * z + w * w);
        if (len == 0)
        {
            axis = new Vector3(1, 0, 0);
            angleDegs = 0;
            return;
        }

        x /= len; y /= len; z /= len; w /= len;

        // Keep w >= 0
        if (w < 0.0)
        {
            w = -w; x = -x; y = -y; z = -z;
        }

        w = Math.Clamp(w, -1, 1);
        angleDegs = 2f * (float)Math.Acos(w) * (180f / MathF.PI);
        var s = (float)Math.Sqrt(1 - w * w);

        if (s < 1e-8)
        {
            axis = new Vector3(1, 0, 0);
        }
        else
        {
            axis = new Vector3(x / s, y / s, z / s);
        }
        return;
    }

    public void Set(Vector3 position, Quaternion rotation, Vector3 scale)
    {
        if (Position != position)
        {
            Position = position;
            PositionChanged?.Invoke(this);
        }
        if (Rotation != rotation)
        {
            Rotation = rotation;
            RotationChanged?.Invoke(this);
        }
        if (Scale != scale)
        {
            Scale = scale;
            ScaleChanged?.Invoke(this);
        }
    }


    public void SetPosition(Vector3 position)
    {
        Position = position;
        PositionChanged?.Invoke(this);
    }
    public void SetPosition(float x, float y, float z)
    {
        Position = new Vector3(x, y, z);
        PositionChanged?.Invoke(this);
    }
    public void SetRotation(Quaternion rotation)
    {
        Rotation = rotation;
        RotationChanged?.Invoke(this);
    }
    public void SetScale(float x, float y, float z)
    {
        Scale = new Vector3(x, y, z);
        ScaleChanged?.Invoke(this);
    }
    public void SetScale(float uniformScale)
    {
        Scale = new Vector3(uniformScale, uniformScale, uniformScale);
        ScaleChanged?.Invoke(this);
    }
    public void SetScale(Vector3 scale)
    {
        Scale = scale;
        ScaleChanged?.Invoke(this);
    }
}