/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	internal struct InputStateBuffers // TypeDefIndex: 6499
	{
		// Fields
		public uint sizePerBuffer; // 0x00
		public uint totalSize; // 0x04
		public unsafe void* defaultStateBuffer; // 0x08
		public unsafe void* noiseMaskBuffer; // 0x10
		public unsafe void* resetMaskBuffer; // 0x18
		private unsafe void* m_AllBuffers; // 0x20
		internal DoubleBuffers m_PlayerStateBuffers; // 0x28
		internal static unsafe void* s_DefaultStateBuffer; // 0x00
		internal static unsafe void* s_NoiseMaskBuffer; // 0x08
		internal static unsafe void* s_ResetMaskBuffer; // 0x10
		internal static DoubleBuffers s_CurrentBuffers; // 0x18
	
		// Nested types
		[Serializable]
		internal struct DoubleBuffers // TypeDefIndex: 6500
		{
			// Fields
			public unsafe void** deviceToBufferMapping; // 0x00
			public int deviceCount; // 0x08
	
			// Properties
			public bool valid { get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
	
			// Methods
			public unsafe void SetFrontBuffer(int deviceIndex, void* ptr); // 0x0000000181DD9870-0x0000000181DD9890
			public unsafe void SetBackBuffer(int deviceIndex, void* ptr); // 0x0000000181DD9850-0x0000000181DD9870
			public unsafe void* GetFrontBuffer(int deviceIndex); // 0x0000000181DD9830-0x0000000181DD9850
			public unsafe void* GetBackBuffer(int deviceIndex); // 0x0000000181DD9810-0x0000000181DD9830
			public void SwapBuffers(int deviceIndex); // 0x0000000181DD9890-0x0000000181DD98F0
		}
	
		// Methods
		public DoubleBuffers GetDoubleBuffersFor(InputUpdateType updateType); // 0x0000000181DE16A0-0x0000000181DE1780
		public static unsafe void* GetFrontBufferForDevice(int deviceIndex); // 0x0000000181DE1780-0x0000000181DE17E0
		public static unsafe void* GetBackBufferForDevice(int deviceIndex); // 0x0000000181DE1640-0x0000000181DE16A0
		public static void SwitchTo(InputStateBuffers buffers, InputUpdateType update); // 0x0000000181DE1F00-0x0000000181DE2000
		public void AllocateAll(InputDevice[] devices, int deviceCount); // 0x0000000181DE1290-0x0000000181DE13F0
		private static unsafe DoubleBuffers SetUpDeviceToBufferMappings(int deviceCount, ref byte* bufferPtr, uint sizePerBuffer, uint mappingTableSizePerBuffer); // 0x0000000181DE1E80-0x0000000181DE1F00
		public void FreeAll(); // 0x0000000181DE1570-0x0000000181DE1640
		public void MigrateAll(InputDevice[] devices, int deviceCount, InputStateBuffers oldBuffers); // 0x0000000181DE17E0-0x0000000181DE1A20
		private static void MigrateDoubleBuffer(DoubleBuffers newBuffer, InputDevice[] devices, int deviceCount, DoubleBuffers oldBuffer); // 0x0000000181DE1A20-0x0000000181DE1C10
		private static unsafe void MigrateSingleBuffer(void* newBuffer, InputDevice[] devices, int deviceCount, void* oldBuffer); // 0x0000000181DE1C10-0x0000000181DE1D60
		private static uint ComputeSizeOfSingleStateBuffer(InputDevice[] devices, int deviceCount); // 0x0000000181DE13F0-0x0000000181DE1570
		private static uint NextDeviceOffset(uint currentOffset, InputDevice device); // 0x0000000181DE1D60-0x0000000181DE1E80
	}
}
