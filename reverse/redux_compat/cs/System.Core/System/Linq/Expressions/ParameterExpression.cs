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

namespace System.Linq.Expressions
{
	[DebuggerTypeProxy(typeof(ParameterExpressionProxy))]
	public class ParameterExpression : Expression // TypeDefIndex: 12132
	{
		// Fields
		[CompilerGenerated]
		private readonly string _Name_k__BackingField; // 0x10
	
		// Properties
		public override Type Type { get; } // 0x0000000181742460-0x00000001817424A0 
		public sealed override ExpressionType NodeType { get; } // 0x00000001817BFE40-0x00000001817BFE50 
		public string Name { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public bool IsByRef { get; } // 0x000000018152D8E0-0x000000018152D900 
	
		// Constructors
		internal ParameterExpression(string name); // 0x00000001817BFDD0-0x00000001817BFE40
	
		// Methods
		internal static ParameterExpression Make(Type type, string name, bool isByRef); // 0x00000001817BFA10-0x00000001817BFDD0
		internal virtual bool GetIsByRef(); // 0x00000001802E7840-0x00000001802E7850
		protected internal override Expression Accept(ExpressionVisitor visitor); // 0x00000001817BF9E0-0x00000001817BFA10
	}
}
