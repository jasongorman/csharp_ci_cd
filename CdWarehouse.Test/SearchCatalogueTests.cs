using NUnit.Framework;

namespace CdWarehouse.Test
{
    [TestFixture]
    public class SearchCatalogueTests
    {
        [Test]
        public void MatchingTitleFound()
        {
            string artist = "Peter Gabriel";
            string title = "So";
            CompactDisc cd = new CompactDisc(artist, title);
            Catalogue catalogue = new Catalogue(cd);
            Assert.AreSame(cd, catalogue.Search(artist, title)[0]);
        }
        
        [Test]
        public void NoMatchingTitleFound()
        {
            string artist = "Peter Gabriel";
            string title = "So";
            CompactDisc cd = new CompactDisc(artist, title);
            Catalogue catalogue = new Catalogue();
            Assert.AreEqual(0, catalogue.Search(artist, title).Count);
        }

    }
}