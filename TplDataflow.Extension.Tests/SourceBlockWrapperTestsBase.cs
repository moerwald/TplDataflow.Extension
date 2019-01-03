using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using NUnit.Framework;
using TplDataFlow.Extension.TaskScheduler.Synchronous;
using TplDataFlow.Extension.TplDataBlockWrapper;

namespace TplDataflow.Extension.Tests
{
    [TestFixture]
    public class SourceBlockWrapperTests
    {
        [Test]
        public void CtorThrowNullException() => Assert.Throws<ArgumentNullException>(() => new SourceBlockWrapper<int>(null));

        [Test]
        public async Task ReceiveAsyncActsAsProxy()
        {
            var ts = new TaskSchedulerSingleThreaded();
            var sourceBlock = new BufferBlock<int>(new DataflowBlockOptions { TaskScheduler = ts });
            var targetBlock = new BufferBlock<int>(new DataflowBlockOptions { TaskScheduler = ts });
            targetBlock.LinkTo(sourceBlock, new DataflowLinkOptions { PropagateCompletion = true });
            targetBlock.Post(42);
            var task = new SourceBlockWrapper<int>(sourceBlock).ReceiveAsync();
            ts.ExecuteAllTasksInActualThread();
            await task;
            Assert.That(task.Result, Is.EqualTo(42));
        }

        [Test]
        public void ReceiveActsAsProxy()
        {
            var ts = new TaskSchedulerSingleThreaded();
            var sourceBlock = new BufferBlock<int>(new DataflowBlockOptions { TaskScheduler = ts });
            var targetBlock = new BufferBlock<int>(new DataflowBlockOptions { TaskScheduler = ts });
            targetBlock.LinkTo(sourceBlock, new DataflowLinkOptions { PropagateCompletion = true });
            targetBlock.Post(42);
            ts.ExecuteAllTasksInActualThread();
            var v = new SourceBlockWrapper<int>(sourceBlock).Receive();
            Assert.That(v, Is.EqualTo(42));
        }
    }
}
