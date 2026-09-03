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
	internal class CStreamReader : StreamReader // TypeDefIndex: 3711
	{
		// Fields
		private TermInfoDriver driver; // 0x60
	
		// Constructors
		public CStreamReader(Stream stream, Encoding encoding); // 0x00000001815D9320-0x00000001815D9450
	
		// Methods
		public override int Peek(); // 0x00000001815D9090-0x00000001815D90B0
		public override int Read(); // 0x00000001815D9110-0x00000001815D9170
		public override int Read([In, Out] char[] dest, int index, int count); // 0x00000001815D9170-0x00000001815D9320
		public override string ReadLine(); // 0x00000001815D90B0-0x00000001815D90E0
		public override string ReadToEnd(); // 0x00000001815D90E0-0x00000001815D9110
	}
}
