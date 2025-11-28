using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_imdb.Models;

[Table("rating")]
public partial class Rating
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("movie_id")]
    public int MovieId { get; set; }

    [Column("rating", TypeName = "decimal(18, 0)")]
    public decimal Rating1 { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Ratings")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("MovieId")]
    [InverseProperty("Ratings")]
    public virtual Movie Movie { get; set; } = null!;
}
