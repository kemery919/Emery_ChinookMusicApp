using Microsoft.EntityFrameworkCore;
using Data;

namespace Services;

public class MusicQueryService{

  private readonly ApplicationDbContext _context;

  public MusicQueryService(ApplicationDbContext context) {
      _context = context;
  }

  public async Task<List<string>> GetAllArtistsWithAlbums() {

    return await _context.Artist
      .Include(a => a.Albums)
      .Select(a => a.Name)
      .ToListAsync();

  }

}