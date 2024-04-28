using System.ComponentModel.DataAnnotations;

namespace StorySuite.Domain
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}