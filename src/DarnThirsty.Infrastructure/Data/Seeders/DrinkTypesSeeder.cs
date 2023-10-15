using DarnThirsty.Core.Data;
using DarnThirsty.Core.Entities;
using DarnThirsty.Core.Enums;
using MongoDB.Driver;

namespace DarnThirsty.Infrastructure.Data.Seeders;

public static class DrinkTypesSeeder
{
	public static void Run(IMongoContext mongoContext)
	{
		try
		{
			void Seed(string name, int code)
			{
				var drinkType = mongoContext.DrinkTypes.FindSync(t => t.name.Equals(name)).FirstOrDefault();

				if (drinkType == null)
				{
					drinkType = new DrinkType
					{
						code = code,
						name = name
					};

					mongoContext.DrinkTypes.InsertOne(drinkType);
				}
			}

			Seed("Beers", (int)DrinkTypesEnum.Beers);
			Seed("Wines", (int)DrinkTypesEnum.Wines);
			Seed("Distilled", (int)DrinkTypesEnum.Distilled);
			Seed("Cocktail", (int)DrinkTypesEnum.Cocktail);
		}
		catch (Exception e)
		{
			throw new Exception(string.Format("{0} - : {1}", nameof(DrinkTypesSeeder), e.Message));
		}
	}
}