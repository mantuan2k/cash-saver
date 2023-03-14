namespace CashSaver.Helper
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        
        protected BaseEntity() { }

        protected BaseEntity(Guid id)
        {
            Id = id;
        }
    }
}