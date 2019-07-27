using System;
using System.Collections;
using UnityEngine;

namespace Morph
{
    public static class CoroutineExtensions
    {
        public static IEnumerator ThenWait (this IEnumerator target, CustomYieldInstruction wait)
        {
            yield return target;
            yield return wait;
        }

        public static IEnumerator ThenWait (this IEnumerator target, float seconds)
        {
            return target.ThenWait(TimeSpan.FromSeconds(seconds));
        }

        public static IEnumerator ThenWait(this IEnumerator target, TimeSpan duration)
        {
            yield return target;
            yield return new WaitForSeconds((float)duration.TotalSeconds);
        }

        public static IEnumerator Then (this IEnumerator target, params IEnumerator[] sequence)
        {
            yield return target;
            foreach (var routine in sequence)
                yield return routine;
        }
    }
}

