using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dtos;

public class Statistic {
  
  [Required]
  public required string Label { get; set; }

  public decimal Value { get; set; }

  public string? ValueMetric { get; set; } // e.g. "Seconds", "Count"
      
}