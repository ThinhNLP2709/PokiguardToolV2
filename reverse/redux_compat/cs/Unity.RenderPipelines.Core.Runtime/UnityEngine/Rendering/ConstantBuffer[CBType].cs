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
	public class ConstantBuffer<CBType> : ConstantBufferBase // TypeDefIndex: 5344
		where CBType : struct
	{
		// Fields
		private HashSet<int> m_GlobalBindings;
		private ComputeBuffer m_GPUConstantBuffer;
	
		// Constructors
		public ConstantBuffer();
		public ConstantBuffer(ComputeBufferMode mode);
	
		// Methods
		public void UpdateData(CommandBuffer cmd, [IsReadOnly] in ref CBType data);
		public void UpdateData(BaseCommandBuffer cmd, [IsReadOnly] in ref CBType data);
		public void UpdateData([IsReadOnly] in ref CBType data);
		public void SetGlobal(CommandBuffer cmd, int shaderId);
		public void SetGlobal(BaseCommandBuffer cmd, int shaderId);
		public void SetGlobal(int shaderId);
		public void Set(CommandBuffer cmd, ComputeShader cs, int shaderId);
		public void Set(IComputeCommandBuffer cmd, ComputeShader cs, int shaderId);
		public void Set(ComputeShader cs, int shaderId);
		public void Set(Material mat, int shaderId);
		public void Set(MaterialPropertyBlock mpb, int shaderId);
		public void PushGlobal(CommandBuffer cmd, [IsReadOnly] in ref CBType data, int shaderId);
		public void PushGlobal(BaseCommandBuffer cmd, [IsReadOnly] in ref CBType data, int shaderId);
		public void PushGlobal([IsReadOnly] in ref CBType data, int shaderId);
		public override void Release();
	}
}
