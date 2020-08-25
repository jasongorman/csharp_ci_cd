namespace CdWarehouse.Test
{
    public class CompactDisc
    {
        private string Artist { get; }
        private string Title { get; }

        public CompactDisc(string artist, string title)
        {
            Artist = artist;
            Title = title;
        }

        public bool Matches(string artist, string title)
        {
            return this.Artist == artist && this.Title == title;
        }
    }
}