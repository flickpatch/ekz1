using System;
using System.Collections.Generic;

namespace GlazAlmaz.Database.Entity;

public partial class Tovar
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Kategory { get; set; } = null!;

    public int Price { get; set; }

    public string Opisanie { get; set; } = null!;

    public int PostavshikNumber { get; set; }

    public byte[]? Photo { get; set; }
}
