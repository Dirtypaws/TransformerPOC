﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Transformer.Transformers
{
    public class DuplicateTransformer : ITransformation<int, int>
    {
        public async Task<IEnumerable<string>> Validate(int input)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Transform(int input)
        {
            throw new System.NotImplementedException();
        }
    }
}