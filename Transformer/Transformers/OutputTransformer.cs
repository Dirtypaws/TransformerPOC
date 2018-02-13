using System.Linq;
using System.Threading.Tasks;
using Transformer.Messages;

namespace Transformer.Transformers
{
    public class OutputTransformer : ITransformation<Generic, Output>
    {
        public async Task<Output> Transform(Generic input)
        {
            var nameSplit = input.Name.Split(',');
            return new Output
            {
                FirstName = nameSplit.Last().Trim(),
                LastName = nameSplit.First().Trim()
            };
        }
    }
}