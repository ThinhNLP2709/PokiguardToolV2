/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler
{
	public struct FixedAttachmentArray<DataType> // TypeDefIndex: 5990
		where DataType : struct
	{
		// Fields
		public static readonly FixedAttachmentArray<DataType> Empty;
		public const int MaxAttachments = 8; // Metadata: 0x00662CE7
		private DataType a0;
		private DataType a1;
		private DataType a2;
		private DataType a3;
		private DataType a4;
		private DataType a5;
		private DataType a6;
		private DataType a7;
		private int activeAttachments;
	
		// Properties
		public int size { get; }
		public ref DataType this[int index] { get => default; }
	
		// Constructors
		public FixedAttachmentArray(int numAttachments);
		public FixedAttachmentArray(DataType[] attachments);
		public FixedAttachmentArray(NativeArray<DataType> attachments);
		static FixedAttachmentArray();
	
		// Methods
		public void Clear();
		public int Add([IsReadOnly] in ref DataType data);
	}
}
