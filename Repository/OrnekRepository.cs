using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class OrnekRepository
{
    private readonly IMongoCollection<Ornek> _ornekCollection;

    public OrnekRepository(IMongoClient client, IOptions<MongoDbSettings> settings)
    {
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _ornekCollection = database.GetCollection<Ornek>("ornekdb"); // Koleksiyon adı
    }

    // Tüm Ornekleri Al
    public async Task<List<Ornek>> GetAllAsync() => 
        await _ornekCollection.Find(_ => true).ToListAsync();

    // ID'ye göre Ornek Al
    public async Task<Ornek?> GetByIdAsync(string id) =>
        await _ornekCollection.Find(e => e.Id == id).FirstOrDefaultAsync();

    // Yeni Ornek Oluştur
    public async Task CreateAsync(Ornek ornek) =>
        await _ornekCollection.InsertOneAsync(ornek);

    // Ornek Güncelle
    public async Task<bool> UpdateAsync(string id, Ornek ornek)
    {
        var result = await _ornekCollection.ReplaceOneAsync(e => e.Id == id, ornek);
        return result.MatchedCount > 0;
    }

    // Ornek Sil
    public async Task<bool> DeleteAsync(string id)
    {
        var result = await _ornekCollection.DeleteOneAsync(e => e.Id == id);
        return result.DeletedCount > 0;
    }
}
