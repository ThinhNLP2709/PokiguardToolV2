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

namespace System.Diagnostics
{
	[ComVisible(true)]
	public sealed class Debugger // TypeDefIndex: 3468
	{
		// Fields
		public static readonly string DefaultCategory; // 0x00
	
		// Constructors
		static Debugger(); // 0x0000000181598FF0-0x0000000181599060
	
		// Methods
		public static bool IsLogging(); // 0x0000000181449F80-0x0000000181449F90
		private static void Log_icall(int level, ref string category, ref string message); // 0x0000000181539480-0x0000000181539490
		public static void Log(int level, string category, string message); // 0x0000000181598F90-0x0000000181598FF0
		public static void NotifyOfCrossThreadDependency(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
