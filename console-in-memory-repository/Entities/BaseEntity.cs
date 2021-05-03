namespace Console_in_memory_repository.Entities
{
    public abstract class BaseEntity
    {
        public  int Id { get; private set; }
        public BaseEntity(int id)
        {
            this.Id = id;
        }

        public abstract string ToListString();
    }
}
