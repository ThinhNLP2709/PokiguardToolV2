/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	internal class VertexBuffer // TypeDefIndex: 14359
	{
		// Fields
		private readonly ulong m_Id; // 0x10
		private bool m_IsActive; // 0x18
		private int m_DeactivateFrame; // 0x1C
		private NativeByteArray[] m_Buffers; // 0x20
		private int m_ActiveIndex; // 0x28
	
		// Properties
		public int bufferCount { get; } // 0x0000000180634EF0-0x0000000180634F10 
	
		// Constructors
		public VertexBuffer(ulong id, int size, bool needDoubleBuffering); // 0x0000000181C2F610-0x0000000181C2F7A0
	
		// Methods
		public override int GetHashCode(); // 0x0000000181C2F480-0x0000000181C2F490
		private static int GetCurrentFrame(); // 0x0000000181C2F470-0x0000000181C2F480
		public NativeByteArray GetBuffer(int size); // 0x0000000181C2F210-0x0000000181C2F470
		private void ResizeBuffer(int bufferId, int newSize); // 0x0000000181C2F4C0-0x0000000181C2F610
		public void Deactivate(); // 0x0000000181C2F150-0x0000000181C2F180
		public void Dispose(); // 0x0000000181C2F180-0x0000000181C2F210
		public bool IsSafeToDispose(); // 0x0000000181C2F490-0x0000000181C2F4C0
	}
}
