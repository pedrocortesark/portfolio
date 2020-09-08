import { Component, OnInit } from '@angular/core';
import { SpotifyService } from './../../services/spotify.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {

  nuevasCanciones: any[];
  loading: boolean;
  error: boolean;
  errorMessage: string;

  constructor(private _spotifyService: SpotifyService) {  
    
    this.loading = true;
    this.error= false;

    this._spotifyService.getNewReleases().subscribe( (response: any) => {
      this.nuevasCanciones = response;
      this.loading = false;
    }, (er) => {
      console.log(er.error.error.message);
      this.errorMessage = er.error.error.message;
      this.error = true;
      this.loading = false;
    });

  }

  

}
