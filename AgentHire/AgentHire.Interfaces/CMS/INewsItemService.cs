using AgentHire.Data.Data.CMS;

namespace AgentHire.Interfaces.CMS
{
    public interface INewsItemService
    {
        Task<IList<NewsItem>> GetNewsItems();
        Task<NewsItem?> GetNewsItem(int idNewsItem);
    }
}
