using System;
using System.Collections.Generic;

namespace book_store_console_app.Models;

public partial class TblBook
{
    public string VcIsbn { get; set; } = null!;

    public string VcTitle { get; set; } = null!;

    public string VcAuthor { get; set; } = null!;

    public string VcPublisher { get; set; } = null!;

    public string VcEdition { get; set; } = null!;

    public decimal DecPrice { get; set; }

    public int IntYear { get; set; }
}
