using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

public class Playlist {

  [Key]
  public int PlaylistId { get; set; }

  [Required]
  public string Name { get; set; } 

  public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();

}