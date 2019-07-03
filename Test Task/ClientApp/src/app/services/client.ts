import { Task } from "./task";

export class Client {
  constructor(
    public id?: number,
    public firstName?: string,
    public lastName?: string,
    public address?: string,
    public phone?: string,
    public tasks?: Task[]
  ) { }
}
