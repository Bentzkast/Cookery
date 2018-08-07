import { Recipe } from './recipe';

export interface User {
  id: number;
  username: string;
  picture: string;
  registered?: Date;
  about?: string;
  recipes?: Recipe[];
}
