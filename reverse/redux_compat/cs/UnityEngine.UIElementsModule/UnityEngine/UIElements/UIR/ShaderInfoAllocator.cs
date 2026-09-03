/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class ShaderInfoAllocator // TypeDefIndex: 5169
	{
		// Fields
		private BaseShaderInfoStorage m_Storage; // 0x10
		private BitmapAllocator32 m_TransformAllocator; // 0x18
		private BitmapAllocator32 m_ClipRectAllocator; // 0x38
		private BitmapAllocator32 m_OpacityAllocator; // 0x58
		private BitmapAllocator32 m_ColorAllocator; // 0x78
		private BitmapAllocator32 m_TextSettingsAllocator; // 0x98
		private bool m_StorageReallyCreated; // 0xB8
		private ColorSpace m_ColorSpace; // 0xBC
		private readonly Vector4[] m_XformPagePos; // 0xC0
		private readonly Vector4[] m_ClipPagePos; // 0xC8
		private readonly Vector4[] m_OpacityPagePos; // 0xD0
		private readonly Vector4[] m_ColorPagePos; // 0xD8
		private readonly Vector4[] m_TextCorePagePos; // 0xE0
		private bool m_TransformPagesErrored; // 0xE8
		private bool m_ClipRectPagesErrored; // 0xE9
		private bool m_OpacityPagesErrored; // 0xEA
		private bool m_ColorPagesErrored; // 0xEB
		private bool m_TextCorePagesErrored; // 0xEC
		private readonly Vector4[] m_ElementInfoPagePos; // 0xF0
		private int m_ElementInfoPageCount; // 0xF8
		private bool m_ElementInfoPagesErrored; // 0xFC
		private static readonly Vector2Int identityTransformTexel; // 0x00
		private static readonly Vector2Int infiniteClipRectTexel; // 0x08
		private static readonly Vector2Int fullOpacityTexel; // 0x10
		private static readonly Vector2Int clearColorTexel; // 0x18
		private static readonly Vector2Int defaultTextCoreSettingsTexel; // 0x20
		private static readonly Matrix4x4 identityTransformValue; // 0x28
		private static readonly Vector4 identityTransformRow0Value; // 0x68
		private static readonly Vector4 identityTransformRow1Value; // 0x78
		private static readonly Vector4 identityTransformRow2Value; // 0x88
		private static readonly Vector4 infiniteClipRectValue; // 0x98
		private static readonly Vector4 fullOpacityValue; // 0xA8
		private static readonly Vector4 clearColorValue; // 0xB8
		private static readonly TextCoreSettings defaultTextCoreSettingsValue; // 0xC8
		public static readonly BMPAlloc identityTransform; // 0x108
		public static readonly BMPAlloc infiniteClipRect; // 0x110
		public static readonly BMPAlloc fullOpacity; // 0x118
		public static readonly BMPAlloc clearColor; // 0x120
		public static readonly BMPAlloc defaultTextCoreSettings; // 0x128
		[NoAutoStaticsCleanup]
		private static int s_DefaultShaderInfoTextureRefCount; // 0x130
		[NoAutoStaticsCleanup]
		private static Texture2D s_DefaultShaderInfoTexture; // 0x138
	
		// Properties
		internal Vector4[] transformPagePositions { get; } // 0x00000001806CCB70-0x00000001806CCB80 
		internal Vector4[] clipRectPagePositions { get; } // 0x00000001806CCB50-0x00000001806CCB60 
		internal Vector4[] opacityPagePositions { get; } // 0x00000001806CCB60-0x00000001806CCB70 
		internal Vector4[] colorPagePositions { get; } // 0x00000001806CCBB0-0x00000001806CCBC0 
		internal Vector4[] textCorePagePositions { get; } // 0x00000001806CCB80-0x00000001806CCB90 
		internal Vector4[] elementInfoPagePositions { get; } // 0x0000000180CC3740-0x0000000180CC3750 
		private static int pageWidth { get; } // 0x0000000180A2FAE0-0x0000000180A2FAF0 
		private static int pageHeight { get; } // 0x0000000180740830-0x0000000180740840 
		public Texture atlas { get; } // 0x0000000182446380-0x0000000182446410 
	
		// Constructors
		public ShaderInfoAllocator(ColorSpace colorSpace); // 0x0000000182445ED0-0x0000000182446380
		static ShaderInfoAllocator(); // 0x0000000182445C20-0x0000000182445ED0
	
		// Methods
		private static void AcquireDefaultShaderInfoTexture(); // 0x00000001824431C0-0x0000000182443690
		private static void ReleaseDefaultShaderInfoTexture(); // 0x0000000182444F20-0x0000000182445010
		private static Vector2Int AllocToTexelCoord(ref BitmapAllocator32 allocator, BMPAlloc alloc); // 0x0000000182443850-0x00000001824438B0
		private static bool AtlasRectMatchesPage(ref BitmapAllocator32 allocator, BMPAlloc defAlloc, RectInt atlasRect); // 0x0000000182443CA0-0x0000000182443DA0
		private BMPAlloc AllocateAndRecordPage(ref BitmapAllocator32 allocator, Vector4[] pageTable, ref bool errored, string allocName); // 0x0000000182443920-0x0000000182443CA0
		private void ReallyCreateStorage(); // 0x0000000182444590-0x0000000182444F20
		public void Dispose(); // 0x0000000182443E50-0x0000000182443FE0
		public void IssuePendingStorageChanges(); // 0x0000000182444570-0x0000000182444590
		public BMPAlloc AllocTransform(); // 0x00000001824438B0-0x0000000182443920
		public BMPAlloc AllocClipRect(); // 0x0000000182443690-0x0000000182443700
		public BMPAlloc AllocOpacity(); // 0x0000000182443770-0x00000001824437E0
		public BMPAlloc AllocColor(); // 0x0000000182443700-0x0000000182443770
		public BMPAlloc AllocTextCoreSettings(TextCoreSettings settings); // 0x00000001824437E0-0x0000000182443850
		public void SetTransformValue(BMPAlloc alloc, Matrix4x4 xform); // 0x00000001824458C0-0x0000000182445B00
		public void SetClipRectValue(BMPAlloc alloc, Vector4 clipRect); // 0x0000000182445010-0x0000000182445190
		public void SetOpacityValue(BMPAlloc alloc, float opacity); // 0x0000000182445350-0x00000001824454D0
		public void SetColorValue(BMPAlloc alloc, Color color); // 0x0000000182445190-0x00000001824452E0
		public void SetTextCoreSettingValue(BMPAlloc alloc, TextCoreSettings settings); // 0x00000001824454D0-0x00000001824458C0
		private void EnsureElementInfoPage(int page); // 0x0000000182443FE0-0x0000000182444250
		private void WriteElementInfoTexel(ushort elementId, ushort transformId, ushort opacityId, float tx, float ty); // 0x0000000182445B00-0x0000000182445C20
		public void SetElementInfoValue(ushort elementId, ushort transformId, ushort opacityId, float tx, float ty); // 0x00000001824452E0-0x0000000182445350
		public void FreeTransform(BMPAlloc alloc); // 0x00000001824444D0-0x0000000182444570
		public void FreeClipRect(BMPAlloc alloc); // 0x0000000182444250-0x00000001824442F0
		public void FreeOpacity(BMPAlloc alloc); // 0x0000000182444390-0x0000000182444430
		public void FreeColor(BMPAlloc alloc); // 0x00000001824442F0-0x0000000182444390
		public void FreeTextCoreSettings(BMPAlloc alloc); // 0x0000000182444430-0x00000001824444D0
		public static ushort BMPAllocToId(BMPAlloc alloc); // 0x0000000182443DA0-0x0000000182443E50
	}
}
