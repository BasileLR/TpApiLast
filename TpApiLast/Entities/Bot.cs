using System;
using System.Collections.Generic;

namespace TpApiLast.Entities;

public partial class Bot
{
    public int? Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? BotName { get; set; }

    public string? Password { get; set; }

    public string? EnrollmentDate { get; set; }
}
