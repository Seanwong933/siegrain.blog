import { Component, OnInit } from "@angular/core";
import { ArticleParameters } from "../../models/article-parameters";
import { ArticleService } from "../../services/article.service";
import ArticleModel from "../../models/article-model";
import { Pagination } from "src/app/shared/models/response-result";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-article-list",
  templateUrl: "./article-list.component.html",
  styleUrls: ["./article-list.component.scss"]
})
export class ArticleListComponent implements OnInit {
  articles: ArticleModel[];
  pagination: Pagination;
  parameter = new ArticleParameters();

  constructor(
    private service: ArticleService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    console.log("article-list ctor.");
  }

  ngOnInit() {
    this.route.queryParams.subscribe(param => {
      this.parameter.pageIndex = param.index || 0;
      this.getPosts();
    });
  }

  async getPosts() {
    let res = await this.service.getPagedArticles(this.parameter);
    if (!res || !res.succeed) return;
    this.articles = res.data as ArticleModel[];
    this.pagination = res.pagination;
  }

  previous() {
    if (!this.pagination.previousPageLink) return;
    this.parameter.pageIndex--;
    this.query();
  }

  next() {
    if (!this.pagination.nextPageLink) return;
    this.parameter.pageIndex++;
    this.query();
  }

  query() {
    this.router.navigate(["/"], {
      queryParams: { index: this.parameter.pageIndex }
    });
  }
}
