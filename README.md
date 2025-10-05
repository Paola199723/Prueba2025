
# Limpiar y reconstruir
```bash
dotnet clean
dotnet build
```
# Restaurar paquetes
```bash
dotnet restore
```
# Migraciones (EF Core)
```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```
# Ejecutar la app
```bash
dotnet run
```
# Instrucciones del Proyecto

Este proyeto esta hecho para probarse por consola, por lo que se requiere que instales todas las dependencias necesarias para que Ejecute el poyecto

Pasos para Compilar
```bash
1) abrir la consola y entrar a la carpeta Prueba
2) ejecutar 
dotnet clean
dotnet build
dotnet run
3) Probar las opciones de cada ejercicio
```
