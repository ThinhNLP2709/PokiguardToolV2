/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions
{
	[DebuggerTypeProxy(typeof(LambdaExpressionProxy))]
	public abstract class LambdaExpression : Expression, IParameterProvider // TypeDefIndex: 12094
	{
		// Fields
		private readonly Expression _body; // 0x10
	
		// Properties
		public sealed override Type Type { get; } // 0x00000001817AAE10-0x00000001817AAE30 
		internal abstract Type TypeCore { get; }
		internal abstract Type PublicType { get; }
		public sealed override ExpressionType NodeType { get; } // 0x0000000181458830-0x0000000181458840 
		public string Name { get; } // 0x0000000180CC9130-0x0000000180CC9150 
		internal virtual string NameCore { get; } // 0x00000001802E7860-0x00000001802E7870 
		public Expression Body { get; } // 0x0000000180377550-0x0000000180377560 
		public Type ReturnType { get; } // 0x00000001817BD3F0-0x00000001817BD480 
		public bool TailCall { get; } // 0x0000000180CC8F00-0x0000000180CC8F20 
		internal virtual bool TailCallCore { get; } // 0x00000001802E7840-0x00000001802E7850 
		[ExcludeFromCodeCoverage]
		int IParameterProvider.ParameterCount { get; } // 0x000000018152CA80-0x000000018152CAA0 
		[ExcludeFromCodeCoverage]
		internal virtual int ParameterCount { get; } // 0x00000001817BD3C0-0x00000001817BD3F0 
	
		// Constructors
		internal LambdaExpression(Expression body); // 0x00000001817BD350-0x00000001817BD3C0
	
		// Methods
		[ExcludeFromCodeCoverage]
		ParameterExpression IParameterProvider.GetParameter(int index); // 0x00000001817BD330-0x00000001817BD350
		[ExcludeFromCodeCoverage]
		internal virtual ParameterExpression GetParameter(int index); // 0x00000001817BD300-0x00000001817BD330
	}
}
