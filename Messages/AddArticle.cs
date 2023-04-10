using BlazorApp1.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace PFAA.Messages
{
	public class AddArticle
	{
		[FromBody]
		public string Name { get;  set; }
		[FromBody]
		public string Description { get;  set; }
		[FromBody]
		public decimal Price { get;  set; }
		[FromBody]
		public string Manufacturer { get;  set; }
		[FromBody]
		public List<ArticleIngredients> Articles { get; set; }
	}
}
