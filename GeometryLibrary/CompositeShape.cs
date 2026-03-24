using System.Numerics;

namespace GeometryLibrary;

public class CompositeShape : Shape
{
    private Shape[] _shapes;

    private static readonly Random _random = new();

    // Constructor
    public CompositeShape(int n)
    {
        _shapes = new Shape[n];
        for (int i = 0; i < n; i++)
        {
            int randomNumber = _random.Next(0,3);
            switch (randomNumber)
            {
                case 0:
                    _shapes[i] = new Tetrahedron();
                    break;
                case 1:
                    _shapes[i] = new Cuboid();
                    break;
                case 2:
                    _shapes[i] = new Cylinder();
                    break;
                default:
                    System.Console.WriteLine("Random Shape could not be added to Shapes");
                    break;
            }
        }
    }

    public Shape this[int index]
    {
        get { return _shapes[index];  }
        set { _shapes[index] = value; }
    }

    public int IsIn(Shape s)
    {
        for (int i = 0; i < _shapes.Length; i++)
        {
            if (_shapes[i].Equals(s))
            {
                return i;
            }
        }
        return -1;
    }


    public override Vector3 Centroid()
    {
        Vector3 weightedSum = Vector3.Zero;
        float totalVolume = 0f;

        foreach (var shape in _shapes)
        {
            // Skip shapes with zero volume to prevent math errors
            if (shape.Volume() == 0f) continue; 

            weightedSum += shape.Centroid() * shape.Volume();
            totalVolume += shape.Volume();
        }

        // Protect against dividing by zero if the composite shape is completely empty
        if (totalVolume == 0f) return Vector3.Zero;

        return weightedSum / totalVolume;    
    }

    public override float SurfaceArea()
    {
        float total = 0f;
        foreach (var shape in _shapes)
        {
           total += shape.SurfaceArea();
        }
        return total;
    }

    public override float Volume()
    {
        float total = 0f;
        foreach (var shape in _shapes)
        {
            total += shape.Volume();
        }
        return total;
    }
}