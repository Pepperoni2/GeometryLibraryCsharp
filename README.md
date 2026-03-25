# Geometry Library

## About The Project
The Geometry Library is a robust, object-oriented 3D geometry engine built in C#. It provides mathematical representations of 3D primitive shapes and enables complex spatial calculations including surface area, volume, and centroids. The project leverages inheritance and polymorphism to handle arrays of mixed geometry through a unified `CompositeShape` structure.

**Built With:**
* C# 10.0+
* .NET SDK (6.0 or higher)
* `System.Numerics` for hardware-accelerated Vector3 math

## Getting Started 

### Prerequisites
To run this project, you will need the .NET SDK installed on your machine.
* Download .NET: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)

### Installation
1. Clone the repository
   ```sh
   git clone [https://github.com/your_username/GeometryLibraryCsharp.git](https://github.com/your_username/GeometryLibraryCsharp.git)
2. Navigate to the project directory
   ```sh
   cd GeometryLibraryCsharp
3. Build the solution to resore dependencies
   ```sh
   dotnet build
### Usage
This library is designed to be easily consumed by other C# projects. You can create shapes, combine them, and sort them mathematically.
```csharp
using GeometryLibrary;

// Create primitive shapes
Cuboid cube = new Cuboid();
Cylinder cylinder = new Cylinder();

// Combine shapes using overloaded operators
CompositeShape composite = cube + cylinder;

// Automatically sort shapes by Surface Area
composite.SortShapes();

// Calculate total volume of all shapes combined
Console.WriteLine($"Total Volume: {composite.Volume()}");
```
To run the demonstration program included in this repository:
```sh
cd GeometricObjectComputation
dotnet run
```
## Roadmap
[x] Implement abstract Shape base class with IComparable interface

[x] Implement 3D Primitives (Tetrahedron, Cuboid, Cylinder)

[x] Implement Scalar Triple Product math for Tetrahedron volume

[x] Implement CompositeShape to group and sort collections of shapes

[x] Overload operators (+, ==, !=, [])

## Contributing
Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are greatly appreciated.
1. Fork the Project

2. Create your Feature Branch (git checkout -b feature/AmazingFeature)

3. Commit your Changes (git commit -m 'Add some AmazingFeature')

4. Push to the Branch (git push origin feature/AmazingFeature)

5. Open a Pull Request
## License
Distributed under the MIT License See ```LICENSE``` for more information.
## Contact
Florian Golubic - cc241008@ustp-students.at

Project Link: https://github.com/Pepperoni2/GeometryLibraryCsharp
## Acknowledgments
- Formula references from standard 3D coordinate geometry

- .NET documentation for System.Numerics.Vector3