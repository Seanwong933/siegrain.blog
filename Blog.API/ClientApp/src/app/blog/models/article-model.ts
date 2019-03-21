import BaseModel from "src/app/shared/models/base-model";
import { SGAnimation } from "src/app/shared/utils/siegrain.animations";

export default class ArticleModel extends BaseModel {
  author: string;
  title: string;
  digest: string;
  category: string;
  content: string;
  viewCount: number = 0;
  commentCount: number = 0;
  cover: string = "assets/img/placeholder.jpg";

  // helper fields
  animation?: SGAnimation;

  constructor(init?: Partial<ArticleModel>) {
    super(init);
    Object.assign(this, init);
  }
}