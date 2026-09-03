/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class ContextContainer : IDisposable // TypeDefIndex: 5346
	{
		// Fields
		private Item[] m_Items; // 0x10
		private List<uint> m_ActiveItemIndices; // 0x18
		[NoAutoStaticsCleanup]
		private static uint s_TypeCount; // 0x00
	
		// Nested types
		private static class TypeId<T> // TypeDefIndex: 5347
		{
			// Fields
			[NoAutoStaticsCleanup]
			public static uint value;
	
			// Constructors
			static TypeId();
		}
	
		private struct Item // TypeDefIndex: 5348
		{
			// Fields
			public ContextItem storage; // 0x00
			public bool isSet; // 0x08
		}
	
		// Constructors
		public ContextContainer(); // 0x0000000181E21CE0-0x0000000181E21D90
	
		// Methods
		public T Get<T>()
			where T : ContextItem, new();
		public T Create<T>()
			where T : ContextItem, new();
		public T GetOrCreate<T>()
			where T : ContextItem, new();
		public bool Contains<T>()
			where T : ContextItem, new();
		private bool Contains(uint typeId); // 0x0000000181E21B40-0x0000000181E21B90
		private T CreateAndGetData<T>(uint typeId)
			where T : ContextItem, new();
		public void Dispose(); // 0x0000000181E21B90-0x0000000181E21CE0
	}
}
