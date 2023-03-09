using APIAA.Models;

namespace APIAA.Services;

public static class VideojuegoService
{
    static List<Videojuego> Videojuegos { get; }
    static int nextId = 1;
    static VideojuegoService()
    {
        //var transaccion = TransaccionService.Get(1);

        Videojuegos = new List<Videojuego>
        {
            /* new Videojuego {Id = 1, Titulo ="Apex Legends", PrecioVenta = 3.99, Unidades = 10, Agotado = false},
            new Videojuego {Id = 2, Titulo ="Medievil", PrecioVenta = 9.99, Unidades = 8, Agotado = false},
            new Videojuego {Id = 3, Titulo ="The Last of Us", PrecioVenta = 80, Unidades = 0, Agotado = true} */
        };

        /* Videojuegos[0].Transacciones.Add(TransaccionService.Get(1));
        Videojuegos[1].Transacciones.Add(TransaccionService.Get(2));
        Videojuegos[2].Transacciones.Add(TransaccionService.Get(3)); */
    }

    public static List<Videojuego> GetAll() => Videojuegos;
    
    public static List<Videojuego> GetNotAgotados(){

        List<Videojuego> filtered = GetAll().Where(x => x.Agotado == false).ToList();

        return filtered;
    }

    public static Videojuego? Get(int id) => Videojuegos.FirstOrDefault(v => v.Id == id);
   

    public static void Add(Videojuego Videojuego)
    {
        /*Controles de coherencia de datos*/
        /**/if(GetAll().Where(x => x.Titulo == Videojuego.Titulo).ToList().Count == 0 || Videojuego.Unidades >= 0){
            if(Videojuego.Unidades == 0){
                Videojuego.Agotado = true;
            }else{
                Videojuego.Agotado = false;
            }
            Videojuego.Id = nextId++;
            Videojuegos.Add(Videojuego);

            /*SE CREA LA TRANSACCIÓN INICIAL*/
            if (Videojuego.Agotado == false){
                TransaccionService.Add(new Transaccion {Unidades = Videojuego.Unidades, Fecha = DateTime.Now, VideojuegoId = Videojuego.Id});
            }
        }else{
            Console.WriteLine("No has puesto los datos bien.");
            return;
        }
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