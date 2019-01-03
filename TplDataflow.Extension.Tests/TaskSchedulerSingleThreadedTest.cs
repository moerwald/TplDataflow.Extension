using NUnit.Framework;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;
using TplDataFlow.Extension.TaskScheduler.Synchronous;
using System.Threading;

namespace TplDataflow.Extension.Tests
{
    [TestFixture]
    public class TaskSchedulerSingleThreadedTest
    {
        [Test]
        public void CheckIfTplDataflowBlocksRunIASingleThread()
        {
            // Arrange
            // We inject the scheduler to the action blocks. Each block inserts the calling thread id to a dictionary.
            ConcurrentDictionary<int, int> threadIdCounts = new ConcurrentDictionary<int, int>();
            TaskSchedulerSingleThreaded ts = new TaskSchedulerSingleThreaded();
            var abList = new List<ActionBlock<string>>
            {
                new ActionBlock<string>( s => IncreaseThreadIdCount() , new ExecutionDataflowBlockOptions { TaskScheduler = ts }),
                new ActionBlock<string>( s => IncreaseThreadIdCount() , new ExecutionDataflowBlockOptions { TaskScheduler = ts }),
                new ActionBlock<string>( s => IncreaseThreadIdCount() , new ExecutionDataflowBlockOptions { TaskScheduler = ts }),
                new ActionBlock<string>( s => IncreaseThreadIdCount() , new ExecutionDataflowBlockOptions { TaskScheduler = ts }),
            };

            abList.ForEach(b => b.Post("test"));

            // Act -> call queued action block calls via a single thread
            ts.ExecuteAllTasksInActualThread();

            // Assert -> threadIdCounts should only contain one entry with the actual thread id.
            Assert.Multiple(() =>
            {
                var currentThreadId = Thread.CurrentThread.ManagedThreadId;
                Assert.That(threadIdCounts.ContainsKey(currentThreadId),
                    Is.True,
                    $"Current thread id {currentThreadId} is not included in {nameof(threadIdCounts)}");
                Assert.That(threadIdCounts.Count,
                    Is.EqualTo(1),
                    $"{nameof(threadIdCounts)} doesnt' contain 1 element");
                Assert.That(threadIdCounts[currentThreadId], Is.EqualTo(abList.Count));
            });

            // Locals
            void IncreaseThreadIdCount()
            {
                var tId = Thread.CurrentThread.ManagedThreadId;
                threadIdCounts[tId] = threadIdCounts.ContainsKey(tId) ? ++threadIdCounts[tId] : 1;
            }
        }
    }
}
