using Microsoft.Extensions.DependencyInjection;
using Data;
using Services;
// using Internal;

ServiceProvider _serviceProvider;
MusicQueryService _musicQueryService;


// Create container to hold services for dependency injection

var services = new ServiceCollection();

// Add services to the service container.

services.AddDbContext<ApplicationDbContext>();
services.AddScoped<MusicQueryService>();

// Get the service provider 

_serviceProvider = services.BuildServiceProvider();

// Retrieve Instance of MusicQueryService from the service container

_musicQueryService = _serviceProvider.GetRequiredService<MusicQueryService>();

// Call the service

//-----------------------
//--------Testing--------
//-----------------------

// // Problem 1 testing

// Console.WriteLine("\n--- GetAllArtistsWithAlbums ---");
// var artistsWithAlbums = await _musicQueryService.GetAllArtistsWithAlbums();
// foreach (var artist in artistsWithAlbums) {
//     Console.WriteLine($"{artist.Name} ({artist.Albums.Count} albums)");
// }

// // Problem 2 testing

// Console.WriteLine("\n--- GetAllArtistsWithMoreThanOneAlbum ---");
// var artistsWithMoreThanOneAlbum = await _musicQueryService.GetAllArtistsWithMoreThanOneAlbum();
// foreach (var artist in artistsWithMoreThanOneAlbum) {
//     Console.WriteLine($"{artist.Name} ({artist.Albums.Count} albums)");
// }

// // Problem 3 testing

// Console.WriteLine("\n--- GetArtistByNameWithAlbums ---");
// var artistByName = await _musicQueryService.GetArtistByNameWithAlbums("AC/DC");
// Console.WriteLine(artistByName != null
//     ? $"{artistByName.Name} has {artistByName.Albums.Count} albums"
//     : "Artist not found");

// // Problem 4 testing

// Console.WriteLine("\n--- GetTracksByAlbumId (AlbumId = 1) ---");
// var tracksByAlbum = await _musicQueryService.GetTracksByAlbumId(1);
// foreach (var track in tracksByAlbum) {
//     Console.WriteLine(track.Name);
// }

// // Problem 5 testing

// Console.WriteLine("\n--- GetAllGenresWithTracks ---");
// var genresWithTracks = await _musicQueryService.GetAllGenresWithTracks();
// foreach (var genre in genresWithTracks) {
//     Console.WriteLine($"{genre.Name} ({genre.Tracks.Count} tracks)");
// }

// // Problem 6 testing

// Console.WriteLine("\n--- GetTracksByGenreId (GenreId = 1) ---");
// var tracksByGenre = await _musicQueryService.GetTracksByGenreId(1);
// foreach (var track in tracksByGenre) {
//     Console.WriteLine(track.Name);
// }

// // Problem 7 testing

// Console.WriteLine("\n--- GetTotalTracksByAlbum ---");
// var totalTracksByAlbum = await _musicQueryService.GetTotalTracksByAlbum();
// foreach (var stat in totalTracksByAlbum) {
//     Console.WriteLine($"{stat.Label}: {stat.Value} tracks");
// }

// // Problem 8 testing

// Console.WriteLine("\n--- GetAlbumsByArtistId (ArtistId = 1) ---");
// var albumsByArtist = await _musicQueryService.GetAlbumsByArtistId(1);
// foreach (var album in albumsByArtist) {
//     Console.WriteLine(album.Title);
// }

// // Problem 9 testing

// Console.WriteLine("\n--- GetAllPlaylistsWithTracks ---");
// var playlistsWithTracks = await _musicQueryService.GetAllPlaylistsWithTracks();
// foreach (var playlist in playlistsWithTracks) {
//     Console.WriteLine($"{playlist.Name} ({playlist.Tracks.Count} tracks)");
// }

// Problem 10 testing

