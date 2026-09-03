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
	[NativeClass("Texture2DArray", PersistentTypeId = 187)]
	[NativeHeader("Runtime/Graphics/Texture2DArray.h")]
	public sealed class Texture2DArray : Texture // TypeDefIndex: 7634
	{
		// Properties
		public static int allSlices { [NativeName("GetAllTextureLayersIdentifier")] get; } // 0x00000001821D6B80-0x00000001821D6BB0 
		public override bool isReadable { get; } // 0x00000001821D6BF0-0x00000001821D6C50 
	
		// Constructors
		[RequiredByNativeCode]
		public Texture2DArray(int width, int height, int depth, GraphicsFormat format, TextureCreationFlags flags); // 0x00000001821D64F0-0x00000001821D65C0
		[ExcludeFromDocs]
		public Texture2DArray(int width, int height, int depth, GraphicsFormat format, TextureCreationFlags flags, int mipCount, MipmapLimitDescriptor mipmapLimitDescriptor); // 0x00000001821D65C0-0x00000001821D6880
		public Texture2DArray(int width, int height, int depth, TextureFormat textureFormat, int mipCount, bool linear, bool createUninitialized, MipmapLimitDescriptor mipmapLimitDescriptor); // 0x00000001821D68E0-0x00000001821D6B80
		public Texture2DArray(int width, int height, int depth, TextureFormat textureFormat, int mipCount, bool linear); // 0x00000001821D6880-0x00000001821D68E0
		[ExcludeFromDocs]
		public Texture2DArray(int width, int height, int depth, TextureFormat textureFormat, bool mipChain); // 0x00000001821D6410-0x00000001821D64F0
	
		// Methods
		[FreeFunction("Texture2DArrayScripting::Create")]
		private static bool Internal_CreateImpl([Writable] Texture2DArray mono, int w, int h, int d, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, bool ignoreMipmapLimit, string mipmapLimitGroupName); // 0x00000001821D5F00-0x00000001821D60D0
		private static void Internal_Create([Writable] Texture2DArray mono, int w, int h, int d, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, bool ignoreMipmapLimit, string mipmapLimitGroupName); // 0x00000001821D60D0-0x00000001821D6190
		internal bool ValidateFormat(TextureFormat format, int width, int height); // 0x00000001821D62C0-0x00000001821D63B0
		internal bool ValidateFormat(GraphicsFormat format, int width, int height); // 0x00000001821D6190-0x00000001821D62C0
		private static void ValidateIsNotCrunched(TextureCreationFlags flags); // 0x00000001821D63B0-0x00000001821D6410
		private static new bool get_isReadable_Injected(IntPtr _unity_self); // 0x00000001821D6BB0-0x00000001821D6BF0
		private static bool Internal_CreateImpl_Injected([Writable] Texture2DArray mono, int w, int h, int d, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, bool ignoreMipmapLimit, ref ManagedSpanWrapper mipmapLimitGroupName); // 0x00000001821D5E80-0x00000001821D5F00
	}
}
