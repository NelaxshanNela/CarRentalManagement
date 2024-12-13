using CarRendalAPI.Database;
using CarRendalAPI.Models;

namespace CarRendalAPI.Repositories
{
    public class SendMailRepository(ApplicationDbContext _context)
    {
        public async Task<EmailTemplate> GetTemplate(EmailTypes emailTypes)
        {
            var template = _context.EmailTemplates.Where(x => x.emailTypes == emailTypes).FirstOrDefault();
            return template;
        }
    }
}
