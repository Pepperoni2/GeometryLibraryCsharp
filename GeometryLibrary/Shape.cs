using System.Numerics;

namespace GeometryLibrary;

public abstract class Shape : IComparable<Shape>
{
    public abstract float SurfaceArea();

    // Compare method
    public int CompareTo(Shape other)
    {
        // Check for NullReferenceException
        if(other is null) return 1;
        return this.SurfaceArea().CompareTo(other.SurfaceArea());
    }
}
