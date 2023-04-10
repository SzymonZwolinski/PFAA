using BlazorApp1.Backend.Enums;
using BlazorApp1.Backend.Models;

namespace BlazorApp1.Backend.Services
{
	public interface IArticleService
	{
		Task<IEnumerable<Article>> GetArticles();
		Task<IEnumerable<Article>> GetArticlesWithFilters(string ingredientName);
		Article GetArticle(Guid articleId);
		void AddArticle(
			string name,
			string description,
			decimal price,
			string manufacturer,
			List<ArticleIngredients> articles);
		void DeleteArticle(Guid articleId);
		void UpdateArticle(
			Guid articleId,
			string name,
			string description,
			decimal price,
			string manufacturer,
			List<ArticleIngredients> articles); //TODO: Zakładamy, że aktualizując produkt, aktualizujemy go całego (tworzymy od nowa)

	}
}
