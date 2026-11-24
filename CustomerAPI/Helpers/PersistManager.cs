
using CustomerAPI.Entities;
using System.Collections.Generic;
using System.Text.Json;
namespace CustomerAPI.Helpers;


public class PersistManager
 
{
    public static List<Customer> Load(string filePath)
    {
        List<Customer> customers = new List<Customer>();
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            customers = JsonSerializer.Deserialize<List<Customer>>(json);
        }
        return customers;
    }

    public static bool Dump(string filePath, List<Customer> customers)
    {

        Boolean status = false;
        try
        {
            string json = JsonSerializer.Serialize(customers, JsonSerializerOptions.Default);
            File.WriteAllText(filePath, json);
            status = true;
        }
        catch (Exception)
        {

        }
        finally
        {

        }
        return status;
    }
}
    
