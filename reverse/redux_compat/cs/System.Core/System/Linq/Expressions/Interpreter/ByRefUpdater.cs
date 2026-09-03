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
	internal abstract class ByRefUpdater // TypeDefIndex: 12355
	{
		// Fields
		public readonly int ArgumentIndex; // 0x10
	
		// Constructors
		public ByRefUpdater(int argumentIndex); // 0x00000001802F9040-0x00000001802F9070
	
		// Methods
		public abstract void Update(InterpretedFrame frame, object value);
		public virtual void UndefineTemps(InstructionList instructions, LocalVariables locals); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
