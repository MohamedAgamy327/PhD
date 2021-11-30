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
    name: 'تقديم',
    type: 'link',
    icon: 'lightbulb',
    roles: [RoleEnum.Admin, RoleEnum.Researcher, RoleEnum.Anonymous]
  },
  {
    state: 'home/short-introduction',
    name: 'مقدمة مختصرة عن المؤشر',
    type: 'link',
    icon: 'description',
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
    roles: [RoleEnum.Admin, RoleEnum.Anonymous]
  },
  {
    state: 'home/login',
    name: 'Login',
    type: 'link',
    icon: 'login',
    roles: [RoleEnum.Admin, RoleEnum.Researcher, RoleEnum.Anonymous]
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
  },
  {
    state: 'home/researches/results',
    name: 'Researchs Results List',
    type: 'link',
    icon: 'format_list_numbered',
    roles: [RoleEnum.Admin, RoleEnum.Anonymous]
  },
  {
    state: 'home/researches/descriptive-statistics',
    name: 'المقاييس الوصفية',
    type: 'link',
    icon: 'stacked_bar_chart',
    roles: [RoleEnum.Admin, RoleEnum.Anonymous]
  },
  {
    state: 'home/researches/charts',
    name: 'Charts',
    type: 'link',
    icon: 'bar_chart',
    roles: [RoleEnum.Admin, RoleEnum.Anonymous]
  },
  {
    state: 'home/research-team',
    name: 'Research Team',
    type: 'link',
    icon: 'supervised_user_circle',
    roles: [RoleEnum.Admin, RoleEnum.Researcher, RoleEnum.Anonymous]
  }
];
