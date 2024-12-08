import { AuthService, ConfigStateService, CurrentUserDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ProdutoViewService } from '../produtos/produto/services/produto.service';
import { ProdutoDto } from '@proxy/produtos';
import { CategoriaProdutoViewService } from '../categoria-produtos/categoria-produto/services/categoria-produto.service';
import { CategoriaProdutoWithNavigationPropertiesDto } from '@proxy/categoria-produtos';

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
  categorias?: PagedResultDto<CategoriaProdutoWithNavigationPropertiesDto>

  constructor(
    private authService: AuthService,
    private configStateService: ConfigStateService,
    private produtosService: ProdutoViewService,
    private categoriaService: CategoriaProdutoViewService
  ) { }

  login() {
    this.authService.navigateToLogin();
  }

  ngOnInit(): void {
    this.user = this.configStateService.getOne('currentUser')
    this.categoriaService
      .getListaCategorias()
      .subscribe(page => this.categorias = page)
    this.produtosService
      .getNovosProdutos()
      .subscribe(page => this.produtos = page)
  }
}
