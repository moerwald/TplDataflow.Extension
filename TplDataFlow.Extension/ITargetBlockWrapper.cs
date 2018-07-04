using System;
using System.Threading;
using System.Threading.Tasks;

namespace TplDataFlow.Extension
{
    /// <summary>
    /// Method signatures are taken from TPL Dataflow DataflowBlock.cs
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    public interface ITargetBlockWrapper<TInput>
    {
        bool Post(TInput item);
        IObserver<TInput> AsObserver();

        Task<bool> SendAsync(TInput item, CancellationToken cancellationToken);

        Task<bool> SendAsync(TInput item);
    }
}
