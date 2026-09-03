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
	internal sealed class CoalesceConversionBinaryExpression : BinaryExpression // TypeDefIndex: 12019
	{
		// Fields
		private readonly LambdaExpression _conversion; // 0x20
	
		// Properties
		public sealed override ExpressionType NodeType { get; } // 0x0000000180A2FB20-0x0000000180A2FB30 
		public sealed override Type Type { get; } // 0x0000000181738F00-0x0000000181738F30 
	
		// Constructors
		internal CoalesceConversionBinaryExpression(Expression left, Expression right, LambdaExpression conversion); // 0x000000018178C5F0-0x000000018178C630
	
		// Methods
		internal override LambdaExpression GetConversion(); // 0x00000001802F8630-0x00000001802F8640
	}
}
