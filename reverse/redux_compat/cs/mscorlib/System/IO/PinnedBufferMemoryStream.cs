/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	internal sealed class PinnedBufferMemoryStream : UnmanagedMemoryStream // TypeDefIndex: 3652
	{
		// Fields
		private byte[] _array; // 0x68
		private GCHandle _pinningHandle; // 0x70
	
		// Constructors
		internal PinnedBufferMemoryStream(byte[] array); // 0x00000001815B2740-0x00000001815B27F0
	
		// Methods
		public override int Read(Span<byte> buffer); // 0x00000001815B2700-0x00000001815B2720
		public override void Write(ReadOnlySpan<byte> buffer); // 0x00000001815B2720-0x00000001815B2740
		~PinnedBufferMemoryStream(); // 0x00000001815B2680-0x00000001815B2700
		protected override void Dispose(bool disposing); // 0x00000001815B2640-0x00000001815B2680
	}
}
