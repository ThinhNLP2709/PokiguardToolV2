/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions.Interpreter
{
	internal sealed class ExceptionHandler // TypeDefIndex: 12345
	{
		// Fields
		private readonly Type _exceptionType; // 0x10
		public readonly int LabelIndex; // 0x18
		public readonly int HandlerStartIndex; // 0x1C
		public readonly int HandlerEndIndex; // 0x20
		public readonly ExceptionFilter Filter; // 0x28
	
		// Constructors
		internal ExceptionHandler(int labelIndex, int handlerStartIndex, int handlerEndIndex, Type exceptionType, ExceptionFilter filter); // 0x00000001817C5DE0-0x00000001817C5E50
	
		// Methods
		public bool Matches(Type exceptionType); // 0x00000001817C5CD0-0x00000001817C5D00
		public override string ToString(); // 0x00000001817C5D00-0x00000001817C5DE0
	}
}
