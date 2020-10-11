// Aşağıdaki script'i reservation veritabanı objelerini uygulama içerisinde oluşturmak için kullanabiliriz.
// EntityFrameworkCore.Tools kütüphanesi yüklü olmalı

Scaffold-DbContext "Host=xxxx;Port=xxx;Database=postgres;Username=postgres;Password=241990" Npgsql.EntityFrameworkCore.PostgreSQL -o Models -force -ContextDir Context -Context ReservationDbContext -Tables reservations