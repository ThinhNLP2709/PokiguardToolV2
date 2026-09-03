/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Internal;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[ExcludeFromPreset]
	[NativeClass("CubemapArray", PersistentTypeId = 188)]
	[NativeHeader("Runtime/Graphics/CubemapArrayTexture.h")]
	public sealed class CubemapArray : Texture // TypeDefIndex: 7635
	{
		// Properties
		public override bool isReadable { get; } // 0x00000001821C9160-0x00000001821C91C0 
	
		// Constructors
		[RequiredByNativeCode]
		public CubemapArray(int width, int cubemapCount, GraphicsFormat format, TextureCreationFlags flags); // 0x00000001821C8EF0-0x00000001821C9120
		[ExcludeFromDocs]
		public CubemapArray(int width, int cubemapCount, GraphicsFormat format, TextureCreationFlags flags, [DefaultValue("Texture.GenerateAllMips")] int mipCount); // 0x00000001821C8D00-0x00000001821C8EF0
	
		// Methods
		[FreeFunction("CubemapArrayScripting::Create")]
		private static bool Internal_CreateImpl([Writable] CubemapArray mono, int ext, int count, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags); // 0x00000001821C8940-0x00000001821C89A0
		private static void Internal_Create([Writable] CubemapArray mono, int ext, int count, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags); // 0x00000001821C89A0-0x00000001821C8A70
		[FreeFunction(Name = "CubemapArrayScripting::Apply", HasExplicitThis = true)]
		private void ApplyImpl(bool updateMipmaps, bool makeNoLongerReadable); // 0x00000001821C8770-0x00000001821C87E0
		[FreeFunction(Name = "CubemapArrayScripting::SetPixels", HasExplicitThis = true, ThrowsException = true)]
		public void SetPixels(Color[] colors, CubemapFace face, int arrayElement, int miplevel); // 0x00000001821C8AE0-0x00000001821C8BC0
		public void SetPixels(Color[] colors, CubemapFace face, int arrayElement); // 0x00000001821C8BC0-0x00000001821C8CA0
		public void Apply([DefaultValue("true")] bool updateMipmaps, [DefaultValue("false")] bool makeNoLongerReadable); // 0x00000001821C87E0-0x00000001821C88A0
		[ExcludeFromDocs]
		public void Apply(); // 0x00000001821C88A0-0x00000001821C8940
		private static void ValidateIsNotCrunched(TextureCreationFlags flags); // 0x00000001821C8CA0-0x00000001821C8D00
		private static new bool get_isReadable_Injected(IntPtr _unity_self); // 0x00000001821C9120-0x00000001821C9160
		private static void ApplyImpl_Injected(IntPtr _unity_self, bool updateMipmaps, bool makeNoLongerReadable); // 0x00000001821C8710-0x00000001821C8770
		private static void SetPixels_Injected(IntPtr _unity_self, ref ManagedSpanWrapper colors, CubemapFace face, int arrayElement, int miplevel); // 0x00000001821C8A70-0x00000001821C8AE0
	}
}
