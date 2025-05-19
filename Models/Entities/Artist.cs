using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

public class Artist {

  [Key]
  public int ArtistId { get; set; }

  [Required]
  public required string Name { get; set; }

  public virtual ICollection<Album> Albums { get; set; } = new List<Album>();

}