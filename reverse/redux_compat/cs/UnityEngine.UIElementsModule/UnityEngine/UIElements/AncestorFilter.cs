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

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class AncestorFilter // TypeDefIndex: 3929
	{
		// Fields
		private CountingBloomFilter m_CountingBloomFilter; // 0x10
		private Stack<int> m_HashStack; // 0x4010
	
		// Constructors
		public AncestorFilter(); // 0x000000018239A3D0-0x000000018239A460
	
		// Methods
		private void AddHash(int hash); // 0x000000018239A060-0x000000018239A0E0
		public unsafe bool IsCandidate(int* ancestorHashes); // 0x000000018239A0E0-0x000000018239A120
		public void PushElement(VisualElement element); // 0x000000018239A200-0x000000018239A3D0
		public void PopElement(); // 0x000000018239A120-0x000000018239A200
	}
}
