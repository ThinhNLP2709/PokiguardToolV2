/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.Layout
{
	[NativeHeader("Modules/UIElements/Core/Layout/Native/LayoutModel.h")]
	internal struct LayoutCacheData // TypeDefIndex: 5185
	{
		// Fields
		public static LayoutCacheData Default; // 0x00
		public LayoutCachedMeasurement CachedLayout; // 0x00
	
		// Constructors
		static LayoutCacheData(); // 0x0000000182438AF0-0x0000000182438B70
	
		// Methods
		[IsReadOnly]
		public override string ToString(); // 0x00000001824389A0-0x0000000182438AF0
		[IsReadOnly]
		public int MeasurementCacheCount(); // 0x0000000182438930-0x00000001824389A0
		public void ClearCachedMeasurements(); // 0x0000000182438850-0x00000001824388F0
		private static unsafe void ClearCachedMeasurements(void* LayoutCacheData); // 0x00000001824388F0-0x0000000182438930
	}
}
