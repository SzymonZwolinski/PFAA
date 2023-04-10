using BlazorApp1.Backend.Enums;
using BlazorApp1.Backend.Models;
using BlazorApp1.Backend.Repositories;
using System.Runtime.CompilerServices;

namespace BlazorApp1.Backend.Services
{
	public class ArticleService : IArticleService
	{
		private readonly IArticleRepository _articleRepository;

		public ArticleService(IArticleRepository articleRepository)
		{
			_articleRepository = articleRepository;
		}

		public void AddArticle(
			string name,
			string description,
			decimal price,
			string manufacturer,
			List<ArticleIngredients> articles)
		{
			var article = 
				new Article(
					name,
					description,
					price,
					manufacturer,
					articles);

			_articleRepository.AddArticle(article);
		}

		public void DeleteArticle(Guid articleId)
		{
			var article = _articleRepository.GetArticle(articleId);
			_articleRepository.DeleteArticle(article);
		}

		public Article GetArticle(Guid articleId)
		{
			return _articleRepository.GetArticle(articleId);
		}

		public Task<IEnumerable<Article>> GetArticles()
		{
			return _articleRepository.GetAllArticlesAsync();
		}

		public async Task<IEnumerable<Article>> GetArticlesWithFilters(string ingredientName)
		{
			var articles = await _articleRepository.GetAllArticlesAsync();
			if(!string.IsNullOrWhiteSpace(ingredientName))
			{
				 return articles.Where(x => x.Articles.SelectMany(y => y.Name) == ingredientName);
			}

			return articles;
		}

		public void UpdateArticle(Guid articleId, string name, string description, decimal price, string manufacturer, List<ArticleIngredients> articles)
		{
			throw new NotImplementedException();
		}
	}
}
