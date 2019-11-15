using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLibrary.API.DbContexts;
using NewsAgregator.API.Entities;

namespace NewsAgregator.API.Services
{
    public class TagLibraryRepository: ITagLibraryRepository, IDisposable
    {
        private readonly CourseLibraryContext _context;

        public TagLibraryRepository(CourseLibraryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Tag> GetTags()
        {
            return _context.Tags.ToList<Tag>();
        }

        public Tag GetTag(Guid tagId)
        {
            if (tagId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(tagId));
            }

            return _context.Tags.FirstOrDefault(t => t.Id == tagId);
        }

        public bool TagExists(Guid tagId)
        {
            if(tagId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(tagId));
            }

            return _context.Tags.Any(t => t.Id == tagId);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose .. 
            }
        }
    }
}
