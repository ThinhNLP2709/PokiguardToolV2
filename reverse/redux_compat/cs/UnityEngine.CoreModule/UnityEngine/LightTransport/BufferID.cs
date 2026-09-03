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
	[DebuggerDisplay("BufferID({Value})")]
	public struct BufferID : IEquatable<UnityEngine.LightTransport.BufferID> // TypeDefIndex: 8185
	{
		// Fields
		public ulong Value; // 0x00
	
		// Constructors
		public BufferID(ulong value); // 0x0000000180CBE820-0x0000000180CBE830
	
		// Methods
		public BufferSlice<T> Slice<T>(ulong offset = 0 /* Metadata: 0x0069D849 */)
			where T : struct;
		public override int GetHashCode(); // 0x000000018126B220-0x000000018126B230
		public bool Equals(BufferID other); // 0x000000018222B040-0x000000018222B050
		public override bool Equals(object obj); // 0x000000018222AFC0-0x000000018222B040
		public static bool operator ==(BufferID a, BufferID b); // 0x000000018163DD90-0x000000018163DDA0
	}
}
