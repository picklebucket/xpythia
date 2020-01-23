import { Component, OnInit } from '@angular/core';
import { Title } from "@angular/platform-browser";


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})

export class HeaderComponent implements OnInit {

  constructor(private titleService: Title) { }

  title: string = '';

  getTitle() {
    this.title = this.titleService.getTitle();
  }

  ngOnInit() {
    this.getTitle()
  }

}
