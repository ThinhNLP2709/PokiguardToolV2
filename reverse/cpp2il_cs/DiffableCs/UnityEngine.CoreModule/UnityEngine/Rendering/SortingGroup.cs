namespace UnityEngine.Rendering;

[NativeType(Header = "Runtime/2D/Sorting/SortingGroup.h")]
[RequireComponent(typeof(Transform))]
public sealed class SortingGroup : Behaviour
{

	[StaticAccessor("SortingGroup", StaticAccessorType::DoubleColon (2))]
	internal static int invalidSortingGroupID
	{
		internal get { } //Length: 42
	}

	public int sortingLayerID
	{
		 get { } //Length: 119
	}

	public int sortingOrder
	{
		 get { } //Length: 119
	}

	internal static int get_invalidSortingGroupID() { }

	public int get_sortingLayerID() { }

	private static int get_sortingLayerID_Injected(IntPtr _unity_self) { }

	public int get_sortingOrder() { }

	private static int get_sortingOrder_Injected(IntPtr _unity_self) { }

	[StaticAccessor("SortingGroup", StaticAccessorType::DoubleColon (2))]
	internal static SortingGroup GetSortingGroupByIndex(int index) { }

	private static IntPtr GetSortingGroupByIndex_Injected(int index) { }

}

