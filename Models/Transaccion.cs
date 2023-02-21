namespace APIAA.Models;

public class Transaccion
{
    public int Id { get; set; }
    public decimal Unidades { get; set;}
    public DateTime Fecha { get; set;}
    public int VideojuegoId {get; set;}

}