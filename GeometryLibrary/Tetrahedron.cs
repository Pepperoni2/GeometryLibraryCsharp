using System.Numerics;

namespace GeometryLibrary;

public class Tetrahedron : Shape
{
    // Property
    private Vector3[] _vertices;

    // Constructor
    public Tetrahedron(Vector3 vertex1, Vector3 vertex2, Vector3 vertex3, Vector3 vertex4)
    {
        _vertices = new Vector3[] { vertex1, vertex2, vertex3, vertex4 };
    }

    // Calculate Centroid method
    public Vector3 Centroid()
    {
        Vector3 sumOfVectors = _vertices[0] + _vertices[1] + _vertices[2] + _vertices[3];
        return sumOfVectors / 4f;
    }
    
    private static float CalculateFaceArea(Vector3 a, Vector3 b, Vector3 c)
    {
            // Find two edges 
            // Edge 1
            Vector3 edge1 = b - a;
            // Edge 2
            Vector3 edge2 = c - a;

            // Cross Product
            Vector3 crossProduct = Vector3.Cross(edge1, edge2);

            return crossProduct.Length() / 2f;
    
    } 
    // Calculate Area of Tetrahedron
    public float SurfaceArea()
    {
        return CalculateFaceArea(_vertices[0], _vertices[1], _vertices[2]) + 
               CalculateFaceArea(_vertices[0], _vertices[1], _vertices[3]) +
               CalculateFaceArea(_vertices[0], _vertices[2], _vertices[3]) +
               CalculateFaceArea(_vertices[1], _vertices[2], _vertices[3]);
    }

    // Override == operator
    public static bool operator ==(Tetrahedron t1, Tetrahedron t2)
    {
        if (ReferenceEquals(t1, t2))  return true;
        if (t1 is null || t2 is null) return false;

        // LINQ Sorting
        var sortedT1 = t1._vertices.OrderBy(t => t.X).ThenBy(t => t.Y).ThenBy(t => t.Z);
        var sortedT2 = t2._vertices.OrderBy(t => t.X).ThenBy(t => t.Y).ThenBy(t => t.Z);
        return sortedT1.SequenceEqual(sortedT2);
    }

    public static bool operator !=(Tetrahedron t1, Tetrahedron t2) => !(t1 == t2);

    // Override Equals and GetHashCode methods
    public override bool Equals(object? obj)
    {
        if (obj is Tetrahedron other)
        {
            return this == other; 
        }
        else
        {
            return false;
        }
    }
    public override int GetHashCode()
    {
       return _vertices[0].GetHashCode() + 
              _vertices[1].GetHashCode() + 
              _vertices[2].GetHashCode() + 
              _vertices[3].GetHashCode();
    }
}