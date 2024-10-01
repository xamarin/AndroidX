using System;
using Android.Runtime;
using Java.Util.Concurrent;
using Android.OS;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Android.Gms.Common.Apis
{
    public class ResultCallback<TResult> : Java.Lang.Object, IResultCallback where TResult : class, IResult
    {
        public ResultCallback (Action<TResult> handler)
        {
            OnResultHandler = handler;
        }

        public Action<TResult> OnResultHandler { get; private set; }

        public void OnResult (Java.Lang.Object result)
        {
            var h = OnResultHandler;
            if (h != null)
                h(result.JavaCast<TResult> ());
        }
    }

    public class AwaitableResultCallback<TResult> : Java.Lang.Object, IResultCallback where TResult : class, IResult
    {
        public AwaitableResultCallback ()
        {
            taskCompletionSource = new TaskCompletionSource<TResult> ();
        }

        TaskCompletionSource<TResult> taskCompletionSource;

        public void OnResult (Java.Lang.Object result)
        {
            var r = result.JavaCast<TResult> ();

            taskCompletionSource.SetResult (r);
        }

        public Task<TResult> AwaitAsync ()
        {
            return taskCompletionSource.Task;
        }

        public TaskAwaiter<TResult> GetAwaiter ()
        {
            return taskCompletionSource.Task.GetAwaiter ();
        }
    }
}
