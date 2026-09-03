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
	[EventCategory(EventCategory.ChangePanel)]
	public abstract class PanelChangedEventBase<T> : EventBase<T>, IProfilerIgnoredEvent // TypeDefIndex: 4090
		where T : PanelChangedEventBase<T>, new()
	{
		// Fields
		[CompilerGenerated]
		private IPanel _originPanel_k__BackingField;
		[CompilerGenerated]
		private IPanel _destinationPanel_k__BackingField;
	
		// Properties
		public IPanel originPanel { [CompilerGenerated] get; [CompilerGenerated] private set; }
		public IPanel destinationPanel { [CompilerGenerated] get; [CompilerGenerated] private set; }
	
		// Constructors
		protected PanelChangedEventBase();
	
		// Methods
		protected override void Init();
		private new void LocalInit();
		public static T GetPooled(IPanel originPanel, IPanel destinationPanel);
	}
}
