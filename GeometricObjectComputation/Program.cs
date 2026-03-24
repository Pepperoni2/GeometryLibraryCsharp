using System;
using GeometryLibrary;

class Program
{
    static void Main()
    {
        Console.WriteLine("--- 1. CREATING BASIC OBJECTS ---");
        // Using our default constructors to make random shapes
        Cuboid cube1 = new Cuboid();
        Cylinder cyl1 = new Cylinder();
        Tetrahedron tet1 = new Tetrahedron();

        Console.WriteLine($"Cuboid:      Volume = {cube1.Volume():F2}, Surface Area = {cube1.SurfaceArea():F2}, Centroid = {cube1.Centroid()}");
        Console.WriteLine($"Cylinder:    Volume = {cyl1.Volume():F2}, Surface Area = {cyl1.SurfaceArea():F2}, Centroid = {cyl1.Centroid()}");
        Console.WriteLine($"Tetrahedron: Volume = {tet1.Volume():F2}, Surface Area = {tet1.SurfaceArea():F2}, Centroid = {tet1.Centroid()}\n");

        Console.WriteLine("--- 2. ADDING SHAPES WITH OVERLOADED + OPERATOR ---");
        
        // Start with an empty CompositeShape
        CompositeShape compShape = new CompositeShape(0); 
        
        // Now use our legal (CompositeShape + Shape) operator!
        compShape = compShape + cube1; 
        compShape = compShape + cyl1; 
        compShape = compShape + tet1; 

        Console.WriteLine($"CompositeShape Total Volume: {compShape.Volume():F2}");
        Console.WriteLine($"CompositeShape Total Surface Area: {compShape.SurfaceArea():F2}\n");

        Console.WriteLine("--- 3. SORTING THE COMPOSITE SHAPE ---");
        Console.WriteLine("Sorting shapes by Surface Area (via IComparable)...");
        compShape.SortShapes();
        
        // PROOF: Loop through the composite shape using the [] indexer to prove it sorted!
        Console.WriteLine("Sort complete. Here is the new order:");
        for (int i = 0; i < 3; i++)
        {
            // Using the [] operator here explicitly shows it works
            Console.WriteLine($"  Index [{i}]: Surface Area = {compShape[i].SurfaceArea():F2} ({compShape[i].GetType().Name})");
        }
        Console.WriteLine();

        Console.WriteLine("--- 4. ISIN, INDEXER [], AND COPY CONSTRUCTOR ---");
        // Find the cuboid we created earlier
        int index = compShape.IsIn(cube1);
        
        if (index != -1)
        {
            Console.WriteLine($"Found 'cube1' at sorted index: {index}");
            
            // Access it using the overloaded [] indexer
            Shape foundShape = compShape[index];

            // Because 'foundShape' is stored as a generic Shape, 
            // we cast it back to a Cuboid to use the specific copy constructor.
            if (foundShape is Cuboid originalCuboid)
            {
                Cuboid clonedCube = new Cuboid(originalCuboid);
                Console.WriteLine("Successfully created a deep copy of the Cuboid using the Copy Constructor!");
                
                // Prove it's a clone by using our overloaded == operator
                bool isExactMatch = (originalCuboid == clonedCube);
                Console.WriteLine($"Does the clone perfectly match the original? {isExactMatch}");
            }
        }
        else
        {
            Console.WriteLine("Shape not found!");
        }
        
        Console.WriteLine("\n*** GEOMETRY PROJECT COMPLETE! ***");
    }
}