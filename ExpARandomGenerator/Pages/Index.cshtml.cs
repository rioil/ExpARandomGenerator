using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExpARandomGenerator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly byte[] _numbers = Enumerable.Range(0, 16).Select(x => (byte)x).ToArray();

        public IList<IList<byte>> Data { get; set; } = Array.Empty<byte[]>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Data = new byte[][] { GenerateRandomData(), GenerateRandomData() };
        }

        private byte[] GenerateRandomData()
        {
            const int Digits = 8;
            var data = _numbers.OrderBy(x => Random.Shared.Next())
                               .Take(Digits)
                               .ToArray();

            return data;
        }
    }
}