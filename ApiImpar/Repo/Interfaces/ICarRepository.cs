using ApiImpar.Models;

namespace ApiImpar.Repo.Interfaces
{
    public interface ICarRepository
    {
        Task<List<CarModel>> Get();
        Task<CarModel> GetById(int Id);
        Task<CarModel> Add(CarModel Car);
        Task<CarModel> Update(CarModel Car, int Id);
        Task<bool> Delete(int Id);

    }
}
