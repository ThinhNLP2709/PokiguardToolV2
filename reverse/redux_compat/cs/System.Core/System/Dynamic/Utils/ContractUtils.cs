/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Dynamic.Utils
{
	internal static class ContractUtils // TypeDefIndex: 12588
	{
		// Properties
		[ExcludeFromCodeCoverage]
		public static Exception Unreachable { get; } // 0x0000000181802EC0-0x0000000181802F20 
	
		// Methods
		public static void Requires(bool precondition, string paramName); // 0x0000000181802E80-0x0000000181802EC0
		public static void RequiresNotNull(object value, string paramName); // 0x0000000181802E20-0x0000000181802E80
		public static void RequiresNotNull(object value, string paramName, int index); // 0x0000000181802DA0-0x0000000181802E20
		public static void RequiresNotNullItems<T>(IList<T> array, string arrayName);
		private static string GetParamName(string paramName, int index); // 0x0000000181802D20-0x0000000181802DA0
		public static void RequiresArrayRange<T>(IList<T> array, int offset, int count, string offsetName, string countName);
	}
}
