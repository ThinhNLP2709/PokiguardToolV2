/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public sealed class DebugDisplaySerializer // TypeDefIndex: 5404
	{
		// Fields
		private static Lazy<DebugDisplaySerializer> s_Instance; // 0x00
		[SerializeReference]
		private List<ISerializedDebugDisplaySettings> m_Settings; // 0x10
		[SerializeField]
		private SerializedDictionary<string, bool> m_FoldoutStates; // 0x18
	
		// Properties
		public static DebugDisplaySerializer instance { get; } // 0x0000000181E39A60-0x0000000181E39AD0 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5405
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<DebugUI.Widget> __9__10_0; // 0x08
			public static Action<DebugUI.Widget> __9__11_0; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181E4F9C0-0x0000000181E4FA30
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _LoadFoldoutStates_b__10_0(DebugUI.Widget widget); // 0x0000000181E4E540-0x0000000181E4E610
			internal void _SaveFoldoutStates_b__11_0(DebugUI.Widget widget); // 0x0000000181E4E610-0x0000000181E4E6D0
			internal DebugDisplaySerializer _.cctor_b__13_0(); // 0x0000000181E4E6D0-0x0000000181E4E7C0
		}
	
		// Constructors
		public DebugDisplaySerializer(); // 0x0000000181E399A0-0x0000000181E39A60
		static DebugDisplaySerializer(); // 0x0000000181E39890-0x0000000181E399A0
	
		// Methods
		private ISerializedDebugDisplaySettings GetOrCreate(Type type); // 0x0000000181E39370-0x0000000181E39530
		private ISerializedDebugDisplaySettings Get(Type type); // 0x0000000181E39530-0x0000000181E39600
		public static T GetOrCreate<T>()
			where T : class, ISerializedDebugDisplaySettings;
		public static T Get<T>()
			where T : class, ISerializedDebugDisplaySettings;
		public static void Clear(); // 0x0000000181E392F0-0x0000000181E39370
		public static void LoadFoldoutStates(); // 0x0000000181E39600-0x0000000181E39720
		public static void SaveFoldoutStates(); // 0x0000000181E39720-0x0000000181E39890
	}
}
