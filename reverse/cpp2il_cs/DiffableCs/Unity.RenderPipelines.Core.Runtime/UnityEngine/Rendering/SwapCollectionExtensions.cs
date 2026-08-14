namespace UnityEngine.Rendering;

[Extension]
public static class SwapCollectionExtensions
{

	[CollectionAccess(CollectionAccessType::ModifyExistingContent (2))]
	[Extension]
	[MustUseReturnValue]
	public static bool TrySwap(IList<TValue> list, int from, int to, out Exception error) { }

}

