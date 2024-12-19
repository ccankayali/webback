public class OrnekService
{
    private readonly OrnekRepository _repository;

    public OrnekService(OrnekRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Ornek>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Ornek?> GetByIdAsync(string id) => _repository.GetByIdAsync(id);

    public Task CreateAsync(Ornek ornek) => _repository.CreateAsync(ornek);

    public Task<bool> UpdateAsync(string id, Ornek ornek) => _repository.UpdateAsync(id, ornek);

    public Task<bool> DeleteAsync(string id) => _repository.DeleteAsync(id);
}
