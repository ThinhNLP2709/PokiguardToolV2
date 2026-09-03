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

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[NativeClass("BatchID")]
	[NativeHeader("Runtime/Camera/BatchRendererGroup.h")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	public struct BatchID : IEquatable<BatchID> // TypeDefIndex: 8339
	{
		// Fields
		public static readonly BatchID Null; // 0x00
		public uint value; // 0x00
	
		// Constructors
		static BatchID(); // 0x00000001822553D0-0x0000000182255410
	
		// Methods
		public override int GetHashCode(); // 0x00000001814330E0-0x00000001814330F0
		public override bool Equals(object obj); // 0x0000000182255330-0x00000001822553D0
		public bool Equals(BatchID other); // 0x00000001815FCAB0-0x00000001815FCAC0
		public static bool operator ==(BatchID a, BatchID b); // 0x0000000182255410-0x0000000182255460
	}
}
