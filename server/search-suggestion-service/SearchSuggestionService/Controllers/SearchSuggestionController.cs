using Microsoft.AspNetCore.Mvc;
using SearchSuggestionService.Models;
using SearchSuggestionService.Services;

namespace SearchSuggestionService.Controllers
{
    [ApiController]
    [Route("")]
    public class SearchSuggestionController : ControllerBase
    {
        private readonly ISearchSuggestionService _searchSuggestionService;
        private readonly ILogger<SearchSuggestionController> _logger;

        public SearchSuggestionController(ISearchSuggestionService searchSuggestionService, ILogger<SearchSuggestionController> logger)
        {
            _searchSuggestionService = searchSuggestionService;
            _logger = logger;
        }

        [HttpGet("search-suggestion")]
        public ActionResult<IEnumerable<SearchSuggestion>> GetSearchSuggestions([FromQuery(Name = "q")] string query)
        {
            _logger.LogInformation($"Received search suggestion request with query: {query}");
            var suggestions = _searchSuggestionService.GetSuggestionsByPrefix(query);
            return Ok(suggestions);
        }

        [HttpGet("default-search-suggestion")]
        public ActionResult<IEnumerable<SearchSuggestion>> GetDefaultSearchSuggestions()
        {
            _logger.LogInformation("Received default search suggestion request");
            var suggestions = _searchSuggestionService.GetDefaultSuggestions();
            return Ok(suggestions);
        }
    }
}
