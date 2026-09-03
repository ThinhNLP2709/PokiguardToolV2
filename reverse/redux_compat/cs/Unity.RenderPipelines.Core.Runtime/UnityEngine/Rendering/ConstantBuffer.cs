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
	public class ConstantBuffer // TypeDefIndex: 5342
	{
		// Fields
		private static readonly List<ConstantBufferBase> m_RegisteredConstantBuffers; // 0x00
	
		// Constructors
		public ConstantBuffer(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static ConstantBuffer(); // 0x0000000181E21AB0-0x0000000181E21B40
	
		// Methods
		public static void PushGlobal<CBType>(CommandBuffer cmd, [IsReadOnly] in ref CBType data, int shaderId)
			where CBType : struct;
		public static void PushGlobal<CBType>(BaseCommandBuffer cmd, [IsReadOnly] in ref CBType data, int shaderId)
			where CBType : struct;
		public static void PushGlobal<CBType>([IsReadOnly] in ref CBType data, int shaderId)
			where CBType : struct;
		public static void Push<CBType>(CommandBuffer cmd, [IsReadOnly] in ref CBType data, ComputeShader cs, int shaderId)
			where CBType : struct;
		public static void Push<CBType>(IComputeCommandBuffer cmd, [IsReadOnly] in ref CBType data, ComputeShader cs, int shaderId)
			where CBType : struct;
		public static void Push<CBType>([IsReadOnly] in ref CBType data, ComputeShader cs, int shaderId)
			where CBType : struct;
		public static void Push<CBType>(CommandBuffer cmd, [IsReadOnly] in ref CBType data, Material mat, int shaderId)
			where CBType : struct;
		public static void Push<CBType>(BaseCommandBuffer cmd, [IsReadOnly] in ref CBType data, Material mat, int shaderId)
			where CBType : struct;
		public static void Push<CBType>([IsReadOnly] in ref CBType data, Material mat, int shaderId)
			where CBType : struct;
		public static void UpdateData<CBType>(CommandBuffer cmd, [IsReadOnly] in ref CBType data)
			where CBType : struct;
		public static void UpdateData<CBType>(BaseCommandBuffer cmd, [IsReadOnly] in ref CBType data)
			where CBType : struct;
		public static void UpdateData<CBType>([IsReadOnly] in ref CBType data)
			where CBType : struct;
		public static void SetGlobal<CBType>(CommandBuffer cmd, int shaderId)
			where CBType : struct;
		public static void SetGlobal<CBType>(BaseCommandBuffer cmd, int shaderId)
			where CBType : struct;
		public static void SetGlobal<CBType>(int shaderId)
			where CBType : struct;
		public static void Set<CBType>(CommandBuffer cmd, ComputeShader cs, int shaderId)
			where CBType : struct;
		public static void Set<CBType>(IComputeCommandBuffer cmd, ComputeShader cs, int shaderId)
			where CBType : struct;
		public static void Set<CBType>(ComputeShader cs, int shaderId)
			where CBType : struct;
		public static void Set<CBType>(Material mat, int shaderId)
			where CBType : struct;
		public static void ReleaseAll(); // 0x0000000181E21950-0x0000000181E21AB0
		internal static void Register(ConstantBufferBase cb); // 0x0000000181E21880-0x0000000181E21950
	}
}
