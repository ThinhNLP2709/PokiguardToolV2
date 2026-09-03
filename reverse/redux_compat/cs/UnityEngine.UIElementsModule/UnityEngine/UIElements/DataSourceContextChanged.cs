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
	[IsReadOnly]
	public struct DataSourceContextChanged // TypeDefIndex: 3852
	{
		// Fields
		private readonly VisualElement m_TargetElement; // 0x00
		private readonly BindingId m_BindingId; // 0x08
		private readonly DataSourceContext m_PreviousContext; // 0xA0
		private readonly DataSourceContext m_NewContext; // 0x138
	
		// Constructors
		internal DataSourceContextChanged(VisualElement element, [IsReadOnly] in BindingId bindingId, [IsReadOnly] in DataSourceContext previousContext, [IsReadOnly] in DataSourceContext newContext); // 0x0000000182389D20-0x0000000182389F00
	}
}
