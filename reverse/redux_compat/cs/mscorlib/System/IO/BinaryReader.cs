/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	[ComVisible(true)]
	public class BinaryReader : IDisposable // TypeDefIndex: 3695
	{
		// Fields
		private Stream m_stream; // 0x10
		private byte[] m_buffer; // 0x18
		private Decoder m_decoder; // 0x20
		private byte[] m_charBytes; // 0x28
		private char[] m_singleChar; // 0x30
		private char[] m_charBuffer; // 0x38
		private int m_maxCharsSize; // 0x40
		private bool m_2BytesPerChar; // 0x44
		private bool m_isMemoryStream; // 0x45
		private bool m_leaveOpen; // 0x46
	
		// Properties
		public virtual Stream BaseStream { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		public BinaryReader(Stream input); // 0x00000001815BDC70-0x00000001815BDCF0
		public BinaryReader(Stream input, Encoding encoding); // 0x00000001815BDCF0-0x00000001815BDD10
		public BinaryReader(Stream input, Encoding encoding, bool leaveOpen); // 0x00000001815BD9E0-0x00000001815BDC70
	
		// Methods
		public virtual void Close(); // 0x00000001815BC210-0x00000001815BC230
		protected virtual void Dispose(bool disposing); // 0x00000001815BC230-0x00000001815BC2F0
		public void Dispose(); // 0x00000001815BC210-0x00000001815BC230
		public virtual int Read(); // 0x00000001815BD7D0-0x00000001815BD7F0
		public virtual bool ReadBoolean(); // 0x00000001815BCB50-0x00000001815BCBA0
		public virtual byte ReadByte(); // 0x00000001815BCBA0-0x00000001815BCBE0
		[CLSCompliant(false)]
		public virtual sbyte ReadSByte(); // 0x00000001815BD370-0x00000001815BD3C0
		public virtual char ReadChar(); // 0x00000001815BCD90-0x00000001815BCDC0
		public virtual short ReadInt16(); // 0x00000001815BD0C0-0x00000001815BD120
		[CLSCompliant(false)]
		public virtual ushort ReadUInt16(); // 0x00000001815BD0C0-0x00000001815BD120
		public virtual int ReadInt32(); // 0x00000001815BD120-0x00000001815BD250
		[CLSCompliant(false)]
		public virtual uint ReadUInt32(); // 0x00000001815BD750-0x00000001815BD7D0
		public virtual long ReadInt64(); // 0x00000001815BD250-0x00000001815BD370
		[CLSCompliant(false)]
		public virtual ulong ReadUInt64(); // 0x00000001815BD250-0x00000001815BD370
		public virtual float ReadSingle(); // 0x00000001815BD3C0-0x00000001815BD400
		public virtual double ReadDouble(); // 0x00000001815BD080-0x00000001815BD0C0
		public virtual decimal ReadDecimal(); // 0x00000001815BCF40-0x00000001815BD080
		public virtual string ReadString(); // 0x00000001815BD400-0x00000001815BD750
		private int InternalReadChars(char[] buffer, int index, int count); // 0x00000001815BC460-0x00000001815BC7F0
		private int InternalReadOneChar(); // 0x00000001815BC7F0-0x00000001815BCAA0
		public virtual char[] ReadChars(int count); // 0x00000001815BCDC0-0x00000001815BCF40
		public virtual int Read(byte[] buffer, int index, int count); // 0x00000001815BD7F0-0x00000001815BD9E0
		public virtual byte[] ReadBytes(int count); // 0x00000001815BCBE0-0x00000001815BCD90
		protected virtual void FillBuffer(int numBytes); // 0x00000001815BC2F0-0x00000001815BC460
		protected internal int Read7BitEncodedInt(); // 0x00000001815BCAA0-0x00000001815BCB50
	}
}
