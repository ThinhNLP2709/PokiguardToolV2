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
using UnityEngine.Bindings;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[NativeClass("CustomPropertyList")]
	[NativeHeader("Modules/UIElements/Core/Native/Style/CustomPropertyList.h")]
	internal struct CustomPropertyList : IDisposable // TypeDefIndex: 4370
	{
		// Fields
		[NativeName("data")]
		private IntPtr m_Data; // 0x00
	
		// Properties
		public int Count { get; } // 0x0000000182523F00-0x0000000182523F40 
		public StylePropertyValue this[UniqueStyleString name] { set {} } // 0x0000000182523D70-0x0000000182523E30
	
		// Methods
		[IsReadOnly]
		public bool TryGetValue(UniqueStyleString name, out StylePropertyValue value); // 0x00000001825239D0-0x0000000182523AB0
		[IsReadOnly]
		public bool ContainsKey(UniqueStyleString name); // 0x00000001825238D0-0x0000000182523950
		[IsReadOnly]
		public void Remove(UniqueStyleString name); // 0x0000000182523950-0x00000001825239D0
		[IsReadOnly]
		public void SetValue(UniqueStyleString name, StylePropertyValue value); // 0x0000000182523D70-0x0000000182523E30
		[NativeName("Create")]
		private void _Create(); // 0x0000000182523EC0-0x0000000182523F00
		public static CustomPropertyList Create(); // 0x0000000182523BE0-0x0000000182523C20
		public void Dispose(); // 0x0000000182523C20-0x0000000182523C60
		[IsReadOnly]
		public bool IsCreated(); // 0x0000000182523C60-0x0000000182523CA0
		[IsReadOnly]
		[NativeName("Acquire")]
		private void _Acquire(); // 0x0000000182523E80-0x0000000182523EC0
		[IsReadOnly]
		public CustomPropertyList Acquire(); // 0x0000000182523AF0-0x0000000182523B30
		public void Release(); // 0x0000000182523CA0-0x0000000182523CE0
		public void SafeRelease(); // 0x0000000182523CA0-0x0000000182523CE0
		public void CopyFrom(CustomPropertyList other); // 0x0000000182523B70-0x0000000182523BE0
		[IsReadOnly]
		private bool TryGetValue(int id, IntPtr outValue); // 0x0000000182523E30-0x0000000182523E80
		[IsReadOnly]
		private bool ContainsKey(int id); // 0x0000000182523B30-0x0000000182523B70
		[IsReadOnly]
		private void Remove(int id); // 0x0000000182523CE0-0x0000000182523D20
		[IsReadOnly]
		private void SetValue(int id, IntPtr inValue); // 0x0000000182523D20-0x0000000182523D70
	}
}
