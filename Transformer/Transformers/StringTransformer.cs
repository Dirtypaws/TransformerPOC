using System.Collections.Generic;
using System.Threading.Tasks;
using Transformer.Messages;

namespace Transformer.Transformers
{
    public class StringTransformer : ITransformation<Generic, string>
    {
        public async Task<IEnumerable<string>> Validate(Generic input)
        {
            return new List<string>();
        }

        public async Task<string> Transform(Generic input)
        {
            return "Hello World";
        }
    }
}