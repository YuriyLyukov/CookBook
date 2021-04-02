export interface IRecipe {
  id: number;
  name: string;
  description: string;
  date: string;
  parentId: number;
  left: number;
  right: number;
  depthLevel: number;
  treeId: string;
}
