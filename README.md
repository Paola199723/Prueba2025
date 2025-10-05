

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

# Instrucciones del Proyecto

Este proyeto esta hecho para probarse por consola, por lo que se requiere que instales todas las dependencias necesarias para que Ejecute el poyecto

Pasos para Compilar

1) abrir la consola y entrar a la carpeta Prueba
2) ejecutar 
dotnet clean
dotnet build
dotnet run
3) Probar las opciones de cada ejercicio

