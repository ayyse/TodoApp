using Abp.Domain.Entities;
using System;
using TodoApp.Authorization.Users;

namespace TodoApp.Models
{
    public class Todo : Entity<int>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Category Category { get; set; }


        public User User { get; set; }

        public string Description { get; set; }
        public bool Completed { get; set; }


        //public DateTime Date { get; set; }
    }
}
