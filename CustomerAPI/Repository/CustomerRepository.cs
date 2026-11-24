namespace CustomerAPI.Repositories;
using CustomerAPI.Entities;
using CustomerAPI.Helpers;
 
public class CustomerRepository
{

    string filePath = @"C:\Users\prana\OneDrive\Desktop\TAP\CustomerSolutions\CustomerAPI\Data\Customer.json";
    public CustomerRepository() { }

    public List<Customer> GetAll()
    {
        Console.WriteLine("get all method invoked");
        List<Customer> allCustomers = PersistManager.Load(filePath);
        return allCustomers;
    }

    public Customer GetById(int id)
    {
        List<Customer> allCustomers = GetAll();
        Customer theCustomer = null;

        for (int i = 0; i < allCustomers.Count; i++)
        {
            if (allCustomers[i].Id == id)
            {
                theCustomer = allCustomers[i];
                return theCustomer;
            }
        }
        return theCustomer;
    }
public bool Create(Customer theCustomer)
    {
        bool status = false;
        List<Customer> allCustomers = GetAll();
        allCustomers.Add(theCustomer);
        PersistManager.Dump(filePath, allCustomers);
        status = true;
        return status;
    }
    public bool Update(Customer customer)
    {
        bool status = false;
        List<Customer> allCustomer = GetAll();
        for(int i=0;i<allCustomer.Count;i++){
            if(allCustomer[i].Id==customer.Id){
                allCustomer[i]=customer;
                PersistManager.Dump(filePath, allCustomer);
                status=true;
                break;
            }
        }
        return status;
    }
        
public bool Delete(int id)

    {
        List<Customer> allCustomer = GetAll();
        Customer existingCustomer = allCustomer.FirstOrDefault(c=> c.Id==id);
        if (existingCustomer == null)
        {
            return false;
        }
        allCustomer.Remove(existingCustomer);
        PersistManager.Dump(filePath, allCustomer);
        return true;
    }
}

