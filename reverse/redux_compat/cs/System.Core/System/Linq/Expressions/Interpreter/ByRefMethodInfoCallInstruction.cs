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
	internal class ByRefMethodInfoCallInstruction : MethodInfoCallInstruction // TypeDefIndex: 12184
	{
		// Fields
		private readonly ByRefUpdater[] _byrefArgs; // 0x20
	
		// Properties
		public override int ProducedStack { get; } // 0x00000001817ABEE0-0x00000001817ABF60 
	
		// Constructors
		internal ByRefMethodInfoCallInstruction(MethodInfo target, int argumentCount, ByRefUpdater[] byrefArgs); // 0x00000001817ABE80-0x00000001817ABEE0
	
		// Methods
		public sealed override int Run(InterpretedFrame frame); // 0x00000001817AB950-0x00000001817ABE80
	}
}
