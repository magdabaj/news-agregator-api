using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsAgregator.API.Entities;

namespace NewsAgregator.API.Services
{
    public interface ITagLibraryRepository
    {
        IEnumerable<Tag> GetTags();
        Tag GetTag(Guid tagId);
        bool TagExists(Guid tagId);
    }
}
