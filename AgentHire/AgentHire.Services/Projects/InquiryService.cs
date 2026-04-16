using AgentHire.Data.Data;
using AgentHire.Data.Data.Projects;
using AgentHire.Interfaces.Projects;
using AgentHire.Services.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AgentHire.Services.Projects
{
    public class InquiryService : BaseService, IInquiryService
    {
        public InquiryService(AgentHireContext context) : base(context) { }

        public async Task<IList<Inquiry>> GetInquiries()
        {
            return await _context.Inquiry.ToListAsync();
        }

        public async Task<Inquiry?> GetInquiry(int idInquiry)
        {
            return await _context.Inquiry.FirstOrDefaultAsync(x => x.IdInquiry == idInquiry);
        }

        public async Task SaveInquiry(Inquiry inquiry)
        {
            _context.Inquiry.Add(inquiry);
            await _context.SaveChangesAsync();
        }
    }
}
