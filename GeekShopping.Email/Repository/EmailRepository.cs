using GeekShopping.Email.Messages;
using GeekShopping.Email.Model;
using GeekShopping.Email.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GeekShopping.Email.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<SqlDbContext> _context;

        public EmailRepository(DbContextOptions<SqlDbContext> context)
        {
            _context = context;
        }

        public async Task SendEmail(UpdatePaymentResultMessage message)
        {
            var email = new EmailLog();
            email.Email = message.Email;
            email.SentDate = DateTime.Now;
            email.Log = $"Order - {message.OrderId} has been created successfully!";

            await using var _db = new SqlDbContext(_context);
            _db.Emails.Add(email);
            await _db.SaveChangesAsync();
        }

    }
}
