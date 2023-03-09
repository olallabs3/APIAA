using APIAA.Models;

namespace APIAA.Services;

public static class BibliotecaService{
    static List<Biblioteca> Bibliotecas {get;}
    static int nextId = 1;
    static BibliotecaService(){
        Bibliotecas = new List<Biblioteca>{};
    
    }

    /* public async List<Biblioteca>GetUsr(int i){
        IQueryable<Biblioteca>? query = EntitySet;
        foreach(string model in Lista)
    } */

    
}