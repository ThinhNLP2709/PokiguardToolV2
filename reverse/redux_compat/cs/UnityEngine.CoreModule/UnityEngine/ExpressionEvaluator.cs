/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting.APIUpdating;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[MovedFrom(true, "UnityEditor", "UnityEditor", null)]
	public class ExpressionEvaluator // TypeDefIndex: 7516
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static PcgRandom s_Random; // 0x00
		[NoAutoStaticsCleanup]
		private static readonly Dictionary<string, Operator> s_Operators; // 0x10
	
		// Nested types
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal class Expression // TypeDefIndex: 7517
		{
			// Fields
			internal readonly string[] rpnTokens; // 0x10
			internal readonly bool hasVariables; // 0x18
	
			// Constructors
			internal Expression(string expression); // 0x000000018218E8F0-0x000000018218EAE0
	
			// Methods
			public bool Evaluate<T>(ref ref T value, int index = 0 /* Metadata: 0x0069D263 */, int count = 1 /* Metadata: 0x0069D264 */);
			public override bool Equals(object obj); // 0x000000018218E6C0-0x000000018218E8B0
			public override int GetHashCode(); // 0x0000000181411DF0-0x0000000181411E20
			public override string ToString(); // 0x000000018218E8B0-0x000000018218E8F0
		}
	
		private struct PcgRandom // TypeDefIndex: 7518
		{
			// Fields
			private readonly ulong increment; // 0x00
			private ulong state; // 0x08
	
			// Constructors
			public PcgRandom(ulong state = 0 /* Metadata: 0x0069D265 */, ulong sequence = 0 /* Metadata: 0x0069D26D */); // 0x0000000182190EF0-0x0000000182190F20
	
			// Methods
			public uint GetUInt(); // 0x0000000182190E50-0x0000000182190EA0
			private static uint RotateRight(uint v, int rot); // 0x00000001814A6A90-0x00000001814A6AB0
			private static uint XshRr(ulong s); // 0x0000000182190EC0-0x0000000182190EF0
			private void Step(); // 0x0000000182190EA0-0x0000000182190EC0
		}
	
		private enum Op // TypeDefIndex: 7519
		{
			Add = 0,
			Sub = 1,
			Mul = 2,
			Div = 3,
			Mod = 4,
			Neg = 5,
			Pow = 6,
			Sqrt = 7,
			Sin = 8,
			Cos = 9,
			Tan = 10,
			Floor = 11,
			Ceil = 12,
			Round = 13,
			Rand = 14,
			Linear = 15
		}
	
		private enum Associativity // TypeDefIndex: 7520
		{
			Left = 0,
			Right = 1
		}
	
		private class Operator // TypeDefIndex: 7521
		{
			// Fields
			public readonly Op op; // 0x10
			public readonly int precedence; // 0x14
			public readonly Associativity associativity; // 0x18
			public readonly int inputs; // 0x1C
	
			// Constructors
			public Operator(Op op, int precedence, int inputs, Associativity associativity); // 0x0000000182190E00-0x0000000182190E50
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 7522
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Predicate<string> __9__14_0; // 0x08
	
			// Constructors
			static __c(); // 0x000000018219AE50-0x000000018219AEC0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _ExpressionToTokens_b__14_0(string res); // 0x000000018219ADC0-0x000000018219AE50
		}
	
		// Constructors
		static ExpressionEvaluator(); // 0x000000018218E080-0x000000018218E6C0
	
		// Methods
		internal static bool Evaluate<T>(string expression, out ref T value, out Expression delayed);
		private static bool EvaluateTokens<T>(string[] tokens, ref ref T value, int index, int count);
		private static bool EvaluateDouble(string[] tokens, ref double value, int index, int count); // 0x000000018218C670-0x000000018218CCC0
		private static string[] InfixToRPN(List<string> tokens); // 0x000000018218D590-0x000000018218DB40
		private static bool NeedToPop(Stack<string> operatorStack, Operator newOperator); // 0x000000018218DD10-0x000000018218DDE0
		private static List<string> ExpressionToTokens(string expression, out bool hasVariables); // 0x000000018218D010-0x000000018218D410
		private static bool IsCommand(string token); // 0x000000018218DB40-0x000000018218DBD0
		private static bool IsVariable(string token); // 0x000000018218DCC0-0x000000018218DD10
		private static bool IsDelayedFunction(string token); // 0x000000018218DBD0-0x000000018218DC40
		private static bool IsOperator(string token); // 0x000000018218DC40-0x000000018218DCC0
		private static Operator TokenToOperator(string token); // 0x000000018218DFE0-0x000000018218E080
		private static string PreFormatExpression(string expression); // 0x000000018218DDE0-0x000000018218DFE0
		private static List<string> FixUnaryOperators(List<string> tokens); // 0x000000018218D410-0x000000018218D590
		private static double EvaluateOp(double[] values, Op op, int index, int count); // 0x000000018218CCC0-0x000000018218D010
		private static bool TryParse<T>(string expression, out ref T result);
	}
}
