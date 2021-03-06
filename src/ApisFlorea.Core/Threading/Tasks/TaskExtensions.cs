﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;



namespace ApisFlorea.Core.Threading.Tasks
{
    /// <summary>
    /// System.Threading.Tasks.Taskの拡張機能を提供します。
    /// </summary>
    public static class TaskExtensions
    {
        #region 打ちっ放し
        /// <summary>
        /// 実行したタスクを打ちっ放しの状態にします。
        /// </summary>
        /// <param name="task">タスク</param>
        /// <remarks>コンパイル時警告の抑制のためにあります。</remarks>
        public static void Forget(this Task task)
        {}
        #endregion


        #region ConfigureAwait(false) のショートカット
        /// <summary>
        /// 実行コンテキストを戻さずにTaskを待機するawaiterを構成します。
        /// </summary>
        /// <param name="task">タスク</param>
        /// <returns>awaiter</returns>
        public static ConfiguredTaskAwaitable Stay(this Task task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));
            return task.ConfigureAwait(false);
        }


        /// <summary>
        /// 実行コンテキストを戻さずにTaskを待機するawaiterを構成します。
        /// </summary>
        /// <typeparam name="T">タスクで扱うデータ型</typeparam>
        /// <param name="task">タスク</param>
        /// <returns>awaiter</returns>
        public static ConfiguredTaskAwaitable<T> Stay<T>(this Task<T> task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));
            return task.ConfigureAwait(false);
        }
        #endregion


        #region WhenAll / WhenAnyへの簡易アクセス
        /// <summary>
        /// 指定されたすべてのタスクが完了してから完了するタスクを作成します。
        /// </summary>
        /// <param name="tasks">完了を待機するタスク</param>
        /// <returns>指定されたすべてのタスクの完了を表すタスク</returns>
        public static Task WhenAll(this IEnumerable<Task> tasks)
        {
            if (tasks == null)
                throw new ArgumentNullException(nameof(tasks));
            return Task.WhenAll(tasks);
        }


        /// <summary>
        /// 指定されたすべてのタスクが完了してから完了するタスクを作成します。
        /// </summary>
        /// <typeparam name="T">タスクの戻り値となる型</typeparam>
        /// <param name="tasks">完了を待機するタスク</param>
        /// <returns>指定されたすべてのタスクの完了を表すタスク</returns>
        public static Task<T[]> WhenAll<T>(this IEnumerable<Task<T>> tasks)
        {
            if (tasks == null)
                throw new ArgumentNullException(nameof(tasks));
            return Task.WhenAll(tasks);
        }


        /// <summary>
        /// 指定されたいずれかのタスクが完了した時点で、続行するタスクを作成します。
        /// </summary>
        /// <param name="tasks">完了を待機するタスク</param>
        /// <returns>指定されたいずれかのタスクの完了を表すタスク。返されるタスクの結果は完了したタスクです。</returns>
        public static Task<Task> WhenAny(this IEnumerable<Task> tasks)
        {
            if (tasks == null)
                throw new ArgumentNullException(nameof(tasks));
            return Task.WhenAny(tasks);
        }


        /// <summary>
        /// 指定されたいずれかのタスクが完了した時点で、続行するタスクを作成します。
        /// </summary>
        /// <typeparam name="T">タスクの戻り値となる型</typeparam>
        /// <param name="tasks">完了を待機するタスク</param>
        /// <returns>指定されたいずれかのタスクの完了を表すタスク。返されるタスクの結果は完了したタスクです。</returns>
        public static Task<Task<T>> WhenAny<T>(this IEnumerable<Task<T>> tasks)
        {
            if (tasks == null)
                throw new ArgumentNullException(nameof(tasks));
            return Task.WhenAny(tasks);
        }
        #endregion


        #region タイムアウト
        /// <summary>
        /// 指定されたタスクにタイムアウト時間を設けます。
        /// </summary>
        /// <param name="task">タスク</param>
        /// <param name="timeout">タイムアウト時間</param>
        /// <returns>処理</returns>
        public static async Task Timeout(this Task task, TimeSpan timeout)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            var delay = Task.Delay(timeout);
            var any = await Task.WhenAny(task, delay).Stay();
            if (any == delay)
                throw new TimeoutException();
        }


        /// <summary>
        /// 指定されたタスクにタイムアウト時間を設けます。
        /// </summary>
        /// <typeparam name="T">タスクで返す型</typeparam>
        /// <param name="task">タスク</param>
        /// <param name="timeout">タイムアウト時間</param>
        /// <returns>処理</returns>
        public static async Task<T> Timeout<T>(this Task<T> task, TimeSpan timeout)
        {
            await ((Task)task).Timeout(timeout).Stay();
            return await task.Stay();
        }
        #endregion
    }
}