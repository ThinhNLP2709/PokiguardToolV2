/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

// Image 40: Assembly-CSharp-firstpass.dll - Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15099-15191

namespace DG.Tweening
{
	public static class DOTweenModuleUnityVersion // TypeDefIndex: 15174
	{
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass8_0 // TypeDefIndex: 15175
		{
			// Fields
			public Material target; // 0x10
			public int propertyID; // 0x18
	
			// Constructors
			public __c__DisplayClass8_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Vector2 _DOOffset_b__0(); // 0x00000001802E7010-0x00000001802E7040
			internal void _DOOffset_b__1(Vector2 x); // 0x00000001802E7040-0x00000001802E7070
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass9_0 // TypeDefIndex: 15176
		{
			// Fields
			public Material target; // 0x10
			public int propertyID; // 0x18
	
			// Constructors
			public __c__DisplayClass9_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Vector2 _DOTiling_b__0(); // 0x00000001802E7140-0x00000001802E7170
			internal void _DOTiling_b__1(Vector2 x); // 0x00000001802E7170-0x00000001802E71A0
		}
	
		[CompilerGenerated]
		private struct _AsyncWaitForCompletion_d__10 : IAsyncStateMachine // TypeDefIndex: 15177
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public Tween t; // 0x20
			private YieldAwaitable.YieldAwaiter __u__1; // 0x28
	
			// Methods
			private void MoveNext(); // 0x00000001802E4900-0x00000001802E4BA0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001802E4BA0-0x00000001802E4C00
		}
	
		[CompilerGenerated]
		private struct _AsyncWaitForElapsedLoops_d__13 : IAsyncStateMachine // TypeDefIndex: 15178
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public Tween t; // 0x20
			public int elapsedLoops; // 0x28
			private YieldAwaitable.YieldAwaiter __u__1; // 0x2C
	
			// Methods
			private void MoveNext(); // 0x00000001802E4C00-0x00000001802E4EA0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001802E4EA0-0x00000001802E4F00
		}
	
		[CompilerGenerated]
		private struct _AsyncWaitForKill_d__12 : IAsyncStateMachine // TypeDefIndex: 15179
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public Tween t; // 0x20
			private YieldAwaitable.YieldAwaiter __u__1; // 0x28
	
			// Methods
			private void MoveNext(); // 0x00000001802E4F00-0x00000001802E5190
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001802E5190-0x00000001802E51F0
		}
	
		[CompilerGenerated]
		private struct _AsyncWaitForPosition_d__14 : IAsyncStateMachine // TypeDefIndex: 15180
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public Tween t; // 0x20
			public float position; // 0x28
			private YieldAwaitable.YieldAwaiter __u__1; // 0x2C
	
			// Methods
			private void MoveNext(); // 0x00000001802E51F0-0x00000001802E54C0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001802E54C0-0x00000001802E5520
		}
	
		[CompilerGenerated]
		private struct _AsyncWaitForRewind_d__11 : IAsyncStateMachine // TypeDefIndex: 15181
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public Tween t; // 0x20
			private YieldAwaitable.YieldAwaiter __u__1; // 0x28
	
			// Methods
			private void MoveNext(); // 0x00000001802E5520-0x00000001802E5800
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001802E5800-0x00000001802E5860
		}
	
		[CompilerGenerated]
		private struct _AsyncWaitForStart_d__15 : IAsyncStateMachine // TypeDefIndex: 15182
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public Tween t; // 0x20
			private YieldAwaitable.YieldAwaiter __u__1; // 0x28
	
			// Methods
			private void MoveNext(); // 0x00000001802E5860-0x00000001802E5B00
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001802E5B00-0x00000001802E5B60
		}
	
		// Extension methods
		public static Sequence DOGradientColor(this Material target, Gradient gradient, float duration); // 0x00000001802E3470-0x00000001802E3670
		public static Sequence DOGradientColor(this Material target, Gradient gradient, string property, float duration); // 0x00000001802E3260-0x00000001802E3470
		public static CustomYieldInstruction WaitForCompletion(this Tween t, bool returnCustomYieldInstruction); // 0x00000001802E39F0-0x00000001802E3AB0
		public static CustomYieldInstruction WaitForRewind(this Tween t, bool returnCustomYieldInstruction); // 0x00000001802E3D20-0x00000001802E3DE0
		public static CustomYieldInstruction WaitForKill(this Tween t, bool returnCustomYieldInstruction); // 0x00000001802E3B80-0x00000001802E3C40
		public static CustomYieldInstruction WaitForElapsedLoops(this Tween t, int elapsedLoops, bool returnCustomYieldInstruction); // 0x00000001802E3AB0-0x00000001802E3B80
		public static CustomYieldInstruction WaitForPosition(this Tween t, float position, bool returnCustomYieldInstruction); // 0x00000001802E3C40-0x00000001802E3D20
		public static CustomYieldInstruction WaitForStart(this Tween t, bool returnCustomYieldInstruction); // 0x00000001802E3DE0-0x00000001802E3EA0
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOOffset(this Material target, Vector2 endValue, int propertyID, float duration); // 0x00000001802E3670-0x00000001802E3830
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOTiling(this Material target, Vector2 endValue, int propertyID, float duration); // 0x00000001802E3830-0x00000001802E39F0
		public static async Task AsyncWaitForCompletion(this Tween t); // 0x00000001802E2DC0-0x00000001802E2E80
		public static async Task AsyncWaitForRewind(this Tween t); // 0x00000001802E30E0-0x00000001802E31A0
		public static async Task AsyncWaitForKill(this Tween t); // 0x00000001802E2F50-0x00000001802E3010
		public static async Task AsyncWaitForElapsedLoops(this Tween t, int elapsedLoops); // 0x00000001802E2E80-0x00000001802E2F50
		public static async Task AsyncWaitForPosition(this Tween t, float position); // 0x00000001802E3010-0x00000001802E30E0
		public static async Task AsyncWaitForStart(this Tween t); // 0x00000001802E31A0-0x00000001802E3260
	}
}
