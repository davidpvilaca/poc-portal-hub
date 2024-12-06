import type {
  CategoriaProdutoCreateDto,
  CategoriaProdutoDto,
  CategoriaProdutoUpdateDto,
  CategoriaProdutoWithNavigationPropertiesDto,
  GetCategoriaProdutosInput,
} from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type {
  AppFileDescriptorDto,
  DownloadTokenResultDto,
  GetFileInput,
  LookupDto,
  LookupRequestDto,
} from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CategoriaProdutoService {
  apiName = 'Default';

  create = (input: CategoriaProdutoCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CategoriaProdutoDto>(
      {
        method: 'POST',
        url: '/api/app/categoria-produtos',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/app/categoria-produtos/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetCategoriaProdutosInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/app/categoria-produtos/all',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          nome: input.nome,
          descricao: input.descricao,
          produtoId: input.produtoId,
        },
      },
      { apiName: this.apiName, ...config },
    );

  deleteByIds = (categoriaProdutoIds: string[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/app/categoria-produtos',
        params: { categoriaProdutoIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CategoriaProdutoDto>(
      {
        method: 'GET',
        url: `/api/app/categoria-produtos/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/app/categoria-produtos/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/app/categoria-produtos/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetCategoriaProdutosInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CategoriaProdutoWithNavigationPropertiesDto>>(
      {
        method: 'GET',
        url: '/api/app/categoria-produtos',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          nome: input.nome,
          descricao: input.descricao,
          produtoId: input.produtoId,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getProdutoLookup = (input: LookupRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>(
      {
        method: 'GET',
        url: '/api/app/categoria-produtos/produto-lookup',
        params: {
          filter: input.filter,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getWithNavigationProperties = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CategoriaProdutoWithNavigationPropertiesDto>(
      {
        method: 'GET',
        url: `/api/app/categoria-produtos/with-navigation-properties/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: string, input: CategoriaProdutoUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CategoriaProdutoDto>(
      {
        method: 'PUT',
        url: `/api/app/categoria-produtos/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/app/categoria-produtos/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
