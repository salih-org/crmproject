


// Aþaðýdaki script'i contact veritabaný objelerini uygulama içerisinde oluþturmak için kullanabiliriz.
// EntityFrameworkCore.Tools kütüphanesi yüklü olmalý

Scaffold-DbContext "Host=salihcloud.eastus.cloudapp.azure.com;Port=2345;Database=postgres;Username=postgres;Password=241990" 
	Npgsql.EntityFrameworkCore.PostgreSQL -o Models -force -ContextDir Context -Context CrmDbContext -Tables contact


