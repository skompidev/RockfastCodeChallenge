import { Observable } from "rxjs";
import { ITodo } from "./todo.model";
import { IUser } from "../../users/models/user";

export interface ITodoDialog extends ITodo {
    users$: Observable<IUser[]>;
    actionBtnText: string;
}

export interface ITodoDialogResponse {
    todo: ITodo,
    isDelete: boolean
}