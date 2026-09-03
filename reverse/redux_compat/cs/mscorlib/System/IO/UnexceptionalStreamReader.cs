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
	internal class UnexceptionalStreamReader : StreamReader // TypeDefIndex: 3709
	{
		// Fields
		private static bool[] newline; // 0x00
		private static char newlineChar; // 0x08
	
		// Constructors
		static UnexceptionalStreamReader(); // 0x00000001815DC2E0-0x00000001815DC390
		public UnexceptionalStreamReader(Stream stream, Encoding encoding); // 0x00000001815DC390-0x00000001815DC400
	
		// Methods
		public override int Peek(); // 0x00000001815D9090-0x00000001815D90B0
		public override int Read(); // 0x00000001815DC2C0-0x00000001815DC2E0
		public override int Read([In, Out] char[] dest_buffer, int index, int count); // 0x00000001815DC060-0x00000001815DC2C0
		private bool CheckEOL(char current); // 0x00000001815DBE10-0x00000001815DC020
		public override string ReadLine(); // 0x00000001815DC020-0x00000001815DC040
		public override string ReadToEnd(); // 0x00000001815DC040-0x00000001815DC060
	}
}
