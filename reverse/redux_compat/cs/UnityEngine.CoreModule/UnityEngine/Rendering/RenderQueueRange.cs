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
	public struct RenderQueueRange : IEquatable<UnityEngine.Rendering.RenderQueueRange> // TypeDefIndex: 8429
	{
		// Fields
		private int m_LowerBound; // 0x00
		private int m_UpperBound; // 0x04
		public static readonly int minimumBound; // 0x00
		public static readonly int maximumBound; // 0x04
	
		// Properties
		public static RenderQueueRange all { get; } // 0x0000000182262D20-0x0000000182262D40 
		public static RenderQueueRange opaque { get; } // 0x0000000182262D40-0x0000000182262D60 
		public static RenderQueueRange transparent { get; } // 0x0000000182262D60-0x0000000182262D80 
		public int lowerBound { get; } // 0x0000000180732D10-0x0000000180732D20 
		public int upperBound { get; } // 0x00000001802E7C60-0x00000001802E7DA0 
	
		// Constructors
		static RenderQueueRange(); // 0x0000000182262CD0-0x0000000182262D20
	
		// Methods
		public bool Equals(RenderQueueRange other); // 0x000000018219A7A0-0x000000018219A7C0
		public override bool Equals(object obj); // 0x0000000182262C30-0x0000000182262CD0
		public override int GetHashCode(); // 0x0000000180DF8AA0-0x0000000180DF8AB0
		public static bool operator ==(RenderQueueRange left, RenderQueueRange right); // 0x0000000182262D80-0x0000000182262E00
	}
}
