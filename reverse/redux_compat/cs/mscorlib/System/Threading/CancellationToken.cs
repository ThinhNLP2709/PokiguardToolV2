/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading
{
	[DebuggerDisplay("IsCancellationRequested = {IsCancellationRequested}")]
	[IsReadOnly]
	public struct CancellationToken // TypeDefIndex: 2542
	{
		// Fields
		private readonly CancellationTokenSource _source; // 0x00
		private static readonly Action<object> s_actionToActionObjShunt; // 0x00
	
		// Properties
		public static CancellationToken None { get; } // 0x00000001802E7860-0x00000001802E7870 
		public bool IsCancellationRequested { get; } // 0x0000000181666410-0x0000000181666450 
		public bool CanBeCanceled { get; } // 0x0000000180A3EC30-0x0000000180A3EC40 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2543
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x0000000181678470-0x00000001816784E0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _.cctor_b__26_0(object obj); // 0x0000000181678310-0x0000000181678380
		}
	
		// Constructors
		internal CancellationToken(CancellationTokenSource source); // 0x0000000180E02C90-0x0000000180E02CA0
		public CancellationToken(bool canceled); // 0x0000000181666370-0x0000000181666410
		static CancellationToken(); // 0x00000001816662A0-0x0000000181666370
	
		// Methods
		public CancellationTokenRegistration Register(Action callback); // 0x0000000181665F50-0x0000000181666050
		internal CancellationTokenRegistration InternalRegisterWithoutEC(Action<object> callback, object state); // 0x0000000181665EA0-0x0000000181665F50
		public CancellationTokenRegistration Register(Action<object> callback, object state, bool useSynchronizationContext, bool useExecutionContext); // 0x0000000181666050-0x00000001816661D0
		public bool Equals(CancellationToken other); // 0x0000000180DF5FE0-0x0000000180DF5FF0
		public override bool Equals(object other); // 0x0000000181665D80-0x0000000181665E20
		public override int GetHashCode(); // 0x0000000181665E20-0x0000000181665EA0
		public static bool operator ==(CancellationToken left, CancellationToken right); // 0x0000000181666450-0x00000001816664B0
		public static bool operator !=(CancellationToken left, CancellationToken right); // 0x00000001816664B0-0x0000000181666510
		public void ThrowIfCancellationRequested(); // 0x00000001816661D0-0x0000000181666240
		private void ThrowOperationCanceledException(); // 0x0000000181666240-0x00000001816662A0
	}
}
