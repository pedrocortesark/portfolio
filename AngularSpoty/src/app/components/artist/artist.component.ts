import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SpotifyService } from './../../services/spotify.service';

@Component({
  selector: 'app-artist',
  templateUrl: './artist.component.html'
})
export class ArtistComponent {

  artist: any;
  toptracks: any[];
  loading: boolean;

  constructor(private _activatedRoute: ActivatedRoute,
              private _spotifyService: SpotifyService) { 

    this._activatedRoute.params.subscribe( myParams => {
      this.getArtist( myParams['id'] );
      this.getTopTracks( myParams['id'] );
    })

  }

  getArtist( id: string)
  {
    this.loading = true;

    this._spotifyService.getArtist(id).subscribe(artista => {
                              this.artist = artista;
                              console.log(this.artist);

                              this.loading = false;
                        });

  };

  getTopTracks(id:string)
  {
    this._spotifyService.getTopTracks(id).subscribe(topTracks => {
      this.toptracks = topTracks;
      console.log(this.toptracks);
      
    });
    
  }

}
