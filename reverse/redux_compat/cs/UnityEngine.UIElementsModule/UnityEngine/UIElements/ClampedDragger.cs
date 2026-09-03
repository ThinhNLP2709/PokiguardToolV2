/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class ClampedDragger : Clickable // TypeDefIndex: 3863
	{
		// Fields
		[CompilerGenerated]
		private Action dragging; // 0x78
		[CompilerGenerated]
		private Action draggingEnded; // 0x80
		[CompilerGenerated]
		private DragDirection _dragDirection_k__BackingField; // 0x88
		[CompilerGenerated]
		private Vector2 _startMousePosition_k__BackingField; // 0x8C
	
		// Properties
		public DragDirection dragDirection { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D620-0x000000018033D630 0x000000018033EC00-0x000000018033EC10
		public Vector2 startMousePosition { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000182382A50-0x0000000182382A70 0x000000018172A430-0x000000018172A440
		public Vector2 delta { get; } // 0x0000000182382A20-0x0000000182382A50 
	
		// Events
		public event Action dragging {
			add; // 0x0000000182382980-0x0000000182382A20
			remove; // 0x0000000182382B20-0x0000000182382BC0
		}
		public event Action draggingEnded {
			add; // 0x00000001823828D0-0x0000000182382980
			remove; // 0x0000000182382A70-0x0000000182382B20
		}
	
		// Nested types
		[Flags]
		public enum DragDirection // TypeDefIndex: 3864
		{
			None = 0,
			LowToHigh = 1,
			HighToLow = 2,
			Free = 4
		}
	
		// Constructors
		public ClampedDragger(Action clickHandler, Action dragHandler); // 0x00000001823826F0-0x00000001823828D0
	
		// Methods
		protected override void ProcessDownEvent(EventBase evt, Vector2 localPosition, int pointerId); // 0x0000000182382460-0x00000001823824B0
		protected override void ProcessUpEvent(EventBase evt, Vector2 localPosition, int pointerId); // 0x00000001823826B0-0x00000001823826F0
		protected override void ProcessMoveEvent(EventBase evt, Vector2 localPosition); // 0x00000001823824B0-0x00000001823826B0
	}
}
