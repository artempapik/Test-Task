"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Task = /** @class */ (function () {
    function Task(id, name, description, clientAddress, startTime, endTime, clientId, client) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.clientAddress = clientAddress;
        this.startTime = startTime;
        this.endTime = endTime;
        this.clientId = clientId;
        this.client = client;
    }
    return Task;
}());
exports.Task = Task;
//# sourceMappingURL=task.js.map