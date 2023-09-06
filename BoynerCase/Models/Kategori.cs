using System;
using System.Collections.Generic;

namespace BoynerCase.Models;

public partial class Kategori
{
    public int Id { get; set; }

    public string KategoriIsmi { get; set; } = null!;

    public virtual ICollection<Urun> Uruns { get; set; } = new List<Urun>();
}
