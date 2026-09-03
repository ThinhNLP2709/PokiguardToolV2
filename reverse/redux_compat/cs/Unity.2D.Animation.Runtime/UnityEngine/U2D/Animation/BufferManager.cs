/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	internal class BufferManager : ScriptableObject // TypeDefIndex: 14360
	{
		// Fields
		private static BufferManager s_Instance; // 0x00
		private Dictionary<ulong, VertexBuffer> m_Buffers; // 0x18
		private Queue<VertexBuffer> m_BuffersToDispose; // 0x20
		[CompilerGenerated]
		private bool _needDoubleBuffering_k__BackingField; // 0x28
	
		// Properties
		public int bufferCount { get; } // 0x0000000181C1A180-0x0000000181C1A2B0 
		public bool needDoubleBuffering { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
		public static BufferManager instance { get; } // 0x0000000181C1A2B0-0x0000000181C1A3D0 
	
		// Constructors
		public BufferManager(); // 0x0000000181C1A0C0-0x0000000181C1A180
	
		// Methods
		private void OnEnable(); // 0x0000000181C19D90-0x0000000181C19EA0
		private void OnDisable(); // 0x0000000181C19C70-0x0000000181C19D90
		private void ForceClearBuffers(); // 0x0000000181C198E0-0x0000000181C19BB0
		public NativeByteArray GetBuffer(ulong id, int bufferSize); // 0x0000000181C19BB0-0x0000000181C19C70
		private VertexBuffer CreateBuffer(ulong id, int bufferSize); // 0x0000000181C19670-0x0000000181C198E0
		public void ReturnBuffer(ulong id); // 0x0000000181C19EA0-0x0000000181C19F80
		private void Update(); // 0x0000000181C19F80-0x0000000181C1A0C0
	}
}
