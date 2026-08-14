namespace Mono.Util;

[AttributeUsage(AttributeTargets::Method (64))]
[Conditional("UNITY")]
[Conditional("FULL_AOT_RUNTIME")]
[Conditional("MONOTOUCH")]
internal sealed class MonoPInvokeCallbackAttribute : Attribute
{

	public MonoPInvokeCallbackAttribute(Type t) { }

}

