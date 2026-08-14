namespace UnityEngine.Rendering;

[Obsolete("BatchRendererGroupGlobals and associated cbuffer are now set automatically by Unity. Setting it manually is no longer necessary or supported.")]
public struct BatchRendererGroupGlobals : IEquatable<BatchRendererGroupGlobals>
{
	public const string kGlobalsPropertyName = "unity_DOTSInstanceGlobalValues"; //Field offset: 0x0
	public static readonly int kGlobalsPropertyId; //Field offset: 0x0
	public Vector4 ProbesOcclusion; //Field offset: 0x0
	public Vector4 SpecCube0_HDR; //Field offset: 0x10
	public Vector4 SpecCube1_HDR; //Field offset: 0x20
	public SHCoefficients SHCoefficients; //Field offset: 0x30

	public static BatchRendererGroupGlobals Default
	{
		 get { } //Length: 505
	}

	private static BatchRendererGroupGlobals() { }

	public override bool Equals(BatchRendererGroupGlobals other) { }

	public virtual bool Equals(object obj) { }

	public static BatchRendererGroupGlobals get_Default() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(BatchRendererGroupGlobals left, BatchRendererGroupGlobals right) { }

	public static bool op_Inequality(BatchRendererGroupGlobals left, BatchRendererGroupGlobals right) { }

}

