using BlazorApp1.Backend.Models;

namespace BlazorApp1.Backend.Repositories
{
	public interface IArticleRepository
	{
		Task<IEnumerable<Article>> GetAllArticlesAsync();
		Article GetArticle(Guid articleId);
		void AddArticle(Article article);
		void UpdateArticle(Article article);
		void DeleteArticle(Article article);

	}
}
