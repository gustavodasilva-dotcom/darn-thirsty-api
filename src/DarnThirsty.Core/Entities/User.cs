using DarnThirsty.Core.Entities.Base;

namespace DarnThirsty.Core.Entities;

public class User : Entity
{
    public string name { get; set; }

    public string email { get; set; }

    public string password { get; set; }

    public bool active { get; set; }
}