/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[MovedFrom(true, "UnityEditor.UIElements", "UnityEditor.UIElementsModule", null)]
	public class FieldMouseDragger<T> : BaseFieldMouseDragger // TypeDefIndex: 4146
	{
		// Fields
		private readonly IValueField<T> m_DrivenField;
		private VisualElement m_DragElement;
		private Rect m_DragHotZone;
		[CompilerGenerated]
		private bool _dragging_k__BackingField;
		[CompilerGenerated]
		private T _startValue_k__BackingField;
		private static readonly EventCallbackGroupFactory<FieldMouseDragger<T>> k_CallbackFactory;
		private EventCallbackGroupFactory<FieldMouseDragger<T>> m_RegisteredCallbacks;
	
		// Properties
		public bool dragging { [CompilerGenerated] get; [CompilerGenerated] set; }
		public T startValue { [CompilerGenerated] get; [CompilerGenerated] set; }
	
		// Nested types
		private class Callbacks // TypeDefIndex: 4147
		{
			// Fields
			public readonly EventCallbackGroup OnDragElementPointerAndKeyDown;
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 4148
			{
				// Fields
				public static readonly __c<T> __9;
				public static EventCallback<PointerDownEvent, FieldMouseDragger<T>> __9__1_0;
				public static EventCallback<PointerUpEvent, FieldMouseDragger<T>> __9__1_1;
				public static EventCallback<KeyDownEvent, FieldMouseDragger<T>> __9__1_2;
	
				// Constructors
				static __c();
				public __c();
	
				// Methods
				internal void _.ctor_b__1_0(PointerDownEvent e, FieldMouseDragger<T> self);
				internal void _.ctor_b__1_1(PointerUpEvent e, FieldMouseDragger<T> self);
				internal void _.ctor_b__1_2(KeyDownEvent e, FieldMouseDragger<T> self);
			}
	
			// Constructors
			public Callbacks(EventArg<FieldMouseDragger<T>> arg);
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4149
		{
			// Fields
			public static readonly __c<T> __9;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal EventCallbackGroup _.cctor_b__24_0(EventArg<FieldMouseDragger<T>> arg);
		}
	
		// Constructors
		public FieldMouseDragger(IValueField<T> drivenField);
		static FieldMouseDragger();
	
		// Methods
		public sealed override void SetDragZone(VisualElement dragElement, Rect hotZone);
		private bool CanStartDrag(int button, Vector2 localPosition);
		private void UpdateValueOnPointerDown(PointerDownEvent evt);
		private void ProcessDownEvent(EventBase evt);
		private void UpdateValueOnPointerMove(PointerMoveEvent evt);
		private void ProcessMoveEvent(bool shiftKey, bool altKey, Vector2 deltaPosition);
		private void UpdateValueOnPointerUp(PointerUpEvent evt);
		private void ProcessUpEvent(EventBase evt, int pointerId);
		private void UpdateValueOnKeyDown(KeyDownEvent evt);
	}
}
