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
	public struct DepthState : IEquatable<UnityEngine.Rendering.DepthState> // TypeDefIndex: 8408
	{
		// Fields
		private byte m_WriteEnabled; // 0x00
		private sbyte m_CompareFunction; // 0x01
	
		// Properties
		public static DepthState defaultValue { get; } // 0x0000000182259A40-0x0000000182259AA0 
	
		// Constructors
		public DepthState(bool writeEnabled = true /* Metadata: 0x0069DB93 */, CompareFunction compareFunction = CompareFunction.Less /* Metadata: 0x0069DB94 */); // 0x00000001822599D0-0x0000000182259A40
	
		// Methods
		public bool Equals(DepthState other); // 0x0000000182259970-0x0000000182259990
		public override bool Equals(object obj); // 0x00000001822598E0-0x0000000182259970
		public override int GetHashCode(); // 0x0000000182259990-0x00000001822599D0
	}
}
