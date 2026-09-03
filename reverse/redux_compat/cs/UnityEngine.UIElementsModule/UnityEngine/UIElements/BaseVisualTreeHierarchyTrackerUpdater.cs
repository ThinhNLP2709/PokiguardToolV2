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
	internal abstract class BaseVisualTreeHierarchyTrackerUpdater : BaseVisualTreeUpdater // TypeDefIndex: 4970
	{
		// Fields
		private State m_State; // 0x28
		private VisualElement m_CurrentChangeElement; // 0x30
		private VisualElement m_CurrentChangeParent; // 0x38
	
		// Nested types
		private enum State // TypeDefIndex: 4971
		{
			Waiting = 0,
			TrackingAddOrMove = 1,
			TrackingRemove = 2
		}
	
		// Constructors
		protected BaseVisualTreeHierarchyTrackerUpdater(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		protected abstract void OnHierarchyChange(VisualElement ve, HierarchyChangeType type);
		public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType); // 0x00000001823F0B90-0x00000001823F0D90
		public override void Update(); // 0x00000001823F1000-0x00000001823F10C0
		private void ProcessNewChange(VisualElement ve); // 0x00000001823F0EC0-0x00000001823F0F60
		private void ProcessAddOrMove(VisualElement ve); // 0x00000001823F0D90-0x00000001823F0EC0
		private void ProcessRemove(VisualElement ve); // 0x00000001823F0F60-0x00000001823F1000
	}
}
