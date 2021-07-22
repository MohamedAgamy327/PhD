import { RoleEnum } from '../enums';
import { MenuItem } from '../models';

export const MenuItemList: MenuItem[] = [
  {
    state: 'home',
    name: 'Home',
    type: 'link',
    icon: 'home',
    roles: []
  },
  {
    state: 'home/survey',
    name: 'Survey',
    type: 'link',
    icon: 'notes',
    roles: []
  },
  {
    state: 'home/users',
    name: 'Users List',
    type: 'link',
    icon: 'person',
    roles: [RoleEnum.Admin]
  },
  {
    state: 'home/researches',
    name: 'Researchs List',
    type: 'link',
    icon: 'work',
    roles: [RoleEnum.Admin]
  }
];
