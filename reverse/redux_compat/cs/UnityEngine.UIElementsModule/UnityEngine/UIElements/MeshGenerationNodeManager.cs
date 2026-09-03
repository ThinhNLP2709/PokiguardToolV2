/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.UIR;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class MeshGenerationNodeManager : IDisposable // TypeDefIndex: 4328
	{
		// Fields
		private List<MeshGenerationNodeImpl> m_Nodes; // 0x10
		private int m_UsedCounter; // 0x18
		private EntryRecorder m_EntryRecorder; // 0x20
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x28
	
		// Properties
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
	
		// Constructors
		public MeshGenerationNodeManager(EntryRecorder entryRecorder); // 0x00000001824D7490-0x00000001824D7560
	
		// Methods
		public void CreateNode(Entry parentEntry, out MeshGenerationNode node); // 0x00000001824D70A0-0x00000001824D70D0
		public void CreateUnsafeNode(Entry parentEntry, out UnsafeMeshGenerationNode node); // 0x00000001824D70D0-0x00000001824D7100
		private MeshGenerationNodeImpl CreateImpl(Entry parentEntry, bool safe); // 0x00000001824D6EA0-0x00000001824D70A0
		public void ResetAll(); // 0x00000001824D7390-0x00000001824D7490
		public void Dispose(); // 0x00000001824D7100-0x00000001824D7260
		protected void Dispose(bool disposing); // 0x00000001824D7260-0x00000001824D7390
	}
}
