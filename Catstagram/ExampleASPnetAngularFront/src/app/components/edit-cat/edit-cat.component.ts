import { CatService } from './../../services/cat.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Cat } from 'src/app/models/cat';

@Component({
  selector: 'app-edit-cat',
  templateUrl: './edit-cat.component.html',
  styleUrls: ['./edit-cat.component.css']
})
export class EditCatComponent implements OnInit {

  editForm: FormGroup;
  id: string;
  cat: Cat;

  constructor(private fb: FormBuilder, private route: ActivatedRoute, private catService: CatService, private router: Router) { 
    this.editForm = this.fb.group({
      'id': [''],
      'description': ['']
    })
  }

  ngOnInit(): void {
    this.route.params.subscribe(data=>{
      this.id = data['id'];
      this.catService.getCat(this.id).subscribe(res => {
        this.cat = res;
        this.editForm = this.fb.group({
          'id': [this.cat.id],
          'description': [this.cat.description]
        })
      });
    })
  }

  editCat()
  {
    this.catService.updateCat(this.editForm.value).subscribe(arg => {
      this.router.navigate(['cats']);
    });
    
  }

}
