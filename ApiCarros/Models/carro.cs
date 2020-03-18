using System.Collections.Generic;

namespace ApiCarros.Models
{
    public class carro
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Fabricante { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public bool Avaria { get; set; }
    }

    public interface ICarroRepositorio
    {
        IEnumerable<carro> GetAll();
        carro Get(int id);
        carro add(carro item);
        void Remove(int id);
        bool Update(carro item);
    }
}