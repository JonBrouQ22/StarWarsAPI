import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { saveAs } from 'file-saver';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    let requestOptions: Object = {
      responseType: 'arraybuffer'
    }
    http.get<ArrayBuffer>(baseUrl + 'starwars', requestOptions).subscribe((data: any) => {
      // should return a csv file
      const blob = new Blob([data], { type: 'application/octet-stream',  });
      const filename = 'StarWarsCharacters.csv';
      saveAs(blob, filename)
    }, error => console.error(error));
  }
}
