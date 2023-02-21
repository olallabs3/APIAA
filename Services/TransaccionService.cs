using APIAA.Models;

namespace APIAA.Services;

public class TransaccionService{

    static List<Transaccion> Transacciones { get; }
    static int nextId = 4;
    static TransaccionService(){
        Transacciones = new List<Transaccion>{
            new Transaccion {Id = 1, Unidades = 10, Fecha = DateTime.Now, VideojuegoId = 1},
            new Transaccion {Id = 2, Unidades = 8, Fecha = DateTime.Now, VideojuegoId = 2},
            new Transaccion {Id = 3, Unidades = 0, Fecha = DateTime.Now, VideojuegoId = 3},
        };
    }

    public static List<Transaccion> GetAll() => Transacciones;

    public static Transaccion? Get(int id) => Transacciones.FirstOrDefault(t => t.Id == id);

    public static void Add(Transaccion Transaccion){
        Transaccion.Id = nextId++;
        Transacciones.Add(Transaccion);
    }

}