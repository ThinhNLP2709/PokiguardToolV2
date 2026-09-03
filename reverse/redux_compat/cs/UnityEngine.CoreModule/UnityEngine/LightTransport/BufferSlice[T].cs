/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.LightTransport
{
	[DebuggerDisplay("BufferSlice(Id: {Id.Value}, Offset: {Offset})")]
	public struct BufferSlice<T> : IEquatable<UnityEngine.LightTransport.BufferSlice<T>> // TypeDefIndex: 8186
		where T : struct
	{
		// Fields
		public BufferID Id;
		public ulong Offset;
	
		// Constructors
		public BufferSlice(BufferID id, ulong offset);
	
		// Methods
		public override int GetHashCode();
		public bool Equals(BufferSlice<T> other);
		public override bool Equals(object obj);
	}
}
