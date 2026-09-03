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
	public abstract class PointerCaptureEventBase<T> : EventBase<T> // TypeDefIndex: 3950
		where T : PointerCaptureEventBase<T>, new()
	{
		// Fields
		[CompilerGenerated]
		private IEventHandler _relatedTarget_k__BackingField;
		[CompilerGenerated]
		private int _pointerId_k__BackingField;
	
		// Properties
		private IEventHandler relatedTarget { [CompilerGenerated] set; }
		public int pointerId { [CompilerGenerated] get; [CompilerGenerated] private set; }
	
		// Constructors
		protected PointerCaptureEventBase();
	
		// Methods
		protected override void Init();
		private new void LocalInit();
		public static T GetPooled(IEventHandler target, IEventHandler relatedTarget, int pointerId);
	}
}
