using System;
using System.Collections.Generic;

namespace AirlineManagementAPI.Models.EF;

public partial class FlightInfo
{
    public int FlightNo { get; set; }

    public string? FromCity { get; set; }

    public string? ToCity { get; set; }

    public int? AvailableSeats { get; set; }

    public decimal? Fare { get; set; }
}
