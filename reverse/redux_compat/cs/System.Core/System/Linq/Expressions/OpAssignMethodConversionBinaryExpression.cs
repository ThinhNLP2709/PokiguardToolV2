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
	internal sealed class OpAssignMethodConversionBinaryExpression : MethodBinaryExpression // TypeDefIndex: 12020
	{
		// Fields
		private readonly LambdaExpression _conversion; // 0x38
	
		// Constructors
		internal OpAssignMethodConversionBinaryExpression(ExpressionType nodeType, Expression left, Expression right, Type type, MethodInfo method, LambdaExpression conversion); // 0x00000001817A6900-0x00000001817A6970
	
		// Methods
		internal override LambdaExpression GetConversion(); // 0x00000001803272A0-0x00000001803272B0
	}
}
