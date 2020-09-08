import { Component } from '@angular/core';
import { SpotifyService } from './../../services/spotify.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html'
})
export class SearchComponent{

  artistas: any[];
  loading: boolean;

  constructor(private _spotityService: SpotifyService) { }

  searchArtist(term: string)
  {
    console.log(term);

    this.loading = true;
    this._spotityService.getArtists(term).subscribe( (response: any) => {
        //console.log(response);
        this.artistas = response;
        this.loading = false;
    } );
  }

}
