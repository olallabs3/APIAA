namespace APIAA.Models;

public class Biblioteca
{
    public int UsuarioId {get; set;}
    public Usuario? Usuario {get; set;}

    public int VideojuegoId {get; set;}
    public Videojuego? Videojuego {get; set;}
    
}