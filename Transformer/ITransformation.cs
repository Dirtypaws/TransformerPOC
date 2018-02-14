using System.Collections.Generic;
using System.Threading.Tasks;

namespace Transformer
{
    public interface ITransformation<T, TResult>
    {
        Task<IEnumerable<string>> Validate(T input);
        Task<TResult> Transform(T input);
    }
}