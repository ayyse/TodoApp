import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryDto, TodoDto, TodoServiceProxy } from '@shared/service-proxies/service-proxies';
import { FormBuilder, Validators, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {

  todos: TodoDto[] = []
  todoAddForm: FormGroup

  todo: TodoDto = new TodoDto()
  category: CategoryDto = new CategoryDto()

  constructor(
    private todoService: TodoServiceProxy,
    private activatedRoute: ActivatedRoute,
    private formBuilder:FormBuilder,) { }

  ngOnInit(): void {
    this.createTodoAddForm()
    this.getAllTodos()
  }

  getAllTodos() {
    this.todoService.getAllTodos().subscribe(response => {
      this.todos = response
    })
    return this.todos.filter(todo => todo.completed)
  }

  deleteTodo(id: number) {
    this.todoService.delete(id).subscribe()
  }

  completedDone(id: number) {
    this.todos.map((v, i) => {
      if (i == id) v.completed = !v.completed
      return v
    })
  }

  todoAdd(todo: TodoDto) {
    todo.categoryId = 2
    todo.categoryName = "Not Completed"
    this.todoService.create(todo).subscribe(response => {
      this.todo = response
    })
  }

  createTodoAddForm(){
    this.todoAddForm = this.formBuilder.group({
      description: ["", Validators.required],
      categoryName: ["", Validators.required]
    })
  }

  updateTodo(todo: TodoDto){
    todo.completed = true
    todo.categoryId = 1
    todo.categoryName = "Completed"
    this.todoService.update(todo).subscribe(response => {
      this.todo = response
    })
  }

  getByCategoryId(categoryId: number) {
    this.todoService.getByCategoryId(categoryId).subscribe(response => {
      this.todos = response
    })
  }

}
