/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.LowLevel
{
	[MovedFrom("UnityEngine.Experimental.LowLevel")]
	public struct PlayerLoopSystem // TypeDefIndex: 8011
	{
		// Fields
		public Type type; // 0x00
		public PlayerLoopSystem[] subSystemList; // 0x08
		public UpdateFunction updateDelegate; // 0x10
		public IntPtr updateFunction; // 0x18
		public IntPtr loopConditionFunction; // 0x20
	
		// Nested types
		public delegate void UpdateFunction(); // TypeDefIndex: 8012; 0x0000000180313920-0x00000001803139C0
	
		// Methods
		public override string ToString(); // 0x000000018224D970-0x000000018224D9A0
	}
}
