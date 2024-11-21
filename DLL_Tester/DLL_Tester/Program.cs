using IoT_Backend_Assignment;
using System;

class Program
{
    static void Main(string[] args)
    {
        var provider = new IPInfoProvider();

        Console.Write("Enter an IP address: ");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Input cannot be empty.");
            return;
        }

        string ip = input;

        try
        {
            var details = provider.GetDetails(ip);
            Console.WriteLine($"City: {details.City}");
            Console.WriteLine($"Country: {details.Country}");
            Console.WriteLine($"Continent: {details.Continent}");
            Console.WriteLine($"Latitude: {details.Latitude}");
            Console.WriteLine($"Longitude: {details.Longitude}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}