using APIAA.Models;

namespace APIAA.Services;

public class TransaccionService{

    static List<Transaccion> Transacciones { get; }
    static int nextId = 1;

    public static List<Transaccion> GetAll() => Transacciones;

    public static Transaccion? Get(int id) => Transacciones.FirstOrDefault(t => t.Id == id);

    public static void Add(Transaccion Transaccion){
        Transaccion.Id = nextId++;
        Transacciones.Add(Transaccion);
    }

}