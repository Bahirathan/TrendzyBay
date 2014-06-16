using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class SearchCore
    {
        private List<Searcher> Searchers { get; set; }

        public SearchCore(List<Searcher> searchers)
        {
            //Add passed in searchers to the list of searchers to use.
            Searchers = searchers;
        }

        public IEnumerable<SearchResult> Search(string searchTerm)
        {
            var result = new List<SearchResult>();

            //Iterate over the collection of Searchers, calling their search method
            //and adding the result to the results to be returned.
            foreach (Searcher searcher in Searchers)
            {
                result.AddRange(searcher.Search(searchTerm));
            }
            return result;
        }

    }

    public abstract class Searcher
    {
        public abstract IEnumerable<SearchResult> Search(string searchTerm);
    }

    public class SearchResponse
    {
        public IEnumerable<SearchResult> Results { get; set; }
        public string OriginalSearchTerm { get; set; }
        public TimeSpan TimeTaken { get; set; }
    }

    public class SearchResult
    {
        public int Ranking { get; set; }
        public long Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string price { get; set; }
        public string imgURL { get; set; }
        public string HTML { get; set; }
        public object OriginatingObject { get; set; }
    }
}
