export interface Recipe {
  id: number;
  name: string;
  tags: string;
  description?: string;
  ingredients?: string;
  instruction?: string;
  pictureUrl: string;
  daysAgo?: number;
  cookingTimeInMin?: number;
  priceLvl?: number;
  userId?: number;
}
