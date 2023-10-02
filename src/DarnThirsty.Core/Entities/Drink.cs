using DarnThirsty.Core.Entities.Base;

namespace DarnThirsty.Core.Entities;

public class Drink : Entity
{
	public string name { get; set; }

	public string image { get; set; }

	public DrinkType type { get; set; }

	public string[] about { get; set; }

	public Recipe recipe { get; set; }
}