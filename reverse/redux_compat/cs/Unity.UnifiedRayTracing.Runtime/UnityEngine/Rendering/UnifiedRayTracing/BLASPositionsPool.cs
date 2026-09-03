/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	internal sealed class BLASPositionsPool : IDisposable // TypeDefIndex: 14300
	{
		// Fields
		public const int VertexSizeInDwords = 3; // Metadata: 0x006A962D
		private const int intialVertexCount = 1000; // Metadata: 0x006A962E
		private GraphicsBuffer m_VerticesBuffer; // 0x10
		private BlockAllocator m_VerticesAllocator; // 0x18
		private readonly ComputeShader m_CopyPositionsShader; // 0x38
		private readonly int m_CopyVerticesKernel; // 0x40
		private readonly ComputeShader m_CopyShader; // 0x48
		private const uint kItemsPerWorkgroup = 6144; // Metadata: 0x006A9630
	
		// Properties
		public GraphicsBuffer VertexBuffer { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		public BLASPositionsPool(ComputeShader copyPositionsShader, ComputeShader copyShader); // 0x00000001821123E0-0x00000001821124F0
	
		// Methods
		public void Dispose(); // 0x00000001821122F0-0x0000000182112360
		public void Clear(); // 0x0000000182112200-0x00000001821122F0
		public void Add(VertexBufferChunk info, out BlockAllocator.Allocation verticesAllocation); // 0x0000000182111CD0-0x0000000182112200
		public void Remove(ref BlockAllocator.Allocation verticesAllocation); // 0x0000000182112360-0x00000001821123E0
	}
}
