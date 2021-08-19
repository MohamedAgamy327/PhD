import { DefaultUrlSerializer, UrlTree } from '@angular/router';

export class LowerCaseUrlSerializer extends DefaultUrlSerializer {

  parse(url: string): UrlTree {
    if (url.includes('token'))
      return super.parse(url);
    return super.parse(url.toLowerCase());
  }

}
