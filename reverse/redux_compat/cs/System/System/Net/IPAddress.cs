/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	[Serializable]
	public class IPAddress // TypeDefIndex: 9003
	{
		// Fields
		public static readonly IPAddress Any; // 0x00
		public static readonly IPAddress Loopback; // 0x08
		public static readonly IPAddress Broadcast; // 0x10
		public static readonly IPAddress None; // 0x18
		internal const long LoopbackMask = 255; // Metadata: 0x0069E219
		public static readonly IPAddress IPv6Any; // 0x20
		public static readonly IPAddress IPv6Loopback; // 0x28
		public static readonly IPAddress IPv6None; // 0x30
		private uint _addressOrScopeId; // 0x10
		private readonly ushort[] _numbers; // 0x18
		private string _toString; // 0x20
		private int _hashCode; // 0x28
		internal const int NumberOfLabels = 8; // Metadata: 0x0069E221
	
		// Properties
		private bool IsIPv4 { get; } // 0x000000018144A260-0x000000018144A270 
		private bool IsIPv6 { get; } // 0x0000000180DAB6D0-0x0000000180DAB6E0 
		private uint PrivateAddress { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x0000000181BF2620-0x0000000181BF2660
		private uint PrivateScopeId { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x0000000181BF2620-0x0000000181BF2660
		public AddressFamily AddressFamily { get; } // 0x0000000181BF25A0-0x0000000181BF25C0 
		public long ScopeId { get; } // 0x0000000181BF25C0-0x0000000181BF2620 
	
		// Nested types
		private sealed class ReadOnlyIPAddress : IPAddress // TypeDefIndex: 9004
		{
			// Constructors
			public ReadOnlyIPAddress(long newAddress); // 0x0000000181BF3C50-0x0000000181BF3CB0
		}
	
		// Constructors
		public IPAddress(long newAddress); // 0x0000000181BF2320-0x0000000181BF23C0
		public IPAddress(byte[] address, long scopeid); // 0x0000000181BF21B0-0x0000000181BF2250
		public IPAddress(ReadOnlySpan<byte> address, long scopeid); // 0x0000000181BF23C0-0x0000000181BF25A0
		internal unsafe IPAddress(ushort* numbers, int numbersLength, uint scopeid); // 0x0000000181BF2250-0x0000000181BF2320
		private IPAddress(ushort[] numbers, uint scopeid); // 0x0000000181BF2150-0x0000000181BF21B0
		static IPAddress(); // 0x0000000181BF1D30-0x0000000181BF2150
	
		// Methods
		public static bool TryParse(string ipString, out IPAddress address); // 0x0000000181BF1BB0-0x0000000181BF1C40
		public static IPAddress Parse(string ipString); // 0x0000000181BF1A60-0x0000000181BF1B00
		public bool TryWriteBytes(Span<byte> destination, out int bytesWritten); // 0x0000000181BF1C40-0x0000000181BF1CE0
		private void WriteIPv6Bytes(Span<byte> destination); // 0x0000000181BDE730-0x0000000181BDE7E0
		private void WriteIPv4Bytes(Span<byte> destination); // 0x0000000181BF1CE0-0x0000000181BF1D30
		public byte[] GetAddressBytes(); // 0x0000000181BF13E0-0x0000000181BF14D0
		public override string ToString(); // 0x0000000181BF1B50-0x0000000181BF1BB0
		public static bool IsLoopback(IPAddress address); // 0x0000000181BF1870-0x0000000181BF1950
		internal bool Equals(object comparandObj, bool compareScopeId); // 0x0000000181BF12A0-0x0000000181BF13E0
		public override bool Equals(object comparand); // 0x0000000181BF1290-0x0000000181BF12A0
		public override int GetHashCode(); // 0x0000000181BF14D0-0x0000000181BF1870
		public IPAddress MapToIPv6(); // 0x0000000181BF1950-0x0000000181BF1A60
		private static byte[] ThrowAddressNullException(); // 0x0000000181BF1B00-0x0000000181BF1B50
	}
}
