using DarnThirsty.Core.Entities.Base;

namespace DarnThirsty.Core.Entities;

public class DrinkType : Entity
{
	public int code { get; set; }
	
	public string name { get; set; }
}