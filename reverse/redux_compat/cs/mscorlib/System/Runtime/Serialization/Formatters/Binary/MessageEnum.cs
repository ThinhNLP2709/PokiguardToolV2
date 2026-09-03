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

namespace System.Runtime.Serialization.Formatters.Binary
{
	[Serializable]
	[Flags]
	internal enum MessageEnum // TypeDefIndex: 3114
	{
		NoArgs = 1,
		ArgsInline = 2,
		ArgsIsArray = 4,
		ArgsInArray = 8,
		NoContext = 16,
		ContextInline = 32,
		ContextInArray = 64,
		MethodSignatureInArray = 128,
		PropertyInArray = 256,
		NoReturnValue = 512,
		ReturnValueVoid = 1024,
		ReturnValueInline = 2048,
		ReturnValueInArray = 4096,
		ExceptionInArray = 8192,
		GenericMethod = 32768
	}
}
