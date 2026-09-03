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
	[EventCategory(EventCategory.Command)]
	public abstract class CommandEventBase<T> : EventBase<T> // TypeDefIndex: 3962
		where T : CommandEventBase<T>, new()
	{
		// Fields
		private string m_CommandName;
	
		// Properties
		public string commandName { get; protected set; }
	
		// Constructors
		protected CommandEventBase();
	
		// Methods
		protected override void Init();
		private new void LocalInit();
		public static T GetPooled(string commandName);
		internal override void Dispatch(BaseVisualElementPanel panel);
	}
}
