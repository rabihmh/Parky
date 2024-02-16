using ParkyAPI.Models;

namespace ParkyAPI.IRepository
{
    public interface ITrailRepository
    {
        public ICollection<Trail> GetTrails();
        public ICollection<Trail> GetTrailsInANationalPark(int nationalParkId);

        public Trail GetTrail(int trailId);

        public bool TrailExists(string name);
        public bool TrailExists(int id);

        public bool CreateTrail(Trail trail);

        public bool UpdateTrail(Trail trail);

        public bool DeleteTrail(Trail trail);

        public bool Save();
    }
}
