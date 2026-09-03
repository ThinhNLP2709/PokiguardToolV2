/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal abstract class BaseVisualTreeUpdater : IVisualTreeUpdater // TypeDefIndex: 4983
	{
		// Fields
		private long frameCount; // 0x10
		[CompilerGenerated]
		private Action<BaseVisualElementPanel> panelChanged; // 0x18
		private BaseVisualElementPanel m_Panel; // 0x20
	
		// Properties
		long IVisualTreeUpdater.FrameCount { get; set; } // 0x0000000180377550-0x0000000180377560 0x0000000180719060-0x0000000180719070
		public BaseVisualElementPanel panel { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x00000001823F12E0-0x00000001823F1330
		public VisualElement visualTree { get; } // 0x00000001823F11F0-0x00000001823F1220 
		public abstract ProfilerMarker profilerMarker { get; }
	
		// Events
		public event Action<BaseVisualElementPanel> panelChanged {
			add; // 0x00000001823F1130-0x00000001823F11F0
			remove; // 0x00000001823F1220-0x00000001823F12E0
		}
	
		// Constructors
		protected BaseVisualTreeUpdater(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Dispose(); // 0x00000001823F10C0-0x00000001823F1130
		protected virtual void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
		public abstract void Update();
		public abstract void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType);
	}
}
