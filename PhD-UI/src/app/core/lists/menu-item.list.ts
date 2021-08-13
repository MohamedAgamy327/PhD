import { RoleEnum } from '../enums';
import { MenuItem } from '../models';

export const MenuItemList: MenuItem[] = [
  {
    state: 'home',
    name: 'Home',
    type: 'link',
    icon: 'home',
    roles: [RoleEnum.Admin, RoleEnum.Researcher, RoleEnum.Anonymous]
  },
  {
    state: 'home/introduction',
    name: 'Introduction',
    type: 'link',
    icon: 'lightbulb',
    roles: [RoleEnum.Admin, RoleEnum.Researcher, RoleEnum.Anonymous]
  },
  {
    state: 'home/survey',
    name: 'Survey',
    type: 'link',
    icon: 'notes',
    roles: [RoleEnum.Researcher]
  },
  {
    state: 'home/register',
    name: 'Register',
    type: 'link',
    icon: 'app_registration',
    roles: [RoleEnum.Anonymous]
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
