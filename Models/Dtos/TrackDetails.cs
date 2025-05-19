using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dtos;

public class TrackDetails {

  [Required]
  public required string Track { get; set; }

  [Required]
  public required string Album { get; set; }

  [Required]
  public required string Artist { get; set; }

} 