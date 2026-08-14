namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

[Extension]
internal static class NativeListExtensions
{

	[Extension]
	internal static int LastIndex(ref NativeList<T>& list) { }

	[Extension]
	internal static ReadOnlySpan<T> MakeReadOnlySpan(ref NativeList<T>& list, int first, int numElements) { }

}

