using System.Numerics;

namespace GeometryLibrary;

public class Cylinder : Shape
{
    private float _radius;
    private Vector3[] _vertices;
    private static readonly Random _random = new();

    // Default Constructor
    public Cylinder()
    {
        _vertices = new Vector3[2];
        _radius      = _random.NextSingle() + 1.0f;
        // Add first random Vertex
        _vertices[0].X = _random.NextSingle() * 10f;
        _vertices[0].Y = _random.NextSingle() * 10f;
        _vertices[0].Z = _random.NextSingle() * 10f;
        
        // Add second random Vertex
        _vertices[1].X = _random.NextSingle() * 10f;
        _vertices[1].Y = _random.NextSingle() * 10f;
        _vertices[1].Z = _random.NextSingle() * 10f;
    }

    // Parameterized Constructor
    public Cylinder(Vector3 vertex1, Vector3 vertex2, float radius)
    {
        // Instantiate vertices
        _vertices = new Vector3[2];
        _vertices[0] = vertex1;
        _vertices[1] = vertex2;

        _radius = radius;

        // VALIDATION Check
        if (radius <= 0f || Vector3.Distance(vertex1, vertex2) < 0.0001f)
        {
            throw new ArgumentException("A cylinder must have a positive radius and a height greater than zero.");
        }
    }

    // The Copy Constructor
    public Cylinder(Cylinder original)
    {
        _vertices = new Vector3[2];
        Array.Copy(original._vertices, this._vertices, 2);
        _radius = original._radius;
    }

    // Height
    public float Height()
    {
        return Vector3.Distance(_vertices[0], _vertices[1]);
    }

    // Area calculations
    // Bottom Area
    public float BottomArea()
    {
        // Using float version of PI to avoid casting errors
        return MathF.PI * _radius * _radius;
    }

    // Surface area
    public override float SurfaceArea()
    {
        return 2 * BottomArea() + (2 * MathF.PI * _radius * Height());
    }

    public override float Volume()
    {
        return BottomArea() * Height();
    }

    public override Vector3 Centroid()
    {
        return (_vertices[0] + _vertices[1]) / 2f;
    }

    // Override == operator
    public static bool operator ==(Cylinder cy1, Cylinder cy2)
    {
        if (ReferenceEquals(cy1, cy2))  return true;
        if (cy1 is null || cy2 is null) return false;

        // LINQ Sorting
        var sortedcy1 = cy1._vertices.OrderBy(cy => cy.X).ThenBy(cy => cy.Y).ThenBy(cy => cy.Z);
        var sortedcy2 = cy2._vertices.OrderBy(cy => cy.X).ThenBy(cy => cy.Y).ThenBy(cy => cy.Z);
        return sortedcy1.SequenceEqual(sortedcy2) && (cy1._radius == cy2._radius);
    }

    public static bool operator !=(Cylinder cy1, Cylinder cy2) => !(cy1 == cy2);

    // Override Equals and GetHashCode methods
    public override bool Equals(object? obj)
    {
        if (obj is Cylinder other)
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
              _radius.GetHashCode();
    }
}