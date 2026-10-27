<div align="center">

# ✦ StoreAPI — Store Management REST API

**REST backend for the StoreApp project.**

![Documentation](https://img.shields.io/badge/Documentation-Updated-8B5CF6?style=for-the-badge) ![Project](https://img.shields.io/badge/Greys2004-Portfolio-4C1D95?style=for-the-badge)

</div>

---

## Overview

REST backend for the StoreApp project.

## Technology

ASP.NET Core, EF Core, SQL Server, Swagger, wkhtmltopdf and Docker.

## Local development

Clone this repository and enter its directory. Then run:

```bash
dotnet restore StoreApi.sln
dotnet run --project StoreApi
```

Install the .NET SDK matching the project target and configure sqlServer securely.

## Related repository

[StoreApp](https://github.com/Greys2004/StoreApp)

## Notes

This README documents the project's verified technologies and intended use. Deployment credentials and application-specific environment values are not included. Do not commit API keys or production secrets.

**Security review:** the current startup code logs sensitive configuration values. Remove that logging and review CORS/authentication before deploying to production.

## Author

**Greys Alexa Almanza Vega** · [GitHub](https://github.com/Greys2004) · [Portfolio](https://greys2004.github.io/Curriculum/)
