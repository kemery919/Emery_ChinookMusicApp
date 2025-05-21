using Microsoft.EntityFrameworkCore;
using Data;
using Models.Entities;
using Models.Dtos;
using SQLitePCL;

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
        Value = (decimal)(genre.Tracks.Select(track => track.Milliseconds).Average()/1000),
        ValueMetric = "Seconds"
      })
      .ToListAsync();

  }

  // Problem 11: Get all artists that have no albums
  public async Task<List<Artist>> GetArtistsWithoutAlbums(){

    return await _context.Artist
      .Include(artist => artist.Albums)
      .Where(artist => artist.Albums.Count == 0)
      .ToListAsync();

  }

  // Problem 12: All tracks and their genre and album
  public async Task<List<Track>> GetTracksWithGenreAndAlbum(){
    
    return await _context.Track
        .Include(track => track.Genre)
        .Include(track => track.Album)
        .ToListAsync();
  
  }

  // Problem 13: Simplified list of track details via the TrackDetails DTO
  public async Task<List<TrackDetails>> GetTrackDetails(){

    return await _context.Track
      .Include(track => track.Album)
      #pragma warning disable CS8602
        .ThenInclude(album => album.Artist)
      .Select (track => new TrackDetails {
        Track = track.Name,
        #pragma warning disable CS8602
        Album = track.Album.Title,
        #pragma warning disable CS8602
        Artist = track.Album.Artist.Name
      })
      .ToListAsync();

  }

  // Problem 14: Albums with the total duration of thier tracks with Statistic DTO
  public async Task<List<Statistic>> GetAlbumsWithTrackDuration(){

    return await _context.Album
      .Include(album => album.Tracks)
      .Select(album => new Statistic{
        Label = album.Title,
        Value = album.Tracks.Select(track => track.Milliseconds).Sum()/1000,
        ValueMetric = "Seconds"
      })
      .ToListAsync();

  }

  // Problem 15: genres with tracks using Statistic DTO
  public async Task<List<Statistic>> GetGenreTrackCounts(){

    return await _context.Genre
      .Include(genre => genre.Tracks)
      .Select(genre => new Statistic{
        Label = genre.Name,
        Value = genre.Tracks.Count(),
        ValueMetric = "Tracks"
      })
      .ToListAsync();

  }

  // Problem 16: Playlist with track count via Statistic DTO
  public async Task<List<Statistic>> GetPlaylistsWithTrackCount(){

    return await _context.Playlist
      .Include(playlist => playlist.Tracks)
      .Select(playlist => new Statistic{
        Label = playlist.Name,
        Value = playlist.Tracks.Count(),
        ValueMetric = "Tracks"
      })
      .ToListAsync();

  }

  // Problem 17: list of all tracks that belong to a specific playlist
  public async Task<List<Track>> GetTracksByPlaylistId(int playlistId){

    return await _context.Playlist
      .Where(playlist => playlist.PlaylistId == playlistId)
      .Include(playlist => playlist.Tracks)
      .SelectMany(playlist => playlist.Tracks)
      .ToListAsync();

  }

  // Problem 18: Playlist with most tracks
  public async Task<Playlist?> GetPlaylistWithMostTracks(){

    return await _context.Playlist
      .Include(playlist => playlist.Tracks)
      .OrderByDescending(playlist => playlist.Tracks.Count())
      .FirstOrDefaultAsync();

  }

  // Problem 19: Playlist with the least tracks
  public async Task<Playlist?> GetPlaylistWithLeastTracks(){

    return await _context.Playlist
      .Include(playlist => playlist.Tracks)
      .OrderBy(playlist => playlist.Tracks.Count())
      .FirstOrDefaultAsync();

  }

  // Problem 20: Top 5 playlist with most tracks
  public async Task<List<Statistic>> GetTopFivePlaylistsWithMostTracks(){

    return await _context.Playlist
      .Include(playlist => playlist.Tracks)
      .OrderByDescending(playlist => playlist.Tracks.Count())
      .Select(playlist => new Statistic{
        Label = playlist.Name,
        Value = playlist.Tracks.Count(),
        ValueMetric = "Number of tracks"
      })
      .Take(5)
      .ToListAsync();

  }

  // Problem 21: Bottom 5 playlist with least tracks
  public async Task<List<Statistic>> GetBottomFivePlaylistsWithLeastTracks(){

    return await _context.Playlist
      .Include(playlist => playlist.Tracks)
      .OrderBy(playlist => playlist.Tracks.Count())
      .Select(playlist => new Statistic{
        Label = playlist.Name,
        Value = playlist.Tracks.Count(),
        ValueMetric = "Number of tracks"
      })
      .Take(5)
      .ToListAsync();

  }
  

}