using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_imdb.Models;

[Table("interests")]
public partial class Interest
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("genre_id")]
    public int GenreId { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Interests")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("GenreId")]
    [InverseProperty("Interests")]
    public virtual Genre Genre { get; set; } = null!;
}
