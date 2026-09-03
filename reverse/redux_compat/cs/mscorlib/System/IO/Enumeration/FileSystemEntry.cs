/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO.Enumeration
{
	[IsByRefLike]
	[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
	public struct FileSystemEntry // TypeDefIndex: 3715
	{
		// Fields
		internal unsafe Interop.NtDll.FILE_FULL_DIR_INFORMATION* _info; // 0x00
		[CompilerGenerated]
		private ReadOnlySpan<char> _Directory_k__BackingField; // 0x08
		[CompilerGenerated]
		private ReadOnlySpan<char> _RootDirectory_k__BackingField; // 0x18
		[CompilerGenerated]
		private ReadOnlySpan<char> _OriginalRootDirectory_k__BackingField; // 0x28
	
		// Properties
		public ReadOnlySpan<char> Directory { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] private set; } // 0x0000000180C57230-0x0000000180C57240 0x0000000181259E20-0x0000000181259E30
		public ReadOnlySpan<char> RootDirectory { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] private set; } // 0x0000000180A5E120-0x0000000180A5E130 0x0000000180F9EBA0-0x0000000180F9EBB0
		public ReadOnlySpan<char> OriginalRootDirectory { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] private set; } // 0x0000000180C46B90-0x0000000180C46BA0 0x00000001815D9CA0-0x00000001815D9CB0
		public ReadOnlySpan<char> FileName { get; } // 0x00000001815D9C50-0x00000001815D9C80 
		public FileAttributes Attributes { get; } // 0x00000001815D9C30-0x00000001815D9C50 
		public bool IsDirectory { get; } // 0x00000001815D9C80-0x00000001815D9CA0 
	
		// Methods
		internal static unsafe void Initialize(ref FileSystemEntry entry, Interop.NtDll.FILE_FULL_DIR_INFORMATION* info, ReadOnlySpan<char> directory, ReadOnlySpan<char> rootDirectory, ReadOnlySpan<char> originalRootDirectory); // 0x00000001815D9A70-0x00000001815D9A90
		public string ToSpecifiedFullPath(); // 0x00000001815D9A90-0x00000001815D9C30
	}
}
