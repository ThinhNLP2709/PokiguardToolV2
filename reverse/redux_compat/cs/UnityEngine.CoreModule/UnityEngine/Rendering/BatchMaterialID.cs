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
	[NativeClass("BatchMaterialID")]
	[NativeHeader("Runtime/Camera/BatchRendererGroup.h")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	public struct BatchMaterialID : IEquatable<BatchMaterialID> // TypeDefIndex: 8340
	{
		// Fields
		public static readonly BatchMaterialID Null; // 0x00
		public uint value; // 0x00
	
		// Constructors
		static BatchMaterialID(); // 0x0000000182255500-0x0000000182255540
	
		// Methods
		public override int GetHashCode(); // 0x00000001814330E0-0x00000001814330F0
		public override bool Equals(object obj); // 0x0000000182255460-0x0000000182255500
		public bool Equals(BatchMaterialID other); // 0x00000001815FCAB0-0x00000001815FCAC0
		public static bool operator ==(BatchMaterialID a, BatchMaterialID b); // 0x0000000182255540-0x0000000182255590
	}
}
