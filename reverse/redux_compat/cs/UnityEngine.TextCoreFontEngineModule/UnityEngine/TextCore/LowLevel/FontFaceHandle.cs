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

// Image 50: UnityEngine.TextCoreFontEngineModule.dll - Assembly: UnityEngine.TextCoreFontEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15505-15532

namespace UnityEngine.TextCore.LowLevel
{
	[UsedByNativeCode]
	[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
	internal struct FontFaceHandle : IEquatable<UnityEngine.TextCore.LowLevel.FontFaceHandle> // TypeDefIndex: 15522
	{
		// Fields
		internal long fontInstanceID; // 0x00
		internal int faceIndex; // 0x08
		internal int pointSize; // 0x0C
	
		// Methods
		public bool Equals(FontFaceHandle other); // 0x0000000180BE3530-0x0000000180BE3550
		public override bool Equals(object obj); // 0x00000001822F36C0-0x00000001822F3760
		public override int GetHashCode(); // 0x00000001822F3760-0x00000001822F3790
	}
}
