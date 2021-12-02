const createProxyMiddleware = require('http-proxy-middleware');
const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:35425';

const context =  [
    "/weatherforecast",
    "/api/customer",
    "/api/consumes",
    "/api/invoice",
    "/api/material",
    "/api/mechanic",
    "/api/order",
    "/api/repair",
    "/api/activity",
    "/api/activity/getdate"

];

module.exports = function(app) {
  const appProxy = createProxyMiddleware(context, {
    target: target,
    secure: false
  });

  app.use(appProxy);
};
