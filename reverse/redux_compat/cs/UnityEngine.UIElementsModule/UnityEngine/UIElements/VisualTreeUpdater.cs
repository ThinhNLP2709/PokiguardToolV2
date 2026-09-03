/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal sealed class VisualTreeUpdater : IDisposable // TypeDefIndex: 4980
	{
		// Fields
		private BaseVisualElementPanel m_Panel; // 0x10
		private UpdaterArray m_UpdaterArray; // 0x18
	
		// Nested types
		private class UpdaterArray // TypeDefIndex: 4981
		{
			// Fields
			private IVisualTreeUpdater[] m_VisualTreeUpdaters; // 0x10
	
			// Properties
			public IVisualTreeUpdater this[VisualTreeUpdatePhase phase] { get => default; set {} } // 0x0000000181ACD1B0-0x0000000181ACD1E0 0x0000000182401130-0x00000001824011B0
			public IVisualTreeUpdater this[int index] { get => default; } // 0x0000000181ACD1B0-0x0000000181ACD1E0 
	
			// Constructors
			public UpdaterArray(); // 0x00000001824010D0-0x0000000182401130
		}
	
		// Constructors
		public VisualTreeUpdater(BaseVisualElementPanel panel); // 0x0000000182406A20-0x0000000182406BF0
	
		// Methods
		public void Dispose(); // 0x0000000182406290-0x00000001824063C0
		public void UpdateVisualTreePhase(VisualTreeUpdatePhase phase); // 0x00000001824067E0-0x0000000182406A20
		public void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType); // 0x0000000182406400-0x0000000182406540
		public void SetUpdater(IVisualTreeUpdater updater, VisualTreeUpdatePhase phase); // 0x0000000182406660-0x00000001824067E0
		public void SetUpdater<T>(VisualTreeUpdatePhase phase)
			where T : IVisualTreeUpdater, new();
		public IVisualTreeUpdater GetUpdater(VisualTreeUpdatePhase phase); // 0x00000001824063C0-0x0000000182406400
		private void SetDefaultUpdaters(); // 0x0000000182406540-0x0000000182406660
	}
}
