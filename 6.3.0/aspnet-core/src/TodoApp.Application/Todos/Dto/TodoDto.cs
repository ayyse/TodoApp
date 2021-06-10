using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using TodoApp.Models;

namespace TodoApp.Todos.Dto
{
    [AutoMapFrom(typeof(Todo))]
    [AutoMapTo(typeof(Todo))]
    public class TodoDto : EntityDto<int>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        //public DateTime Date { get; set; }
        public bool Completed { get; set; }
    }
}
