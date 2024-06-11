using ApiImpar.Data;
using ApiImpar.Models;
using ApiImpar.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiImpar.Repo
{
    public class CarRepository : ICarRepository
    {
        private readonly ApiImparDBContext _dBContext;
        public CarRepository(ApiImparDBContext apiImparDBContext) {

            _dBContext = apiImparDBContext;

        }

        public async  Task<CarModel> Add(CarModel Car)
        {
                await _dBContext.Cars.AddAsync(Car);
                await _dBContext.SaveChangesAsync();
                return Car;
        }

        public async Task<bool> Delete(int id)
        {
            CarModel CarId =   await GetById(id);
            PhotoModel PhotoId = await GetPhotoById(CarId.PhotoId);

            if (CarId == null)
            {
                throw new Exception($"Car Id:{id} Not Found");
            }
            else if (PhotoId == null)
            {
                throw new Exception($"Photo Id:{id} Not Found");
            }

            _dBContext.Cars.Remove(CarId);
            _dBContext.Photos.Remove(PhotoId);
            await _dBContext.SaveChangesAsync();
            return true;

        }

        public async Task<List<CarModel>> Get()
        {
            return await _dBContext.Cars
                .Include(x=>x.Photo)
                .ToListAsync();
        }

        public async Task<CarModel> GetById(int id)
        {
            return await _dBContext.Cars.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PhotoModel> GetPhotoById(int id)
        {
            return await _dBContext.Photos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CarModel> Update(CarModel Car, int id)
        {
            CarModel CarId = await GetById(id);
            PhotoModel PhotoId = await GetPhotoById(CarId.PhotoId);

            if (CarId == null)
            {
                throw new Exception($"Car Id:{id} Not Found");
            }
            else if (PhotoId == null) {
                throw new Exception($"Photo Id:{id} Not Found");
            }

            CarId.PhotoId = Car.PhotoId;    
            CarId.Name = Car.Name;  
            CarId.Status = Car.Status;

            PhotoId.Base64 = Car.Photo.Base64;


             _dBContext.Cars.Update(CarId);
            _dBContext.Photos.Update(PhotoId);
            await _dBContext.SaveChangesAsync();

            return CarId;
        }
    }
}
