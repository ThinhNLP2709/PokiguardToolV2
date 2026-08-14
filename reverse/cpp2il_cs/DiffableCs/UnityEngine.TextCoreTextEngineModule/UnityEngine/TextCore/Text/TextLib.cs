namespace UnityEngine.TextCore.Text;

[NativeHeader("Modules/TextCoreTextEngine/Native/TextLib.h")]
[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule", "Unity.UIElements.PlayModeTests"})]
internal class TextLib
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(TextLib textLib) { }

	}

	private static Byte[] s_ICUData; //Field offset: 0x0
	private readonly IntPtr m_Ptr; //Field offset: 0x10

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal TextLib() { }

	[NativeMethod(Name = "TextLib::FindIntersectingLink")]
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static int FindIntersectingLink(Vector2 point, IntPtr textGenerationInfo) { }

	private static int FindIntersectingLink_Injected(in Vector2 point, IntPtr textGenerationInfo) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal NativeTextInfo GenerateText(NativeTextGenerationSettings settings, IntPtr textGenerationInfo) { }

	[NativeMethod(Name = "TextLib::GenerateTextMesh")]
	private NativeTextInfo GenerateTextInternal(NativeTextGenerationSettings settings, IntPtr textGenerationInfo) { }

	private static void GenerateTextInternal_Injected(IntPtr _unity_self, in NativeTextGenerationSettings settings, IntPtr textGenerationInfo, out NativeTextInfo ret) { }

	private static TextAsset GetICUAsset() { }

	[RequiredByNativeCode]
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"Unity.UIElements.PlayModeTests"})]
	internal static bool GetICUdata(Span<Byte> data, int maxSize) { }

	private static IntPtr GetInstance() { }

	[RequiredByNativeCode]
	internal static int LoadAndCountICUdata() { }

	[NativeMethod(Name = "TextLib::MeasureText")]
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal Vector2 MeasureText(NativeTextGenerationSettings settings, IntPtr textGenerationInfo) { }

	private static void MeasureText_Injected(IntPtr _unity_self, in NativeTextGenerationSettings settings, IntPtr textGenerationInfo, out Vector2 ret) { }

}

