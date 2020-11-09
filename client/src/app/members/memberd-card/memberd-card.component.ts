import { Component, Input, OnInit } from '@angular/core';
import { Member } from 'src/app/_models/member';

@Component({
  selector: 'app-memberd-card',
  templateUrl: './memberd-card.component.html',
  styleUrls: ['./memberd-card.component.css']
})
export class MemberdCardComponent implements OnInit {
@Input() member: Member;
  constructor() { }

  ngOnInit(): void {
  }

}
