using Gorge.Core;
using Gorge.Services;

namespace Gorge.World;

/// <summary>
/// The root object that everything in Workspace derives from
/// </summary>
public class WorldObject
{
    public int Id;
    public string Name = "Unnamed Object";

    private Transform _transform = new();
    public Transform Transform
    {
        get { return _transform; }
        set
        {
            _transform = value;
            OnTransformChanged();
        }
    }

    protected virtual void OnTransformChanged() { }
}