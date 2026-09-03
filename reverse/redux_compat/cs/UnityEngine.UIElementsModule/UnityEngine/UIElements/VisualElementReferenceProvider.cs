/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
	internal class VisualElementReferenceProvider : IDisposable // TypeDefIndex: 4303
	{
		// Fields
		private Dictionary<IVisualElementReferenceHandler, int> m_DeferredOperations; // 0x10
		internal readonly List<GCHandle> m_VisualElementReferences; // 0x18
		private VisualElementAssetReferenceTable m_ReferenceTable; // 0x20
		internal bool m_Invoking; // 0x28
		private VisualElementAssetReferenceTable m_CurrentTable; // 0x30
	
		// Nested types
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 4304
		{
			// Fields
			public static Action<IVisualElementReferenceHandler> _0___ClearReferences; // 0x00
		}
	
		// Constructors
		public VisualElementReferenceProvider(); // 0x00000001824E46B0-0x00000001824E4730
	
		// Methods
		~VisualElementReferenceProvider(); // 0x00000001824E3E00-0x00000001824E3E70
		public virtual void Add(IVisualElementReferenceHandler handler); // 0x00000001824E3900-0x00000001824E3B90
		public virtual void Remove(IVisualElementReferenceHandler handler); // 0x00000001824E4240-0x00000001824E4480
		public bool Contains(IVisualElementReferenceHandler handler); // 0x00000001824E3CF0-0x00000001824E3D90
		private void Invoke(Action<IVisualElementReferenceHandler> action); // 0x00000001824E3F70-0x00000001824E4240
		private static void ClearReferences(IVisualElementReferenceHandler handler); // 0x00000001824E3CA0-0x00000001824E3CF0
		private void ResolveReferences(IVisualElementReferenceHandler handler); // 0x00000001824E4480-0x00000001824E44E0
		public void UnloadReferences(); // 0x00000001824E4520-0x00000001824E46B0
		public void ResolveReferences(VisualElementAssetReferenceTable table); // 0x00000001824E44E0-0x00000001824E4520
		private void InvokeResolveReferences(VisualElementAssetReferenceTable table); // 0x00000001824E3E70-0x00000001824E3F70
		private void ClearHandles(); // 0x00000001824E3B90-0x00000001824E3CA0
		public void Dispose(); // 0x00000001824E3D90-0x00000001824E3DF0
		private void Dispose(bool disposing); // 0x00000001824E3DF0-0x00000001824E3E00
	}
}
