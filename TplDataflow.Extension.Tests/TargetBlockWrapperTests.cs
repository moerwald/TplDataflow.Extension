using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using TplDataFlow.Extension.TaskScheduler.Synchronous;
using TplDataFlow.Extension.TplDataBlockWrapper;

namespace TplDataflow.Extension.Tests
{
    [TestFixture]
    public class TargetBlockWrapperTests
    {
        [Test]
        public void CtorThrowNullException() => Assert.Throws<ArgumentNullException>(() => new TargetBlockWrapper<int>(null));

        [Test]
        public void PostActsAsProxy()
        {
            int receivedValue = 0;
            var ts = new TaskSchedulerSingleThreaded();
            var ab = new ActionBlock<int>(i => receivedValue = i, new ExecutionDataflowBlockOptions { TaskScheduler = ts });
            new TargetBlockWrapper<int>(ab).Post(42);

            ts.ExecuteAllTasksInActualThread();
            Assert.That(receivedValue, Is.EqualTo(42));
        }

        [Test]
        public async Task SendAsyncActsAsProxy()
        {
            int receivedValue = 0;
            var ts = new TaskSchedulerSingleThreaded();
            var ab = new ActionBlock<int>(i => receivedValue = i, new ExecutionDataflowBlockOptions { TaskScheduler = ts });
            var task = new TargetBlockWrapper<int>(ab).SendAsync(42);

            ts.ExecuteAllTasksInActualThread();
            await task;
            Assert.That(receivedValue, Is.EqualTo(42));
        }
    }
}
