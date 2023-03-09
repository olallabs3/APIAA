using APIAA.Models;
using Microsoft.EntityFrameworkCore;

namespace APIAA.Services;

public static class UsuarioService
{
    static List<Usuario> Usuarios { get; }

    //Comprobar el int cuando acabemos de meter usuarios por código
    static int nextId = 5;
    static UsuarioService()
    {
        Usuarios = new List<Usuario>
        {
            new Usuario{Id= 1, Nombre="administrador1" , Contrasenya="admin123",Fecha = DateTime.Now, Admin=true },
             new Usuario{Id= 2, Nombre="administrador2" , Contrasenya="admin123",Fecha = DateTime.Now, Admin=true },
              new Usuario{Id= 3, Nombre="administrador3" , Contrasenya="admin123",Fecha = DateTime.Now, Admin=true },
            new Usuario{Id= 4, Nombre="prueba" , Contrasenya="prueba",Fecha = DateTime.Now, Admin=false }
        };
    }

// public async Task<Usuario> AddUsuarioAsync(Usuario usuario)
//         {
//             try
//             {
//                 await _db.Usuario.AddAsync(usuario);
//                 await _db.SaveChangesAsync();
//                 return await _db.Usuario.FindAsync(usuario.Id); // Auto ID from DB
//             }
//             catch (Exception ex)
//             {
//                 return null; // An error occured
//             }
//         }

    //Recoger datos de los usuarios, solo los datos correspondientes a nombre y contraseña
    public static List<Usuario> GetAll() => Usuarios;

    //Recoger todos los datos por id
    public static Usuario? Get(int id) => Usuarios.FirstOrDefault(u => u.Id == id);
    
    //Recoger todos los datos por nombre
    public static Usuario? GetNombre(string nombre) => Usuarios.FirstOrDefault(u => u.Nombre == nombre);


    //  public static Usuario? GetNombreAll(string nombre) => Usuarios.(u => u.Nombre == nombre).ToList();

    public static void Add(Usuario Usuario)
    {
        Usuario.Id = nextId++;
        Usuarios.Add(Usuario);
    }

    //Borrado de usuario por id
    public static void Delete(int id)
    {
        var Usuario = Get(id);
        if (Usuario is null)
            return;

        Usuarios.Remove(Usuario);
    }

    // // Borrado de usuario por nombre
    // public static void Delete(string nombre)
    // {
    //     var Usuario = GetNombre(nombre);
    //     if (Usuario is null)
    //         return;

    //     Usuarios.Remove(Usuario);
    // }

    public static void Update(Usuario Usuario)
    {
        var index = Usuarios.FindIndex(u => u.Id == Usuario.Id);
        if (index == -1)
            return;

        Usuarios[index] = Usuario;
    }
}