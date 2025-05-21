using Microsoft.EntityFrameworkCore;
using Data;
using Models.Entities;
using Models.Dtos;

namespace Services;

public class MusicQueryService{

  private readonly ApplicationDbContext _context;

  public MusicQueryService(ApplicationDbContext context) {
      _context = context;
  }


  // Problem 1: Get all artists with albums
  public async Task<List<Artist>> GetAllArtistsWithAlbums() {

    return await _context.Artist
      .Where(artist => artist.Albums.Count > 0)
      .Include(artist => artist.Albums)
      .ToListAsync();

  }

  // Problem 2: Get all artists with more than one album
  public async Task<List<Artist>> GetAllArtistsWithMoreThanOneAlbum() {

    return await _context.Artist
      .Include(a => a.Albums)
      .Where(a => a.Albums.Count > 1)
      .ToListAsync();

  }

  // Problem 3: Get artist by name with albums
  public async Task<Artist?> GetArtistByNameWithAlbums(string artistName) {

    return await _context.Artist
      .Include(a => a.Albums)
      .FirstOrDefaultAsync(a => a.Name == artistName);

  }

  // Problem 4: Get tracks by album id
  public async Task<List<Track>> GetTracksByAlbumId(int albumId){
    
    return await _context.Track
      .Include(track => track.Album)
      .Where(track => track.AlbumId == albumId)
      .ToListAsync();

  }

  // Problem 5: Get all albums with tracks
  public async Task<List<Genre>> GetAllGenresWithTracks(){
    
    return await _context.Genre
      .Include(genre => genre.Tracks)
      .ToListAsync();

  }

  // Problem 6: Get tracks by genre id
  public async Task<List<Track>> GetTracksByGenreId(int genreId){
    return await _context.Track
      .Include(track => track.Genre)
      .Where(track => track.GenreId == genreId)
      .ToListAsync();
  }

  // Problem 7: Get all albums with tracks
  public async Task<List<Statistic>> GetTotalTracksByAlbum(){
    
    return await _context.Album
      .Include(album => album.Tracks)
      .Select (album => new Statistic {
        Label = album.Title,
        Value = album.Tracks.Count,
        ValueMetric = "Tracks"
      })
      .ToListAsync();

  }

  // Problem 8: Get albums by artist id
  public async Task<List<Album>> GetAlbumsByArtistId(int artistId){
   
    return await _context.Album
      .Include(album => album.Artist)
      .Where(album => album.ArtistId == artistId)
      .ToListAsync();

  }

  // Problem 9: Get all pLaylists with tracks
  public async Task<List<Playlist>> GetAllPlaylistsWithTracks(){
    
    return await _context.Playlist
      .Include(playlist => playlist.Tracks)
      .Where(playlist => playlist.Tracks.Count > 0)
      .ToListAsync();

  }

  // Problem 10: Get average duration by genre

  public async Task<List<Statistic>> GetAverageDurationByGenre(){

    return await _context.Genre
      .Include(genre => genre.Tracks)
      .Select (genre => new Statistic {
        Label = genre.Name,
        Value = genre.Tracks.Select(track => track.Milliseconds).Sum()/60,
        ValueMetric = "Seconds"
      })
      .ToListAsync();

  }

}