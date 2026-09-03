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
	internal abstract class CallInstruction : Instruction // TypeDefIndex: 12182
	{
		// Properties
		public abstract int ArgumentCount { get; }
		public override string InstructionName { get; } // 0x00000001817AC8C0-0x00000001817AC8F0 
		public override int ConsumedStack { get; } // 0x000000018178B5A0-0x000000018178B5C0 
	
		// Constructors
		protected CallInstruction(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static CallInstruction Create(MethodInfo info); // 0x00000001817AC010-0x00000001817AC070
		public static CallInstruction Create(MethodInfo info, ParameterInfo[] parameters); // 0x00000001817AC070-0x00000001817AC210
		private static CallInstruction GetArrayAccessor(MethodInfo info, int argumentCount); // 0x00000001817AC210-0x00000001817AC710
		public static void ArrayItemSetter1(Array array, int index0, object value); // 0x00000001817ABF70-0x00000001817ABFA0
		public static void ArrayItemSetter2(Array array, int index0, int index1, object value); // 0x00000001817ABFA0-0x00000001817ABFD0
		public static void ArrayItemSetter3(Array array, int index0, int index1, int index2, object value); // 0x00000001817ABFD0-0x00000001817AC010
		protected static bool TryGetLightLambdaTarget(object instance, out LightLambda lightLambda); // 0x00000001817AC770-0x00000001817AC8C0
		protected object InterpretLambdaInvoke(LightLambda targetLambda, object[] args); // 0x00000001817AC710-0x00000001817AC770
	}
}
