/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.EnhancedTouch
{
	public struct Touch : IEquatable<Touch> // TypeDefIndex: 6360
	{
		// Fields
		private readonly Finger m_Finger; // 0x00
		internal InputStateHistory<TouchState> m_TouchRecord; // 0x08
		internal static GlobalState s_GlobalState; // 0x00
	
		// Properties
		public bool valid { get; } // 0x0000000181DD4770-0x0000000181DD4780 
		public Finger finger { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public UnityEngine.InputSystem.TouchPhase phase { get; } // 0x0000000181DD4160-0x0000000181DD41D0 
		public bool began { get; } // 0x0000000181DD3C50-0x0000000181DD3CA0 
		public bool inProgress { get; } // 0x0000000181DD3FB0-0x0000000181DD4030 
		public bool ended { get; } // 0x0000000181DD3D90-0x0000000181DD3E00 
		public int touchId { get; } // 0x0000000181DD4620-0x0000000181DD4690 
		public float pressure { get; } // 0x0000000181DD41D0-0x0000000181DD4250 
		public Vector2 radius { get; } // 0x0000000181DD4250-0x0000000181DD42D0 
		public double startTime { get; } // 0x0000000181DD44B0-0x0000000181DD4530 
		public double time { get; } // 0x0000000181DD45E0-0x0000000181DD4620 
		public Touchscreen screen { get; } // 0x0000000181DD4350-0x0000000181DD43B0 
		public Vector2 screenPosition { get; } // 0x0000000181DD42D0-0x0000000181DD4350 
		public Vector2 startScreenPosition { get; } // 0x0000000181DD4430-0x0000000181DD44B0 
		public Vector2 delta { get; } // 0x0000000181DD3CA0-0x0000000181DD3D20 
		public int tapCount { get; } // 0x0000000181DD4570-0x0000000181DD45E0 
		public bool isTap { get; } // 0x0000000181DD4090-0x0000000181DD4110 
		public int displayIndex { get; } // 0x0000000181DD3D20-0x0000000181DD3D90 
		public bool isInProgress { get; } // 0x0000000181DD4030-0x0000000181DD4090 
		internal uint updateStepCount { get; } // 0x0000000181DD4700-0x0000000181DD4770 
		internal uint uniqueId { get; } // 0x0000000181DD4690-0x0000000181DD4700 
		private ref TouchState state { get; } // 0x0000000181DD4530-0x0000000181DD4570 
		private ref ExtraDataPerTouchState extraData { get; } // 0x0000000181DD3E00-0x0000000181DD3E40 
		public TouchHistory history { get; } // 0x0000000181DD3EC0-0x0000000181DD3FB0 
		public static ReadOnlyArray<Touch> activeTouches { get; } // 0x0000000181DD3BB0-0x0000000181DD3C50 
		public static ReadOnlyArray<Finger> fingers { get; } // 0x0000000181DD3E40-0x0000000181DD3EC0 
		public static ReadOnlyArray<Finger> activeFingers { get; } // 0x0000000181DD39D0-0x0000000181DD3BB0 
		public static IEnumerable<Touchscreen> screens { get; } // 0x0000000181DD43B0-0x0000000181DD4430 
		public static int maxHistoryLengthPerFinger { get; } // 0x0000000181DD4110-0x0000000181DD4160 
	
		// Events
		public static event Action<Finger> onFingerDown {
			add; // 0x0000000181DD3790-0x0000000181DD3850
			remove; // 0x0000000181DD4780-0x0000000181DD4840
		}
		public static event Action<Finger> onFingerUp {
			add; // 0x0000000181DD3910-0x0000000181DD39D0
			remove; // 0x0000000181DD4900-0x0000000181DD49C0
		}
		public static event Action<Finger> onFingerMove {
			add; // 0x0000000181DD3850-0x0000000181DD3910
			remove; // 0x0000000181DD4840-0x0000000181DD4900
		}
	
		// Nested types
		internal struct GlobalState // TypeDefIndex: 6361
		{
			// Fields
			internal InlinedArray<Touchscreen> touchscreens; // 0x00
			internal int historyLengthPerFinger; // 0x18
			internal CallbackArray<Action<Finger>> onFingerDown; // 0x20
			internal CallbackArray<Action<Finger>> onFingerMove; // 0x70
			internal CallbackArray<Action<Finger>> onFingerUp; // 0xC0
			internal FingerAndTouchState playerState; // 0x110
		}
	
		internal struct FingerAndTouchState // TypeDefIndex: 6362
		{
			// Fields
			public InputUpdateType updateMask; // 0x00
			public Finger[] fingers; // 0x08
			public Finger[] activeFingers; // 0x10
			public Touch[] activeTouches; // 0x18
			public int activeFingerCount; // 0x20
			public int activeTouchCount; // 0x24
			public int totalFingerCount; // 0x28
			public uint lastId; // 0x2C
			public bool haveBuiltActiveTouches; // 0x30
			public bool haveActiveTouchesNeedingRefreshNextUpdate; // 0x31
			public InputStateHistory<TouchState> activeTouchState; // 0x38
	
			// Methods
			public void AddFingers(Touchscreen screen); // 0x0000000181DC3BB0-0x0000000181DC3CD0
			public void RemoveFingers(Touchscreen screen); // 0x0000000181DC3D60-0x0000000181DC3E90
			public void Destroy(); // 0x0000000181DC3CD0-0x0000000181DC3D60
			public void UpdateActiveFingers(); // 0x0000000181DC3E90-0x0000000181DC3FD0
			public void UpdateActiveTouches(); // 0x0000000181DC3FD0-0x0000000181DC4690
		}
	
		internal struct ExtraDataPerTouchState // TypeDefIndex: 6363
		{
			// Fields
			public Vector2 accumulatedDelta; // 0x00
			public uint uniqueId; // 0x08
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 6364
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static SavedStructState<GlobalState> __9__80_0; // 0x08
			public static Action __9__80_1; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181DD4C60-0x0000000181DD4CD0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _SaveAndResetState_b__80_0(ref GlobalState state); // 0x0000000181DD4AB0-0x0000000181DD4C40
			internal void _SaveAndResetState_b__80_1(); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		internal Touch(Finger finger, InputStateHistory<TouchState> touchRecord); // 0x0000000180F378E0-0x0000000180F37920
		static Touch(); // 0x0000000181DD3690-0x0000000181DD3790
	
		// Methods
		public override string ToString(); // 0x0000000181DD32B0-0x0000000181DD3690
		public bool Equals(Touch other); // 0x0000000181DD2C70-0x0000000181DD2CE0
		public override bool Equals(object obj); // 0x0000000181DD2CE0-0x0000000181DD2DC0
		public override int GetHashCode(); // 0x0000000181DD2DC0-0x0000000181DD2E10
		internal static void AddTouchscreen(Touchscreen screen); // 0x0000000181DD2A40-0x0000000181DD2BE0
		internal static void RemoveTouchscreen(Touchscreen screen); // 0x0000000181DD2E10-0x0000000181DD3010
		internal static void BeginUpdate(); // 0x0000000181DD2BE0-0x0000000181DD2C40
		private static GlobalState CreateGlobalState(); // 0x0000000181DD2C40-0x0000000181DD2C70
		internal static ISavedState SaveAndResetState(); // 0x0000000181DD3010-0x0000000181DD32B0
	}
}
