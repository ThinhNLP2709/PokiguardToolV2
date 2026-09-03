/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct AttachmentIndexArray // TypeDefIndex: 8390
	{
		// Fields
		[NoAutoStaticsCleanup]
		public static AttachmentIndexArray Emtpy; // 0x00
		private int a0; // 0x00
		private int a1; // 0x04
		private int a2; // 0x08
		private int a3; // 0x0C
		private int a4; // 0x10
		private int a5; // 0x14
		private int a6; // 0x18
		private int a7; // 0x1C
		private int activeAttachments; // 0x20
	
		// Properties
		public int this[int index] { get => default; set {} } // 0x0000000182255030-0x0000000182255150 0x0000000182255150-0x0000000182255270
		public int Length { get; } // 0x0000000180C4F680-0x0000000180C4F690 
	
		// Constructors
		public AttachmentIndexArray(int numAttachments); // 0x0000000182254F70-0x0000000182255030
		static AttachmentIndexArray(); // 0x0000000182254F00-0x0000000182254F70
	}
}
