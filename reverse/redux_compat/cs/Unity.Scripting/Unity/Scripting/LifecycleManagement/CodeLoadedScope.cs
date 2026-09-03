/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting.LifecycleManagement
{
	[Nullable(0)]
	[NullableContext(1)]
	internal sealed class CodeLoadedScope : LifecycleScope // TypeDefIndex: 14856
	{
		// Fields
		public static readonly string ScopeName; // 0x00
		private static int _codeLoadedGeneration; // 0x08
		private static AsyncLocal<int> _executionContextGeneration; // 0x10
		[Nullable(2)]
		private static CancellationTokenSource _cancellationTokenSource; // 0x18
		[CompilerGenerated]
		private readonly ImplicitLifecycleScope[] _ImplicitOuterScopes_k__BackingField; // 0x30
	
		// Properties
		public static int CurrentCodeLoadedGeneration { get; } // 0x0000000182063880-0x00000001820638D0 
		public static int ExecutionContextGeneration { get; } // 0x00000001820638D0-0x0000000182063950 
		public static CancellationToken CancellationToken { get; } // 0x00000001820637C0-0x0000000182063880 
		public override ImplicitLifecycleScope[] ImplicitOuterScopes { [CompilerGenerated] get; } // 0x000000018031E110-0x000000018031E120 
	
		// Constructors
		public CodeLoadedScope(); // 0x0000000182063510-0x00000001820637C0
		static CodeLoadedScope(); // 0x0000000182063450-0x0000000182063510
	
		// Methods
		internal static int IncrementCodeLoadedGeneration(); // 0x00000001820632A0-0x00000001820633C0
		public static void CancelIfNotInCorrectGeneration(); // 0x00000001820630E0-0x00000001820631C0
		protected override void Enter(ScopeTransitionHelper scopeTransitionHelper); // 0x00000001820631C0-0x0000000182063230
		protected override void Exit(ScopeTransitionHelper scopeTransitionHelper); // 0x0000000182063230-0x00000001820632A0
		private static void RecycleCancellationTokenSource(); // 0x00000001820633C0-0x0000000182063450
	}
}
