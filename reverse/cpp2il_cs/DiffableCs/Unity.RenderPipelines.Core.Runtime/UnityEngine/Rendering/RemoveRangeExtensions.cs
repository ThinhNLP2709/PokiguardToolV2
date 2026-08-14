namespace UnityEngine.Rendering;

[Extension]
public static class RemoveRangeExtensions
{

	[CollectionAccess(CollectionAccessType::ModifyExistingContent (2))]
	[Extension]
	[MustUseReturnValue]
	public static bool TryRemoveElementsInRange(IList<TValue> list, int index, int count, out Exception error) { }

}

