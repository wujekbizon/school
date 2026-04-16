using AgentHire.Data.Data.CMS;

namespace AgentHire.Interfaces.CMS
{
    public interface IPageService
    {
        Task<IList<Page>> GetPages();
        Task<Page?> GetPage(int idPage);
    }
}
