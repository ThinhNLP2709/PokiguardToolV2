/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct GPUComponentJaggedUpdate : IDisposable // TypeDefIndex: 12957
	{
		// Fields
		private JaggedSpan<byte> m_Data; // 0x00
		private GPUComponent m_Component; // 0x20
	
		// Properties
		public int PropertyID { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public int StrideInBytes { get; } // 0x0000000180D17D10-0x0000000180D17D20 
		public JaggedSpan<byte> Data { get; } // 0x0000000181325CE0-0x0000000181325D00 
	
		// Constructors
		public GPUComponentJaggedUpdate(int initialCapacity, Allocator allocator, GPUComponent component); // 0x0000000181F344B0-0x0000000181F34500
	
		// Methods
		public void Dispose(); // 0x0000000181F344A0-0x0000000181F344B0
		public void Append([IsReadOnly] in GPUComponentUpdate section); // 0x0000000181F34440-0x0000000181F344A0
	}
}
