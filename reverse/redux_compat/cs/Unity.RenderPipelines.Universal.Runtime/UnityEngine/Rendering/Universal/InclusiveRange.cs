/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal struct InclusiveRange // TypeDefIndex: 9797
	{
		// Fields
		public short start; // 0x00
		public short end; // 0x02
	
		// Properties
		public bool isEmpty { get; } // 0x0000000181FDB6D0-0x0000000181FDB6E0 
		public static InclusiveRange empty { get; } // 0x0000000181FDB6C0-0x0000000181FDB6D0 
	
		// Constructors
		public InclusiveRange(short startEnd); // 0x0000000181FDB6B0-0x0000000181FDB6C0
		public InclusiveRange(short start, short end); // 0x0000000181552300-0x0000000181552310
	
		// Methods
		public void Expand(short index); // 0x0000000181FDB530-0x0000000181FDB5B0
		public void Clamp(short min, short max); // 0x0000000181FDB490-0x0000000181FDB520
		public bool Contains(short index); // 0x0000000181FDB520-0x0000000181FDB530
		public static InclusiveRange Merge(InclusiveRange a, InclusiveRange b); // 0x0000000181FDB5B0-0x0000000181FDB630
		public override string ToString(); // 0x0000000181FDB630-0x0000000181FDB6B0
	}
}
