using System;
using System.Collections.Generic;

namespace GlazAlmaz.Database.Entity;

public partial class User
{
    public int Userid { get; set; }

    public string Login { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string Role { get; set; } = null!;
}
