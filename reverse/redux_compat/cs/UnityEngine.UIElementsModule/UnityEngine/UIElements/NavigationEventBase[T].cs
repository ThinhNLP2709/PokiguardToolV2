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
	[EventCategory(EventCategory.Navigation)]
	public abstract class NavigationEventBase<T> : EventBase<T>, INavigationEvent // TypeDefIndex: 4081
		where T : NavigationEventBase<T>, new()
	{
		// Fields
		[CompilerGenerated]
		private EventModifiers _modifiers_k__BackingField;
		[CompilerGenerated]
		private NavigationDeviceType _deviceType_k__BackingField;
	
		// Properties
		public EventModifiers modifiers { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public bool shiftKey { get; }
		internal NavigationDeviceType deviceType { [VisibleToOtherModules(new string[1] {"UnityEditor.GraphToolkitModule" })] [CompilerGenerated] get; [CompilerGenerated] private set; }
	
		// Constructors
		protected NavigationEventBase();
	
		// Methods
		protected override void Init();
		private new void LocalInit();
		[VisibleToOtherModules(new string[1] {"UnityEditor.GraphToolkitModule" })]
		internal static T GetPooled(NavigationDeviceType deviceType, EventModifiers modifiers = EventModifiers.None /* Metadata: 0x006604F9 */);
		internal override void Dispatch(BaseVisualElementPanel panel);
	}
}
