import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class SpotifyService {

  constructor(private _http: HttpClient) { 
    console.log("Servicio de Spotify listo para usarse");
  }

  getQuery(query: string)
  {
    const url = `https://api.spotify.com/v1/${query}`;

    const headers = new HttpHeaders({
      'Authorization': 'Bearer BQBm3gBp6Uk4XC0mpnKCTfebv0GrkQdJg3mgrLI3NSYRmNTcex7pbW2ujMLSO0R4eD4pyAws8moWWa4UWDg'
    });

    return this._http .get(url, {headers});

  }


  getNewReleases()
  {

    return this.getQuery('browse/new-releases?country=es&limit=20')
                .pipe( map( (response) => {
                  return response['albums'].items;
                 }) );
    
  }

  getArtists(text: string)
  {

    return this .getQuery(`search?q=${text}&type=artist&limit=20`)
                .pipe( map( (response) => response['artists'].items ) );

  }

  getArtist(id: string)
  {
    return this .getQuery(`artists/${id}`);
  }

  getTopTracks(id: string)
  {
    return this .getQuery(`artists/${id}/top-tracks?country=es`)
                .pipe ( map( response => response['tracks']) );

  }

}
