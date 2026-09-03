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

namespace System.Runtime.InteropServices
{
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	[ComVisible(true)]
	public sealed class DllImportAttribute : Attribute // TypeDefIndex: 3148
	{
		// Fields
		internal string _val; // 0x10
		public string EntryPoint; // 0x18
		public CharSet CharSet; // 0x20
		public bool SetLastError; // 0x24
		public bool ExactSpelling; // 0x25
		public bool PreserveSig; // 0x26
		public CallingConvention CallingConvention; // 0x28
		public bool BestFitMapping; // 0x2C
		public bool ThrowOnUnmappableChar; // 0x2D
	
		// Properties
		public string Value { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		internal DllImportAttribute(string dllName, string entryPoint, CharSet charSet, bool exactSpelling, bool setLastError, bool preserveSig, CallingConvention callingConvention, bool bestFitMapping, bool throwOnUnmappableChar); // 0x000000018150BB00-0x000000018150BB90
		public DllImportAttribute(string dllName); // 0x00000001802E7420-0x00000001802E7460
	
		// Methods
		internal static Attribute GetCustomAttribute(RuntimeMethodInfo method); // 0x000000018150B850-0x000000018150BAD0
		internal static bool IsDefined(RuntimeMethodInfo method); // 0x000000018150BAD0-0x000000018150BB00
	}
}
