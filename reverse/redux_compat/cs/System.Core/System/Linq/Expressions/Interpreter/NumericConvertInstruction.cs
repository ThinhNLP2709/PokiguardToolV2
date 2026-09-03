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
	internal abstract class NumericConvertInstruction : Instruction // TypeDefIndex: 12464
	{
		// Fields
		internal readonly TypeCode _from; // 0x10
		internal readonly TypeCode _to; // 0x14
		private readonly bool _isLiftedToNull; // 0x18
	
		// Properties
		public override string InstructionName { get; } // 0x00000001817FB810-0x00000001817FB840 
		public override int ConsumedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Nested types
		internal sealed class Unchecked : NumericConvertInstruction // TypeDefIndex: 12465
		{
			// Properties
			public override string InstructionName { get; } // 0x0000000181802740-0x0000000181802770 
	
			// Constructors
			public Unchecked(TypeCode from, TypeCode to, bool isLiftedToNull); // 0x00000001817E9FE0-0x00000001817EA030
	
			// Methods
			protected override object Convert(object obj); // 0x00000001818021C0-0x0000000181802740
			private object ConvertInt32(int obj); // 0x0000000181801BF0-0x0000000181801DE0
			private object ConvertInt64(long obj); // 0x0000000181801DE0-0x0000000181801FB0
			private object ConvertUInt64(ulong obj); // 0x0000000181801FB0-0x00000001818021C0
			private object ConvertDouble(double obj); // 0x00000001818019D0-0x0000000181801BF0
		}
	
		internal sealed class Checked : NumericConvertInstruction // TypeDefIndex: 12466
		{
			// Properties
			public override string InstructionName { get; } // 0x00000001817EA030-0x00000001817EA060 
	
			// Constructors
			public Checked(TypeCode from, TypeCode to, bool isLiftedToNull); // 0x00000001817E9FE0-0x00000001817EA030
	
			// Methods
			protected override object Convert(object obj); // 0x00000001817E9C70-0x00000001817E9FE0
			private object ConvertInt32(int obj); // 0x00000001817E93B0-0x00000001817E9680
			private object ConvertInt64(long obj); // 0x00000001817E9680-0x00000001817E9970
			private object ConvertUInt64(ulong obj); // 0x00000001817E9970-0x00000001817E9C70
			private object ConvertDouble(double obj); // 0x00000001817E9000-0x00000001817E93B0
		}
	
		internal sealed class ToUnderlying : NumericConvertInstruction // TypeDefIndex: 12467
		{
			// Properties
			public override string InstructionName { get; } // 0x0000000181801190-0x00000001818011C0 
	
			// Constructors
			public ToUnderlying(TypeCode to, bool isLiftedToNull); // 0x0000000181801150-0x0000000181801190
	
			// Methods
			protected override object Convert(object obj); // 0x0000000181800E50-0x0000000181801150
		}
	
		// Constructors
		protected NumericConvertInstruction(TypeCode from, TypeCode to, bool isLiftedToNull); // 0x00000001817E9FE0-0x00000001817EA030
	
		// Methods
		public sealed override int Run(InterpretedFrame frame); // 0x00000001817FB580-0x00000001817FB670
		protected abstract object Convert(object obj);
		public override string ToString(); // 0x00000001817FB670-0x00000001817FB810
	}
}
