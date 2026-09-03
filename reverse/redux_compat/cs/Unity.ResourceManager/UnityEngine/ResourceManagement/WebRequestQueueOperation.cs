/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement
{
	public class WebRequestQueueOperation // TypeDefIndex: 13678
	{
		// Fields
		private bool m_Completed; // 0x10
		public UnityWebRequestAsyncOperation Result; // 0x18
		public Action<UnityWebRequestAsyncOperation> OnComplete; // 0x20
		internal UnityWebRequest m_WebRequest; // 0x28
	
		// Properties
		public bool IsDone { get; } // 0x000000018205BA50-0x000000018205BA70 
		public UnityWebRequest WebRequest { get; internal set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
	
		// Constructors
		public WebRequestQueueOperation(UnityWebRequest request); // 0x0000000181332DD0-0x0000000181332E10
	
		// Methods
		internal void Complete(UnityWebRequestAsyncOperation asyncOp); // 0x000000018205BA00-0x000000018205BA50
	}
}
