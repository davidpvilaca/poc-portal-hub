import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:/',
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
  production: true,
  application: {
    baseUrl,
    name: 'PortalHub',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:',
      rootNamespace: 'PortalHub',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
