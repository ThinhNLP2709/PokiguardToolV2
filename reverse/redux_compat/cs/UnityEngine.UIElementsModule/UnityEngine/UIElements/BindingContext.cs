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
	public struct BindingContext // TypeDefIndex: 3820
	{
		// Fields
		private readonly VisualElement m_TargetElement; // 0x00
		private readonly BindingId m_BindingId; // 0x08
		private readonly PropertyPath m_DataSourcePath; // 0xA0
		private readonly object m_DataSource; // 0x130
	
		// Properties
		public VisualElement targetElement { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public BindingId bindingId { get; } // 0x0000000181328340-0x00000001813283B0 
		public PropertyPath dataSourcePath { get; } // 0x000000018237DF90-0x000000018237E000 
		public object dataSource { get; } // 0x0000000181C2D460-0x0000000181C2D470 
	
		// Constructors
		internal BindingContext(VisualElement targetElement, [IsReadOnly] in BindingId bindingId, [IsReadOnly] in PropertyPath resolvedDataSourcePath, object resolvedDataSource); // 0x000000018237DE30-0x000000018237DF90
	}
}
