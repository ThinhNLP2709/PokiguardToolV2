/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IntegerTime;
using UnityEngine;
using UnityEngine.Bindings;

// Image 43: UnityEngine.InputForUIModule.dll - Assembly: UnityEngine.InputForUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15251-15301

namespace UnityEngine.InputForUI
{
	[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
	internal struct PointerEvent : IEventProperties // TypeDefIndex: 15276
	{
		// Fields
		public Type type; // 0x00
		public int pointerIndex; // 0x04
		public Vector2 position; // 0x08
		public Vector2 deltaPosition; // 0x10
		public Vector3 worldPosition; // 0x18
		public Quaternion worldOrientation; // 0x24
		public float maxDistance; // 0x34
		public Vector2 scroll; // 0x38
		public int displayIndex; // 0x40
		public Vector2 tilt; // 0x44
		public float twist; // 0x4C
		public float pressure; // 0x50
		public bool isInverted; // 0x54
		public Button button; // 0x58
		public ButtonsState buttonsState; // 0x5C
		public int clickCount; // 0x60
		[CompilerGenerated]
		private DiscreteTime _timestamp_k__BackingField; // 0x68
		[CompilerGenerated]
		private EventSource _eventSource_k__BackingField; // 0x70
		[CompilerGenerated]
		private uint _playerId_k__BackingField; // 0x74
		[CompilerGenerated]
		private EventModifiers _eventModifiers_k__BackingField; // 0x78
	
		// Properties
		public bool isPrimaryPointer { get; } // 0x00000001822AC010-0x00000001822AC030 
		public Ray worldRay { get; } // 0x00000001822AC030-0x00000001822AC170 
		public float azimuth { get; } // 0x00000001822ABF40-0x00000001822AC010 
		public float altitude { get; } // 0x00000001822ABEF0-0x00000001822ABF40 
		public DiscreteTime timestamp { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180316960-0x0000000180316970 0x000000018033EA60-0x000000018033EA70
		public EventSource eventSource { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180CC2260-0x0000000180CC2270 0x0000000180CC2270-0x0000000180CC2280
		public uint playerId { [CompilerGenerated] set; } // 0x000000018198E760-0x000000018198E770
		public EventModifiers eventModifiers { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x000000018169BB50-0x000000018169BB60 0x00000001805936B0-0x00000001805936C0
	
		// Nested types
		public enum Type // TypeDefIndex: 15277
		{
			PointerMoved = 1,
			Scroll = 2,
			ButtonPressed = 3,
			ButtonReleased = 4,
			State = 5,
			TouchCanceled = 6,
			TrackedCanceled = 6
		}
	
		[Flags]
		public enum Button : uint // TypeDefIndex: 15278
		{
			None = 0,
			Primary = 1,
			FingerInTouch = 1,
			PenTipInTouch = 1,
			MouseLeft = 1,
			PenEraserInTouch = 2,
			MouseRight = 2,
			PenBarrelButton = 4,
			MouseMiddle = 4,
			MouseForward = 8,
			MouseBack = 16
		}
	
		public struct ButtonsState // TypeDefIndex: 15279
		{
			// Fields
			private uint _state; // 0x00
	
			// Methods
			public void Set(Button button, bool pressed); // 0x0000000181BC0E70-0x0000000181BC0E90
			public bool Get(Button button); // 0x00000001822A2AE0-0x00000001822A2AF0
			public void Reset(); // 0x00000001812C86B0-0x00000001812C86C0
			public override string ToString(); // 0x00000001822A2C60-0x00000001822A2CC0
		}
	
		// Methods
		public override string ToString(); // 0x00000001822AAF60-0x00000001822ABEF0
		internal static Button ButtonFromButtonIndex(int index); // 0x00000001822AAF50-0x00000001822AAF60
	}
}
