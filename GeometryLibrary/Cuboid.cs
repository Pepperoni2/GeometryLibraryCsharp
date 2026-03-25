using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace GeometryLibrary;

public class Cuboid : Shape
{
    private Vector3[] _vertices;
    private static readonly Random _random = new();

    // Default constructor
    public Cuboid()
    {
        _vertices = new Vector3[8];
        var L = (_random.NextSingle() * 9f) + 1.0f;
        var W = (_random.NextSingle() * 9f) + 1.0f;
        var H = (_random.NextSingle() * 9f) + 1.0f;

        // Bottom Face (Floor)
        // Generate random origin
        _vertices[0].X = _random.NextSingle() * 10f;
        _vertices[0].Y = _random.NextSingle() * 10f;
        _vertices[0].Z = _random.NextSingle() * 10f;

        _vertices[1] = _vertices[0] + new Vector3(L, 0, 0);
        _vertices[2] = _vertices[0] + new Vector3(L, W, 0); // far-right corner of the floor
        _vertices[3] = _vertices[0] + new Vector3(0, W, 0);

        // Top Face (Ceiling)
        _vertices[4] = _vertices[0] + new Vector3(0, 0, H); 
        _vertices[5] = _vertices[0] + new Vector3(L, 0, H);
        _vertices[6] = _vertices[0] + new Vector3(L, W, H);
        _vertices[7] = _vertices[0] + new Vector3(0, W, H);

    }

    // Parameterized Constructor
    public Cuboid(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3, 
                  Vector3 v4, Vector3 v5, Vector3 v6, Vector3 v7)
    {
        // Instantiate the array so it has space for 8 points
        _vertices = new Vector3[8];

        // Slot each parameter into the array
        _vertices[0] = v0;
        _vertices[1] = v1;
        _vertices[2] = v2;
        _vertices[3] = v3;
        _vertices[4] = v4;
        _vertices[5] = v5;
        _vertices[6] = v6;
        _vertices[7] = v7;

        // VALIDATION Check
        if (this.Volume() < 0.0001f)
        {
            throw new ArgumentException("The provided vertices are coplanar (flat) and do not form a valid 3D Cuboid.");
        }
    }

    // Copy constructor
    public Cuboid(Cuboid original)
    {
        _vertices = new Vector3[8];
        Array.Copy(original._vertices, this._vertices, 8);
    }

    public override float SurfaceArea()
    {
        var L = Vector3.Distance(_vertices[0], _vertices[1]);
        var W = Vector3.Distance(_vertices[0], _vertices[3]);
        var H = Vector3.Distance(_vertices[0], _vertices[4]);

        return 2 * ((L * W) + (L * H) + (W * H));
    }


    public override Vector3 Centroid()
    {
        Vector3 sumOfVectors = Vector3.Zero;
        for (int i = 0; i < _vertices.Length; i++)
        {
            sumOfVectors += _vertices[i];
        }
        return sumOfVectors / 8f;
    }

    public override float Volume()
    {
        var L = Vector3.Distance(_vertices[0], _vertices[1]);
        var W = Vector3.Distance(_vertices[0], _vertices[3]);
        var H = Vector3.Distance(_vertices[0], _vertices[4]);

        return L * W * H;
    } 

    // Override == operator
    public static bool operator ==(Cuboid c1, Cuboid c2)
    {
        if (ReferenceEquals(c1, c2))  return true;
        if (c1 is null || c2 is null) return false;

        // LINQ Sorting
        var sortedC1 = c1._vertices.OrderBy(c => c.X).ThenBy(c => c.Y).ThenBy(c => c.Z);
        var sortedC2 = c2._vertices.OrderBy(c => c.X).ThenBy(c => c.Y).ThenBy(c => c.Z);
        return sortedC1.SequenceEqual(sortedC2);
    }

    public static bool operator !=(Cuboid c1, Cuboid c2) => !(c1 == c2);

    // Override Equals and GetHashCode methods
    public override bool Equals(object? obj)
    {
        if (obj is Cuboid other)
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
              _vertices[3].GetHashCode() +
              _vertices[4].GetHashCode() +
              _vertices[5].GetHashCode() +
              _vertices[6].GetHashCode() +
              _vertices[7].GetHashCode();
    }
}