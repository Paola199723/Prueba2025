using Microsoft.EntityFrameworkCore;
using BibliotecaApp.Application.Services;
using BibliotecaApp.Infrastructure.Repositories;
using BibliotecaApp.Domain.Entities;
using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MENU PRINCIPAL ===");
            Console.WriteLine("1. Esquema base de datos Ejercicio 1");
            Console.WriteLine("2. Suma de enteros ejercicio 2");
            Console.WriteLine("3. Gestion de Biblioteca Ejercicio 3");
            Console.WriteLine("0. Salir");
            Console.Write("Selecciona una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {

                case "1": ejercicio1Menu(); break;
                case "2": ejercicio2(); break;
                case "3": Ejercicio3(); break;
                case "0": return;
                default: Console.WriteLine("❌ Opción inválida."); break;
            }

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }
    }

static void Ejercicio3()
{
  var biblioteca = new BibliotecaService();

    while (true)
    {
        Console.WriteLine("\n===== 📘 MENÚ DE BIBLIOTECA =====");
        Console.WriteLine("1. Ver libros");
        Console.WriteLine("2. Prestar libro");
        Console.WriteLine("3. Devolver libro");
        Console.WriteLine("4. Ver libros prestados");
        Console.WriteLine("0. Salir");
        Console.Write("Seleccione una opción: ");

        var opcion = Console.ReadLine() ?? string.Empty;


        switch (opcion)
        {
            case "1":
                biblioteca.MostrarLibros();
                break;
            case "2":
                Console.Write("Ingrese el ID del libro: ");
                int idLibro = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Ingrese el ID del miembro: ");
                int idMiembro = int.Parse(Console.ReadLine() ?? "0");
                biblioteca.PrestarLibro(idLibro, idMiembro);
                break;
            case "3":
                Console.Write("Ingrese el ID del libro a devolver: ");
                int idDev = int.Parse(Console.ReadLine() ?? "0");
                biblioteca.DevolverLibro(idDev);
                break;
            case "4":
                biblioteca.MostrarPrestamos();
                break;
            case "0":
                Console.WriteLine("👋 Saliendo...");
                return;
            default:
                Console.WriteLine("Opción no válida. Intente de nuevo.");
                break;
        }
    }
}    
static void ejercicio2()
    {

        // pedir la lista de numeros y el destino
        Console.WriteLine("\n=== Ejercicio 2 ===");

        Console.Write("Ingresa la lista de números separados por espacio: ");
        string? entrada = Console.ReadLine();

        // Convertir la entrada en un arreglo de enteros
        int[] numeros = entrada
            ?.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray() ?? Array.Empty<int>();

        Console.Write("Ingresa el número destino: ");
        int destino = int.Parse(Console.ReadLine() ?? "0");



        var solver = new Ejercicio2();
        int[] resultado = solver.CalcularIndices(numeros, destino);

        if (resultado.Length > 0)
        {
            Console.WriteLine($"Los índices que suman {destino} son: [{resultado[0]}, {resultado[1]}]");
        }
        else
        {
            Console.WriteLine("No se encontraron dos números que sumen el destino.");
        }

        Console.ReadKey();

    }

static void ejercicio1Menu()
{
    using var context = new BlogContext();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MENU PRINCIPAL ===");
            Console.WriteLine("1. Agregar usuario");
            Console.WriteLine("2. Editar usuario");
            Console.WriteLine("3. Ver usuarios");
            Console.WriteLine("4. Crear publicación");
            Console.WriteLine("5. Ver publicaciones");
            Console.WriteLine("6. Agregar comentario");
            Console.WriteLine("7. Ver comentarios");
            Console.WriteLine("8. Agregar etiqueta");
            Console.WriteLine("9. Ver etiquetas");
            Console.WriteLine("0. Salir");
            Console.Write("Selecciona una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": AgregarUsuario(context); break;
                case "2": EditarUsuario(context); break;
                case "3": VerUsuarios(context); break;
                case "4": CrearPost(context); break;
                case "5": VerPosts(context); break;
                case "6": AgregarComentario(context); break;
                case "7": VerComentarios(context); break;
                case "8": AgregarEtiqueta(context); break;
                case "9": VerEtiquetas(context); break;
                case "0": return;
                default: Console.WriteLine("Opción inválida."); break;
            }

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }
}


    static void AgregarUsuario(BlogContext context)
    {
        Console.WriteLine("\n=== AGREGAR USUARIO ===");

        Console.Write("Username: ");
        var username = Console.ReadLine();

        Console.Write("Email: ");
        var email = Console.ReadLine();

        Console.Write("Password: ");
        var password = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("⚠️ Todos los campos son obligatorios.");
            return;
        }

        var nuevoUsuario = new User
        {
            Username = username,
            Email = email,
            Password = password
        };

        context.Users.Add(nuevoUsuario);
        context.SaveChanges();

        Console.WriteLine("\nUsuario agregado correctamente.");
    }

