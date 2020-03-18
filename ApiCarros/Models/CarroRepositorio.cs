using System;
using System.Collections.Generic;

namespace ApiCarros.Models
{
    public class CarroRepositorio : ICarroRepositorio
    {
        private List<carro> carro = new List<carro>();
        private int _nextId = 1;

        public CarroRepositorio()
        {
            add(new carro { Modelo = "Kadett", Fabricante = "Gm_chevrolet", Placa = "HZG-4739", Cor = "Branco", Avaria = false });
            add(new carro { Modelo = "Polo", Fabricante = "VW", Placa = "LAO-4742", Cor = "Preto", Avaria = false });
            add(new carro { Modelo = "Kwid", Fabricante = "Renault", Placa = "DQW-2361", Cor = "Branco", Avaria = false });
            add(new carro { Modelo = "Corsa", Fabricante = "Gm_chevrolet", Placa = "LOP-5629", Cor = "Cinza", Avaria = false });
            add(new carro { Modelo = "Celta", Fabricante = "Gm_chevrolet", Placa = "LAO-5213", Cor = "Amarelo", Avaria = false });
            add(new carro { Modelo = "Monza", Fabricante = "Gm_chevrolet", Placa = "LMM-4739", Cor = "Vermelho", Avaria = false });
        }



        public carro add(carro item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            carro.Add(item);
            return item;
        }



        public carro Get(int id)
        {
            return carro.Find(p => p.Id == id);
        }


        public IEnumerable<carro> GetAll()
        {
            return carro;
        }



        public void Remove(int id)
        {
            carro.RemoveAll(p => p.Id == id);
        }



        public bool Update(carro item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = carro.FindIndex(p => p.Id == item.Id);

            if (index == -1)
            {
                return false;
            }
            carro.RemoveAt(index);
            carro.Add(item);
            return true;

        }
    }
}