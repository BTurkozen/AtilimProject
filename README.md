# AtilimProject

---
<h4>Migration ve Update Database için Gerekli Komutlar</h4>
<ul>
  <caption>Burada Yazan Komutlar "Atilim.Services.Identity.Infrastructure" içerisinde "Migration Komutları.txt" dosyasında da bulunmaktadır.</caption>
  
  <li>Api > Properties > LaunchSettings Environment "Production" / "Development" yaptıktan sonra aşağıdaki işlemleri gerçekleştirebilirsiniz.</li>
  <li>Migration Ekleme için gereken Kod => add-migration "{MIGRATION_MESSAGE}" -c IdentityContext -o Migrations -p Atilim.Services.Identity.Infrastructure -s Atilim.Services.Identity.Api</li>
  <li>Database Update için gereken Kod => update-database -Context IdentityContext -Project Atilim.Services.Identity.Infrastructure -StartupProject Atilim.Services.Identity.Api</li>
  <li>Update işlemi gerçekleştirmeden Yapılan Migration'ı silmek için gereken Kod => remove-migration -Context IdentityContext -Project Atilim.Services.Identity.Infrastructure -StartupProject Atilim.Services.Identity.Api</li>
</ul>

---
