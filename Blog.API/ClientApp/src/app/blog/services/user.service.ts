import { Injectable } from "@angular/core";
import { BaseService, ISubService } from "src/app/shared/services/base.service";
import { UserModel } from "../models/user-model";

@Injectable({
  providedIn: "root"
})
export class UserService extends BaseService implements ISubService {
  serviceName = "Users";

  /**
   * 登录
   */
  async signIn(loginname: string, password: string): Promise<UserModel> {
    let res = await this.get(`${this.serviceName}/Token`, {
      loginname: loginname,
      password: password
    });
    if (!res || !res.succeed) return null;
    let model = res.data.user as UserModel;
    model.token = res.data.token;
    this.store.signIn(model);
    return model;
  }

  /**
   * 重置密码
   */
  async reset(
    id: number,
    password: string,
    newPassword: string
  ): Promise<boolean> {
    let res = await this.put(`${this.serviceName}/Reset`, {
      id: id,
      password: password,
      newPassword: newPassword
    });
    return res && res.succeed;
  }
}
