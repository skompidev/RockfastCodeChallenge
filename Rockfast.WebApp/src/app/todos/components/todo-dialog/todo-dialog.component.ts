import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ITodoDialog, ITodoDialogResponse } from '../../models/todo-dialog.model';
import { ITodo } from '../../models/todo.model';

@Component({
  selector: 'rf-app-todo-dialog',
  templateUrl: './todo-dialog.component.html',
  styleUrl: './todo-dialog.component.scss'
})
export class TodoDialogComponent implements OnInit {
  form!: FormGroup;
  todoData!: ITodoDialog;
  errors: any = {
    name: ''
  };

  buttonText = 'Delete';

  constructor(private fb: FormBuilder,
    private dialogRef: MatDialogRef<TodoDialogComponent>,
    @Inject(MAT_DIALOG_DATA) data: ITodoDialog) {
      this.buttonText = data.actionBtnText;
      this.todoData = data;      
    }

  ngOnInit(): void {
    this.form = this.fb.group({
      name: [this.todoData?.name, [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      isComplete: [this.todoData?.dateCompleted ? true : false],
      dateCompleted: [this.todoData?.dateCompleted ?? new Date()],
      userId: [this.todoData?.userId]
    });
  }

  getErrors() {
    Object.keys(this.form.controls).forEach(key => {
      const formCtrlErrors = this.form.controls[key].errors;
      if(formCtrlErrors) {
        let errorStr = '';
        Object.keys(formCtrlErrors).forEach(errKey => {
          if (errKey === 'required') {
            errorStr =  errorStr + `* This is a reqiured field.`
          }
          if (errKey === 'minlength') {
            errorStr =  errorStr + `* Min length is ${formCtrlErrors[errKey].requiredLength}.`
          }
          if (errKey === 'maxlength') {
            errorStr =  errorStr + `* Max length is ${formCtrlErrors[errKey].requiredLength}.`
          }
        });
        this.errors[key] = errorStr;
      }
    }); 
    return true;
  }

  save() {
    if (this.form.valid) {
      const isComplete = this.form.controls['isComplete'].value ?? false;
      const dateCompleted = isComplete ? this.form.controls['dateCompleted'].value : null;
      const todoToSave: ITodo = {
        id: this.todoData.id,
        name: this.form.controls['name'].value,
        userId: this.form.controls['userId'].value,
        dateCompleted: dateCompleted
      }
      const todoDialogResponse: ITodoDialogResponse = {
        todo: todoToSave,
        isDelete: false
      }
      this.dialogRef.close(todoDialogResponse);
    } else {
      this.getErrors();
    }
  }

  clearOrDelete() {
    if (this.buttonText === 'Delete') {
      const todoDialogResponse: ITodoDialogResponse = {
        todo: this.todoData,
        isDelete: this.buttonText === 'Delete'
      }
      this.dialogRef.close(todoDialogResponse);
    } else {
      this.form.reset();
    }
  }
}
