import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Heroe } from './../../services/heroes.service';
import { Router } from '@angular/router';

 
@Component({
  selector: 'app-heroe-tarjeta',
  templateUrl: './heroe-tarjeta.component.html'
})
export class HeroeTarjetaComponent implements OnInit {

  @Input() heroe: Heroe;
  @Input() index: number;

  @Output() heroeSeleccionado: EventEmitter<number>

  constructor(private _router: Router) { 
    this.heroeSeleccionado = new EventEmitter()
  }

  ngOnInit(): void {
  }

  verHeroe(){
    this._router.navigate(['/heroes', this.index])
    //this.heroeSeleccionado.emit(this.index);
  }
}
