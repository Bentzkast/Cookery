export interface Recipe {
  id: number;
  name: string;
  description?: string;
  ingredients?: string;
  instruction?: string;
  pictureUrl: string;
  daysAgo?: number;
}
