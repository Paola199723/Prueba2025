# Limpiar y reconstruir
dotnet clean
dotnet build

# Restaurar paquetes
dotnet restore

# Migraciones (EF Core)
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update

# Ejecutar la app
dotnet run
