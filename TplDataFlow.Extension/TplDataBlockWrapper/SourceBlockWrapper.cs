using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;


namespace TplDataFlow.Extension.TplDataBlockWrapper
{
    public class SourceBlockWrapper<TOutput> : ISourceBlockWrapper<TOutput>
    {
        private readonly IReceivableSourceBlock<TOutput> _sourceBlock;

        public SourceBlockWrapper(IReceivableSourceBlock<TOutput> sourceBlock) =>  _sourceBlock = sourceBlock ?? throw new ArgumentNullException(nameof(sourceBlock));

        public IDisposable LinkTo(ITargetBlock<TOutput> target) => _sourceBlock.LinkTo(target);

        public IDisposable LinkTo(ITargetBlock<TOutput> target, Predicate<TOutput> predicate) => _sourceBlock.LinkTo(target, predicate);

        public IDisposable LinkTo(ITargetBlock<TOutput> target, DataflowLinkOptions linkOptions, Predicate<TOutput> predicate) => _sourceBlock.LinkTo(target, linkOptions, predicate);

        public Task<bool> OutputAvailableAsync() => _sourceBlock.OutputAvailableAsync();

        public Task<bool> OutputAvailableAsync(CancellationToken cancellationToken) => _sourceBlock.OutputAvailableAsync(cancellationToken);

        public TOutput Receive() => _sourceBlock.Receive();

        public TOutput Receive(TimeSpan timeout) => _sourceBlock.Receive(timeout);

        public TOutput Receive(CancellationToken cancellationToken) => _sourceBlock.Receive(cancellationToken);

        public TOutput Receive(TimeSpan timeout, CancellationToken cancellationToken) => _sourceBlock.Receive(timeout, cancellationToken);

        public Task<TOutput> ReceiveAsync(TimeSpan timeout) => _sourceBlock.ReceiveAsync(timeout);

        public Task<TOutput> ReceiveAsync(CancellationToken cancellationToken) => _sourceBlock.ReceiveAsync(cancellationToken);

        public Task<TOutput> ReceiveAsync() => _sourceBlock.ReceiveAsync();

        public Task<TOutput> ReceiveAsync(TimeSpan timeout, CancellationToken cancellationToken) => _sourceBlock.ReceiveAsync(timeout, cancellationToken);

        public bool TryReceive(out TOutput item) => _sourceBlock.TryReceive(out item);
    }
}
