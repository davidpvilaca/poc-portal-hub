import { AuthService, ConfigStateService, CurrentUserDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ProdutoViewService } from '../produtos/produto/services/produto.service';
import { ProdutoDto } from '@proxy/produtos';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated
  }

  user?: CurrentUserDto
  produtos?: PagedResultDto<ProdutoDto>

  constructor(
    private authService: AuthService,
    private configStateService: ConfigStateService,
    private produtosService: ProdutoViewService
  ) { }

  login() {
    this.authService.navigateToLogin();
  }

  ngOnInit(): void {
    this.user = this.configStateService.getOne('currentUser')
    this.produtosService
      .getNovosProdutos()
      .subscribe(page => this.produtos = page)
  }
}
