import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HeroesService, Heroe } from '../../services/heroes.service';



@Component({
  selector: 'app-search',
  templateUrl: './search.component.html'
})
export class SearchComponent implements OnInit {

  heroes: Heroe[];
  myTerm: string;

  constructor(private _activatedRoute: ActivatedRoute,
              private _heroesService: HeroesService) { }

  ngOnInit(): void 
  {

    this._activatedRoute.params.subscribe(myParams => {
      this.myTerm = myParams['term'];
      this.heroes = this._heroesService.searchHeroe(this.myTerm);
    })


  }

}
