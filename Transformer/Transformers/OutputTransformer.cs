using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Transformer.Messages;

namespace Transformer.Transformers
{
    public class OutputTransformer : ITransformation<Generic, Output>
    {
        private string[] nameSplit;

        public async Task<IEnumerable<string>> Validate(Generic input)
        {
            var valMsg = new List<string>();

            nameSplit = input.Name.Split(',');
            if (nameSplit.Length < 2)
            {
                valMsg.Add("Invalid first name last name supplied");
            }

            return valMsg;
        }

        public async Task<Output> Transform(Generic input)
        {
            return new Output
            {
                FirstName = nameSplit.Last().Trim(),
                LastName = nameSplit.First().Trim()
            };
        }
    }
}