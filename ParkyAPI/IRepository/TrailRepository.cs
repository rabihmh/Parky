using Microsoft.EntityFrameworkCore;
using ParkyAPI.Data;
using ParkyAPI.Models;

namespace ParkyAPI.IRepository
{
    public class TrailRepository : ITrailRepository
    {
        private readonly ApplicationDbContext _context;

        public TrailRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ICollection<Trail> GetTrails()
        {
            return _context.Trails.Include(c => c.NationalPark).OrderBy(n => n.Name).ToList();
        }

        public ICollection<Trail> GetTrailsInANationalPark(int nationalParkId)
        {
            return _context.Trails.Include(c=>c.NationalPark).Where(c=>c.NationalParkId==nationalParkId).ToList();
        }

        public Trail GetTrail(int trailId)
        {
            return _context.Trails.Include(c => c.NationalPark).FirstOrDefault(n => n.Id == trailId);
        }

        public bool TrailExists(string name)
        {
            var exists = _context.Trails.Any(n => n.Name.ToLower().Trim()==name.ToLower().Trim());
            return exists;
        }
        public bool TrailExists(int id)
        {
            return _context.Trails.Any(n=>n.Id ==id);
         
        }

        public bool CreateTrail(Trail trail)
        {
            _context.Trails.Add(trail);
            return Save();
        }

        public bool UpdateTrail(Trail trail)
        {
            _context.Trails.Update(trail);
            return Save();
        }

        public bool DeleteTrail(Trail trail)
        {
            _context.Trails.Remove(trail);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
