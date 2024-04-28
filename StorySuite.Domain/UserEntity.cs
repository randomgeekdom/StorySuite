namespace StorySuite.Domain
{
    public abstract class UserEntity : Entity
    {
        public Guid UserId { get; set; }
    }
}