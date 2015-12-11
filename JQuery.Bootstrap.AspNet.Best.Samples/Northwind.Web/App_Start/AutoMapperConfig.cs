using AutoMapper;
using Northwind.Data.Models;
using Northwind.Infrastructure.Tasks;
using Northwind.Web.Models;

namespace Northwind.Web
{
    public class AutoMapperConfig : IRunAtInit
    {
        public void Execute()
        {
            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<Customer, CustomerViewModel>();
            Mapper.CreateMap<Employee, EmployeeViewModel>();

            Mapper.CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Status,
                      opt => opt.MapFrom
                      (src => src.Discontinued ? "danger" : src.UnitPrice > 50 ? "info" : src.UnitsInStock < 20 ? "warning" : ""));

        }
    }
}