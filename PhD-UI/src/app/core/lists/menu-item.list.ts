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
    name: 'مقدمة',
    type: 'sub',
    icon: 'event_note',
    roles: [RoleEnum.Admin, RoleEnum.Researcher, RoleEnum.Anonymous],
    children: [
      { state: 'home/short-introduction', name: 'منهجية بناء الدليل', roles: [RoleEnum.Admin, RoleEnum.Researcher, RoleEnum.Anonymous] },
      { state: 'home/classification', name: 'تصنيف  المردود الاقتصادى لمشروعات البحثية الابتكارية', roles: [RoleEnum.Admin, RoleEnum.Researcher, RoleEnum.Anonymous] },
      { state: 'home/structure', name: 'هيكل الدليل المركب للمردود الاقتصادى للمشروع البحثى', roles: [RoleEnum.Admin, RoleEnum.Researcher, RoleEnum.Anonymous] }
    ]
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
    name: 'Login',
    type: 'sub',
    icon: 'login',
    roles: [RoleEnum.Admin, RoleEnum.Researcher, RoleEnum.Anonymous],
    children: [
      { state: 'home/login', name: 'Researcher Login', roles: [RoleEnum.Admin, RoleEnum.Researcher, RoleEnum.Anonymous] },
      { state: 'home/admin-login', name: 'Admin Login', roles: [RoleEnum.Admin, RoleEnum.Researcher, RoleEnum.Anonymous] }
    ]
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
