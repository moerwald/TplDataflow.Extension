using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TplDataFlow.Extension.TplDataBlockWrapper
{
    /// <summary>
    /// Method signatures are taken from TPL Dataflow DataflowBlock.cs
    /// </summary>
    /// <typeparam name="TOutput"></typeparam>
    public interface ISourceBlockWrapper<TOutput>
    {
        IDisposable LinkTo(ITargetBlock<TOutput> target);

        IDisposable LinkTo(ITargetBlock<TOutput> target, Predicate<TOutput> predicate);
        IDisposable LinkTo(ITargetBlock<TOutput> target, DataflowLinkOptions linkOptions, Predicate<TOutput> predicate);

        Task<bool> OutputAvailableAsync();
        Task<bool> OutputAvailableAsync(CancellationToken cancellationToken);

        TOutput Receive();
        TOutput Receive(TimeSpan timeout);
        TOutput Receive(TimeSpan timeout, CancellationToken cancellationToken);
        TOutput Receive(CancellationToken cancellationToken);
        Task<TOutput> ReceiveAsync(TimeSpan timeout);
        Task<TOutput> ReceiveAsync(CancellationToken cancellationToken);
        Task<TOutput> ReceiveAsync();
        Task<TOutput> ReceiveAsync(TimeSpan timeout, CancellationToken cancellationToken);
        bool TryReceive(out TOutput item);
    }
}
