using DAL.Base;
using System;

namespace DAL.EntityFramework.Models
{
    public class EFEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }
    }
}
