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
	[EventCategory(EventCategory.Pointer)]
	public abstract class MouseEventBase<T> : EventBase<T>, IMouseEvent, IMouseEventInternal, IPointerOrMouseEvent // TypeDefIndex: 4054
		where T : MouseEventBase<T>, new()
	{
		// Fields
		[CompilerGenerated]
		private EventModifiers _modifiers_k__BackingField;
		[CompilerGenerated]
		private Vector2 _mousePosition_k__BackingField;
		[CompilerGenerated]
		private Vector2 _localMousePosition_k__BackingField;
		[CompilerGenerated]
		private Vector2 _mouseDelta_k__BackingField;
		[CompilerGenerated]
		private int _clickCount_k__BackingField;
		[CompilerGenerated]
		private int _button_k__BackingField;
		[CompilerGenerated]
		private int _pressedButtons_k__BackingField;
		[CompilerGenerated]
		private IPointerEvent _sourcePointerEvent_k__BackingField;
		[CompilerGenerated]
		private bool _recomputeTopElementUnderMouse_k__BackingField;
		[CompilerGenerated]
		private Ray? _panelRay_k__BackingField;
	
		// Properties
		public EventModifiers modifiers { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public Vector2 mousePosition { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public Vector2 localMousePosition { [CompilerGenerated] get; [CompilerGenerated] internal set; }
		public Vector2 mouseDelta { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public int clickCount { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public int button { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public int pressedButtons { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public bool ctrlKey { get; }
		public bool commandKey { get; }
		internal IPointerEvent sourcePointerEvent { [CompilerGenerated] get; [CompilerGenerated] set; }
		internal bool recomputeTopElementUnderMouse { [CompilerGenerated] get; [CompilerGenerated] set; }
		internal Ray? panelRay { [CompilerGenerated] get; [CompilerGenerated] set; }
		IPointerEvent IMouseEventInternal.sourcePointerEvent { get; }
		Vector3 IPointerOrMouseEvent.position { get; }
		Ray? IPointerOrMouseEvent.panelRay { get; }
		public override IEventHandler currentTarget { get; internal set; }
	
		// Constructors
		protected MouseEventBase();
	
		// Methods
		protected override void Init();
		private new void LocalInit();
		protected internal override void PreDispatch(IPanel panel);
		protected internal override void PostDispatch(IPanel panel);
		internal override void Dispatch(BaseVisualElementPanel panel);
		internal static T GetPooled(IMouseEvent triggerEvent, Vector2 mousePosition);
		public static T GetPooled(IMouseEvent triggerEvent);
		protected static T GetPooled(IPointerEvent pointerEvent);
	}
}
