
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class FileValidationService {

  checkInvalidImages(files: any) {
    const invalidTypes = [...files].some(file => !file.type.includes('image/'));
    return invalidTypes;
  }

  checkInvalidImage(file: any) {
    const invalidTypes = !file.type.includes('image/');
    return invalidTypes;
  }

}
