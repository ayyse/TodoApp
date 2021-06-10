using Abp.Domain.Entities;
using System.Collections.Generic;

namespace TodoApp.Models
{
    public class Category : Entity<int>
    {
        public string Name { get; set; }

        public ICollection<Todo> Todos { get; set; }
    }
}
