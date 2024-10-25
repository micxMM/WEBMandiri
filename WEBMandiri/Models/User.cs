using System;
using System.Collections.Generic;

namespace WEBMandiri.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Nama { get; set; }

    public int? Umur { get; set; }

    public string? Pekerjaan { get; set; }

    public string? Domisili { get; set; }

    public virtual ICollection<Transaksi> Transaksis { get; set; } = new List<Transaksi>();
}
