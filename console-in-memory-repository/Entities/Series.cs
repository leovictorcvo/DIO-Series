using Console_in_memory_repository.Enums;
using System;

namespace Console_in_memory_repository.Entities
{
    public class Series : BaseEntity
    {
        public string Name { get; private set; }
        public ECategories Category { get; private set; }
        public bool Active { get; set; }
        private string ActiveString => this.Active ? "Ativa" : "Excluída";

        public Series(int id, string name, ECategories category, bool active) : base(id)
        {
            this.Name = name;
            this.Category = category;
            this.Active = active;
        }


        public override string ToString() =>
            $"ID: {this.Id}{Environment.NewLine}Nome: {this.Name}{Environment.NewLine}Categoria: {(ECategories)this.Category}{Environment.NewLine}Status: {this.ActiveString}";

        public override string ToListString() => $"{this.Id} - {this.Name} - {this.ActiveString}";
    }
}
