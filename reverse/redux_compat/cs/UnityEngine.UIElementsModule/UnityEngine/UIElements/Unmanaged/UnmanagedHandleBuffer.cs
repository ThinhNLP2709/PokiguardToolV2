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

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.Unmanaged
{
	[DefaultMember("Item")]
	[NativeClass("UnmanagedHandleBuffer")]
	[NativeHeader("Modules/UIElements/Core/Native/Unmanaged/UnmanagedList.h")]
	internal struct UnmanagedHandleBuffer : IDisposable // TypeDefIndex: 4994
	{
		// Fields
		private static readonly UnmanagedHandleBuffer k_Uncreated; // 0x00
		[NativeName("data")]
		private IntPtr m_Data; // 0x00
	
		// Properties
		public int Count { get; } // 0x00000001824008B0-0x00000001824008F0 
		public ReadOnlySpan<UnmanagedDataHandle> ReadOnlySpan { get; } // 0x0000000182400970-0x0000000182400A60 
	
		// Methods
		[NativeName("CreateTemporary")]
		private void _CreateTemporary(); // 0x0000000182400930-0x0000000182400970
		public static UnmanagedHandleBuffer None(); // 0x00000001824008F0-0x0000000182400930
		public static UnmanagedHandleBuffer CreateTemporary(); // 0x00000001824007F0-0x0000000182400830
		public void Dispose(); // 0x0000000182400830-0x0000000182400870
		[NativeName("Count")]
		private int NativeCount(); // 0x00000001824008B0-0x00000001824008F0
		private IntPtr GetPtr(int index); // 0x0000000182400870-0x00000001824008B0
	}
}
