/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	[Serializable]
	[ComVisible(true)]
	public class StringReader : TextReader // TypeDefIndex: 3697
	{
		// Fields
		private string _s; // 0x18
		private int _pos; // 0x20
		private int _length; // 0x24
	
		// Constructors
		public StringReader(string s); // 0x00000001815D06C0-0x00000001815D0780
	
		// Methods
		public override void Close(); // 0x00000001814CBE20-0x00000001814CBE40
		protected override void Dispose(bool disposing); // 0x00000001815D00B0-0x00000001815D00E0
		public override int Peek(); // 0x00000001815D00E0-0x00000001815D0120
		public override int Read(); // 0x00000001815D0670-0x00000001815D06C0
		public override int Read([In, Out] char[] buffer, int index, int count); // 0x00000001815D0460-0x00000001815D0670
		public override string ReadToEnd(); // 0x00000001815D0410-0x00000001815D0460
		public override string ReadLine(); // 0x00000001815D0310-0x00000001815D0410
		[ComVisible(false)]
		public override Task<int> ReadAsync(char[] buffer, int index, int count); // 0x00000001815D0120-0x00000001815D0310
	}
}
