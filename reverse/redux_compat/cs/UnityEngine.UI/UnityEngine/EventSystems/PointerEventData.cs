/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.EventSystems
{
	public class PointerEventData : BaseEventData // TypeDefIndex: 13164
	{
		// Fields
		[CompilerGenerated]
		private GameObject _pointerEnter_k__BackingField; // 0x20
		private GameObject m_PointerPress; // 0x28
		[CompilerGenerated]
		private GameObject _lastPress_k__BackingField; // 0x30
		[CompilerGenerated]
		private GameObject _rawPointerPress_k__BackingField; // 0x38
		[CompilerGenerated]
		private GameObject _pointerDrag_k__BackingField; // 0x40
		[CompilerGenerated]
		private GameObject _pointerClick_k__BackingField; // 0x48
		[CompilerGenerated]
		private RaycastResult _pointerCurrentRaycast_k__BackingField; // 0x50
		[CompilerGenerated]
		private RaycastResult _pointerPressRaycast_k__BackingField; // 0xC0
		public List<GameObject> hovered; // 0x130
		[CompilerGenerated]
		private bool _eligibleForClick_k__BackingField; // 0x138
		[CompilerGenerated]
		private int _displayIndex_k__BackingField; // 0x13C
		[CompilerGenerated]
		private int _pointerId_k__BackingField; // 0x140
		[CompilerGenerated]
		private Vector2 _position_k__BackingField; // 0x144
		[CompilerGenerated]
		private Vector2 _delta_k__BackingField; // 0x14C
		[CompilerGenerated]
		private Vector2 _pressPosition_k__BackingField; // 0x154
		[CompilerGenerated]
		private Vector3 _worldPosition_k__BackingField; // 0x15C
		[CompilerGenerated]
		private Vector3 _worldNormal_k__BackingField; // 0x168
		[CompilerGenerated]
		private float _clickTime_k__BackingField; // 0x174
		[CompilerGenerated]
		private int _clickCount_k__BackingField; // 0x178
		[CompilerGenerated]
		private Vector2 _scrollDelta_k__BackingField; // 0x17C
		[CompilerGenerated]
		private bool _useDragThreshold_k__BackingField; // 0x184
		[CompilerGenerated]
		private bool _dragging_k__BackingField; // 0x185
		[CompilerGenerated]
		private InputButton _button_k__BackingField; // 0x188
		[CompilerGenerated]
		private float _pressure_k__BackingField; // 0x18C
		[CompilerGenerated]
		private float _tangentialPressure_k__BackingField; // 0x190
		[CompilerGenerated]
		private float _altitudeAngle_k__BackingField; // 0x194
		[CompilerGenerated]
		private float _azimuthAngle_k__BackingField; // 0x198
		[CompilerGenerated]
		private float _twist_k__BackingField; // 0x19C
		[CompilerGenerated]
		private Vector2 _tilt_k__BackingField; // 0x1A0
		[CompilerGenerated]
		private PenStatus _penStatus_k__BackingField; // 0x1A8
		[CompilerGenerated]
		private Vector2 _radius_k__BackingField; // 0x1AC
		[CompilerGenerated]
		private Vector2 _radiusVariance_k__BackingField; // 0x1B4
		[CompilerGenerated]
		private bool _fullyExited_k__BackingField; // 0x1BC
		[CompilerGenerated]
		private bool _reentered_k__BackingField; // 0x1BD
	
		// Properties
		public GameObject pointerEnter { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public GameObject lastPress { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public GameObject rawPointerPress { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		public GameObject pointerDrag { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		public GameObject pointerClick { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		public RaycastResult pointerCurrentRaycast { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B7F00-0x00000001825B7F50 0x00000001825B8230-0x00000001825B8280
		public RaycastResult pointerPressRaycast { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B7F50-0x00000001825B7FA0 0x00000001825B8290-0x00000001825B82F0
		public bool eligibleForClick { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D280-0x000000018033D290 0x000000018033E890-0x000000018033E8A0
		public int displayIndex { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001824DAB20-0x00000001824DAB30 0x00000001825B81F0-0x00000001825B8200
		public int pointerId { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001824DAAC0-0x00000001824DAAD0 0x00000001825B8280-0x00000001825B8290
		public Vector2 position { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B7FA0-0x00000001825B7FC0 0x00000001825B8380-0x00000001825B8390
		public Vector2 delta { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B7E10-0x00000001825B7E30 0x00000001825B81E0-0x00000001825B81F0
		public Vector2 pressPosition { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B8060-0x00000001825B8080 0x00000001825B8390-0x00000001825B83A0
		[Obsolete("Use either pointerCurrentRaycast.worldPosition or pointerPressRaycast.worldPosition", true)]
		public Vector3 worldPosition { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B8170-0x00000001825B8190 0x00000001825B8450-0x00000001825B8470
		[Obsolete("Use either pointerCurrentRaycast.worldNormal or pointerPressRaycast.worldNormal", true)]
		public Vector3 worldNormal { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B8150-0x00000001825B8170 0x00000001825B8430-0x00000001825B8450
		public float clickTime { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B7E00-0x00000001825B7E10 0x00000001825B81D0-0x00000001825B81E0
		public int clickCount { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181974850-0x0000000181974860 0x00000001825B81C0-0x00000001825B81D0
		public Vector2 scrollDelta { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B80E0-0x00000001825B8100 0x00000001825B83E0-0x00000001825B83F0
		public bool useDragThreshold { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B8140-0x00000001825B8150 0x00000001825B8420-0x00000001825B8430
		public bool dragging { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B7E30-0x00000001825B7E40 0x00000001825B8200-0x00000001825B8210
		public InputButton button { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182093660-0x0000000182093670 0x00000001825B81B0-0x00000001825B81C0
		public float pressure { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B8080-0x00000001825B8090 0x00000001825B83A0-0x00000001825B83B0
		public float tangentialPressure { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B8100-0x00000001825B8110 0x00000001825B83F0-0x00000001825B8400
		public float altitudeAngle { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B7DF0-0x00000001825B7E00 0x00000001825B8190-0x00000001825B81A0
		public float azimuthAngle { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181E65020-0x0000000181E65030 0x00000001825B81A0-0x00000001825B81B0
		public float twist { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B8130-0x00000001825B8140 0x00000001825B8410-0x00000001825B8420
		public Vector2 tilt { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B8110-0x00000001825B8130 0x00000001825B8400-0x00000001825B8410
		public PenStatus penStatus { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B7EF0-0x00000001825B7F00 0x00000001825B8220-0x00000001825B8230
		public Vector2 radius { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B80B0-0x00000001825B80D0 0x00000001825B83C0-0x00000001825B83D0
		public Vector2 radiusVariance { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B8090-0x00000001825B80B0 0x00000001825B83B0-0x00000001825B83C0
		public bool fullyExited { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B7EE0-0x00000001825B7EF0 0x00000001825B8210-0x00000001825B8220
		public bool reentered { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001825B80D0-0x00000001825B80E0 0x00000001825B83D0-0x00000001825B83E0
		public Camera enterEventCamera { get; } // 0x00000001825B7E40-0x00000001825B7EE0 
		public Camera pressEventCamera { get; } // 0x00000001825B7FC0-0x00000001825B8060 
		public GameObject pointerPress { get; set; } // 0x000000018033D240-0x000000018033D250 0x00000001825B82F0-0x00000001825B8380
	
		// Nested types
		public enum InputButton // TypeDefIndex: 13165
		{
			Left = 0,
			Right = 1,
			Middle = 2
		}
	
		public enum FramePressState // TypeDefIndex: 13166
		{
			Pressed = 0,
			Released = 1,
			PressedAndReleased = 2,
			NotChanged = 3
		}
	
		// Constructors
		public PointerEventData(EventSystem eventSystem); // 0x00000001825B7C30-0x00000001825B7DF0
	
		// Methods
		public bool IsPointerMoving(); // 0x00000001825B7500-0x00000001825B7530
		public bool IsScrolling(); // 0x00000001825B7530-0x00000001825B7560
		public override string ToString(); // 0x00000001825B7560-0x00000001825B7C30
	}
}
