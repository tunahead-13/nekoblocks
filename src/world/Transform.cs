using System.Numerics;

namespace Gorge.World;

// This should really be moved somewhere else
public class Transform
{
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 Scale;

    public static void QuaternionToAxisAngle(Quaternion q, out Vector3 axis, out float angle)
    {
        var x = q.X;
        var y = q.Y;
        var z = q.Z;
        var w = q.W;

        var len = (float)Math.Sqrt(x * x + y * y + z * z + w * w);
        if (len == 0)
        {
            axis = new Vector3(1, 0, 0);
            angle = 0;
            return;
        }

        x /= len; y /= len; z /= len; w /= len;

        // Keep w >= 0
        if (w < 0.0)
        {
            w = -w; x = -x; y = -y; z = -z;
        }

        w = Math.Clamp(w, -1, 1);
        angle = 2 * (float)Math.Acos(w);
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
}