using ApiImpar.Models;

namespace ApiImpar.Repo.Interfaces
{
    public interface IPhotoRepository
    {
        Task<CarModel> GetById(int Id);
        Task<CarModel> Update(CarModel Car, int Id);
        Task<bool> Delete(int Id);
    }
}
