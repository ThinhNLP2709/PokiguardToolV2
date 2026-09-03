/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.LowLevel
{
	[MovedFrom("UnityEngine.Experimental.LowLevel")]
	[NativeHeader("Runtime/Misc/PlayerLoop.h")]
	[RequiredByNativeCode]
	internal struct PlayerLoopSystemInternal // TypeDefIndex: 8010
	{
		// Fields
		public Type type; // 0x00
		public PlayerLoopSystem.UpdateFunction updateDelegate; // 0x08
		public IntPtr updateFunction; // 0x10
		public IntPtr loopConditionFunction; // 0x18
		public int numSubSystems; // 0x20
	}
}
