# youtube-clone

## Migration Commands

```bash
$ cd VideoApp.DataAccess
$ dotnet ef migrations add <migration-name> --startup-project ../VideoApp.WebAPI --output-dir Migrations
$ dotnet ef database update --startup-project ../VideoApp.WebAPI
```
