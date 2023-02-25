using System;
using System.Collections.Generic;

namespace GlazAlmaz.Database.Entity;

public partial class Postavshiki
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public long Phone { get; set; }
}