Console.WriteLine("\n--- GetAverageDurationByGenre ---");
var avgDurationByGenre = await _musicQueryService.GetAverageDurationByGenre();
foreach (var stat in avgDurationByGenre) {
    Console.WriteLine($"{stat.Label}: {stat.Value} {stat.ValueMetric}");
}

// // Problem 11 testing

// Console.WriteLine("\n--- GetArtistsWithoutAlbums ---");
// var artistsWithoutAlbums = await _musicQueryService.GetArtistsWithoutAlbums();
// foreach (var artist in artistsWithoutAlbums) {
//     Console.WriteLine(artist.Name);
// }

// // Problem 12 testing

// Console.WriteLine("\n--- GetTracksWithGenreAndAlbum ---");
// var tracksWithGenreAndAlbum = await _musicQueryService.GetTracksWithGenreAndAlbum();
// foreach (var track in tracksWithGenreAndAlbum) {
//     Console.WriteLine($"{track.Name} - {track.Album?.Title} ({track.Genre?.Name})");
// }

// // Problem 13 testing

// Console.WriteLine("\n--- GetTrackDetails ---");
// var trackDetails = await _musicQueryService.GetTrackDetails();
// foreach (var detail in trackDetails) {
//     Console.WriteLine($"{detail.Track} - {detail.Album} by {detail.Artist}");
// }

// // Problem 14 testing

// Console.WriteLine("\n--- GetAlbumsWithTrackDuration ---");
// var albumDurations = await _musicQueryService.GetAlbumsWithTrackDuration();
// foreach (var stat in albumDurations) {
//     Console.WriteLine($"{stat.Label}: {stat.Value} {stat.ValueMetric}");
// }

// // Problem 15 testing

// Console.WriteLine("\n--- GetGenreTrackCounts ---");
// var genreTrackCounts = await _musicQueryService.GetGenreTrackCounts();
// foreach (var stat in genreTrackCounts) {
//     Console.WriteLine($"{stat.Label}: {stat.Value}");
// }

// // Problem 16 testing

// Console.WriteLine("\n--- GetPlaylistsWithTrackCount ---");
// var playlistStats = await _musicQueryService.GetPlaylistsWithTrackCount();
// foreach (var stat in playlistStats) {
//     Console.WriteLine($"{stat.Label}: {stat.Value}");
// }

// // Problem 17 testing

// Console.WriteLine("\n--- GetTracksByPlaylistId (PlaylistId = 1) ---");
// var tracksInPlaylist = await _musicQueryService.GetTracksByPlaylistId(1);
// foreach (var track in tracksInPlaylist) {
//     Console.WriteLine(track.Name);
// }

// // Problem 18 testing

// Console.WriteLine("\n--- GetPlaylistWithMostTracks ---");
// var mostTracksPlaylist = await _musicQueryService.GetPlaylistWithMostTracks();
// Console.WriteLine($"{mostTracksPlaylist?.Name} ({mostTracksPlaylist?.Tracks.Count} tracks)");

// // Problem 19 testing

// Console.WriteLine("\n--- GetPlaylistWithLeastTracks ---");
// var leastTracksPlaylist = await _musicQueryService.GetPlaylistWithLeastTracks();
// Console.WriteLine($"{leastTracksPlaylist?.Name} ({leastTracksPlaylist?.Tracks.Count} tracks)");

// // Problem 20 testing

// Console.WriteLine("\n--- GetTopFivePlaylistsWithMostTracks ---");
// var top5Stats = await _musicQueryService.GetTopFivePlaylistsWithMostTracks();
// foreach (var stat in top5Stats) {
//     Console.WriteLine($"{stat.Label}: {stat.Value} tracks");
// }

// // Problem 21 testing

// Console.WriteLine("\n--- GetBottomFivePlaylistsWithLeastTracks ---");
// var bottom5Stats = await _musicQueryService.GetBottomFivePlaylistsWithLeastTracks();
// foreach (var stat in bottom5Stats) {
//     Console.WriteLine($"{stat.Label}: {stat.Value} tracks");
// }