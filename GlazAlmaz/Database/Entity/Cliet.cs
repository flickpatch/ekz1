using System;
using System.Collections.Generic;

namespace GlazAlmaz.Database.Entity;

public partial class Cliet
{
    public int UserId { get; set; }

    public string Fio { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Phone { get; set; } = null!;
}
