/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.InputForUI;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[EventCategory(EventCategory.Pointer)]
	public abstract class PointerEventBase<T> : EventBase<T>, IPointerEvent, IPointerEventInternal, IPointerOrMouseEvent // TypeDefIndex: 4107
		where T : PointerEventBase<T>, new()
	{
		// Fields
		private bool m_AltitudeNeedsConversion;
		private bool m_AzimuthNeedsConversion;
		private float m_AltitudeAngle;
		private float m_AzimuthAngle;
		private bool m_TiltNeeded;
		private Vector2 m_Tilt;
		[CompilerGenerated]
		private int _pointerId_k__BackingField;
		[CompilerGenerated]
		private string _pointerType_k__BackingField;
		[CompilerGenerated]
		private bool _isPrimary_k__BackingField;
		[CompilerGenerated]
		private int _button_k__BackingField;
		[CompilerGenerated]
		private int _pressedButtons_k__BackingField;
		[CompilerGenerated]
		private Vector3 _position_k__BackingField;
		[CompilerGenerated]
		private Vector3 _localPosition_k__BackingField;
		[CompilerGenerated]
		private Vector3 _deltaPosition_k__BackingField;
		[CompilerGenerated]
		private float _deltaTime_k__BackingField;
		[CompilerGenerated]
		private int _clickCount_k__BackingField;
		[CompilerGenerated]
		private float _pressure_k__BackingField;
		[CompilerGenerated]
		private float _tangentialPressure_k__BackingField;
		[CompilerGenerated]
		private float _twist_k__BackingField;
		[CompilerGenerated]
		private PenStatus _penStatus_k__BackingField;
		[CompilerGenerated]
		private Vector2 _radius_k__BackingField;
		[CompilerGenerated]
		private Vector2 _radiusVariance_k__BackingField;
		[CompilerGenerated]
		private UnityEngine.EventModifiers _modifiers_k__BackingField;
		[CompilerGenerated]
		private IMouseEvent _compatibilityMouseEvent_k__BackingField;
		[CompilerGenerated]
		private int _displayIndex_k__BackingField;
		[CompilerGenerated]
		private bool _recomputeTopElementUnderPointer_k__BackingField;
		[CompilerGenerated]
		private Ray? _panelRay_k__BackingField;
	
		// Properties
		public int pointerId { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public string pointerType { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public bool isPrimary { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public int button { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public int pressedButtons { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public Vector3 position { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public Vector3 localPosition { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public Vector3 deltaPosition { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public float deltaTime { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public int clickCount { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public float pressure { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public float tangentialPressure { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public float altitudeAngle { get; protected set; }
		public float azimuthAngle { get; protected set; }
		public float twist { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public Vector2 tilt { get; protected set; }
		public PenStatus penStatus { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public Vector2 radius { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public Vector2 radiusVariance { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public UnityEngine.EventModifiers modifiers { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public bool shiftKey { get; }
		public bool ctrlKey { get; }
		public bool commandKey { get; }
		public bool altKey { get; }
		internal IMouseEvent compatibilityMouseEvent { [CompilerGenerated] get; [CompilerGenerated] set; }
		internal int displayIndex { [CompilerGenerated] set; }
		internal bool recomputeTopElementUnderPointer { [CompilerGenerated] get; [CompilerGenerated] set; }
		internal Ray? panelRay { [CompilerGenerated] get; [CompilerGenerated] set; }
		IMouseEvent IPointerEventInternal.compatibilityMouseEvent { get; }
		Ray? IPointerOrMouseEvent.panelRay { get; }
		public override IEventHandler currentTarget { get; internal set; }
	
		// Constructors
		protected PointerEventBase();
	
		// Methods
		protected override void Init();
		private new void LocalInit();
		private static float TiltToAzimuth(Vector2 tilt);
		private static Vector2 AzimuthAndAlitutudeToTilt(float altitude, float azimuth);
		private static float TiltToAltitude(Vector2 tilt);
		internal static T GetPooled(PointerEvent pointerEvent, Vector3 position, int pointerId, float deltaTime);
		internal static T GetPooled(IPointerEvent triggerEvent, Vector2 position, int pointerId);
		public static T GetPooled(IPointerEvent triggerEvent);
		internal virtual IMouseEvent GetPooledCompatibilityMouseEvent();
		protected internal override void PreDispatch(IPanel panel);
		protected internal override void PostDispatch(IPanel panel);
		internal override void Dispatch(BaseVisualElementPanel panel);
	}
}
