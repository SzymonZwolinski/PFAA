namespace BlazorApp1.Backend.Models
{
	public class Article
	{
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public decimal Price { get; private set; }
		public DateTime CreateData { get; private set; }
		public string Manufacturer { get; private set; }
		public IEnumerable<ArticleIngredients> Articles => _Articles;
		private List<ArticleIngredients> _Articles { get; set; } = new List<ArticleIngredients>();

		public Article(
			string name,
			string description,
			decimal price,
			string manufacturer,
			List<ArticleIngredients> articles)
		{
			Id = Guid.NewGuid();
			CreateData = DateTime.UtcNow;
			SetName(name);
			SetDescription(description);
			SetPrice(price);
			SetManufacturer(manufacturer);
			SetArticles(articles);
		}

		private void SetName(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("invalid_name_value", $"Name can not be null or whitespace.");
			}

			if (name.Length > 255)
			{
				throw new ArgumentOutOfRangeException("invalid_name_length", $"Name can not be longer than 255 chars.");
			}

			Name = name;
		}

		private void SetDescription(string description)
		{
			if (string.IsNullOrWhiteSpace(description))
			{
				throw new ArgumentNullException("invalid_description_value", $"Description can not be null or whitespace.");
			}

			if (description.Length > 255)
			{
				throw new ArgumentOutOfRangeException("invalid_description_length", $"Description can not be longer than 255 chars.");
			}

			Description = description;
		}

		private void SetPrice(decimal price)
		{
			if(price < 0)
			{
				throw new ArgumentOutOfRangeException("invalid_price_value", $"Price can not be less than 0");
			}

			Price = price;
		}

		private void SetManufacturer(string manufacturer)
		{
			if(manufacturer.Length > 255) 
			{
				throw new ArgumentOutOfRangeException("invalid_manufacturer_lenght", $"Manufacturer lenght can not be longer than 255 chars.");
			}

			Manufacturer = manufacturer;
		}

		private void SetArticles(List<ArticleIngredients> articles)
		{
			if(articles is not null && !articles.Any())
			{
				throw new ArgumentNullException("invalid_ingredients_value", $"Ingredients list can not be null or empty.");
			}

			_Articles = articles;
		}
	}
}
