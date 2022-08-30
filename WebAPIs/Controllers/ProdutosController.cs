using Domain.InterfacesExternal;
using Entities.EntitiesExternal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        private readonly IProduto _IProduto;

        public ProdutosController(IProduto IProduto)
        {
            _IProduto = IProduto;
        }

        [Produces("application/json")]
        [HttpPost("/api/ListProd")]
        public List<Produto> ListProd()
        {
            return _IProduto.List();
        }

        [Produces("application/json")]
        [HttpPost("/api/GetOne")]
        public Produto GetOne(int id)
        {
            return _IProduto.GetOne(id);
        }

        [Produces("application/json")]
        [HttpPost("/api/CreateProd")]
        public bool CreateProd(Produto collection)
        {
            try
            {
                _IProduto.Create(collection);

                return true;
            }
            catch
            {
                return false;
            }
        }

        [Produces("application/json")]
        [HttpPost("/api/UpdateProd")]
        public bool UpdateProd(Produto collection)
        {
            try
            {
                _IProduto.Update(collection);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [Produces("application/json")]
        [HttpPost("/api/DeleteProd")]
        public bool DeleteProd(int id)
        {
            try
            {
                _IProduto.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
