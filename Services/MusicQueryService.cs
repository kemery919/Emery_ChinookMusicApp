using Microsoft.EntityFrameworkCore;
using Data;
using Models.Entities;

namespace Services;

public class MusicQueryService{

  private readonly ApplicationDbContext _context;

  public MusicQueryService(ApplicationDbContext context) {
      _context = context;
  }

  public async Task<List<Artist>> GetAllArtistsWithAlbums() {

    return await _context.Artist
      .Where(artist => artist.Albums.Count > 0)
      .Include(artist => artist.Albums)
      .ToListAsync();
  }

}