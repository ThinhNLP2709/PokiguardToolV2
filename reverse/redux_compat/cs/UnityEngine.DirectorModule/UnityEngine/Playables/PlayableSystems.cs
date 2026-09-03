/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 63: UnityEngine.DirectorModule.dll - Assembly: UnityEngine.DirectorModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15783-15793

namespace UnityEngine.Playables
{
	[NativeHeader("Modules/Director/ScriptBindings/PlayableSystems.bindings.h")]
	[StaticAccessor("PlayableSystemsBindings", StaticAccessorType.DoubleColon)]
	internal static class PlayableSystems // TypeDefIndex: 15789
	{
		// Fields
		private static Dictionary<int, Type> s_SystemTypes; // 0x00
		private static Dictionary<int, PlayableSystemDelegate> s_Delegates; // 0x08
		private static ReaderWriterLockSlim s_RWLock; // 0x10
	
		// Nested types
		public delegate void PlayableSystemDelegate(IReadOnlyList<DataPlayableOutput> outputs); // TypeDefIndex: 15790; 0x00000001804A78A0-0x00000001804A78B0
	
		public enum PlayableSystemStage : ushort // TypeDefIndex: 15791
		{
			FixedUpdate = 0,
			FixedUpdatePostPhysics = 1,
			Update = 2,
			AnimationBegin = 3,
			AnimationEnd = 4,
			LateUpdate = 5,
			Render = 6
		}
	
		private class DataPlayableOutputList : IReadOnlyList<DataPlayableOutput> // TypeDefIndex: 15792
		{
			// Fields
			private unsafe PlayableOutputHandle* m_Outputs; // 0x10
			private int m_Count; // 0x18
	
			// Properties
			public DataPlayableOutput this[int index] { get => default; } // 0x0000000182270B60-0x0000000182270CA0 
			public int Count { get; } // 0x0000000180B23260-0x0000000180B23270 
	
			// Nested types
			private class DataPlayableOutputEnumerator : IEnumerator<DataPlayableOutput> // TypeDefIndex: 15793
			{
				// Fields
				private DataPlayableOutputList m_List; // 0x10
				private int m_Index; // 0x18
	
				// Properties
				public DataPlayableOutput Current { get; } // 0x0000000182270890-0x0000000182270AB0 
				object IEnumerator.Current { get; } // 0x0000000182270830-0x0000000182270890 
	
				// Constructors
				public DataPlayableOutputEnumerator(DataPlayableOutputList list); // 0x0000000181560590-0x00000001815605D0
	
				// Methods
				public void Dispose(); // 0x0000000181547240-0x0000000181547260
				public bool MoveNext(); // 0x0000000182270800-0x0000000182270830
				public void Reset(); // 0x00000001810FCE00-0x00000001810FCE10
			}
	
			// Constructors
			public unsafe DataPlayableOutputList(PlayableOutputHandle* outputs, int count); // 0x0000000182270B20-0x0000000182270B60
	
			// Methods
			public IEnumerator<DataPlayableOutput> GetEnumerator(); // 0x0000000182270AB0-0x0000000182270B20
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000182270AB0-0x0000000182270B20
		}
	
		// Constructors
		static PlayableSystems(); // 0x00000001822711B0-0x0000000182271650
	
		// Methods
		private static int CombineTypeAndIndex(int typeIndex, PlayableSystemStage stage); // 0x0000000182270FD0-0x0000000182270FE0
		[RequiredByNativeCode]
		private static bool Internal_CallSystemDelegate(int systemIndex, PlayableSystemStage stage, IntPtr outputsPtr, int numOutputs); // 0x0000000182270FE0-0x00000001822711B0
	}
}
