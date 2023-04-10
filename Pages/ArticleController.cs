using BlazorApp1.Backend.Services;
using Microsoft.AspNetCore.Mvc;
using PFAA.Messages;

namespace PFAA.Pages
{
	[Route("[controller]")]
	public class ArticleController : Controller
	{
		private readonly IArticleService _articleService;
		public ArticleController(IArticleService articleService)
		{
			_articleService = articleService;
		}

		[HttpGet]
		public IActionResult GetArticles()
		{
			var articles = _articleService.GetArticles();
			return new JsonResult(articles);
		}

		[HttpPost]
		public IActionResult PostArticle([FromBody] AddArticle command)
		{
			_articleService.AddArticle(command.Name, command.Description, command.Price, command.Manufacturer, command.Articles);

			return Ok();
		}

		[HttpDelete]
		public IActionResult DeleteArticle([FromQuery] Guid articleId) 
		{
			_articleService.DeleteArticle(articleId);

			return Ok();
		}

		[HttpGet("/{id}")]
		public IActionResult GetArticle([FromRoute] Guid articleId)
		{
			var article = _articleService.GetArticle(articleId);

			return new JsonResult(article);
		}
		
	}
}
