
import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConstEnum } from '../enums';
import { SideBarList, HeaderList, LanguageFlagList } from '../lists';

@Injectable({
  providedIn: 'root'
})

export class CoreService {

  sidenavMode = 'side';
  layout: string;
  currentLanguage: string;
  selectLangFlag: string;
  sidenavOpen = true;
  collapseSidebar: boolean;
  dark: boolean;
  sideBarFilterClass: any = SideBarList;
  sideBarColor: number;
  headerFilterClass: any = HeaderList;
  headerColor: number;
  langArray: any[] = LanguageFlagList;

  constructor(private translate: TranslateService) {
    this.currentLanguage = localStorage.getItem(ConstEnum.language) || 'en';
    this.layout = localStorage.getItem(ConstEnum.layout) || 'ltr';
    this.selectLangFlag = localStorage.getItem(ConstEnum.selectLangFlag) || './assets/img/en.png';
    this.collapseSidebar = (localStorage.getItem(ConstEnum.collapseSidebar) === 'true') || false;
    this.dark = (localStorage.getItem(ConstEnum.dark) === 'true') || false;
    this.sideBarColor = Number(localStorage.getItem(ConstEnum.sidebarColor)) || 0;
    this.headerColor = Number(localStorage.getItem(ConstEnum.headerColor)) || 0;
  }


  collapseSidebarChange(event: any) {
    if (event.checked) {
      this.collapseSidebar = true;
    } else {
      this.collapseSidebar = false;
    }
    localStorage.setItem(ConstEnum.collapseSidebar, String(this.collapseSidebar));
  }

  sidebarFilter(selectedFilter: any) {
    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.sideBarFilterClass.length; i++) {
      document.getElementById('main-app').classList.remove(this.sideBarFilterClass[i].colorSelect);
      if (this.sideBarFilterClass[i].colorSelect === selectedFilter.colorSelect) {
        document.getElementById('main-app').classList.add(this.sideBarFilterClass[i].colorSelect);
        localStorage.setItem(ConstEnum.sidebarColor, String(i));
      }
    }
    document.querySelector('.radius-circle').classList.remove('radius-circle');
    document.getElementById(selectedFilter.sideBarSelect).classList.add('radius-circle');
  }

  headerFilter(selectedFilter: any) {
    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.headerFilterClass.length; i++) {
      document.getElementById('main-app').classList.remove(this.headerFilterClass[i].colorSelect);
      if (this.headerFilterClass[i].colorSelect === selectedFilter.colorSelect) {
        document.getElementById('main-app').classList.add(this.headerFilterClass[i].colorSelect);
        localStorage.setItem(ConstEnum.headerColor, String(i));
      }
    }
    document.querySelector('.radius-active').classList.remove('radius-active');
    document.getElementById(selectedFilter.headerSelect).classList.add('radius-active');
  }

  addClassOnBody(event: any) {
    const body = document.body;
    if (event.checked) {
      body.classList.add('dark-theme-active');
    } else {
      body.classList.remove('dark-theme-active');
    }
    localStorage.setItem(ConstEnum.dark, String(this.dark));
  }

  changeRTL(isChecked: any) {
    if (isChecked) {
      this.layout = 'rtl';
    } else {
      this.layout = 'ltr';
    }
    localStorage.setItem(ConstEnum.layout, this.layout);
  }

  setLang(lang: any) {
    localStorage.setItem(ConstEnum.language, lang);
    for (const data of this.langArray) {
      if (data.value === lang) {
        this.selectLangFlag = data.img;
        localStorage.setItem(ConstEnum.selectLangFlag, this.selectLangFlag);
        break;
      }
    }
    this.translate.use(lang);
  }

}
