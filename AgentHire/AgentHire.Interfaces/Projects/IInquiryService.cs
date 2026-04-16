using AgentHire.Data.Data.Projects;

namespace AgentHire.Interfaces.Projects
{
    public interface IInquiryService
    {
        Task<IList<Inquiry>> GetInquiries();
        Task<Inquiry?> GetInquiry(int idInquiry);
        Task SaveInquiry(Inquiry inquiry);
    }
}
