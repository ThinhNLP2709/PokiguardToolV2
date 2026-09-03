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
	[Serializable]
	[UxmlObject]
	public abstract class Binding // TypeDefIndex: 3818
	{
		// Fields
		private bool m_Dirty; // 0x10
		private BindingUpdateTrigger m_UpdateTrigger; // 0x14
	
		// Properties
		public bool isDirty { get; } // 0x00000001805625D0-0x00000001805625E0 
		[CreateProperty]
		[HideInInspector]
		[Tooltip("This informs the binding system of whether the binding object should be updated on every frame, when a change occurs in the source or on every frame if change detection is impossible, and when explicitly marked as dirty.")]
		[UxmlAttribute]
		public BindingUpdateTrigger updateTrigger { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
	
		// Constructors
		internal Binding(); // 0x0000000181750370-0x0000000181750390
	
		// Methods
		public static void SetGlobalLogLevel(BindingLogLevel logLevel); // 0x00000001823817B0-0x0000000182381810
		public static BindingLogLevel GetGlobalLogLevel(); // 0x0000000182381640-0x00000001823816A0
		public static void SetPanelLogLevel(IPanel panel, BindingLogLevel logLevel); // 0x0000000182381810-0x00000001823818C0
		public static BindingLogLevel GetPanelLogLevel(IPanel panel); // 0x00000001823816A0-0x0000000182381730
		public static void ResetPanelLogLevel(IPanel panel); // 0x0000000182381730-0x00000001823817B0
		public void MarkDirty(); // 0x000000018030F220-0x000000018030F230
		internal void ClearDirty(); // 0x0000000181738210-0x0000000181738220
		protected internal virtual void OnActivated([IsReadOnly] in BindingActivationContext context); // 0x00000001802E76C0-0x00000001802E76D0
		protected internal virtual void OnDeactivated([IsReadOnly] in BindingActivationContext context); // 0x00000001802E76C0-0x00000001802E76D0
		protected internal virtual void OnDataSourceChanged([IsReadOnly] in DataSourceContextChanged context); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
