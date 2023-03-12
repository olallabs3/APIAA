using APIAA.Models;

namespace APIAA.Services;

public static class BibliotecaService{
    static List<Biblioteca> Bibliotecas {get;}
    static int nextId = 1;
    static BibliotecaService(){
        Bibliotecas = new List<Biblioteca>{};
    
    }    
}