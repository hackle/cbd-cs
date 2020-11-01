using System;
using System.Collections.Generic;

public enum Category { House, Car }
public struct CreateRequest
{
    public Category Category;
    public int Area;
    public string Address;
    public string Make;
    public string Model;
}

public struct Car
{
    public string Make;
    public string Model;
}

public struct House 
{
    public string Address;
    public int Area;
}

public static class RequestDescriptor
{
    /*
        CreateRequest is "opaque" as it contains unnecessary information for each scenario.
        Try to refactor it so each branch has only information that's required
    */
    public static string Describe(CreateRequest request)
    {
        return new Dictionary<Category, Func<string>>
        {
            { Category.Car, () => HandleCar(AsCar(request)) },
            { Category.House, () => HandleHouse(AsHouse(request)) },
        }[request.Category]();
    } 

    static Car AsCar(CreateRequest request) => new Car { Make = request.Make, Model = request.Model };
    static House AsHouse(CreateRequest request) => new House { Address = request.Address, Area = request.Area };

    static string HandleCar(Car car) 
    {
        return $"Requested a {car.Make}-{car.Model} car";
    }

    static string HandleHouse(House house)
    {
        return $"Requested a house of {house.Area}sqm at {house.Address}";
    }
}