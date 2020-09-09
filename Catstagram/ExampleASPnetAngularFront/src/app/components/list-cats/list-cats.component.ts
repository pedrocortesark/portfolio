import { Router } from '@angular/router';
import { CatService } from './../../services/cat.service';
import { Component, OnInit } from '@angular/core';
import { Cat } from '../../models/cat';

@Component({
  selector: 'app-list-cats',
  templateUrl: './list-cats.component.html',
  styleUrls: ['./list-cats.component.css']
})
export class ListCatsComponent implements OnInit {

  cats: Array<Cat>;

  constructor(private catService:CatService, private router: Router) {  }

  ngOnInit(): void {
    this.fetchCats();
  }

  fetchCats()
  {
    this.catService.getCats().subscribe(data=>{
      this.cats = data;
    })
  }

  routeToCat(idx)
  {
    this.router.navigate(['cats', idx])
  }

  deleteCat(index)
  {
    this.catService.deleteCat(index).subscribe(res => {
      this.fetchCats();
    })
  }

  editCat(indice)
  {
    this.router.navigate([`cats/${indice}/edit`]);
  }

}
