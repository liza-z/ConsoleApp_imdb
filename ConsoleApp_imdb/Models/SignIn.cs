using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_imdb.Models;

[Table("sign_in")]
public partial class SignIn
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("ip_address")]
    [StringLength(50)]
    [Unicode(false)]
    public string? IpAddress { get; set; }

    [Column("time")]
    public DateOnly? Time { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("SignIns")]
    public virtual Customer Customer { get; set; } = null!;
}
