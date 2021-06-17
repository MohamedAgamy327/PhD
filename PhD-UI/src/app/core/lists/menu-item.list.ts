import { RoleEnum } from '../enums';
import { MenuItem } from '../models';

export const MenuItemList: MenuItem[] = [
  {
    state: 'home',
    name: 'Home',
    type: 'link',
    icon: 'home',
    roles: [RoleEnum.Admin]
  },
  {
    state: 'home/users',
    name: 'Users List',
    type: 'link',
    icon: 'person',
    roles: [RoleEnum.Admin]
  }
];
