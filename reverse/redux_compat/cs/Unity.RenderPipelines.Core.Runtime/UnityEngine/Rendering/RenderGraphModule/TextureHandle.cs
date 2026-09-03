/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[DebuggerDisplay("Texture ({handle.index})")]
	[IsReadOnly]
	[MovedFrom(true, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
	public struct TextureHandle : IEquatable<TextureHandle> // TypeDefIndex: 5963
	{
		// Fields
		private static readonly TextureHandle s_NullHandle; // 0x00
		internal readonly ResourceHandle handle; // 0x00
		private readonly bool builtin; // 0x0C
	
		// Properties
		public static TextureHandle nullHandle { get; } // 0x0000000181EEFAA0-0x0000000181EEFB00 
	
		// Constructors
		internal TextureHandle([IsReadOnly] in ResourceHandle h); // 0x0000000181EEF9F0-0x0000000181EEFA10
		internal TextureHandle(int handle, bool shared = false /* Metadata: 0x00662C3C */, bool builtin = false /* Metadata: 0x00662C3D */); // 0x0000000181EEFA10-0x0000000181EEFAA0
		static TextureHandle(); // 0x00000001802E76C0-0x00000001802E76D0
	
		// Methods
		public static implicit operator RenderTargetIdentifier(TextureHandle texture); // 0x0000000181EEFEC0-0x0000000181EF0000
		public static implicit operator Texture(TextureHandle texture); // 0x0000000181EEFDC0-0x0000000181EEFEC0
		public static implicit operator RenderTexture(TextureHandle texture); // 0x0000000181EEFBE0-0x0000000181EEFCE0
		public static implicit operator RTHandle(TextureHandle texture); // 0x0000000181EEFCE0-0x0000000181EEFDC0
		public bool Equals(TextureHandle other); // 0x0000000181EEF6B0-0x0000000181EEF790
		public override bool Equals(object obj); // 0x0000000181EEF790-0x0000000181EEF840
		public override int GetHashCode(); // 0x0000000181EEF8C0-0x0000000181EEF940
		public static bool operator ==(TextureHandle lhs, TextureHandle rhs); // 0x0000000181EEFB00-0x0000000181EEFBE0
		public static bool operator !=(TextureHandle lhs, TextureHandle rhs); // 0x0000000181EF0000-0x0000000181EF00E0
		public bool IsValid(); // 0x0000000181EEF940-0x0000000181EEF9F0
		internal bool IsBuiltin(); // 0x0000000181D11B10-0x0000000181D11B20
		public TextureDesc GetDescriptor(RenderGraph renderGraph); // 0x0000000181EEF840-0x0000000181EEF8C0
	}
}
