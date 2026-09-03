/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	[Serializable]
	[ComVisible(true)]
	public class BinaryWriter : IDisposable // TypeDefIndex: 3696
	{
		// Fields
		public static readonly BinaryWriter Null; // 0x00
		protected Stream OutStream; // 0x10
		private byte[] _buffer; // 0x18
		private Encoding _encoding; // 0x20
		private Encoder _encoder; // 0x28
		[OptionalField]
		private bool _leaveOpen; // 0x30
		private byte[] _largeByteBuffer; // 0x38
		private int _maxChars; // 0x40
	
		// Constructors
		protected BinaryWriter(); // 0x00000001815BEBD0-0x00000001815BECE0
		public BinaryWriter(Stream output); // 0x00000001815BEED0-0x00000001815BEF50
		public BinaryWriter(Stream output, Encoding encoding); // 0x00000001815BEBB0-0x00000001815BEBD0
		public BinaryWriter(Stream output, Encoding encoding, bool leaveOpen); // 0x00000001815BECE0-0x00000001815BEED0
		static BinaryWriter(); // 0x00000001815BEA60-0x00000001815BEBB0
	
		// Methods
		public virtual void Close(); // 0x00000001815181C0-0x00000001815181E0
		protected virtual void Dispose(bool disposing); // 0x00000001815BDD10-0x00000001815BDD70
		public void Dispose(); // 0x00000001815181C0-0x00000001815181E0
		public virtual void Flush(); // 0x00000001815BDD70-0x00000001815BDDA0
		public virtual void Write(bool value); // 0x00000001815BE530-0x00000001815BE590
		public virtual void Write(byte value); // 0x00000001815BE350-0x00000001815BE380
		[CLSCompliant(false)]
		public virtual void Write(sbyte value); // 0x00000001815BE350-0x00000001815BE380
		public virtual void Write(byte[] buffer); // 0x00000001815BE380-0x00000001815BE410
		public virtual void Write(byte[] buffer, int index, int count); // 0x00000001815BE980-0x00000001815BE9B0
		public virtual void Write(char ch); // 0x00000001815BE840-0x00000001815BE980
		public virtual void Write(char[] chars); // 0x00000001815BE410-0x00000001815BE4E0
		public virtual void Write(double value); // 0x00000001815BE740-0x00000001815BE790
		public virtual void Write(short value); // 0x00000001815BE1A0-0x00000001815BE210
		[CLSCompliant(false)]
		public virtual void Write(ushort value); // 0x00000001815BE6D0-0x00000001815BE740
		public virtual void Write(int value); // 0x00000001815BE790-0x00000001815BE840
		[CLSCompliant(false)]
		public virtual void Write(uint value); // 0x00000001815BE9B0-0x00000001815BEA60
		public virtual void Write(long value); // 0x00000001815BE590-0x00000001815BE6D0
		[CLSCompliant(false)]
		public virtual void Write(ulong value); // 0x00000001815BE210-0x00000001815BE350
		public virtual void Write(float value); // 0x00000001815BE4E0-0x00000001815BE530
		public virtual void Write(string value); // 0x00000001815BDE10-0x00000001815BE1A0
		protected void Write7BitEncodedInt(int value); // 0x00000001815BDDA0-0x00000001815BDE10
	}
}
