using DDDCommerceBCC.Domain;
using DDDCommerceBCC.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ECommerceDB.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _context;

        public PedidosController(IPedidoRepository context)
        {
            _context = context;
        }

        // GET: api/Pedidos
        [HttpGet]
        public ActionResult<List<Pedido>> GetPedidos()
        {
            return _context.GetAll();
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public ActionResult<Pedido> GetPedido(int id)
        {
            var pedido = _context.GetPedidoById(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }


        // POST: api/Pedidos
        [HttpPost]
        public ActionResult<Pedido> PostPedido(Pedido pedido)
        {
            _context.AddPedido(pedido);
            return CreatedAtAction("GetPedido", new { id = pedido.Id }, pedido);
        }

        // DELETE: api/Pedidos/5
        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            if (_context.DeletePedido(id))
                return Ok("Pedido Deletado com sucesso");

            return NotFound("Id nao encontrado");
        }

    }
}
