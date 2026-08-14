namespace UnityEngine.U2D.Animation;

[BurstCompile]
internal static class BurstedSpriteSkinUtilities
{
	public static class SetVertexPositionFromByteBuffer_000001A8$BurstDirectCall
	{
		private static IntPtr Pointer; //Field offset: 0x0

		private static IntPtr GetFunctionPointer() { }

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr unnamed_param_0) { }

		public static void Invoke(in NativeArray<Byte>& buffer, in NativeArray<Int32>& indices, ref NativeArray<Vector3>& vertices, int stride) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class SetVertexPositionFromByteBuffer_000001A8$PostfixBurstDelegate : MulticastDelegate
	{

		public SetVertexPositionFromByteBuffer_000001A8$PostfixBurstDelegate(object unnamed_param_0, IntPtr unnamed_param_1) { }

		public override IAsyncResult BeginInvoke(in NativeArray<Byte>& buffer, in NativeArray<Int32>& indices, ref NativeArray<Vector3>& vertices, int stride, AsyncCallback unnamed_param_4, object unnamed_param_5) { }

		public override void EndInvoke(IAsyncResult unnamed_param_0) { }

		public override void Invoke(in NativeArray<Byte>& buffer, in NativeArray<Int32>& indices, ref NativeArray<Vector3>& vertices, int stride) { }

	}

	public static class ValidateBoneWeights_000001A7$BurstDirectCall
	{
		private static IntPtr Pointer; //Field offset: 0x0

		private static IntPtr GetFunctionPointer() { }

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr unnamed_param_0) { }

		public static bool Invoke(in NativeCustomSlice<BoneWeight>& boneWeights, int bindPoseCount) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class ValidateBoneWeights_000001A7$PostfixBurstDelegate : MulticastDelegate
	{

		public ValidateBoneWeights_000001A7$PostfixBurstDelegate(object unnamed_param_0, IntPtr unnamed_param_1) { }

		public override IAsyncResult BeginInvoke(in NativeCustomSlice<BoneWeight>& boneWeights, int bindPoseCount, AsyncCallback unnamed_param_2, object unnamed_param_3) { }

		public override bool EndInvoke(IAsyncResult unnamed_param_0) { }

		public override bool Invoke(in NativeCustomSlice<BoneWeight>& boneWeights, int bindPoseCount) { }

	}


	[BurstCompile]
	[MonoPInvokeCallback(typeof(SetVertexPositionFromByteBuffer_000001A8$PostfixBurstDelegate))]
	internal static void SetVertexPositionFromByteBuffer(in NativeArray<Byte>& buffer, in NativeArray<Int32>& indices, ref NativeArray<Vector3>& vertices, int stride) { }

	[BurstCompile]
	public static void SetVertexPositionFromByteBuffer$BurstManaged(in NativeArray<Byte>& buffer, in NativeArray<Int32>& indices, ref NativeArray<Vector3>& vertices, int stride) { }

	[BurstCompile]
	[MonoPInvokeCallback(typeof(ValidateBoneWeights_000001A7$PostfixBurstDelegate))]
	internal static bool ValidateBoneWeights(in NativeCustomSlice<BoneWeight>& boneWeights, int bindPoseCount) { }

	[BurstCompile]
	public static bool ValidateBoneWeights$BurstManaged(in NativeCustomSlice<BoneWeight>& boneWeights, int bindPoseCount) { }

}

