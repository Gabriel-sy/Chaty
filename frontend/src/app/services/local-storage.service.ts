import { isPlatformBrowser } from '@angular/common';
import { Injectable, PLATFORM_ID, inject } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  private storage: any;
  private readonly platformId = inject(PLATFORM_ID)


  constructor(private router: Router) {
    if(isPlatformBrowser(this.platformId)){
      this.storage = localStorage;
    } else {
      this.storage = undefined;
    }
    
  }

  set(key: string, value: string): boolean {
    if(this.storage){
      this.storage.setItem(key, value);
      return true;
    }
    return false;
  }

  get(key: string): any {
    if(this.storage){
      return this.storage.getItem(key);
    }
    return undefined;
  }

  clear(): boolean{
    if(this.storage){
      this.storage.clear();
      return true;
    }
    return false;
  }

  remove(key: string): boolean {
    if(this.storage){
      this.storage.removeItem(key);
      return true;
    }
    return false;
  }

  isLoggedIn(): boolean {
    if(this.storage && isPlatformBrowser(this.platformId)){

      
      let expireDate = this.get('expireDate');

      if(this.get('jwt') == null){
        return false;
      }

      if(expireDate){
        let expireDateAsNumber = parseInt(expireDate)
        let dateNow = Date.now();
  
        dateNow /= 60000;
        expireDateAsNumber /= 60000;
  
        if(parseInt((dateNow - expireDateAsNumber).toFixed()) > 2000){
          return false;
        } else {
          return true;
        }

      } else {
        return false;
      }
    }
    return false;
  }

  logout(): boolean{
    if(this.storage){
      this.storage.removeItem('jwt');
      this.storage.removeItem('expireDate');
      this.storage.removeItem('userName');
      this.router.navigateByUrl('login')
      return true;
    }
    return false;
  }
}
