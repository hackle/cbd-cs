public enum Category { House, Car }
public struct CreateRequest
{
    public Category Category;
    public int area;
    public string address;
    public string make;
    public string model;
}

public static class RequestDescriptor
{
    /*
        CreateRequest is "opaque" as it contains unnecessary information for each scenario.
        Try to refactor it so each branch has only information that's required
    */
    public static string Describe(CreateRequest request)
    {
        if (request.Category == Category.Car) {
            return $"Requested a {request.make}-{request.model} car";
        } else if (request.Category == Category.House) {
            return $"Requested a house of {request.area}sqm at {request.address}";
        }

        return null;
    } 
}