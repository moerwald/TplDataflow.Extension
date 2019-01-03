using System.Collections.Generic;
using System.Threading.Tasks;

namespace TplDataFlow.Extension.TaskScheduler.Synchronous
{
    /// <summary>
    /// A single threaded task scheduler. Scheduled task can be fired via <see cref="ExecuteAllTasksInActualThread"/>.
    ///
    /// This scheduler is helpfull when trying to test TPL dataflow blocks in a synchronous way.
    /// </summary>
    public class TaskSchedulerSingleThreaded : System.Threading.Tasks.TaskScheduler
    {
        private readonly LinkedList<Task> _taskList = new LinkedList<Task>();

        public override int MaximumConcurrencyLevel => 1;

        protected override IEnumerable<Task> GetScheduledTasks() => _taskList;

        protected override void QueueTask(Task task)
        {
            lock (_taskList)
            {
                _taskList.AddLast(task);
            }
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            lock (_taskList)
            {
                _taskList.AddLast(task);

            }
            return false;
        }

        public void ExecuteAllTasksInActualThread()
        {
            // Work on copy, new task may be added, while list iteration is performed
            LinkedList<Task> listCopy = null;
            lock (_taskList)
            {
                listCopy = new LinkedList<Task>(_taskList);
            }

            foreach (Task t in listCopy)
            {
                this.TryExecuteTask(t);
            }
        }
    }
}
