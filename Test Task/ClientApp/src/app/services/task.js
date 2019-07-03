"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Task = /** @class */ (function () {
    function Task(id, name, description, clientAddress, 
    //public startTime?: Date,
    //public endTime?: Date,
    clientId, client) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.clientAddress = clientAddress;
        this.clientId = clientId;
        this.client = client;
    }
    return Task;
}());
exports.Task = Task;
//# sourceMappingURL=task.js.map