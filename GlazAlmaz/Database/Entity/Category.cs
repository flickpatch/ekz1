using System;
using System.Collections.Generic;

namespace GlazAlmaz.Database.Entity;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}
