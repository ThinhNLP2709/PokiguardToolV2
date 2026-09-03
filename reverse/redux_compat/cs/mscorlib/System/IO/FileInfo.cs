/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	[Serializable]
	public sealed class FileInfo : FileSystemInfo // TypeDefIndex: 3678
	{
		// Properties
		public long Length { get; } // 0x00000001815C07B0-0x00000001815C08B0 
		public override string Name { get; } // 0x00000001806CCC00-0x00000001806CCC10 
	
		// Constructors
		private FileInfo(); // 0x00000001815C07A0-0x00000001815C07B0
		public FileInfo(string fileName); // 0x00000001815C04C0-0x00000001815C0600
		internal FileInfo(string originalPath, string fullPath = null, string fileName = null, bool isNormalized = false /* Metadata: 0x0064F0C7 */); // 0x00000001815C0600-0x00000001815C07A0
		private FileInfo(SerializationInfo info, StreamingContext context); // 0x00000001815BF630-0x00000001815BF650
	
		// Methods
		public StreamWriter CreateText(); // 0x00000001815C03C0-0x00000001815C0430
		public StreamWriter AppendText(); // 0x00000001815C0350-0x00000001815C03C0
		public FileStream OpenRead(); // 0x00000001815C0430-0x00000001815C04C0
	}
}
