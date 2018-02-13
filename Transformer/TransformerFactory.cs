using System;
using System.Configuration;
using System.Linq;

namespace Transformer
{
    public static class TransformerFactory
    {
        private static readonly Type[] Transformations;

        static TransformerFactory()
        {
            if (Transformations == null)
                Transformations = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Where(x => x.Namespace == "Transformer.Transformers" && !x.IsAbstract)
                    .ToArray();
        }

        public static ITransformation<T, TResult> Create<T, TResult>()
        {
            var classes = Transformations.Where(x => typeof(ITransformation<T, TResult>).IsAssignableFrom(x));

            if (!classes.Any())
            {
                throw new ArgumentException($"No mapping existing between {nameof(T)} and {nameof(TResult)}");
            }

            if (classes.Count() > 1)
            {
                throw new ArgumentException($"Could not resolve transformation between the following transformers: {Environment.NewLine}{string.Join(Environment.NewLine, classes.Select(x => x.FullName))}");
            }

            var cl = classes.First();
            return Activator.CreateInstance(cl) as ITransformation<T, TResult>;
        }
    }
}