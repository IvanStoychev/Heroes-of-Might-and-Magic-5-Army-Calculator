using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class TSystemIcon
{
    public int Id { get; set; }

    public string Name { get; set; }

    public byte[] ImageBytes { get; set; }
}
