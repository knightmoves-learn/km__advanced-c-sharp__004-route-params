# 004 Route Params

## Lecture

[![004 Route Params](https://img.youtube.com/vi/Tz_s6hQy6Q4/0.jpg)](https://www.youtube.com/watch?v=Tz_s6hQy6Q4)

## Instructions

In this assignment you will add a new route to a controller in an API meant to keep track of homes and their energy usage. This new route should allow looking up a home's information by an owner's last name.

In `HomeEnergyUsageApi/Controllers/HomesController.cs`...

- Should contain a second HTTP GET method taking one route parameter
  - This method should return a specific `Home` from the existing list `homes`.
  - The `Home` being returned, should be the `Home` in `homes` whose `ownerLastName` property is the same as the route parameter being passed in to your new GET method.
  - If no `ownerLastName`s in `homes` match the passed route paramter, the method should return the existing `Home notFound`.
- Any existing methods or properties on `HomesController.cs` should NOT be changed

Additional Information:

- The `Home` type is defined for you as a record in `HomeEnergyUsageApi/Models/HomeModel.cs`, do not change this definition.
- You should ONLY make code changes in `HomeEnergyUsageApi/Controllers/HomesController.cs` to complete this assignment.

## Resources

- https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-8.0#route-templates
- https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-watch

## Building toward CSTA Standards

- Explain how abstractions hide the underlying implementation details of computing systems embedded in everyday objects (3A-CS-01) https://www.csteachers.org/page/standards
- Demonstrate code reuse by creating programming solutions using libraries and APIs (3B-AP-16) https://www.csteachers.org/page/standards
- Translate between different bit representations of real-world phenomena, such as characters, numbers, and images (3A-DA-09) https://www.csteachers.org/page/standards
- Use lists to simplify solutions, generalizing computational problems instead of repeatedly using simple variables (3A-AP-14) https://www.csteachers.org/page/standards
- Compare and contrast fundamental data structures and their uses (3B-AP-12) https://www.csteachers.org/page/standards

Copyright &copy; 2025 Knight Moves. All Rights Reserved.
