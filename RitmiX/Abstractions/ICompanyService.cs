using RitmiX.Entities;

namespace RitmiX.Abstractions
{
    public interface CompanyService
    {
        Task<Company> GetAll();
        Task<int> GetById(int id);
        Task<Company> Create();
        Task<Company> Update(int id);
    }
}
