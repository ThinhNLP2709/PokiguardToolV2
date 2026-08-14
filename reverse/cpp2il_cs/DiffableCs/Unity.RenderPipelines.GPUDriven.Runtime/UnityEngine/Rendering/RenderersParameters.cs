namespace UnityEngine.Rendering;

internal struct RenderersParameters
{
	[Flags]
	internal enum Flags
	{
		None = 0,
		UseBoundingSphereParameter = 1,
	}

	internal struct ParamInfo
	{
		public int index; //Field offset: 0x0
		public int gpuAddress; //Field offset: 0x4
		public int uintOffset; //Field offset: 0x8

		public bool valid
		{
			 get { } //Length: 7
		}

		public bool get_valid() { }

	}

	internal static class ParamNames
	{
		public static readonly int _BaseColor; //Field offset: 0x0
		public static readonly int unity_SpecCube0_HDR; //Field offset: 0x4
		public static readonly int unity_SHCoefficients; //Field offset: 0x8
		public static readonly int unity_LightmapST; //Field offset: 0xC
		public static readonly int unity_ObjectToWorld; //Field offset: 0x10
		public static readonly int unity_WorldToObject; //Field offset: 0x14
		public static readonly int unity_MatrixPreviousM; //Field offset: 0x18
		public static readonly int unity_MatrixPreviousMI; //Field offset: 0x1C
		public static readonly int unity_WorldBoundingSphere; //Field offset: 0x20
		public static readonly Int32[] DOTS_ST_WindParams; //Field offset: 0x28
		public static readonly Int32[] DOTS_ST_WindHistoryParams; //Field offset: 0x30

		private static ParamNames() { }

	}

	private static int s_uintSize; //Field offset: 0x0
	public ParamInfo lightmapScale; //Field offset: 0x0
	public ParamInfo localToWorld; //Field offset: 0xC
	public ParamInfo worldToLocal; //Field offset: 0x18
	public ParamInfo matrixPreviousM; //Field offset: 0x24
	public ParamInfo matrixPreviousMI; //Field offset: 0x30
	public ParamInfo shCoefficients; //Field offset: 0x3C
	public ParamInfo boundingSphere; //Field offset: 0x48
	public ParamInfo[] windParams; //Field offset: 0x58
	public ParamInfo[] windHistoryParams; //Field offset: 0x60

	private static RenderersParameters() { }

	public RenderersParameters(in GPUInstanceDataBuffer instanceDataBuffer) { }

	[CompilerGenerated]
	internal static ParamInfo <.ctor>g__GetParamInfo|14_0(in GPUInstanceDataBuffer instanceDataBuffer, int paramNameIdx, bool assertOnFail = true) { }

	public static GPUInstanceDataBuffer CreateInstanceDataBuffer(Flags flags, in InstanceNumInfo instanceNumInfo) { }

}

