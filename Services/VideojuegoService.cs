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
        if(Videojuego is null)
            return;

        Videojuegos.Remove(Videojuego);
    }

    public static void Update(Videojuego Videojuego)
    {
        var index = Videojuegos.FindIndex(v => v.Id == Videojuego.Id);
        if(index == -1)
            return;

        Videojuegos[index] = Videojuego;
    }
}