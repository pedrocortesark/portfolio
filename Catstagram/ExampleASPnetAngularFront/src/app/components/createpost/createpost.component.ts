import { CatService } from './../../services/cat.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';



@Component({
  selector: 'app-createpost',
  templateUrl: './createpost.component.html',
  styleUrls: ['./createpost.component.css']
})
export class CreatepostComponent implements OnInit {

  catForm: FormGroup;

  constructor( private fb: FormBuilder, private catService: CatService, private toastrService: ToastrService ) { 
    this.catForm = this.fb.group({
      'ImageUrl': ['', Validators.required],
      'Description': ['']
    });
  }

  ngOnInit(): void {
  }

  get ImageUrl()
  {
    return this.catForm.get('ImageUrl')
  }

  create()
  {
    this.catService.create(this.catForm.value).subscribe(data => console.log(data));
    this.toastrService.success("Success");
  }

}
