using Microsoft.AspNetCore.Mvc;
using WEBAPI_order_ticket.Models;
using WEBAPI_order_ticket.Repositories.TicketRepository;

namespace WEBAPI_order_ticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private ITicketRepository _ticketRepository;

        public TicketsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetAllTicket()
        {
            try
            {
                var tickets = await _ticketRepository.GetAllAsync();
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicketById([FromRoute] string id)
        {
            try
            {
                var ticket = await _ticketRepository.GetByIdAsync(id);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("invoices/{idTicket}")]
        public async Task<ActionResult<Ticket>> GetTicketByIdTicket([FromRoute] string idTicket)
        {
            try
            {
                var tickets = await _ticketRepository.GetAllByInvoiceId(idTicket);
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost()]
        public async Task<ActionResult<Ticket>> CreateTicket(Ticket ticket)
        {
            try
            {
                ticket.TicketId = Guid.NewGuid().ToString();
                var newTicket = await _ticketRepository.AddAsync(ticket);
                return CreatedAtAction(nameof(GetTicketById), new { id = newTicket.TicketId }, newTicket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
