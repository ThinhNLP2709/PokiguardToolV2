/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic.Utils;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions.Interpreter
{
	internal class LightLambda // TypeDefIndex: 12362
	{
		// Fields
		private readonly IStrongBox[] _closure; // 0x10
		private readonly Interpreter _interpreter; // 0x18
		private static readonly CacheDict<Type, Func<LightLambda, Delegate>> _runCache; // 0x00
		private readonly LightDelegateCreator _delegateCreator; // 0x20
	
		// Properties
		internal string DebugView { get; } // 0x00000001817F31D0-0x00000001817F3360 
	
		// Nested types
		private class DebugViewPrinter // TypeDefIndex: 12363
		{
			// Fields
			private readonly Interpreter _interpreter; // 0x10
			private readonly Dictionary<int, int> _tryStart; // 0x18
			private readonly Dictionary<int, string> _handlerEnter; // 0x20
			private readonly Dictionary<int, int> _handlerExit; // 0x28
			private string _indent; // 0x30
	
			// Constructors
			public DebugViewPrinter(Interpreter interpreter); // 0x00000001817EB100-0x00000001817EB240
	
			// Methods
			private void Analyze(); // 0x00000001817EA650-0x00000001817EA980
			private void AddTryStart(int index); // 0x00000001817EA590-0x00000001817EA650
			private void AddHandlerExit(int index); // 0x00000001817EA4F0-0x00000001817EA590
			private void Indent(); // 0x00000001817EAAD0-0x00000001817EAB20
			private void Dedent(); // 0x00000001817EA980-0x00000001817EA9D0
			public override string ToString(); // 0x00000001817EAB20-0x00000001817EB100
			private void EmitExits(StringBuilder sb, int index); // 0x00000001817EA9D0-0x00000001817EAAD0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass74_0 // TypeDefIndex: 12364
		{
			// Fields
			public MethodInfo targetMethod; // 0x10
			public Type delegateType; // 0x18
	
			// Constructors
			public __c__DisplayClass74_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Delegate _MakeRunDelegateCtor_b__0(LightLambda lambda); // 0x00000001818018B0-0x00000001818018F0
		}
	
		// Constructors
		internal LightLambda(LightDelegateCreator delegateCreator, IStrongBox[] closure); // 0x00000001817F3160-0x00000001817F31D0
		static LightLambda(); // 0x00000001817F30D0-0x00000001817F3160
	
		// Methods
		internal TRet Run0<TRet>();
		internal void RunVoid0(); // 0x00000001817F2B80-0x00000001817F2CC0
		internal static Delegate MakeRun0<TRet>(LightLambda lambda);
		internal static Delegate MakeRunVoid0(LightLambda lambda); // 0x00000001817F2B10-0x00000001817F2B80
		internal TRet Run1<T0, TRet>(T0 arg0);
		internal void RunVoid1<T0>(T0 arg0);
		internal static Delegate MakeRun1<T0, TRet>(LightLambda lambda);
		internal static Delegate MakeRunVoid1<T0>(LightLambda lambda);
		internal TRet Run2<T0, T1, TRet>(T0 arg0, T1 arg1);
		internal void RunVoid2<T0, T1>(T0 arg0, T1 arg1);
		internal static Delegate MakeRun2<T0, T1, TRet>(LightLambda lambda);
		internal static Delegate MakeRunVoid2<T0, T1>(LightLambda lambda);
		internal TRet Run3<T0, T1, T2, TRet>(T0 arg0, T1 arg1, T2 arg2);
		internal void RunVoid3<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2);
		internal static Delegate MakeRun3<T0, T1, T2, TRet>(LightLambda lambda);
		internal static Delegate MakeRunVoid3<T0, T1, T2>(LightLambda lambda);
		internal TRet Run4<T0, T1, T2, T3, TRet>(T0 arg0, T1 arg1, T2 arg2, T3 arg3);
		internal void RunVoid4<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3);
		internal static Delegate MakeRun4<T0, T1, T2, T3, TRet>(LightLambda lambda);
		internal static Delegate MakeRunVoid4<T0, T1, T2, T3>(LightLambda lambda);
		internal TRet Run5<T0, T1, T2, T3, T4, TRet>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		internal void RunVoid5<T0, T1, T2, T3, T4>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		internal static Delegate MakeRun5<T0, T1, T2, T3, T4, TRet>(LightLambda lambda);
		internal static Delegate MakeRunVoid5<T0, T1, T2, T3, T4>(LightLambda lambda);
		internal TRet Run6<T0, T1, T2, T3, T4, T5, TRet>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
		internal void RunVoid6<T0, T1, T2, T3, T4, T5>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
		internal static Delegate MakeRun6<T0, T1, T2, T3, T4, T5, TRet>(LightLambda lambda);
		internal static Delegate MakeRunVoid6<T0, T1, T2, T3, T4, T5>(LightLambda lambda);
		internal TRet Run7<T0, T1, T2, T3, T4, T5, T6, TRet>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
		internal void RunVoid7<T0, T1, T2, T3, T4, T5, T6>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
		internal static Delegate MakeRun7<T0, T1, T2, T3, T4, T5, T6, TRet>(LightLambda lambda);
		internal static Delegate MakeRunVoid7<T0, T1, T2, T3, T4, T5, T6>(LightLambda lambda);
		internal TRet Run8<T0, T1, T2, T3, T4, T5, T6, T7, TRet>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);
		internal void RunVoid8<T0, T1, T2, T3, T4, T5, T6, T7>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);
		internal static Delegate MakeRun8<T0, T1, T2, T3, T4, T5, T6, T7, TRet>(LightLambda lambda);
		internal static Delegate MakeRunVoid8<T0, T1, T2, T3, T4, T5, T6, T7>(LightLambda lambda);
		internal TRet Run9<T0, T1, T2, T3, T4, T5, T6, T7, T8, TRet>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);
		internal void RunVoid9<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);
		internal static Delegate MakeRun9<T0, T1, T2, T3, T4, T5, T6, T7, T8, TRet>(LightLambda lambda);
		internal static Delegate MakeRunVoid9<T0, T1, T2, T3, T4, T5, T6, T7, T8>(LightLambda lambda);
		internal TRet Run10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TRet>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9);
		internal void RunVoid10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9);
		internal static Delegate MakeRun10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TRet>(LightLambda lambda);
		internal static Delegate MakeRunVoid10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(LightLambda lambda);
		internal TRet Run11<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TRet>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10);
		internal void RunVoid11<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10);
		internal static Delegate MakeRun11<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TRet>(LightLambda lambda);
		internal static Delegate MakeRunVoid11<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(LightLambda lambda);
		internal TRet Run12<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TRet>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11);
		internal void RunVoid12<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11);
		internal static Delegate MakeRun12<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TRet>(LightLambda lambda);
		internal static Delegate MakeRunVoid12<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(LightLambda lambda);
		internal TRet Run13<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TRet>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12);
		internal void RunVoid13<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12);
		internal static Delegate MakeRun13<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TRet>(LightLambda lambda);
		internal static Delegate MakeRunVoid13<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(LightLambda lambda);
		internal TRet Run14<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TRet>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13);
		internal void RunVoid14<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13);
		internal static Delegate MakeRun14<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TRet>(LightLambda lambda);
		internal static Delegate MakeRunVoid14<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(LightLambda lambda);
		internal TRet Run15<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TRet>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14);
		internal void RunVoid15<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14);
		internal static Delegate MakeRun15<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TRet>(LightLambda lambda);
		internal static Delegate MakeRunVoid15<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(LightLambda lambda);
		private static Func<LightLambda, Delegate> GetRunDelegateCtor(Type delegateType); // 0x00000001817F1FF0-0x00000001817F2190
		private static Func<LightLambda, Delegate> MakeRunDelegateCtor(Type delegateType); // 0x00000001817F2280-0x00000001817F2B10
		private Delegate CreateCustomDelegate(Type delegateType); // 0x00000001817F16A0-0x00000001817F1FF0
		internal Delegate MakeDelegate(Type delegateType); // 0x00000001817F2190-0x00000001817F2210
		private InterpretedFrame MakeFrame(); // 0x00000001817F2210-0x00000001817F2280
		internal void RunVoidRef2<T0, T1>(ref ref T0 arg0, ref ref T1 arg1);
		public object Run(params object[] arguments); // 0x00000001817F2EC0-0x00000001817F30D0
		public object RunVoid(params object[] arguments); // 0x00000001817F2CC0-0x00000001817F2EC0
	}
}
