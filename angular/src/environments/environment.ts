import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44338/',
  redirectUri: baseUrl,
  clientId: 'PortalHub_App',
  responseType: 'code',
  scope: 'offline_access PortalHub',
  requireHttps: true,
  impersonation: {
    userImpersonation: true,
  }
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'PortalHub',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44338',
      rootNamespace: 'PortalHub',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
