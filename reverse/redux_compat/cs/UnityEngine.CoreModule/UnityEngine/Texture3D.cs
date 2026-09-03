/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Internal;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[ExcludeFromPreset]
	[NativeClass("Texture3D", PersistentTypeId = 117)]
	[NativeHeader("Runtime/Graphics/Texture3D.h")]
	public sealed class Texture3D : Texture // TypeDefIndex: 7633
	{
		// Properties
		public override bool isReadable { get; } // 0x00000001821DD3B0-0x00000001821DD410 
	
		// Constructors
		[ExcludeFromDocs]
		[RequiredByNativeCode]
		public Texture3D(int width, int height, int depth, GraphicsFormat format, TextureCreationFlags flags); // 0x00000001821DD120-0x00000001821DD370
		[ExcludeFromDocs]
		public Texture3D(int width, int height, int depth, GraphicsFormat format, TextureCreationFlags flags, [DefaultValue("Texture.GenerateAllMips")] int mipCount); // 0x00000001821DCF10-0x00000001821DD120
	
		// Methods
		[NativeName("SetPixel")]
		private void SetPixelImpl(int mip, int x, int y, int z, Color color); // 0x00000001821DCC20-0x00000001821DCCB0
		[FreeFunction("Texture3DScripting::Create")]
		private static bool Internal_CreateImpl([Writable] Texture3D mono, int w, int h, int d, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, IntPtr nativeTex); // 0x00000001821DCA70-0x00000001821DCAD0
		private static void Internal_Create([Writable] Texture3D mono, int w, int h, int d, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, IntPtr nativeTex); // 0x00000001821DCAD0-0x00000001821DCBC0
		[FreeFunction(Name = "Texture3DScripting::Apply", HasExplicitThis = true)]
		private void ApplyImpl(bool updateMipmaps, bool makeNoLongerReadable); // 0x00000001821DC900-0x00000001821DC970
		[FreeFunction(Name = "Texture3DScripting::SetPixels", HasExplicitThis = true, ThrowsException = true)]
		public void SetPixels(Color[] colors, int miplevel); // 0x00000001821DCDF0-0x00000001821DCEB0
		private IntPtr GetWritableImageData(int depthSlice = 0 /* Metadata: 0x0069D3EC */, int mipLevel = 0 /* Metadata: 0x0069D3ED */); // 0x00000001821DCA50-0x00000001821DCA70
		public void Apply([DefaultValue("true")] bool updateMipmaps, [DefaultValue("false")] bool makeNoLongerReadable); // 0x00000001821DC990-0x00000001821DCA50
		[ExcludeFromDocs]
		public void Apply(bool updateMipmaps); // 0x00000001821DC980-0x00000001821DC990
		[ExcludeFromDocs]
		public void Apply(); // 0x00000001821DC970-0x00000001821DC980
		public void SetPixel(int x, int y, int z, Color color, [DefaultValue("0")] int mipLevel); // 0x00000001821DCCB0-0x00000001821DCD90
		public NativeArray<T> GetPixelData<T>(int mipLevel)
			where T : struct;
		private static void ValidateIsNotCrunched(TextureCreationFlags flags); // 0x00000001821DCEB0-0x00000001821DCF10
		private static new bool get_isReadable_Injected(IntPtr _unity_self); // 0x00000001821DD370-0x00000001821DD3B0
		private static void SetPixelImpl_Injected(IntPtr _unity_self, int mip, int x, int y, int z, in Color color); // 0x00000001821DCBC0-0x00000001821DCC20
		private static void ApplyImpl_Injected(IntPtr _unity_self, bool updateMipmaps, bool makeNoLongerReadable); // 0x00000001821DC8A0-0x00000001821DC900
		private static void SetPixels_Injected(IntPtr _unity_self, ref ManagedSpanWrapper colors, int miplevel); // 0x00000001821DCD90-0x00000001821DCDF0
	}
}
