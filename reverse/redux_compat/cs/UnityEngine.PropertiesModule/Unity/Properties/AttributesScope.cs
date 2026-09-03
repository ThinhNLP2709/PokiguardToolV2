/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties.Internal;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	[IsReadOnly]
	public struct AttributesScope : IDisposable // TypeDefIndex: 14445
	{
		// Fields
		private readonly IAttributes m_Target; // 0x00
		private readonly List<Attribute> m_Previous; // 0x08
	
		// Constructors
		public AttributesScope(IProperty target, IProperty source); // 0x00000001822D9290-0x00000001822D9390
		internal AttributesScope(IAttributes target, List<Attribute> attributes); // 0x00000001822D91F0-0x00000001822D9290
	
		// Methods
		public void Dispose(); // 0x00000001822D91A0-0x00000001822D91F0
	}
}
