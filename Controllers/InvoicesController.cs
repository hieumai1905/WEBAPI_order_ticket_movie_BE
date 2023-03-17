using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_order_ticket.Models;
using WEBAPI_order_ticket.Repositories.InvoicesRepository;

namespace WEBAPI_order_ticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private IInvoiceRepository _invoiceRepository;

        public InvoicesController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetAllInvoice()
        {
            try
            {
                var invoices = await _invoiceRepository.GetAllAsync();
                return Ok(invoices);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoiceById([FromRoute] string id)
        {
            try
            {
                var invoice = await _invoiceRepository.GetByIdAsync(id);
                return Ok(invoice);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("invoices/{idUser}")]
        public async Task<ActionResult<Invoice>> GetInvoiceByIdUser([FromRoute] string idUser)
        {
            try
            {
                var invoices = await _invoiceRepository.GetAllInvoiceByIdUser(idUser);
                return Ok(invoices);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost()]
        public async Task<ActionResult<Invoice>> CreateInvoice(Invoice invoice)
        {
            try
            {
                invoice.InvoiceId = Guid.NewGuid().ToString();
                var newInvoice = await _invoiceRepository.AddAsync(invoice);
                return CreatedAtAction(nameof(GetInvoiceById), new { id = newInvoice.InvoiceId }, newInvoice);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
