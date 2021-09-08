using System.Collections.Generic;
using System.Linq;
// Este es un comentario
namespace CdWarehouse.Test
{
    public class Catalogue
    {
        private readonly CompactDisc[] _cds;

        public Catalogue(params CompactDisc[] cds)
        {
            _cds = cds;
        }

        public List<CompactDisc> Search(string artist, string title)
        {
            return _cds.Where(cd => cd.Matches(artist, title)).ToList();
        }
    }
}