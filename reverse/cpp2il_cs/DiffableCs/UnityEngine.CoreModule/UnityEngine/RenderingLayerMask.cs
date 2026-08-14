namespace UnityEngine;

[NativeClass("RenderingLayerMask", "struct RenderingLayerMask;")]
[NativeHeader("Runtime/BaseClasses/TagManager.h")]
[NativeHeader("Runtime/Graphics/RenderingLayerMask.h")]
[RequiredByNativeCode(Optional = True, GenerateProxy = True)]
public struct RenderingLayerMask
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static readonly RenderingLayerMask <defaultRenderingLayerMask>k__BackingField; //Field offset: 0x0
	internal const int maxRenderingLayerSize = 32; //Field offset: 0x0
	[NativeName("m_Bits")]
	private uint m_Bits; //Field offset: 0x0

	private static RenderingLayerMask() { }

	[StaticAccessor("GetTagManager()", StaticAccessorType::Dot (0))]
	public static String[] GetDefinedRenderingLayerNames() { }

	[StaticAccessor("GetTagManager()", StaticAccessorType::Dot (0))]
	public static uint GetDefinedRenderingLayersCombinedMaskValue() { }

	[StaticAccessor("GetTagManager()", StaticAccessorType::Dot (0))]
	public static int GetRenderingLayerCount() { }

	[NativeMethod("StringToRenderingLayer")]
	[StaticAccessor("GetTagManager()", StaticAccessorType::Dot (0))]
	public static int NameToRenderingLayer(string layerName) { }

	private static int NameToRenderingLayer_Injected(ref ManagedSpanWrapper layerName) { }

	public static uint op_Implicit(RenderingLayerMask mask) { }

}

