"use strict";

// https://learn.microsoft.com/en-us/aspnet/core/signalr/javascript-client?view=aspnetcore-7.0

var connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7102/chat-hub", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
    })
    .configureLogging(signalR.LogLevel.Debug)
    .withAutomaticReconnect([3, 3, 3, 3])
    .build();

connection.on("ReceiveMessage", (username, message) => { addMessage(username, message); });
connection.on("ReceiveClientCount", (count) => { setClientCount(count); });
connection.on("Notify", (notification) => { setNotification(notification); });
connection.on("ReceiveWarning", (message) => { alert(message); });
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

function addMessage(username, message) {
    $("#messageList").append(`<li>${username} says ${message}</li>`);
}

function setClientCount(count) {
    $("#clientCount").text(count);
}

function setNotification(notification) {
    $("#notification").html(notification);
}

start();