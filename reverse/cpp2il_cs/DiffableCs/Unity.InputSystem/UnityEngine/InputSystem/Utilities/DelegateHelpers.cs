namespace UnityEngine.InputSystem.Utilities;

internal static class DelegateHelpers
{

	public static void InvokeCallbacksSafe(ref CallbackArray<Action>& callbacks, ProfilerMarker marker, string callbackName, object context = null) { }

	public static void InvokeCallbacksSafe(ref CallbackArray<Action`1<TValue>>& callbacks, TValue argument, string callbackName, object context = null) { }

	public static void InvokeCallbacksSafe(ref CallbackArray<Action`2<TValue1, TValue2>>& callbacks, TValue1 argument1, TValue2 argument2, ProfilerMarker marker, string callbackName, object context = null) { }

	public static void InvokeCallbacksSafe_AndInvokeReturnedActions(ref CallbackArray<Func`2<TValue, Action>>& callbacks, TValue argument, string callbackName, object context = null) { }

	public static bool InvokeCallbacksSafe_AnyCallbackReturnsObject(ref CallbackArray<Func`2<TValue, TReturn>>& callbacks, TValue argument, string callbackName, object context = null) { }

	public static bool InvokeCallbacksSafe_AnyCallbackReturnsTrue(ref CallbackArray<Func`3<TValue1, TValue2, Boolean>>& callbacks, TValue1 argument1, TValue2 argument2, string callbackName, object context = null) { }

}

