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
using System.Threading.Tasks;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	[Serializable]
	[ComVisible(true)]
	public class StringWriter : TextWriter // TypeDefIndex: 3698
	{
		// Fields
		private static UnicodeEncoding m_encoding; // 0x00
		private StringBuilder _sb; // 0x30
		private bool _isOpen; // 0x38
	
		// Properties
		public override Encoding Encoding { get; } // 0x00000001815D1150-0x00000001815D1210 
	
		// Constructors
		public StringWriter(); // 0x00000001815D0D30-0x00000001815D0E50
		public StringWriter(IFormatProvider formatProvider); // 0x00000001815D0F40-0x00000001815D1040
		public StringWriter(StringBuilder sb); // 0x00000001815D1040-0x00000001815D1150
		public StringWriter(StringBuilder sb, IFormatProvider formatProvider); // 0x00000001815D0E50-0x00000001815D0F40
	
		// Methods
		public override void Close(); // 0x00000001815D0780-0x00000001815D07A0
		protected override void Dispose(bool disposing); // 0x00000001815D07A0-0x00000001815D07B0
		public override void Write(char value); // 0x00000001815D0D00-0x00000001815D0D30
		public override void Write(char[] buffer, int index, int count); // 0x00000001815D0AD0-0x00000001815D0CC0
		public override void Write(string value); // 0x00000001815D0CC0-0x00000001815D0D00
		[ComVisible(false)]
		public override Task WriteAsync(char value); // 0x00000001815D0950-0x00000001815D0A10
		[ComVisible(false)]
		public override Task WriteAsync(string value); // 0x00000001815D0A10-0x00000001815D0AD0
		[ComVisible(false)]
		public override Task WriteAsync(char[] buffer, int index, int count); // 0x00000001815D0870-0x00000001815D0950
		[ComVisible(false)]
		public override Task FlushAsync(); // 0x00000001815D07B0-0x00000001815D0840
		public override string ToString(); // 0x00000001815D0840-0x00000001815D0870
	}
}
