/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[UsedByNativeCode]
	public struct VertexAttributeDescriptor : IEquatable<UnityEngine.Rendering.VertexAttributeDescriptor> // TypeDefIndex: 8279
	{
		// Fields
		[CompilerGenerated]
		private VertexAttribute _attribute_k__BackingField; // 0x00
		[CompilerGenerated]
		private VertexAttributeFormat _format_k__BackingField; // 0x04
		[CompilerGenerated]
		private int _dimension_k__BackingField; // 0x08
		[CompilerGenerated]
		private int _stream_k__BackingField; // 0x0C
	
		// Properties
		public VertexAttribute attribute { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public VertexAttributeFormat format { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
		public int dimension { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
		public int stream { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x0000000180732D30-0x0000000180732D40 0x0000000180732D70-0x0000000180732D80
	
		// Constructors
		public VertexAttributeDescriptor(VertexAttribute attribute = VertexAttribute.Position /* Metadata: 0x0069DA81 */, VertexAttributeFormat format = VertexAttributeFormat.Float32 /* Metadata: 0x0069DA82 */, int dimension = 3 /* Metadata: 0x0069DA83 */, int stream = 0 /* Metadata: 0x0069DA84 */); // 0x000000018192E480-0x000000018192E4A0
	
		// Methods
		public override string ToString(); // 0x0000000182254670-0x0000000182254A20
		public override int GetHashCode(); // 0x0000000182254650-0x0000000182254670
		public override bool Equals(object other); // 0x00000001822545A0-0x0000000182254650
		public bool Equals(VertexAttributeDescriptor other); // 0x00000001815FB130-0x00000001815FB160
	}
}
