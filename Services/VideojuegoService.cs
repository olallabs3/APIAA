using APIAA.Models;

namespace APIAA.Services;

public static class VideojuegoService
{
    static List<Videojuego> Videojuegos { get; }
    static int nextId = 5;
    static VideojuegoService()
    {
        Videojuegos = new List<Videojuego>
        {
            new Videojuego {Id = 1,Titulo ="Apex Legends", PrecioVenta = 3.99, Unidades = 10, Agotado = false},
            new Videojuego {Id = 2,Titulo ="Sheltered", PrecioVenta = 4.99, Unidades = 11, Agotado = false}
        };
    }

    public static List<Videojuego> GetAll() => Videojuegos;

    public static Videojuego? Get(int id) => Videojuegos.FirstOrDefault(v => v.Id == id);
   

    public static void Add(Videojuego Videojuego)
    {
        Videojuego.Id = nextId++;
        Videojuegos.Add(Videojuego);
    }

    public static void Delete(int id)
    {
        var Videojuego = Get(id);
        if (Videojuego is null)
            return;

        Videojuegos.Remove(Videojuego);
    }

    public static void Update(Videojuego Videojuego)
    {
        var index = Videojuegos.FindIndex(v => v.Id == Videojuego.Id);
        if (index == -1)
            return;

        Videojuegos[index] = Videojuego;
    }
}