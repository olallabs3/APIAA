using APIAA.Models;
using Microsoft.EntityFrameworkCore;

namespace APIAA.Services;

public static class UsuarioService
{
    static List<Usuario> Usuarios { get; }

    //Comprobar el int cuando acabemos de meter usuarios por código
    static int nextId = 1;
    static UsuarioService()
    {
        Usuarios = new List<Usuario>
        {};
    }

    public static List<Usuario> GetAll() => Usuarios;

    //Recoger todos los datos por id
    public static Usuario? Get(int id) => Usuarios.FirstOrDefault(u => u.Id == id);
    
    //Recoger todos los datos por nombre
    public static Usuario? GetNombre(string nombre) => Usuarios.FirstOrDefault(u => u.Nombre == nombre);

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

    public static void Update(Usuario Usuario)
    {
        var index = Usuarios.FindIndex(u => u.Id == Usuario.Id);
        if (index == -1)
            return;

        Usuarios[index] = Usuario;
    }


}