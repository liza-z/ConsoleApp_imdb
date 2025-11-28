using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_imdb.Models;

[Table("customers")]
public partial class Customer
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(30)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("surname")]
    [StringLength(50)]
    [Unicode(false)]
    public string Surname { get; set; } = null!;

    [Column("mail")]
    [StringLength(100)]
    [Unicode(false)]
    public string Mail { get; set; } = null!;

    [Column("password")]
    [StringLength(20)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [InverseProperty("Customer")]
    public virtual ICollection<Interest> Interests { get; set; } = new List<Interest>();

    [InverseProperty("Customer")]
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    [InverseProperty("Customer")]
    public virtual ICollection<SignIn> SignIns { get; set; } = new List<SignIn>();
}
