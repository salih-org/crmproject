


// A�a��daki script'i contact veritaban� objelerini uygulama i�erisinde olu�turmak i�in kullanabiliriz.
// EntityFrameworkCore.Tools k�t�phanesi y�kl� olmal�

Scaffold-DbContext "Host=xxx;Port=xxx;Database=postgres;Username=postgres;Password=241990" 
	Npgsql.EntityFrameworkCore.PostgreSQL -o Models -force -ContextDir Context -Context CrmDbContext -Tables contact


