using UnityEngine;

public static class Vector2Extensions
{
    public static Vector3 ToXYZ(this Vector2 original,float? x=null,float? y=null,float? z=null)
    {
        return new Vector3(x ?? original.x, y ?? 0, z ?? original.y);
    }

    public static Vector2 DirectionTo(this Vector2 source,Vector2 destination)
    {
        return (destination - source).normalized;
    }
}
