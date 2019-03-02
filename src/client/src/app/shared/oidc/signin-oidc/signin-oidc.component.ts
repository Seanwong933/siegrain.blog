import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { OpenIdConnectService } from "../open-id-connect.service";
import { LoggingService } from "../../services/logging.service";

@Component({
  selector: "app-signin-oidc",
  templateUrl: "./signin-oidc.component.html",
  styleUrls: ["./signin-oidc.component.scss"]
})
export class SigninOidcComponent implements OnInit {
  constructor(
    private openIdConnectService: OpenIdConnectService,
    private router: Router,
    private logger: LoggingService
  ) {}

  ngOnInit() {
    // 订阅用户登录成功的广播，登录成功就跳转首页
    this.openIdConnectService.userLoaded$.subscribe(userLoaded => {
      if (userLoaded) {
        this.router.navigate(["./"]);
      } else {
        this.logger.info("An error happened: user wasn't loaded.");
      }
    });

    // 登录操作结束后，不论结果
    this.openIdConnectService.handleCallback();
  }
}
