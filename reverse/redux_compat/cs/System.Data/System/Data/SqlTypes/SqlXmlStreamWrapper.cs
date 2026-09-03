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

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data.SqlTypes
{
	internal sealed class SqlXmlStreamWrapper : Stream // TypeDefIndex: 11370
	{
		// Fields
		private Stream _stream; // 0x28
		private long _lPosition; // 0x30
		private bool _isClosed; // 0x38
	
		// Properties
		public override bool CanRead { get; } // 0x00000001818F6B10-0x00000001818F6B60 
		public override bool CanSeek { get; } // 0x00000001818F6B60-0x00000001818F6BB0 
		public override bool CanWrite { get; } // 0x00000001818F6BB0-0x00000001818F6C00 
		public override long Length { get; } // 0x00000001818F6C00-0x00000001818F6CD0 
		public override long Position { get; set; } // 0x00000001818F6CD0-0x00000001818F6D80 0x00000001818F6D80-0x00000001818F6EB0
	
		// Constructors
		internal SqlXmlStreamWrapper(Stream stream); // 0x00000001818F6AB0-0x00000001818F6B10
	
		// Methods
		public override long Seek(long offset, SeekOrigin origin); // 0x00000001818F60E0-0x00000001818F63B0
		public override int Read(byte[] buffer, int offset, int count); // 0x00000001818F5E60-0x00000001818F60E0
		public override void Write(byte[] buffer, int offset, int count); // 0x00000001818F6820-0x00000001818F6AB0
		public override int ReadByte(); // 0x00000001818F5CC0-0x00000001818F5E60
		public override void WriteByte(byte value); // 0x00000001818F66C0-0x00000001818F6820
		public override void SetLength(long value); // 0x00000001818F63B0-0x00000001818F64A0
		public override void Flush(); // 0x00000001818F5C10-0x00000001818F5C30
		protected override void Dispose(bool disposing); // 0x00000001818F5BB0-0x00000001818F5C10
		private void ThrowIfStreamCannotSeek(string method); // 0x00000001818F6530-0x00000001818F65C0
		private void ThrowIfStreamCannotRead(string method); // 0x00000001818F64A0-0x00000001818F6530
		private void ThrowIfStreamCannotWrite(string method); // 0x00000001818F65C0-0x00000001818F6650
		private void ThrowIfStreamClosed(string method); // 0x00000001818F6650-0x00000001818F66C0
		private bool IsStreamClosed(); // 0x00000001818F5C30-0x00000001818F5CC0
	}
}
