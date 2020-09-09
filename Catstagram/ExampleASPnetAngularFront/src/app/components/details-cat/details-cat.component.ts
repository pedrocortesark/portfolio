import { CatService } from './../../services/cat.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Cat } from 'src/app/models/cat';
import { map, mergeMap } from 'rxjs/operators';

@Component({
  selector: 'app-details-cat',
  templateUrl: './details-cat.component.html',
  styleUrls: ['./details-cat.component.css']
})
export class DetailsCatComponent implements OnInit {

  id: string;
  cat: Cat;

  constructor(private route:ActivatedRoute, private catService: CatService) { 
    // this.route.params.subscribe(result => {
    //   this.id = result['id'];
    //   console.log(this.id);
    //   this.catService.getCat(this.id).subscribe(resp =>{
    //     this.cat = resp;
    //   });
    // })
    this.fetchData();
  }

  ngOnInit(): void {

  }

  fetchData()
  {
    this.route.params.pipe(map(data => {
      const id = data['id'];
      return id;
    }), mergeMap(id => this.catService.getCat(id))).subscribe(res => {
      this.cat = res;
    })
  }

}
