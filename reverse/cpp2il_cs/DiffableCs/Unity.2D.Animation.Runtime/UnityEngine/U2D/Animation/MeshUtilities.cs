namespace UnityEngine.U2D.Animation;

[BurstCompile]
internal static class MeshUtilities
{
	public static class AddToEdgeMap_00000081$BurstDirectCall
	{
		private static IntPtr Pointer; //Field offset: 0x0

		private static IntPtr GetFunctionPointer() { }

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr unnamed_param_0) { }

		public static void Invoke(in int2 edge, ref UnsafeHashMap<Int32, int3>& edgeMap) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class AddToEdgeMap_00000081$PostfixBurstDelegate : MulticastDelegate
	{

		public AddToEdgeMap_00000081$PostfixBurstDelegate(object unnamed_param_0, IntPtr unnamed_param_1) { }

		public override IAsyncResult BeginInvoke(in int2 edge, ref UnsafeHashMap<Int32, int3>& edgeMap, AsyncCallback unnamed_param_2, object unnamed_param_3) { }

		public override void EndInvoke(IAsyncResult unnamed_param_0) { }

		public override void Invoke(in int2 edge, ref UnsafeHashMap<Int32, int3>& edgeMap) { }

	}

	public static class GetFirstUnusedIndex_00000083$BurstDirectCall
	{
		private static IntPtr Pointer; //Field offset: 0x0

		private static IntPtr GetFunctionPointer() { }

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr unnamed_param_0) { }

		public static int Invoke(in NativeArray<Boolean>& usedValues) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class GetFirstUnusedIndex_00000083$PostfixBurstDelegate : MulticastDelegate
	{

		public GetFirstUnusedIndex_00000083$PostfixBurstDelegate(object unnamed_param_0, IntPtr unnamed_param_1) { }

		public override IAsyncResult BeginInvoke(in NativeArray<Boolean>& usedValues, AsyncCallback unnamed_param_1, object unnamed_param_2) { }

		public override int EndInvoke(IAsyncResult unnamed_param_0) { }

		public override int Invoke(in NativeArray<Boolean>& usedValues) { }

	}

	public static class SortEdges_00000082$BurstDirectCall
	{
		private static IntPtr Pointer; //Field offset: 0x0

		private static IntPtr GetFunctionPointer() { }

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr unnamed_param_0) { }

		public static void Invoke(in NativeArray<int2>& unsortedEdges, out NativeArray<int2>& sortedEdges) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class SortEdges_00000082$PostfixBurstDelegate : MulticastDelegate
	{

		public SortEdges_00000082$PostfixBurstDelegate(object unnamed_param_0, IntPtr unnamed_param_1) { }

		public override IAsyncResult BeginInvoke(in NativeArray<int2>& unsortedEdges, out NativeArray<int2>& sortedEdges, AsyncCallback unnamed_param_2, object unnamed_param_3) { }

		public override void EndInvoke(IAsyncResult unnamed_param_0) { }

		public override void Invoke(in NativeArray<int2>& unsortedEdges, out NativeArray<int2>& sortedEdges) { }

	}


	[BurstCompile]
	[MonoPInvokeCallback(typeof(AddToEdgeMap_00000081$PostfixBurstDelegate))]
	private static void AddToEdgeMap(in int2 edge, ref UnsafeHashMap<Int32, int3>& edgeMap) { }

	[BurstCompile]
	public static void AddToEdgeMap$BurstManaged(in int2 edge, ref UnsafeHashMap<Int32, int3>& edgeMap) { }

	[BurstCompile]
	[MonoPInvokeCallback(typeof(GetFirstUnusedIndex_00000083$PostfixBurstDelegate))]
	private static int GetFirstUnusedIndex(in NativeArray<Boolean>& usedValues) { }

	[BurstCompile]
	public static int GetFirstUnusedIndex$BurstManaged(in NativeArray<Boolean>& usedValues) { }

	public static NativeArray<int2> GetOutlineEdges(in NativeArray<UInt16>& indices) { }

	[BurstCompile]
	[MonoPInvokeCallback(typeof(SortEdges_00000082$PostfixBurstDelegate))]
	private static void SortEdges(in NativeArray<int2>& unsortedEdges, out NativeArray<int2>& sortedEdges) { }

	[BurstCompile]
	public static void SortEdges$BurstManaged(in NativeArray<int2>& unsortedEdges, out NativeArray<int2>& sortedEdges) { }

}

