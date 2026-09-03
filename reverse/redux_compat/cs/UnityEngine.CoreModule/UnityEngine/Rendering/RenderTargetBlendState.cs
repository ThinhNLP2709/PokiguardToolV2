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
	public struct RenderTargetBlendState : IEquatable<UnityEngine.Rendering.RenderTargetBlendState> // TypeDefIndex: 8432
	{
		// Fields
		private byte m_WriteMask; // 0x00
		private byte m_SourceColorBlendMode; // 0x01
		private byte m_DestinationColorBlendMode; // 0x02
		private byte m_SourceAlphaBlendMode; // 0x03
		private byte m_DestinationAlphaBlendMode; // 0x04
		private byte m_ColorBlendOperation; // 0x05
		private byte m_AlphaBlendOperation; // 0x06
		private byte m_Padding; // 0x07
	
		// Properties
		public static RenderTargetBlendState defaultValue { get; } // 0x00000001822636C0-0x00000001822636D0 
	
		// Constructors
		public RenderTargetBlendState(ColorWriteMask writeMask = ColorWriteMask.Alpha | ColorWriteMask.Blue | ColorWriteMask.Green | ColorWriteMask.Red | ColorWriteMask.All /* Metadata: 0x0069DBC0 */, BlendMode sourceColorBlendMode = BlendMode.One /* Metadata: 0x0069DBC1 */, BlendMode destinationColorBlendMode = BlendMode.Zero /* Metadata: 0x0069DBC2 */, BlendMode sourceAlphaBlendMode = BlendMode.One /* Metadata: 0x0069DBC3 */, BlendMode destinationAlphaBlendMode = BlendMode.Zero /* Metadata: 0x0069DBC4 */, BlendOp colorBlendOperation = BlendOp.Add /* Metadata: 0x0069DBC5 */, BlendOp alphaBlendOperation = BlendOp.Add /* Metadata: 0x0069DBC6 */); // 0x0000000182263690-0x00000001822636C0
	
		// Methods
		public bool Equals(RenderTargetBlendState other); // 0x00000001822634A0-0x00000001822634F0
		public override bool Equals(object obj); // 0x00000001822634F0-0x00000001822635C0
		public override int GetHashCode(); // 0x00000001822635C0-0x0000000182263690
	}
}
