using System;
using System.Collections.Generic;

namespace SurfAppAPI.Models;

public partial class Image
{
    public int Id { get; set; }

    public int BoardId { get; set; }

    public string Picture { get; set; } = null!;

    public virtual Board Board { get; set; } = null!;
}
