/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public class NavigationMoveEvent : NavigationEventBase<NavigationMoveEvent> // TypeDefIndex: 4083
	{
		// Fields
		[CompilerGenerated]
		private Direction _direction_k__BackingField; // 0x70
		[CompilerGenerated]
		private Vector2 _move_k__BackingField; // 0x74
	
		// Properties
		public Direction direction { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180CC2260-0x0000000180CC2270 0x0000000180CC2270-0x0000000180CC2280
		public Vector2 move { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180BE5D30-0x0000000180BE5D50 0x0000000180BE5ED0-0x0000000180BE5EE0
	
		// Nested types
		public enum Direction // TypeDefIndex: 4084
		{
			None = 0,
			Left = 1,
			Up = 2,
			Right = 3,
			Down = 4,
			Next = 5,
			Previous = 6
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4085
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824AB2E0-0x00000001824AB350
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal NavigationMoveEvent _.cctor_b__0_0(); // 0x00000001824A9AA0-0x00000001824A9B30
		}
	
		// Constructors
		static NavigationMoveEvent(); // 0x00000001824A03A0-0x00000001824A0480
		public NavigationMoveEvent(); // 0x00000001824A0480-0x00000001824A04F0
	
		// Methods
		internal static Direction DetermineMoveDirection(float x, float y, float deadZone = 0.6f /* Metadata: 0x00660501 */); // 0x00000001824A0070-0x00000001824A00F0
		internal static NavigationMoveEvent GetPooled(Vector2 moveVector, NavigationDeviceType deviceType, EventModifiers modifiers = EventModifiers.None /* Metadata: 0x00660505 */); // 0x00000001824A00F0-0x00000001824A01F0
		[VisibleToOtherModules(new string[1] {"UnityEditor.GraphToolkitModule" })]
		internal static NavigationMoveEvent GetPooled(Direction direction, NavigationDeviceType deviceType, EventModifiers modifiers = EventModifiers.None /* Metadata: 0x00660506 */); // 0x00000001824A01F0-0x00000001824A0280
		protected override void Init(); // 0x00000001824A0280-0x00000001824A02C0
		private new void LocalInit(); // 0x00000001824A02C0-0x00000001824A02F0
		protected internal override void PostDispatch(IPanel panel); // 0x00000001824A02F0-0x00000001824A03A0
	}
}
