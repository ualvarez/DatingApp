import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrls: ['./confirm-dialog.component.css']
})
export class ConfirmDialogComponent implements OnInit {
  title:string;
  message:string;
  btnOkText:string;
  btnCancelText:string;
  result: boolean; 

  constructor(public BsModalRef: BsModalRef) { }

  ngOnInit(): void {
  }

  confirm(){
    this.result = true;
    this.BsModalRef.hide();
  }

  decline(){
    this.result = false;
    this.BsModalRef.hide();
  }

}
