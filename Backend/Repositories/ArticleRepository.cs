using BlazorApp1.Backend.Models;

namespace BlazorApp1.Backend.Repositories
{
	public class ArticleRepository : IArticleRepository
	{
		public readonly List<Article> Articles = new List<Article>();
		public ArticleRepository() 
		{
			//TODO: Dodać db 
		}

		public void AddArticle(Article article)
		{
			Articles.Add(article);
		}

		public void DeleteArticle(Article article)
		{
			Articles.Remove(article);
		}

		public Task<IEnumerable<Article>> GetAllArticlesAsync()
		{
			return (Task<IEnumerable<Article>>)Articles.AsEnumerable();
		}

		public Article GetArticle(Guid articleId)
		{
			return Articles.FirstOrDefault(x => x.Id == articleId);
		}

		public void UpdateArticle(Article article)
		{
			throw new NotImplementedException();
		}
	}
}
