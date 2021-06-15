using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasuriLib.Extensions
{
    public static class TaskExtension
    {
        public static Task ContinueWithThorwException(this Task src, Action<Task> action)
        {
            return src.ContinueWith(x =>
            {
                if (x.Exception != null)
                    throw new Exception(x.Exception.InnerException?.Message);

                action(x);
            });
        }

        public static Task ContinueWithThorwException(this Task src, Action<Task> action, TaskScheduler scheduler)
        {
            return src.ContinueWith(x =>
            {
                if (x.Exception != null)
                    throw new Exception(x.Exception.InnerException?.Message);

                action(x);
            }, scheduler);
        }

        public static Task ContinueWithThorwException<TResult>(this Task<TResult> src, Action<Task<TResult>> action)
        {
            return src.ContinueWith(x =>
            {
                if (x.Exception != null)
                    throw new Exception(x.Exception.InnerException?.Message);

                action(x);
            });
        }

        public static Task ContinueWithThorwException<TResult>(this Task<TResult> src, Action<Task<TResult>> action, TaskScheduler scheduler)
        {
            return src.ContinueWith(x =>
            {
                if (x.Exception != null)
                    throw new Exception(x.Exception.InnerException?.Message);

                action(x);
            }, scheduler);
        }
    }
}
