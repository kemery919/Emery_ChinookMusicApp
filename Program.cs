using Microsoft.Extensions.DependencyInjection;
using Data;
using Services;

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

//// Call the service
// Problem 1 testing

List<string> artistsWithAlbums = await _musicQueryService.GetAllArtistsWithAlbums();

artistsWithAlbums.ForEach(artist => Console.WriteLine(artist));


