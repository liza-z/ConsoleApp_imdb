using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_imdb.Models;

[Table("movie_actor")]
public partial class MovieActor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("movie_id")]
    public int MovieId { get; set; }

    [Column("actor_id")]
    public int ActorId { get; set; }

    [ForeignKey("ActorId")]
    [InverseProperty("MovieActors")]
    public virtual Actor Actor { get; set; } = null!;

    [ForeignKey("MovieId")]
    [InverseProperty("MovieActors")]
    public virtual Movie Movie { get; set; } = null!;
}
