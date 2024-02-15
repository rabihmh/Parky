using ParkyAPI.Models;

namespace ParkyAPI.IRepository
{
    public interface INationalParkRepository
    {
        public ICollection<NationalPark> GetNationalParks();

        public NationalPark GetNationalPark(int nationalParkId);

        public bool NationalParkExists(string name);
        public bool NationalParkExists(int id);

        public bool CreateNationalPark(NationalPark nationalPark);

        public bool UpdateNationalPark(NationalPark nationalPark);

        public bool DeleteNationalPark(NationalPark nationalPark);

        public bool Save();
    }
}
