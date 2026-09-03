/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Util
{
	internal class DelayedActionManager : ComponentSingleton<UnityEngine.ResourceManagement.Util.DelayedActionManager> // TypeDefIndex: 13704
	{
		// Fields
		private List<DelegateInfo>[] m_Actions; // 0x20
		private LinkedList<DelegateInfo> m_DelayedActions; // 0x28
		private Stack<LinkedListNode<DelegateInfo>> m_NodeCache; // 0x30
		private int m_CollectionIndex; // 0x38
		private bool m_DestroyOnCompletion; // 0x3C
	
		// Properties
		public static bool IsActive { get; } // 0x0000000182049FF0-0x000000018204A120 
	
		// Nested types
		private struct DelegateInfo // TypeDefIndex: 13705
		{
			// Fields
			private static int s_Id; // 0x00
			private int m_Id; // 0x00
			private Delegate m_Delegate; // 0x08
			private object[] m_Target; // 0x10
			[CompilerGenerated]
			private float _InvocationTime_k__BackingField; // 0x18
	
			// Properties
			public float InvocationTime { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806CB0A0-0x00000001806CB0B0 0x0000000180FB0A90-0x0000000180FB0AA0
	
			// Constructors
			public DelegateInfo(Delegate d, float invocationTime, params object[] p); // 0x000000018204A650-0x000000018204A6E0
	
			// Methods
			public override string ToString(); // 0x000000018204A290-0x000000018204A650
			public void Invoke(); // 0x000000018204A120-0x000000018204A290
		}
	
		// Constructors
		public DelayedActionManager(); // 0x0000000182049E00-0x0000000182049FF0
	
		// Methods
		private LinkedListNode<DelegateInfo> GetNode(ref DelegateInfo del); // 0x00000001820497A0-0x0000000182049890
		public static void Clear(); // 0x0000000182049730-0x0000000182049790
		private void DestroyWhenComplete(); // 0x0000000182049790-0x00000001820497A0
		public static void AddAction(Delegate action, float delay = 0f /* Metadata: 0x006A7E44 */, params object[] parameters); // 0x00000001820496B0-0x0000000182049730
		private void AddActionInternal(Delegate action, float delay, params object[] parameters); // 0x0000000182049420-0x00000001820496B0
		public static bool Wait(float timeout = 0f /* Metadata: 0x006A7E48 */, float timeAdvanceAmount = 0f /* Metadata: 0x006A7E4C */); // 0x0000000182049C70-0x0000000182049E00
		private void LateUpdate(); // 0x0000000182049B90-0x0000000182049BC0
		private void InternalLateUpdate(float t); // 0x0000000182049890-0x0000000182049B90
		private void OnApplicationQuit(); // 0x0000000182049BC0-0x0000000182049C70
	}
}
