


// A�a��daki script'i contact veritaban� objelerini uygulama i�erisinde olu�turmak i�in kullanabiliriz.
// EntityFrameworkCore.Tools k�t�phanesi y�kl� olmal�

Scaffold-DbContext "Host=salihcloud.eastus.cloudapp.azure.com;Port=2345;Database=postgres;Username=postgres;Password=241990" 
	Npgsql.EntityFrameworkCore.PostgreSQL -o Models -force -ContextDir Context -Context CrmDbContext -Tables contact


