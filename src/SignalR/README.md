# SignalR Demo – .NET 9

This repository demonstrates a basic SignalR implementation using two separate ASP.NET Core projects:

1. **`DotNetWorkspace.SignalR.Server`** – A minimal SignalR server hosting a Hub.
2. **`DotNetWorkspace.SignalR.WebUI`** – An ASP.NET Core MVC client that connects to the SignalR Hub.

---

## 1. Clone the Repository

1. Clone the repository to your local machine:
   ```bash
   git clone https://github.com/furkanisitan/dotnet-workspace.git
   ```

2. Navigate to the `src/SignalR` folder:
   ```bash
   cd dotnet-workspace/src/SignalR
   ```

---

## 2. Run the Server Project

1. Navigate to the Server project:
   ```bash
   cd DotNetWorkspace.SignalR.Server
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

4. Run the server:
   ```bash
   dotnet run
   ```

> By default, the server will be hosted on `https://localhost:7230`.

---

## 3. Run the Web UI (Client) Project

1. Open a **new terminal window**, then navigate to the Web UI project:
   ```bash
   cd dotnet-workspace/src/SignalR/DotNetWorkspace.SignalR.WebUI
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

4. Run the Web UI:
   ```bash
   dotnet run
   ```

> By default, the Web UI will be hosted on `https://localhost:7240`.

---

## 4. Test the Application

### 4. Test the Application

1. Open your browser and navigate to the Web UI (e.g., `https://localhost:7240`).
2. The app will attempt to connect to the SignalR server. Once connected, you'll see the UI for real-time messaging.
3. To **test real-time messaging**, open **multiple browser windows** or **use different browsers** (e.g., Chrome, Edge, Firefox, etc.). Each window represents a separate client session.
4. In one of the browser windows, send a message. You will see the message appear in **all other connected client windows** in real-time, without needing to refresh the pages.
5. This demonstrates SignalR's real-time capabilities, where multiple clients can interact simultaneously. Try typing different messages in each window and see how they appear across all open sessions.


---

## 🌐 Requirements

1. [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
2. Internet connection (for CDN resources used in the frontend)
3. Any terminal or command line tool
4. Browser (Chrome, Edge, Firefox, etc.)

---

## 📁 Project Structure

```
dotnet-workspace/
└── src/
    └── SignalR/
        ├── DotNetWorkspace.SignalR.Server/   # SignalR server (Hub)
        └── DotNetWorkspace.SignalR.WebUI/    # MVC client using SignalR
```

---

## 🔐 HTTPS Development Certificates

1. If you haven't trusted the development certificate yet, run:
   ```bash
   dotnet dev-certs https --trust
   ```
