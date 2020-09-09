import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HeroesService, Heroe } from './../../services/heroes.service';


@Component({
  selector: 'app-heroe',
  templateUrl: './heroe.component.html'
})
export class HeroeComponent {

  heroe: Heroe;

  constructor(private _activatedRoute: ActivatedRoute,
              private _heroesService: HeroesService) { 

    this._activatedRoute.params.subscribe(myParams => { 
      
      let index = myParams['id'];
      this.heroe = this._heroesService.getHeroe(index)
      console.log(this.heroe);
    
    })

  };


}
