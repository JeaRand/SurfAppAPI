using System;
using System.Collections.Generic;

namespace SurfAppAPI.Models;

public partial class Booking
{
    public int Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string CustomerId { get; set; } = null!;

    public int BoardId { get; set; }

    public virtual Board Board { get; set; } = null!;

    public virtual AspNetUser Customer { get; set; } = null!;
}
