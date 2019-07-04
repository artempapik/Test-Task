import { Client } from "./client";

export class Task {
  constructor(
    public id?: number,
    public name?: string,
    public description?: string,
    public clientAddress?: string,
    public startTime?: string,
    public endTime?: string,
    public clientId?: number,
    public client?: Client
  ) { }
}
