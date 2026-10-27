<div align="center">

# ✦ StoreAPI

### Store management backend

REST backend for StoreApp, including SQL Server persistence and PDF-related tooling.

![Tech](https://img.shields.io/badge/Purple_Future-Portfolio-974ECA?style=for-the-badge&labelColor=251139)

[GitHub profile](https://github.com/Greys2004) · [Portfolio](https://greys2004.github.io/Curriculum/) · [Related application](https://github.com/Greys2004/StoreApp)

</div>

---

## ✦ Highlights

- Controller-based REST API
- Entity Framework Core with SQL Server
- Swagger documentation
- PDF-related dependency integration

## ⚙️ Technologies

`ASP.NET Core` · `Entity Framework Core` · `SQL Server` · `Swagger`

## 🚀 Run locally

```bash
dotnet restore StoreApi.sln
dotnet run --project StoreApi
```

Install the matching .NET SDK, then configure the `sqlServer` connection string securely. Swagger is available at `/swagger` when running.

## 📌 Notes

**Security:** current startup code logs configuration values that may contain secrets and allows any CORS origin. Remove sensitive logging and review deployment security before production.

Never commit production secrets or credentials.

---

<div align="center">**Greys Alexa Almanza Vega** · Software Engineer 💜</div>
