using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlersDBContext _context { get; set; }
        public EFBowlersRepository (BowlersDBContext temp)
        {
            _context = temp;
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;

        public void Save(Bowler b)
        {
            _context.SaveChanges();
        }

        public void AddBowler(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }

        public void Edit(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();
        }

        public void Delete(Bowler b)
        {
            _context.Remove(b);
            _context.SaveChanges();
        }

        //public void SaveBook(Bowler b)
        //{
        //    _context.SaveChanges();
        //}

        //public void CreateBook(Bowler b)
        //{
        //    _context.Add(b);
        //    _context.SaveChanges();
        //}

        //public void DeleteBook(Bowler b)
        //{
        //    _context.Remove(b);
        //    _context.SaveChanges();
        //}
    }
}
