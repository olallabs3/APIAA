namespace APIAA.Models;

public class Videojuego
{
public int Id {get; set;}
public string? Titulo {get; set;}
public double PrecioVenta {get; set;}
public int Unidades {get; set;}
public bool Agotado {get; set;}

public ICollection<Usuario>? Usuarios { get; set; }
public List<Biblioteca>? Bibliotecas {get; set;}
}