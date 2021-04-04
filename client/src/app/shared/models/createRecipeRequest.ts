export interface ICreateRecipeRequest {
  name: string;
  description: string;
  parentId?: number | null;
}
