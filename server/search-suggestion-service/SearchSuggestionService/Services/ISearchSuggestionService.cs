using SearchSuggestionService.Models;

namespace SearchSuggestionService.Services
{
    public interface ISearchSuggestionService
    {
        IEnumerable<SearchSuggestion> GetDefaultSuggestions();
        IEnumerable<SearchSuggestion> GetSuggestionsByPrefix(string prefix);
    }
}
