using APIAA.Models;

namespace APIAA.Services;

public static class UsuarioService
{
    static List<Usuario> Usuarios { get; }
    static int nextId = 0;
    static UsuarioService()
    {
        Usuarios = new List<Usuario>
        {

        };
    }


    //Recoger datos de los usuarios, solo los datos correspondientes a nombre y contraseña
    public static List<Usuario> GetAll() => Usuarios;

    public static Usuario? Get(int id) => Usuarios.FirstOrDefault(u => u.Id == id);

    public static Usuario? GetNombre(string nombre) => Usuarios.FirstOrDefault(v => v.Nombre == nombre);

    public static void Add(Usuario Usuario)
    {
        Usuario.Id = nextId++;
        Usuarios.Add(Usuario);
    }

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