using System;

namespace ArtistMVC.Models;

//create a class called ArtistModel to hold the artistid, name, spotifyid, and spotifyurl
public class ArtistModel
{
    public int ArtistId { get; set; }
    public string? Name { get; set; }
    public string? SpotifyId { get; set; }
    public string SpotifyUrl
    {
        get
        {
            return $"https://open.spotify.com/artist/{SpotifyId}";
        }
    }
}
