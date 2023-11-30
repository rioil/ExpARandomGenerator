using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ExpARandomGenerator.Controllers
{
    [ApiController]
    [Route("/")]
    public class RandomGeneratorController : ControllerBase
    {
        private readonly ILogger<RandomGeneratorController> _logger;

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
            int previos = -1;
            for (int i = 0; i < 8; i++)
            {
                int number;
                do
                {
                    number = Random.Shared.Next(0x0, 0xF);
                } while (previos == number);
                
                previos = number;
                builder.Append(number.ToString("X1"));
            }

            return builder.ToString();
        }
    }

    public record RandomData(string Data1, string Data2);
}