using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ExpARandomGenerator.Controllers
{
    [ApiController]
    [Route("/")]
    public class RandomGeneratorController : ControllerBase
    {
        private readonly ILogger<RandomGeneratorController> _logger;

        private readonly byte[] _numbers = Enumerable.Range(0, 16).Select(x => (byte)x).ToArray();

        public RandomGeneratorController(ILogger<RandomGeneratorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public RandomData Get()
        {
            return new RandomData(GenerateRandomData(), GenerateRandomData());
        }

        private string GenerateRandomData()
        {
            var builder = new StringBuilder();
            var shuffled = _numbers.OrderBy(x => Random.Shared.Next()).Take(8);
            foreach (var number in shuffled)
            {
                builder.AppendFormat("{0:X1}", number);
            }

            return builder.ToString();
        }
    }

    public record RandomData(string Data1, string Data2);
}