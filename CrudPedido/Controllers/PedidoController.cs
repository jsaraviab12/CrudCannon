using CrudPedido.Managers;
using CrudPedido.Models;
using CrudPedido.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CrudPedido.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoManager _pedidoManager;
        public PedidoController(PedidoManager pedidoManager)
        {
            _pedidoManager = pedidoManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetPedidos()
        {
            List<Pedido> lista = await _pedidoManager.GetPedidos();

            return StatusCode(StatusCodes.Status200OK, lista);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedido(int id)
        {
            Pedido lista = await _pedidoManager.GetPedido(id);
            return StatusCode(StatusCodes.Status200OK, lista);
        }
        [HttpPost]
        public async Task<IActionResult> crear([FromBody] PedidoRequest pedido)
        {
            bool respuesta = await _pedidoManager.CreatePedido(pedido);

            return StatusCode(StatusCodes.Status200OK, respuesta);
        }
        [HttpPut]
        public async Task<IActionResult> actualizar([FromBody] Pedido pedido)
        {
            bool respuesta = await _pedidoManager.ActualizarPedido(pedido);

            return StatusCode(StatusCodes.Status200OK, respuesta);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> eliminar(string id)
        {
            bool respuesta = await _pedidoManager.EliminarPedido(id);

            return StatusCode(StatusCodes.Status200OK, respuesta);
        }
    }
}
