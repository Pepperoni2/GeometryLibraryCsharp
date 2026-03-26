# Geometric Object Computation

## Overview
`Computation` is the console application designed to demonstrate and test the capabilities of the core `GeometryLibrary`. It acts as the entry point of the project, showcasing how the 3D geometric primitive classes and the composite shape architecture interact in a real-world execution.

## Features Demonstrated
When you run this application, it automatically executes a sequence of operations to prove the library's functionality:
1. **Instantiation & Math:** Creates random instances of a `Cuboid`, `Cylinder`, and `Tetrahedron` and calculates their specific Volumes, Surface Areas, and Centroids.
2. **Operator Overloading:** Uses the overloaded `+` operator to merge the individual 3D primitives into a single `CompositeShape`.
3. **Polymorphism:** Calculates the total volume and total surface area of the combined composite shape.
4. **Sorting (IComparable):** Uses the `Array.Sort()` method to automatically sort the mixed geometry inside the composite shape based on their Surface Areas.
5. **Searching & Indexing:** Demonstrates finding a specific shape in memory using the `IsIn()` method and accessing it via the overloaded `[]` indexer.
6. **Deep Copying:** Proves memory safety by successfully utilizing the Copy Constructor to create an independent clone of a shape.

## How to Run
To execute the demonstration program, ensure you have the .NET SDK installed. 

Navigate to this directory in your terminal and run:
```sh
cd Computation
dotnet run