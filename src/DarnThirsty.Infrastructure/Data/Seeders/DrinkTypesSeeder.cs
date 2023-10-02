using DarnThirsty.Core.Entities;
using MongoDB.Driver;

namespace DarnThirsty.Infrastructure.Data.Seeders;

public static class DrinkTypesSeeder
{
	public static async Task RunAsync(IMongoCollection<DrinkType> drinkTypesCollection)
	{
		try
		{
			async Task Seed(string _name)
			{
				if (await drinkTypesCollection.FindSync(t => t.name.Equals(_name)).FirstOrDefaultAsync() == null)
				{
					await drinkTypesCollection.InsertOneAsync(new DrinkType
					{
						name = _name
					});
				}
			}

			await Seed("Beers");
			await Seed("Wines");
			await Seed("Distilled");
			await Seed("Cocktail");
		}
		catch (Exception e)
		{
			Console.WriteLine(string.Format("The following error occurred at {0}: {1}",
				nameof(RunAsync), e.Message));
		}
	}
}