using System.Numerics;

namespace GeometryLibrary;

public class CompositeShape : Shape
{
    private List<Shape> _ShapeList;


    // Override [] operator
    // public static bool operator [](Tetrahedron t1, Tetrahedron t2)
    // {
    //     if (ReferenceEquals(t1, t2))  return true;
    //     if (t1 is null || t2 is null) return false;

    //     // LINQ Sorting
    //     var sortedT1 = t1._vertices.OrderBy(t => t.X).ThenBy(t => t.Y).ThenBy(t => t.Z);
    //     var sortedT2 = t2._vertices.OrderBy(t => t.X).ThenBy(t => t.Y).ThenBy(t => t.Z);
    //     return sortedT1.SequenceEqual(sortedT2);
    // }

    public override Vector3 Centroid()
    {
        throw new NotImplementedException();
    }

    public override float SurfaceArea()
    {
        throw new NotImplementedException();
    }

    public override float Volume()
    {
        throw new NotImplementedException();
    }
}