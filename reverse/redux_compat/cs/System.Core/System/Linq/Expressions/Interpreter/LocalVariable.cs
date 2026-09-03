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
	internal sealed class LocalVariable // TypeDefIndex: 12387
	{
		// Fields
		public readonly int Index; // 0x10
		private int _flags; // 0x14
	
		// Properties
		public bool IsBoxed { get; set; } // 0x00000001817F3FB0-0x00000001817F3FC0 0x00000001817F3FC0-0x00000001817F3FE0
		public bool InClosure { get; } // 0x00000001817F3FA0-0x00000001817F3FB0 
	
		// Constructors
		internal LocalVariable(int index, bool closure); // 0x00000001817F3F60-0x00000001817F3FA0
	
		// Methods
		public override string ToString(); // 0x00000001817F3E90-0x00000001817F3F60
	}
}
