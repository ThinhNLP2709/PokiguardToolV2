/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.TextCore;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[NativeHeader("Modules/TextCoreTextEngine/Native/TextLib.h")]
	[VisibleToOtherModules(new string[3] {"UnityEngine.UIElementsModule", "Unity.UIElements.PlayModeTests", "UnityEngine.IMGUIModule" })]
	internal class TextLib // TypeDefIndex: 12702
	{
		// Fields
		private readonly IntPtr m_Ptr; // 0x10
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 12703
		{
			// Methods
			public static IntPtr ConvertToNative(TextLib textLib); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public TextLib(byte[] icuData); // 0x0000000182347910-0x00000001823479B0
	
		// Methods
		private static IntPtr GetInstance(byte[] icuData); // 0x0000000182346990-0x0000000182346A10
		public NativeTextInfo GenerateText(NativeTextGenerationSettings settings, IntPtr textGenerationInfo, ref bool wasCached); // 0x0000000182346760-0x0000000182346910
		public bool HasMissingGlyphs(NativeTextInfo textInfo, ref Dictionary<EntityId, HashSet<uint>> missingGlyphsPerFontAsset); // 0x0000000182346A10-0x0000000182346DE0
		public void ProcessMeshInfos(NativeTextInfo textInfo, NativeTextGenerationSettings settings, ref List<List<List<int>>> textElementIndicesByMesh, bool uvsAreGenerated); // 0x0000000182346ED0-0x0000000182347840
		[NativeMethod(IsThreadSafe = true)]
		public void ShapeText(NativeTextGenerationSettings settings, IntPtr textGenerationInfo); // 0x00000001823478A0-0x0000000182347910
		[NativeMethod(Name = "TextLib::GenerateTextMesh", IsThreadSafe = true)]
		private NativeTextInfo GenerateTextInternal(NativeTextGenerationSettings settings, IntPtr textGenerationInfo, ref bool uvsAreGenerated); // 0x00000001823466C0-0x0000000182346760
		[NativeMethod(Name = "TextLib::MeasureText")]
		public Vector2 MeasureText(NativeTextGenerationSettings settings, IntPtr textGenerationInfo); // 0x0000000182346E50-0x0000000182346ED0
		[NativeMethod(Name = "TextLib::FindIntersectingLink")]
		public static int FindIntersectingLink(Vector2 point, IntPtr textGenerationInfo); // 0x0000000182346610-0x0000000182346650
		[NativeMethod(Name = "TextLib::GetCharacterCount")]
		public static int GetCharacterCount(IntPtr textGenerationInfo); // 0x0000000182346910-0x0000000182346950
		private static IntPtr GetInstance_Injected(ref ManagedSpanWrapper icuData); // 0x0000000182346950-0x0000000182346990
		private static void ShapeText_Injected(IntPtr _unity_self, in NativeTextGenerationSettings settings, IntPtr textGenerationInfo); // 0x0000000182347840-0x00000001823478A0
		private static void GenerateTextInternal_Injected(IntPtr _unity_self, in NativeTextGenerationSettings settings, IntPtr textGenerationInfo, ref bool uvsAreGenerated, ); // 0x0000000182346650-0x00000001823466C0
		private static void MeasureText_Injected(IntPtr _unity_self, in NativeTextGenerationSettings settings, IntPtr textGenerationInfo, ); // 0x0000000182346DE0-0x0000000182346E50
		private static int FindIntersectingLink_Injected(in Vector2 point, IntPtr textGenerationInfo); // 0x00000001823465C0-0x0000000182346610
	}
}
