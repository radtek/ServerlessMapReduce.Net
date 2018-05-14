using System.Collections.Generic;
using ServerlessMapReduceDotNet.Abstractions;
using ServerlessMapReduceDotNet.Model;

namespace ServerlessMapReduceDotNet.FinalReducers
{
    class MakeAccidentCountFinalReducer : IFinalReduceFunc
    {
        public IReadOnlyCollection<string> FinalReduce(IKeyValuePair keyValuePair)
        {
            var countKvp = (CountKvp) keyValuePair;
            return new[] {$"{countKvp.Key},{countKvp.Value}"};
        }
    }
}