using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TplDataFlow.Extension
{
    public class TargetBlockWrapper<TInput> : ITargetBlockWrapper<TInput>
    {
        private ITargetBlock<TInput> _targetBlock;

        public TargetBlockWrapper(ITargetBlock<TInput> targetBlock) => _targetBlock = targetBlock ?? throw new ArgumentNullException(nameof(targetBlock));

        public IObserver<TInput> AsObserver() => _targetBlock.AsObserver();

        public bool Post(TInput item) => _targetBlock.Post(item);

        public Task<bool> SendAsync(TInput item, CancellationToken cancellationToken) => _targetBlock.SendAsync(item, cancellationToken);

        public Task<bool> SendAsync(TInput item) => _targetBlock.SendAsync(item);
    }
}
