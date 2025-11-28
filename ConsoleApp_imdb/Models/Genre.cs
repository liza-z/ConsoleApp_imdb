using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_imdb.Models;

[Table("genre")]
public partial class Genre
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(30)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Genre")]
    public virtual ICollection<GenreMovie> GenreMovies { get; set; } = new List<GenreMovie>();

    [InverseProperty("Genre")]
    public virtual ICollection<Interest> Interests { get; set; } = new List<Interest>();
}
