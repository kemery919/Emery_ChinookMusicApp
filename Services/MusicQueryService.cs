using Microsoft.EntityFrameworkCore;
using Data;

namespace Services;

public class MusicQueryService{

  private readonly ApplicationDbContext _context;

  public MusicQueryService(ApplicationDbContext context) {
      _context = context;
  }

  

}