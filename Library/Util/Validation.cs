using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Godot;

namespace Utils
{
    public static class Validation
    {
        public static bool IsValid<T>(this T obj)
            where T : GodotObject
        {
            return GodotObject.IsInstanceValid(obj);
        }

        public static T ConsoleValid<T>(this T obj)
            where T : GodotObject
        {
            if (!obj.IsValid())
                throw new InvalidOperationException($"{typeof(T).Name} is invalid or freed.");

            return obj;
        }

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T EnsureValid<T>(this T obj)
            where T : GodotObject
        {
            if (Debugger.IsAttached && !obj.IsValid())
            {
                Debugger.Break();
            }

            return obj;
        }
    }
}
