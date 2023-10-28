"use strict";

// https://learn.microsoft.com/en-us/aspnet/core/signalr/javascript-client?view=aspnetcore-7.0

var connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5088/chat-hub", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
    })
    .configureLogging(signalR.LogLevel.Debug)
    .withAutomaticReconnect([3, 3, 3, 3])
    .build();

connection.on("ReceiveMessage", (user, message) => { addMessage(user, message); });
connection.onreconnecting(error => { setStatus(); });
connection.onreconnected(connectionId => { setStatus(); });
connection.onclose(error => { start(); });


$("#sendButton").on("click", (event) => {
    var user = $("#userInput").val();
    var message = $("#messageInput").val();

    connection
        .invoke("SendMessage", user, message)
        .catch((err) => {
            return console.error(err.toString());
        });

    event.preventDefault();
});

function start() {
    connection
        .start()
        .catch((err) => {
            setTimeout(start, 3000);
        })
        .finally(() => {
            setStatus();
        });
};

function setStatus() {
    if (connection.state === signalR.HubConnectionState.Connected) {
        $("#sendButton").prop("disabled", false);
        $("#connecting").hide();
    } else {
        $("#sendButton").prop("disabled", true);
        $("#connecting").show();
    }
}

function addMessage(user, message) {
    $("#messageList").append(`<li>${user} says ${message}</li>`);
}

start();
