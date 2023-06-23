using Microsoft.AspNetCore.Mvc;
using TiendaApi.Datos;
using TiendaApi.Model;

namespace TiendaApi.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController
    {
        [HttpGet]
        public async Task<ActionResult<List<ModeloProducto>>>Get()
        {
            var funcion = new DatosProductos();
            var lista = await funcion.MostrarRecibo();
            return lista;
        }
        [HttpPost]
        public async Task Post([FromBody] ModeloProducto parametros)
        {
            var funcion = new DatosProductos();
            await funcion.InsertarRecibo(parametros);

        }
    }
}
