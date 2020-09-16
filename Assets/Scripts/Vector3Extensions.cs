using UnityEngine;

public static class Vector3Extensions
{
    public static Vector2 ToXZ(this Vector3 original)
    {
        return new Vector2(original.x, original.z);
    }

    public static Vector3 With(this Vector3 original,float? x=null,float? y=null,float? z=null)
    {
        return new Vector3(x ?? original.x, y ?? original.y, z ?? original.z);
    }

    public static Vector3 DirectionTo(this Vector3 source, Vector3 destination)
    {
        return (destination - source).normalized;
    }
}