import { User } from "./Auth";


export interface Tag {
  tagId: string;
  body: string;
  tweetId: string;
}


export interface Tweet {
  tweetId: string;
  body: string;
  image: string;
  userForeignKey: string;
  tweeter: User;
  tags: Tag[];
}
