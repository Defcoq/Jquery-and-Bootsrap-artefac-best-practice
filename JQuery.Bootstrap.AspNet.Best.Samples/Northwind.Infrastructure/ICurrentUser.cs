using Northwind.Data.Models;

namespace Northwind.Infrastructure
{
    public interface ICurrentUser
    {
        ApplicationUser User { get; }
    }
}