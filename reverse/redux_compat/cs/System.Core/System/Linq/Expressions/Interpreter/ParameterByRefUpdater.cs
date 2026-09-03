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
	internal sealed class ParameterByRefUpdater : ByRefUpdater // TypeDefIndex: 12356
	{
		// Fields
		private readonly LocalVariable _parameter; // 0x18
	
		// Constructors
		public ParameterByRefUpdater(LocalVariable parameter, int argumentIndex); // 0x00000001817FC810-0x00000001817FC860
	
		// Methods
		public override void Update(InterpretedFrame frame, object value); // 0x00000001817FC660-0x00000001817FC810
	}
}
