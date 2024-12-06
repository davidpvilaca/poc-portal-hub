import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetProdutosInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  nome?: string;
  descricao?: string;
  cicloDeVida?: string;
  dataPublicacaoMin?: string;
  dataPublicacaoMax?: string;
  linkDocumentacao?: string;
  plataforma?: string;
  tecnologias?: string;
  status?: string;
}

export interface ProdutoCreateDto {
  nome: string;
  descricao?: string;
  cicloDeVida: string;
  dataPublicacao?: string;
  linkDocumentacao?: string;
  plataforma?: string;
  tecnologias?: string;
  status?: string;
}

export interface ProdutoDto extends FullAuditedEntityDto<string> {
  nome: string;
  descricao?: string;
  cicloDeVida: string;
  dataPublicacao?: string;
  linkDocumentacao?: string;
  plataforma?: string;
  tecnologias?: string;
  status?: string;
  concurrencyStamp?: string;
}

export interface ProdutoUpdateDto {
  nome: string;
  descricao?: string;
  cicloDeVida: string;
  dataPublicacao?: string;
  linkDocumentacao?: string;
  plataforma?: string;
  tecnologias?: string;
  status?: string;
  concurrencyStamp?: string;
}
