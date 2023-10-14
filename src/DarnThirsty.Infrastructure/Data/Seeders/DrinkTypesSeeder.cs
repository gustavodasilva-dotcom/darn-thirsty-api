using DarnThirsty.Core.Entities;
using MongoDB.Driver;

namespace DarnThirsty.Infrastructure.Data.Seeders;

public static class DrinkTypesSeeder
{
	public static void Run(IMongoCollection<DrinkType> drinkTypesCollection)
	{
		try
		{
			void Seed(string _name)
			{
				var drinkType = drinkTypesCollection.FindSync(t => t.name.Equals(_name)).FirstOrDefault();

				if (drinkType == null)
				{
					drinkType = new DrinkType
					{
						name = _name
					};

					drinkTypesCollection.InsertOne(drinkType);
				}
			}

			Seed("Beers");
			Seed("Wines");
			Seed("Distilled");
			Seed("Cocktail");
		}
		catch (Exception e)
		{
			throw new Exception(string.Format("{0} - : {1}", nameof(DrinkTypesSeeder), e.Message));
		}
	}
}