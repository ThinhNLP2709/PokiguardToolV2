/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct RenderTargetIdentifier : IEquatable<RenderTargetIdentifier> // TypeDefIndex: 8281
	{
		// Fields
		public static readonly RenderTargetIdentifier Invalid; // 0x00
		private BuiltinRenderTextureType m_Type; // 0x00
		private int m_NameID; // 0x04
		private EntityId m_EntityId; // 0x08
		private IntPtr m_BufferPointer; // 0x10
		private int m_MipLevel; // 0x18
		private CubemapFace m_CubeFace; // 0x1C
		private int m_DepthSlice; // 0x20
	
		// Constructors
		public RenderTargetIdentifier(BuiltinRenderTextureType type); // 0x000000018224FBB0-0x000000018224FBF0
		public RenderTargetIdentifier(int nameID); // 0x000000018224F9C0-0x000000018224FA00
		public RenderTargetIdentifier(int nameID, int mipLevel = 0 /* Metadata: 0x0069DA8B */, CubemapFace cubeFace = CubemapFace.Unknown /* Metadata: 0x0069DA8C */, int depthSlice = 0 /* Metadata: 0x0069DA8D */); // 0x000000018224FB50-0x000000018224FBB0
		public RenderTargetIdentifier(RenderTargetIdentifier renderTargetIdentifier, int mipLevel, CubemapFace cubeFace = CubemapFace.Unknown /* Metadata: 0x0069DA8E */, int depthSlice = 0 /* Metadata: 0x0069DA8F */); // 0x000000018224FB20-0x000000018224FB50
		public RenderTargetIdentifier(Texture tex); // 0x000000018224FBF0-0x000000018224FCF0
		public RenderTargetIdentifier(Texture tex, int mipLevel = 0 /* Metadata: 0x0069DA90 */, CubemapFace cubeFace = CubemapFace.Unknown /* Metadata: 0x0069DA91 */, int depthSlice = 0 /* Metadata: 0x0069DA92 */); // 0x000000018224FA00-0x000000018224FB20
	
		// Methods
		public static implicit operator RenderTargetIdentifier(BuiltinRenderTextureType type); // 0x000000018224FD30-0x000000018224FD90
		public static implicit operator RenderTargetIdentifier(int nameID); // 0x000000018224FD90-0x000000018224FDF0
		public static implicit operator RenderTargetIdentifier(Texture tex); // 0x000000018224FDF0-0x000000018224FE20
		public override string ToString(); // 0x000000018224F670-0x000000018224F9C0
		public override int GetHashCode(); // 0x000000018224F620-0x000000018224F670
		public bool Equals(RenderTargetIdentifier rhs); // 0x000000018224F560-0x000000018224F620
		public override bool Equals(object obj); // 0x000000018224F4B0-0x000000018224F560
		public static bool operator ==(RenderTargetIdentifier lhs, RenderTargetIdentifier rhs); // 0x000000018224FCF0-0x000000018224FD30
		public static bool operator !=(RenderTargetIdentifier lhs, RenderTargetIdentifier rhs); // 0x000000018224FE20-0x000000018224FE60
	}
}
