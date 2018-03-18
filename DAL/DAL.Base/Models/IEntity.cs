using System;

namespace DAL.Base
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        byte[] Version { get; set; }
    }
}
