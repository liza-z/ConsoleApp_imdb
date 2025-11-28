using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_imdb.Models;

[Table("genre_movies")]
public partial class GenreMovie
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("genre_id")]
    public int GenreId { get; set; }

    [Column("movie_id")]
    public int MovieId { get; set; }

    [ForeignKey("GenreId")]
    [InverseProperty("GenreMovies")]
    public virtual Genre Genre { get; set; } = null!;

    [ForeignKey("MovieId")]
    [InverseProperty("GenreMovies")]
    public virtual Movie Movie { get; set; } = null!;
}
