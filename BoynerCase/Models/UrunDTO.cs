﻿using System;
using System.Collections.Generic;

namespace BoynerCase.Models;

public partial class UrunDTO
{
    public int Id { get; set; }

    public string UrunIsmi { get; set; } = null!;

    public string? Aciklama { get; set; }

    public int? KategoriId { get; set; }
}