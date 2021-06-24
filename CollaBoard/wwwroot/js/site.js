"use strict";


function getWebSocketConnection(server, hub) {
    return new signalR.HubConnectionBuilder().withUrl("https://localhost:44372/participants").build();
}

function Send() {
    connection.invoke("SendMessage", "UserValue", "MessageValue").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
};
