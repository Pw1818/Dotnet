
using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.Entities;


public class Customer
{
    public int Id{get;set;}
    public string CustomerName{get;set;}
    
    public string Mobile{get;set;}
    public int Age{get;set;}
}