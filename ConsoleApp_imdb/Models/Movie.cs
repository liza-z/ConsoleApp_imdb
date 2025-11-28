using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_imdb.Models;

[Table("movie")]
public partial class Movie
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Title { get; set; }

    [Column("release_date")]
    public DateOnly ReleaseDate { get; set; }

    [Column("duration")]
    public int Duration { get; set; }

    [Column("director_id")]
    public int DirectorId { get; set; }

    [Column("writer_id")]
    public int WriterId { get; set; }

    [Column("rating")]
    public int? Rating { get; set; }

    [Column("box_office")]
    public long? BoxOffice { get; set; }

    [Column("budget")]
    public long? Budget { get; set; }

    [ForeignKey("DirectorId")]
    [InverseProperty("Movies")]
    public virtual Director Director { get; set; } = null!;

    [InverseProperty("Movie")]
    public virtual ICollection<GenreMovie> GenreMovies { get; set; } = new List<GenreMovie>();

    [InverseProperty("Movie")]
    public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();

    [InverseProperty("Movie")]
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    [ForeignKey("WriterId")]
    [InverseProperty("Movies")]
    public virtual Writer Writer { get; set; } = null!;
}
