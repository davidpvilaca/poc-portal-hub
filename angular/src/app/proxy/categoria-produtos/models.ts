import type { AuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { ProdutoDto } from '../produtos/models';

export interface CategoriaProdutoCreateDto {
  nome: string;
  descricao?: string;
  produtoIds: string[];
}

export interface CategoriaProdutoDto extends AuditedEntityDto<string> {
  nome: string;
  descricao?: string;
  concurrencyStamp?: string;
}

export interface CategoriaProdutoUpdateDto {
  nome: string;
  descricao?: string;
  produtoIds: string[];
  concurrencyStamp?: string;
}

export interface CategoriaProdutoWithNavigationPropertiesDto {
  categoriaProduto: CategoriaProdutoDto;
  produtos: ProdutoDto[];
}

export interface GetCategoriaProdutosInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  nome?: string;
  descricao?: string;
  produtoId?: string;
}
