/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	[NativeClass("TransformHandle")]
	[UsedByNativeCode]
	public struct TransformHandle : IEquatable<UnityEngine.TransformHandle>, IComparable<UnityEngine.TransformHandle> // TypeDefIndex: 7857
	{
		// Fields
		internal IntPtr pTransformData; // 0x00
		[SerializeField]
		internal EntityId id; // 0x08
	
		// Methods
		public override bool Equals(object obj); // 0x0000000182220700-0x0000000182220790
		public bool Equals(TransformHandle other); // 0x00000001822206F0-0x0000000182220700
		public int CompareTo(TransformHandle other); // 0x00000001822206E0-0x00000001822206F0
		public override int GetHashCode(); // 0x0000000182220790-0x00000001822207A0
	}
}
