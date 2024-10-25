using System;
using System.Collections.Generic;

namespace WEBMandiri.Models;

public partial class Transaksi
{
    public int Id { get; set; }

    public int? IdUser { get; set; }

    public string? NamaBarang { get; set; }

    public int? Jumlah { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
