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
	internal sealed class FieldByRefUpdater : ByRefUpdater // TypeDefIndex: 12358
	{
		// Fields
		private readonly LocalDefinition? _object; // 0x18
		private readonly FieldInfo _field; // 0x30
	
		// Constructors
		public FieldByRefUpdater(LocalDefinition? obj, FieldInfo field, int argumentIndex); // 0x00000001817EFEC0-0x00000001817EFF30
	
		// Methods
		public override void Update(InterpretedFrame frame, object value); // 0x00000001817EFE60-0x00000001817EFEC0
		public override void UndefineTemps(InstructionList instructions, LocalVariables locals); // 0x00000001817EFE00-0x00000001817EFE60
	}
}
