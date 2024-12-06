import type { GetProdutosInput, ProdutoCreateDto, ProdutoDto, ProdutoUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { AppFileDescriptorDto, DownloadTokenResultDto, GetFileInput } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ProdutoService {
  apiName = 'Default';

  create = (input: ProdutoCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ProdutoDto>(
      {
        method: 'POST',
        url: '/api/app/produtos',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/app/produtos/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetProdutosInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/app/produtos/all',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          nome: input.nome,
          descricao: input.descricao,
          cicloDeVida: input.cicloDeVida,
          dataPublicacaoMin: input.dataPublicacaoMin,
          dataPublicacaoMax: input.dataPublicacaoMax,
          linkDocumentacao: input.linkDocumentacao,
          plataforma: input.plataforma,
          tecnologias: input.tecnologias,
          status: input.status,
        },
      },
      { apiName: this.apiName, ...config },
    );

  deleteByIds = (produtoIds: string[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/app/produtos',
        params: { produtoIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ProdutoDto>(
      {
        method: 'GET',
        url: `/api/app/produtos/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/app/produtos/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/app/produtos/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetProdutosInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ProdutoDto>>(
      {
        method: 'GET',
        url: '/api/app/produtos',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          nome: input.nome,
          descricao: input.descricao,
          cicloDeVida: input.cicloDeVida,
          dataPublicacaoMin: input.dataPublicacaoMin,
          dataPublicacaoMax: input.dataPublicacaoMax,
          linkDocumentacao: input.linkDocumentacao,
          plataforma: input.plataforma,
          tecnologias: input.tecnologias,
          status: input.status,
        },
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: string, input: ProdutoUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ProdutoDto>(
      {
        method: 'PUT',
        url: `/api/app/produtos/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/app/produtos/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
