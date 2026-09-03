/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 23: UnityEngine.IMGUIModule.dll - Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13910-13956

namespace UnityEngine
{
	internal struct SliderHandler // TypeDefIndex: 13954
	{
		// Fields
		private readonly Rect position; // 0x00
		private readonly float currentValue; // 0x10
		private readonly float size; // 0x14
		private readonly float start; // 0x18
		private readonly float end; // 0x1C
		private readonly GUIStyle slider; // 0x20
		private readonly GUIStyle thumb; // 0x28
		private readonly GUIStyle thumbExtent; // 0x30
		private readonly bool horiz; // 0x38
		private readonly int id; // 0x3C
	
		// Constructors
		public SliderHandler(Rect position, float currentValue, float size, float start, float end, GUIStyle slider, GUIStyle thumb, bool horiz, int id, GUIStyle thumbExtent = null); // 0x00000001822A0E70-0x00000001822A0EF0
	
		// Methods
		public float Handle(); // 0x000000018229F0E0-0x000000018229F370
		private float OnMouseDown(); // 0x000000018229F770-0x000000018229FC70
		private float OnMouseDrag(); // 0x000000018229FC70-0x000000018229FDE0
		private float OnMouseUp(); // 0x000000018229FDE0-0x000000018229FE80
		private float OnRepaint(); // 0x000000018229FE80-0x00000001822A0460
		private EventType CurrentEventType(); // 0x000000018229EF40-0x000000018229EFA0
		private int CurrentScrollTroughSide(); // 0x000000018229EFA0-0x000000018229F0E0
		private bool IsEmptySlider(); // 0x000000018229F630-0x000000018229F650
		private bool SupportsPageMovements(); // 0x00000001822A0790-0x00000001822A07F0
		private float PageMovementValue(); // 0x00000001822A0460-0x00000001822A05A0
		private float PageUpMovementBound(); // 0x00000001822A05A0-0x00000001822A0660
		private Event CurrentEvent(); // 0x0000000181C15620-0x0000000181C15D20
		private float ValueForCurrentMousePosition(); // 0x00000001822A0A10-0x00000001822A0B20
		private float Clamp(float value); // 0x000000018229EEE0-0x000000018229EF10
		private Rect ThumbSelectionRect(); // 0x00000001822A0910-0x00000001822A0950
		private void StartDraggingWithValue(float dragStartValue); // 0x00000001822A0730-0x00000001822A0790
		private SliderState SliderState(); // 0x00000001822A0660-0x00000001822A0730
		private Rect ThumbExtRect(); // 0x00000001822A07F0-0x00000001822A0910
		private Rect ThumbRect(); // 0x00000001822A0910-0x00000001822A0950
		private Rect VerticalThumbRect(); // 0x00000001822A0C20-0x00000001822A0E70
		private Rect HorizontalThumbRect(); // 0x000000018229F370-0x000000018229F630
		private float ClampedCurrentValue(); // 0x000000018229EF10-0x000000018229EF40
		private float MousePosition(); // 0x000000018229F670-0x000000018229F770
		private float ValuesPerPixel(); // 0x00000001822A0B20-0x00000001822A0C20
		private float ThumbSize(); // 0x00000001822A0950-0x00000001822A0A10
		private float MaxValue(); // 0x000000018229F650-0x000000018229F660
		private float MinValue(); // 0x000000018229F660-0x000000018229F670
	}
}
