using System.Xml.Linq;

namespace BlazorApp1.Backend.Models
{
	public class ArticleIngredients
	{
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public string Amount { get; private set; }

		public ArticleIngredients(string name, string Amount)
		{
			Id = Guid.NewGuid();
			SetTitle(name);
			SetAmount(Amount);
		}

		private void SetTitle(string name) 
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("invalid_ingredientname_value", $"Ingredient Name can not be null or whitespace.");
			}	

			if(name.Length > 255)
			{
				throw new ArgumentOutOfRangeException("invalid_ingredientname_length", $"Ingredient Name can not be longer than 255 chars.");
			}

			Name = name;
		}

		private void SetAmount(string amount) 
		{
			if(!string.IsNullOrWhiteSpace(amount)
				&& amount.Length > 255) 
			{
				throw new ArgumentOutOfRangeException("invalid_amount_lenght", $"Length can not be longer than 255 chars.");
			}

			Amount = amount;
		}
	}
}
