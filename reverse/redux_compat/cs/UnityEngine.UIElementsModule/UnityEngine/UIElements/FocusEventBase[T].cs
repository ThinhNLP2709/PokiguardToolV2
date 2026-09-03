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
	[EventCategory(EventCategory.Focus)]
	public abstract class FocusEventBase<T> : EventBase<T> // TypeDefIndex: 4030
		where T : FocusEventBase<T>, new()
	{
		// Fields
		[CompilerGenerated]
		private Focusable _relatedTarget_k__BackingField;
		[CompilerGenerated]
		private FocusChangeDirection _direction_k__BackingField;
		[CompilerGenerated]
		private FocusController _focusController_k__BackingField;
		[CompilerGenerated]
		private bool _IsFocusDelegated_k__BackingField;
	
		// Properties
		public Focusable relatedTarget { [CompilerGenerated] get; [CompilerGenerated] private set; }
		private FocusChangeDirection direction { [CompilerGenerated] set; }
		protected FocusController focusController { [CompilerGenerated] get; [CompilerGenerated] private set; }
		private bool IsFocusDelegated { [CompilerGenerated] set; }
	
		// Constructors
		protected FocusEventBase();
	
		// Methods
		protected override void Init();
		private new void LocalInit();
		public static T GetPooled(IEventHandler target, Focusable relatedTarget, FocusChangeDirection direction, FocusController focusController, bool bIsFocusDelegated = false /* Metadata: 0x006604F4 */);
	}
}
