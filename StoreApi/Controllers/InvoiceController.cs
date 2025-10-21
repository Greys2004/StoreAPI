using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApi.Models.DTOs;
using StoreApi.Models.Entities;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public InvoicesController(StoreDbContext context)
        {
            _context = context;
        }

        // GET: /api/invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices(int? orderId, bool? isPaid)
        {
            var query = _context.Invoices.AsQueryable();

            if (orderId.HasValue)
                query = query.Where(i => i.OrderId == orderId.Value);

            if (isPaid.HasValue)
                query = query.Where(i => i.IsPaid == isPaid.Value);

            var invoices = await query
                .Include(i => i.Order)
                .ToListAsync();

            return Ok(invoices);
        }

        // GET: /api/invoices/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var invoice = await _context.Invoices
                .Include(i => i.Order)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (invoice == null)
                return NotFound();

            return Ok(invoice);
        }

        // POST: /api/invoices
        [HttpPost]
        public async Task<ActionResult> CreateInvoice([FromBody] InvoiceDTO dto)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var order = await _context.Order.FindAsync(dto.OrderId);
                if (order == null)
                    return BadRequest("La orden indicada no existe.");

                var total = dto.Total;
                if (total == 0)
                    total = dto.Subtotal + dto.Tax;

                var invoice = new Invoice
                {
                    OrderId = dto.OrderId,
                    InvoiceNumber = dto.InvoiceNumber,
                    IssueDate = dto.IssueDate,
                    DueDate = dto.DueDate,
                    Subtotal = dto.Subtotal,
                    Tax = dto.Tax,
                    Total = total,
                    Currency = dto.Currency,
                    IsPaid = dto.IsPaid,
                    PaymentDate = dto.PaymentDate,
                    BillingName = dto.BillingName,
                    BillingAddress = dto.BillingAddress,
                    BillingEmail = dto.BillingEmail,
                    TaxId = dto.TaxId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = null
                };

                _context.Invoices.Add(invoice);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return CreatedAtAction(nameof(GetInvoice), new { id = invoice.Id }, invoice);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return Problem("Ocurrió un error al crear la factura.");
            }
        }
    }
}
