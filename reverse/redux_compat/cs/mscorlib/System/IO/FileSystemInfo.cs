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
	public abstract class FileSystemInfo : MarshalByRefObject, ISerializable // TypeDefIndex: 3679
	{
		// Fields
		private Interop.Kernel32.WIN32_FILE_ATTRIBUTE_DATA _data; // 0x18
		private int _dataInitialized; // 0x3C
		protected string FullPath; // 0x40
		protected string OriginalPath; // 0x48
		internal string _name; // 0x50
	
		// Properties
		public FileAttributes Attributes { get; } // 0x00000001815C4F40-0x00000001815C4FB0 
		internal bool ExistsCore { get; } // 0x00000001815C4FB0-0x00000001815C5030 
		internal long LengthCore { get; } // 0x00000001815C50C0-0x00000001815C5140 
		internal string NormalizedPath { get; } // 0x00000001815C5140-0x00000001815C51C0 
		public virtual string Name { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		public virtual bool Exists { get; } // 0x00000001815C5030-0x00000001815C50C0 
	
		// Constructors
		protected FileSystemInfo(); // 0x00000001815C07A0-0x00000001815C07B0
		protected FileSystemInfo(SerializationInfo info, StreamingContext context); // 0x00000001815C4DB0-0x00000001815C4F40
	
		// Methods
		private void EnsureDataInitialized(); // 0x00000001815C4BC0-0x00000001815C4C30
		public void Refresh(); // 0x00000001815C4D60-0x00000001815C4D90
		[ComVisible(false)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001815C4C30-0x00000001815C4D60
		public override string ToString(); // 0x00000001815C4D90-0x00000001815C4DB0
	}
}
