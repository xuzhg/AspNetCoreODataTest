using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class UriParserExtenstionEdmModel
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Customer>("Customers");
            builder.EntitySet<Order>("Orders");

            builder.EntityType<Customer>().Function("CalculateSalary").Returns<int>().Parameter<int>("month");
            builder.EntityType<Customer>().Action("UpdateAddress");
            builder.EntityType<Customer>()
                .Collection.Function("GetCustomerByGender")
                .ReturnsCollectionFromEntitySet<Customer>("Customers")
                .Parameter<Gender>("gender");

            return builder.GetEdmModel();
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }

        public int Age { get; set; }
        public IList<Order> Orders { get; set; }
    }

    public class VipCustomer : Customer
    {
        public string VipProperty { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }

    public class Order
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
