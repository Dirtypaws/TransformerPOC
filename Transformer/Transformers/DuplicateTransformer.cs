using System.Threading.Tasks;

namespace Transformer.Transformers
{
    public class DuplicateTransformer : ITransformation<int, int>
    {
        public Task<int> Transform(int input)
        {
            throw new System.NotImplementedException();
        }
    }
}