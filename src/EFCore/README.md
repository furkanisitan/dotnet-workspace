
# EFCore Use Cases

This repository contains examples for working with [Entity Framework Core (EF Core)](https://learn.microsoft.com/en-us/ef/core/). The project demonstrates various EF Core concepts such as relationships (one-to-one, one-to-many, many-to-many), keyless entities, owned entities, enum usage, and creating views through migrations.

## 📚 Contents

1. **[Relationships](./DotNetWorkspace.EFCore.Persistence/Entities/)**  
   - One-to-One Relationship
   - One-to-Many Relationship
   - Many-to-Many Relationship

2. **[Fluent API Configurations](./DotNetWorkspace.EFCore.Persistence/EntityConfigurations/)**  
   Configure entities and relationships using Fluent API.

3. **[Keyless Entities](./DotNetWorkspace.EFCore.Persistence/Entities/Views/)**  
   Use entities without primary keys for views or raw SQL results.

4. **[Owned Entities](./DotNetWorkspace.EFCore.Persistence/Entities/Owned/)**  
   Work with dependent entities tied to a principal entity.

5. **[Enum Usage in Entities](./DotNetWorkspace.EFCore.Persistence/Enums/)**  
   Map enums to database columns in EF Core.

6. **[Creating Views with Migrations](./DotNetWorkspace.EFCore.Persistence/Migrations/20250407212005_CreateViews_MANUAL.cs)**  
   Create reusable database views using migrations.

## 🚀 How to Use

1. **Clone the repository to your local machine:**

   ```bash
   git clone https://github.com/furkanisitan/dotnet-workspace.git
   ```

2. **Navigate to the EFCore project:**

   ```bash
   cd dotnet-workspace/src/SignalR/DotNetWorkspace.EFCore.Persistence
   ```

3. **Restore dependencies:**

   ```bash
   dotnet restore
   ```

4. **Build the project:**

   ```bash
   dotnet build
   ```

5. **Apply migrations to the database:**

   ```bash
   dotnet ef database update
   ```

   > You may need to update the connection string in [ApplicationDbContext](./DotNetWorkspace.EFCore.Persistence/ApplicationDbContext.cs).

6. **Run the application:**

   ```bash
   dotnet run
   ```

## 🔑 Key Technologies

- **Entity Framework Core**: The ORM used for data access.
- **C#**: The programming language used.
- **SQL Server**: The database used in this example (can be replaced with any other provider).

## 🛠️ Contributing

Feel free to open an issue or create a pull request for any improvements or bug fixes.
