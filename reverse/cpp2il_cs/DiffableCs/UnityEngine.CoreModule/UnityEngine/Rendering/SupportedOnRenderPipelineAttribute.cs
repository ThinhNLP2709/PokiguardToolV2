namespace UnityEngine.Rendering;

[AttributeUsage(AttributeTargets::Class (4), AllowMultiple = False)]
public class SupportedOnRenderPipelineAttribute : Attribute
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Type, String> <>9__6_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal Type[] <.cctor>b__12_0() { }

		internal string <.ctor>b__6_0(Type t) { }

	}

	internal enum SupportedMode
	{
		Unsupported = 0,
		Supported = 1,
		SupportedByBaseClass = 2,
	}

	private static readonly Lazy<Type[]> k_DefaultRenderPipelineAsset; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly Type[] <renderPipelineTypes>k__BackingField; //Field offset: 0x10

	public Type[] renderPipelineTypes
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	private static SupportedOnRenderPipelineAttribute() { }

	public SupportedOnRenderPipelineAttribute(Type renderPipeline) { }

	public SupportedOnRenderPipelineAttribute(Type[] renderPipeline) { }

	[CompilerGenerated]
	public Type[] get_renderPipelineTypes() { }

	public SupportedMode GetSupportedMode(Type renderPipelineAssetType) { }

	internal static SupportedMode GetSupportedMode(Type[] renderPipelineTypes, Type renderPipelineAssetType) { }

	public static bool IsTypeSupportedOnRenderPipeline(Type type, Type renderPipelineAssetType) { }

}

