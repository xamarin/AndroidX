using System;
using Android.Runtime;
using Android.Gms.Tasks;
using System.Runtime.CompilerServices;
using Android.Gms.Extensions;

namespace Android.Gms.Extensions
{
    public static class TasksExtensions
    {
        
        public static System.Threading.Tasks.Task<TResult> AsAsync<TResult> (this Task task) where TResult : class, IJavaObject
        {
            var c = new AwaitableTaskCompleteListener<TResult> ();

            // The Java Task<T> returned from this call is the same task
            // so we do not have to await it
            task.AddOnCompleteListener (c);

            return c.AwaitAsync ();
        }

        public static System.Threading.Tasks.Task AsAsync (this Task task)
        {
            var c = new AwaitableTaskCompleteListener<Java.Lang.Object> ();

            task.AddOnCompleteListener (c);

            return c.AwaitAsync ();
        }

        public static TaskAwaiter<TResult> GetAwaiter<TResult> (this Task task) where TResult : class, IJavaObject
        {
            var c = new AwaitableTaskCompleteListener<TResult> ();

            task.AddOnCompleteListener (c);

            return c.GetAwaiter ();
        }

        public static TaskAwaiter<Java.Lang.Object> GetAwaiter (this Task task)
        {
            var c = new AwaitableTaskCompleteListener<Java.Lang.Object> ();

            task.AddOnCompleteListener (c);

            return c.GetAwaiter ();
        }
    }

    [Android.Runtime.Preserve]
    class AwaitableTaskCompleteListener<TResult> : Java.Lang.Object, IOnCompleteListener where TResult : class, IJavaObject
    {
        System.Threading.Tasks.TaskCompletionSource<TResult> taskCompletionSource;

        [Android.Runtime.Preserve]
        public AwaitableTaskCompleteListener ()
        {
            taskCompletionSource = new System.Threading.Tasks.TaskCompletionSource<TResult> ();
        }

        [Android.Runtime.Preserve]
        public void OnComplete (Task task)
        {
            if (task.IsSuccessful) {
                taskCompletionSource.SetResult (task?.Result?.JavaCast<TResult> ());
            } else {
                taskCompletionSource.SetException (task.Exception);
            }
        }

        [Android.Runtime.Preserve]
        public System.Threading.Tasks.Task<TResult> AwaitAsync ()
        {
            return taskCompletionSource.Task;
        }

        [Android.Runtime.Preserve]
        public TaskAwaiter<TResult> GetAwaiter ()
        {
            return taskCompletionSource.Task.GetAwaiter ();
        }
    }
}

namespace Android.Gms.Tasks
{
    [Android.Runtime.Preserve]
    public partial class Task
    {
        [Android.Runtime.Preserve]
        public virtual Java.Lang.Object Result {
            get { return RawResult; }
        }
    }

    [Android.Runtime.Preserve]
    public partial class TaskCompletionSource
    {
        [Android.Runtime.Preserve]
        public virtual Task Task { get { return GetTask (); } }
    }
}
