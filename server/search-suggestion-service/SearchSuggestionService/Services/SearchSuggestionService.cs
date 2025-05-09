using SearchSuggestionService.Models;

namespace SearchSuggestionService.Services
{
    public class SearchSuggestionService : ISearchSuggestionService
    {
        private readonly List<SearchSuggestion> _suggestions = new List<SearchSuggestion>
        {
            new SearchSuggestion { Keyword = "Tshirts", Link = "page=0,16::apparels=5" },
            new SearchSuggestion { Keyword = "Jeans", Link = "page=0,16::apparels=6" },
            new SearchSuggestion { Keyword = "Sweaters", Link = "page=0,16::apparels=21" },
            new SearchSuggestion { Keyword = "Bedsheets", Link = "page=0,16::apparels=22" },
            new SearchSuggestion { Keyword = "Handbags", Link = "page=0,16::apparels=29" },
            
          
        };

        public IEnumerable<SearchSuggestion> GetDefaultSuggestions()
        {
            return _suggestions.Take(5);
        }

        public IEnumerable<SearchSuggestion> GetSuggestionsByPrefix(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                return GetDefaultSuggestions();
            }

            var matchingSuggestions = _suggestions
                .Where(s => s.Keyword.Contains(prefix, StringComparison.OrdinalIgnoreCase))
                .Take(10);
                
            if (!matchingSuggestions.Any())
            {
                return GetDefaultSuggestions();
            }
            
            return matchingSuggestions;
        }
    }
}