static void EditarUsuario(BlogContext context)
{
    Console.WriteLine("\n=== EDITAR USUARIO ===");
    Console.Write("ID del usuario a editar: ");

    if (int.TryParse(Console.ReadLine(), out int id))
    {
        var usuario = context.Users.Find(id);
        if (usuario == null)
        {
            Console.WriteLine("Usuario no encontrado.");
            return;
        }

        Console.Write($"Nuevo username ({usuario.Username}): ");
        var nuevoUsername = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevoUsername))
            usuario.Username = nuevoUsername;

        Console.Write($"Nuevo email ({usuario.Email}): ");
        var nuevoEmail = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevoEmail))
            usuario.Email = nuevoEmail;

        Console.Write("Nueva contraseña (dejar vacío si no cambia): ");
        var nuevoPassword = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevoPassword))
            usuario.Password = nuevoPassword;

        context.SaveChanges();
        Console.WriteLine("\nUsuario actualizado correctamente.");
    }
    else
    {
        Console.WriteLine(" ID inválido.");
    }
}

static void VerUsuarios(BlogContext context)
{
    Console.WriteLine("\n=== LISTA DE USUARIOS ===");
    var usuarios = context.Users.ToList();

    if (!usuarios.Any())
    {
        Console.WriteLine("No hay usuarios registrados.");
        return;
    }

    foreach (var u in usuarios)
    {
        Console.WriteLine($"ID: {u.Id} | Username: {u.Username} | Email: {u.Email}");
    }
}


    static void CrearPost(BlogContext context)
    {
        Console.WriteLine("\n=== CREAR PUBLICACIÓN ===");
        Console.Write("ID del usuario autor: ");
        if (!int.TryParse(Console.ReadLine(), out int userId))
        {
            Console.WriteLine(" ID inválido.");
            return;
        }

        var user = context.Users.Find(userId);
        if (user == null)
        {
            Console.WriteLine("Usuario no encontrado.");
            return;
        }

        Console.Write("Título: ");
        var title = Console.ReadLine();

        Console.Write("Contenido: ");
        var content = Console.ReadLine();

        var post = new Post { Title = title!, Content = content!, UserId = userId };
        context.Posts.Add(post);
        context.SaveChanges();

        Console.WriteLine("\nPublicación creada correctamente.");
    }

    static void VerPosts(BlogContext context)
    {
        Console.WriteLine("\n=== PUBLICACIONES ===");
        var posts = context.Posts.Include(p => p.User).ToList();

        if (!posts.Any())
        {
            Console.WriteLine("No hay publicaciones.");
            return;
        }

        foreach (var p in posts)
        {
            Console.WriteLine($"ID: {p.Id} | Título: {p.Title} | Autor: {p.User.Username}");
        }
    }

    static void AgregarComentario(BlogContext context)
    {
        Console.WriteLine("\n=== AGREGAR COMENTARIO ===");
        Console.Write("ID del post: ");
        if (!int.TryParse(Console.ReadLine(), out int postId))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var post = context.Posts.Find(postId);
        if (post == null)
        {
            Console.WriteLine("Publicación no encontrada.");
            return;
        }

        Console.Write("ID del usuario: ");
        if (!int.TryParse(Console.ReadLine(), out int userId))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var user = context.Users.Find(userId);
        if (user == null)
        {
            Console.WriteLine("Usuario no encontrado.");
            return;
        }

        Console.Write("Comentario: ");
        var content = Console.ReadLine();

        var comment = new Comment { Content = content!, PostId = postId, UserId = userId };
        context.Comments.Add(comment);
        context.SaveChanges();

        Console.WriteLine("\nComentario agregado correctamente.");
    }

    static void VerComentarios(BlogContext context)
    {
        Console.WriteLine("\n=== COMENTARIOS ===");
        var comments = context.Comments
            .Include(c => c.User)
            .Include(c => c.Post)
            .ToList();

        if (!comments.Any())
        {
            Console.WriteLine("No hay comentarios.");
            return;
        }

        foreach (var c in comments)
        {
            Console.WriteLine($"[{c.Id}] {c.User.Username} en '{c.Post.Title}': {c.Content}");
        }
    }

    static void AgregarEtiqueta(BlogContext context)
    {
        Console.WriteLine("\n=== AGREGAR ETIQUETA ===");
        Console.Write("Nombre de la etiqueta: ");
        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("El nombre no puede estar vacío.");
            return;
        }

        var tag = new Tag { Name = name };
        context.Tags.Add(tag);
        context.SaveChanges();

        Console.WriteLine("\nEtiqueta agregada correctamente.");
    }

    static void VerEtiquetas(BlogContext context)
    {
        Console.WriteLine("\n=== ETIQUETAS ===");
        var tags = context.Tags.ToList();

        if (!tags.Any())
        {
            Console.WriteLine("No hay etiquetas registradas.");
            return;
        }

        foreach (var t in tags)
        {
            Console.WriteLine($"ID: {t.Id} | Nombre: {t.Name}");
        }
    }

}