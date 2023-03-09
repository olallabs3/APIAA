namespace APIAA.Models;

public class Usuario
{
public int Id {get; set;}
public string? Nombre {get; set;}
public string? Contrasenya {get; set;}
public DateTime Fecha {get; set;}
public bool Admin {get; set;}

public ICollection<Videojuego>? Videojuegos { get; set; }
public List<Biblioteca>? Bibliotecas {get; set;}
}