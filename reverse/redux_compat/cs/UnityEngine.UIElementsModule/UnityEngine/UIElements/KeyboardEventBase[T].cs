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
	[EventCategory(EventCategory.Keyboard)]
	public abstract class KeyboardEventBase<T> : EventBase<T>, IKeyboardEvent // TypeDefIndex: 4044
		where T : KeyboardEventBase<T>, new()
	{
		// Fields
		[CompilerGenerated]
		private EventModifiers _modifiers_k__BackingField;
		[CompilerGenerated]
		private char _character_k__BackingField;
		[CompilerGenerated]
		private KeyCode _keyCode_k__BackingField;
	
		// Properties
		public EventModifiers modifiers { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public char character { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public KeyCode keyCode { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public bool shiftKey { get; }
		public bool ctrlKey { get; }
		public bool commandKey { get; }
		public bool altKey { get; }
		internal bool functionKey { get; }
		public bool actionKey { get; }
	
		// Constructors
		protected KeyboardEventBase();
	
		// Methods
		protected override void Init();
		private new void LocalInit();
		public static T GetPooled(char c, KeyCode keyCode, EventModifiers modifiers);
		internal override void Dispatch(BaseVisualElementPanel panel);
	}
}
