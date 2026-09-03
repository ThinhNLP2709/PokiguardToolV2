/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct SubMeshDescriptor // TypeDefIndex: 8278
	{
		// Fields
		[CompilerGenerated]
		private Bounds _bounds_k__BackingField; // 0x00
		[CompilerGenerated]
		private MeshTopology _topology_k__BackingField; // 0x18
		[CompilerGenerated]
		private int _indexStart_k__BackingField; // 0x1C
		[CompilerGenerated]
		private int _indexCount_k__BackingField; // 0x20
		[CompilerGenerated]
		private int _baseVertex_k__BackingField; // 0x24
		[CompilerGenerated]
		private int _firstVertex_k__BackingField; // 0x28
		[CompilerGenerated]
		private int _vertexCount_k__BackingField; // 0x2C
	
		// Properties
		public Bounds bounds { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001808BAC90-0x00000001808BACB0 0x0000000182253B30-0x0000000182253B50
		public MeshTopology topology { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		public int indexStart { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
		public int indexCount { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public int baseVertex { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
		public int firstVertex { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
		public int vertexCount { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001803FE010-0x00000001803FE020
	
		// Constructors
		public SubMeshDescriptor(int indexStart, int indexCount, MeshTopology topology = MeshTopology.Triangles /* Metadata: 0x0069DA80 */); // 0x0000000182253AF0-0x0000000182253B30
	
		// Methods
		public override string ToString(); // 0x0000000182253790-0x0000000182253AF0
	}
}
