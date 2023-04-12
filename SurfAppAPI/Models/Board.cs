using System;
using System.Collections.Generic;

namespace SurfAppAPI.Models;

public partial class Board
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double? Length { get; set; }

    public double? Width { get; set; }

    public double? Thickness { get; set; }

    public double? Volume { get; set; }

    public string? Type { get; set; }

    public decimal Price { get; set; }

    public string? Equipment { get; set; }

    public int? ClickCount { get; set; }

    public int Version { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual ICollection<Image> Images { get; } = new List<Image>();
}
