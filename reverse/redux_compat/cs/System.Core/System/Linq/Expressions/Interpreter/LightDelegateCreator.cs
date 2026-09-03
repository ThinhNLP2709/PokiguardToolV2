/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions.Interpreter
{
	internal sealed class LightDelegateCreator // TypeDefIndex: 12361
	{
		// Fields
		private readonly LambdaExpression _lambda; // 0x10
		[CompilerGenerated]
		private readonly Interpreter _Interpreter_k__BackingField; // 0x18
	
		// Properties
		internal Interpreter Interpreter { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		internal LightDelegateCreator(Interpreter interpreter, LambdaExpression lambda); // 0x00000001814BCAD0-0x00000001814BCB20
	
		// Methods
		public Delegate CreateDelegate(); // 0x00000001817F1570-0x00000001817F1580
		internal Delegate CreateDelegate(IStrongBox[] closure); // 0x00000001817F1580-0x00000001817F16A0
	}
}
