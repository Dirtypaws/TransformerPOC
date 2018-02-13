using System.Threading.Tasks;

namespace Transformer
{
    public interface ITransformation<T, TResult>
    {
        Task<TResult> Transform(T input);
    }
}