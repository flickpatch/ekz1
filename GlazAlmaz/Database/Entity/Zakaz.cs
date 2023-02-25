using System;
using System.Collections.Generic;

namespace GlazAlmaz.Database.Entity;

public partial class Zakaz
{
    public int Id { get; set; }

    public string ClientId { get; set; } = null!;

    public string TovarId { get; set; } = null!;

    public DateTime Date { get; set; }

    public string Number { get; set; } = null!;

    public string? Discription { get; set; }
}
