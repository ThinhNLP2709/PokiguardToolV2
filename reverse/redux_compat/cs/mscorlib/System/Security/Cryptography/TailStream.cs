/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Cryptography
{
	internal sealed class TailStream : Stream // TypeDefIndex: 2805
	{
		// Fields
		private byte[] _Buffer; // 0x28
		private int _BufferSize; // 0x30
		private int _BufferIndex; // 0x34
		private bool _BufferFull; // 0x38
	
		// Properties
		public byte[] Buffer { get; } // 0x000000018149ADC0-0x000000018149AE40 
		public override bool CanRead { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override bool CanSeek { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override bool CanWrite { get; } // 0x000000018149AE40-0x000000018149AE50 
		public override long Length { get; } // 0x000000018149AE50-0x000000018149AEB0 
		public override long Position { get; set; } // 0x000000018149AEB0-0x000000018149AF10 0x000000018149AF10-0x000000018149AF70
	
		// Constructors
		public TailStream(int bufferSize); // 0x000000018149AD40-0x000000018149ADC0
	
		// Methods
		public void Clear(); // 0x0000000181475250-0x0000000181475270
		protected override void Dispose(bool disposing); // 0x000000018149A9D0-0x000000018149AA90
		public override void Flush(); // 0x00000001802E76C0-0x00000001802E76D0
		public override long Seek(long offset, SeekOrigin origin); // 0x000000018149AAF0-0x000000018149AB50
		public override void SetLength(long value); // 0x000000018149AB50-0x000000018149ABB0
		public override int Read(byte[] buffer, int offset, int count); // 0x000000018149AA90-0x000000018149AAF0
		public override void Write(byte[] buffer, int offset, int count); // 0x000000018149ABB0-0x000000018149AD40
	}
}
