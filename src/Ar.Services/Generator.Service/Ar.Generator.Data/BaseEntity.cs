using System;

namespace Ar.Generator.Data
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime AddedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string IPAddress { get; set; }
    }
}
