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
	[EventCategory(EventCategory.StyleTransition)]
	public abstract class TransitionEventBase<T> : EventBase<T>, IProfilerIgnoredEvent // TypeDefIndex: 4134
		where T : TransitionEventBase<T>, new()
	{
		// Fields
		[CompilerGenerated]
		private readonly StylePropertyNameCollection _stylePropertyNames_k__BackingField;
		[CompilerGenerated]
		private double _elapsedTime_k__BackingField;
	
		// Properties
		public StylePropertyNameCollection stylePropertyNames { [CompilerGenerated] get; }
		protected double elapsedTime { [CompilerGenerated] set; }
	
		// Constructors
		protected TransitionEventBase();
	
		// Methods
		protected override void Init();
		private new void LocalInit();
		public static T GetPooled(StylePropertyName stylePropertyName, double elapsedTime);
	}
}
