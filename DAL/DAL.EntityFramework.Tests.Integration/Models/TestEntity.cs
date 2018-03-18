using DAL.EntityFramework.Models;

namespace DAL.EntityFramework.Tests.Integration.Models
{
    public class TestEntity : EFEntity
    {
        public string Name { get; set; }
    }
}
