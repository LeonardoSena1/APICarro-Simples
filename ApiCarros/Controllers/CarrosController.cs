using ApiCarros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCarros.Controllers
{

    public class CarrosController : ApiController
    {
        static readonly ICarroRepositorio repositorio = new CarroRepositorio();

        //GetAllCarros – retorna todos os Carros;
        public IEnumerable<carro> GetAllCarros()
        {
            return repositorio.GetAll();
        }


        //GetCarro – retorna um Carro;
        public carro GetCarro(int id)
        {
            carro item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }


        //GetCarrosPorFabricante – retorna os carros por fabricante;
        public IEnumerable<carro> GetCarrosPorFabricante(string fabricante)
        {
            return repositorio.GetAll().Where(p => string.Equals(p.Fabricante, fabricante, StringComparison.OrdinalIgnoreCase));
        }


        //PostCarro – inclui um novo carro;
        public HttpResponseMessage PostCarro(carro item)
        {
            item = repositorio.add(item);
            var response = Request.CreateResponse<carro>(HttpStatusCode.Created, item);

            string Uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(Uri);
            return response;
        }


        //PutCarro – altera um carro;
        public void PutCarro(int id, carro carro)
        {
            carro.Id = id;
            if (!repositorio.Update(carro))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }


        //DeleteCarro – exclui um carro;
        public void DeleteCarro(int id)
        {
            carro item = repositorio.Get(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repositorio.Remove(id);
        }
    }
}
