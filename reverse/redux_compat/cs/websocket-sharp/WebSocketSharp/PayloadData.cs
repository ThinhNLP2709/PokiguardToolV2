/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp
{
	internal class PayloadData : IEnumerable<byte> // TypeDefIndex: 13244
	{
		// Fields
		private byte[] _data; // 0x10
		private long _extDataLength; // 0x18
		private long _length; // 0x20
		public static readonly PayloadData Empty; // 0x00
		public static readonly ulong MaxLength; // 0x08
	
		// Properties
		internal ushort Code { get; } // 0x00000001825DE140-0x00000001825DE2B0 
		internal long ExtensionDataLength { get; set; } // 0x00000001825D8710-0x00000001825D8720 0x00000001804C2E30-0x00000001804C2E40
		internal bool HasReservedCode { get; } // 0x00000001825DE370-0x00000001825DE400 
		internal string Reason { get; } // 0x00000001825DE410-0x00000001825DE4D0 
		public byte[] ApplicationData { get; } // 0x00000001825DE090-0x00000001825DE140 
		public byte[] ExtensionData { get; } // 0x00000001825DE2B0-0x00000001825DE370 
		public ulong Length { get; } // 0x00000001825DE400-0x00000001825DE410 
	
		// Nested types
		[CompilerGenerated]
		private sealed class _GetEnumerator_d__25 : IEnumerator<byte> // TypeDefIndex: 13245
		{
			// Fields
			private int __1__state; // 0x10
			private byte __2__current; // 0x14
			public PayloadData __4__this; // 0x18
			private byte[] __s__1; // 0x20
			private int __s__2; // 0x28
			private byte _b_5__3; // 0x2C
	
			// Properties
			byte IEnumerator<System.Byte>.Current { [DebuggerHidden] get; } // 0x0000000181102980-0x0000000181102990 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001826004E0-0x0000000182600510 
	
			// Constructors
			[DebuggerHidden]
			public _GetEnumerator_d__25(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x00000001826003F0-0x00000001826004A0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001826004A0-0x00000001826004E0
		}
	
		// Constructors
		static PayloadData(); // 0x00000001825DDD50-0x00000001825DDE30
		internal PayloadData(byte[] data); // 0x00000001825DDE30-0x00000001825DDE80
		internal PayloadData(byte[] data, long length); // 0x00000001825DE040-0x00000001825DE090
		internal PayloadData(ushort code, string reason); // 0x00000001825DDE80-0x00000001825DE040
	
		// Methods
		internal void Mask(byte[] key); // 0x00000001825DDCB0-0x00000001825DDD40
		public IEnumerator<byte> GetEnumerator(); // 0x00000001825DDC40-0x00000001825DDCB0
		public byte[] ToArray(); // 0x00000001825D8700-0x00000001825D8710
		public override string ToString(); // 0x00000001825DDD40-0x00000001825DDD50
		IEnumerator IEnumerable.GetEnumerator(); // 0x00000001825DDC40-0x00000001825DDCB0
	}
}
