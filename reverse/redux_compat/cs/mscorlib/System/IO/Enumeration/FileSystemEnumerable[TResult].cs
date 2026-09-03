/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO.Enumeration
{
	public class FileSystemEnumerable<TResult> : IEnumerable<TResult> // TypeDefIndex: 3716
	{
		// Fields
		private DelegateEnumerator _enumerator;
		private readonly FindTransform _transform;
		private readonly EnumerationOptions _options;
		private readonly string _directory;
		[CompilerGenerated]
		private FindPredicate _ShouldIncludePredicate_k__BackingField;
		[CompilerGenerated]
		private FindPredicate _ShouldRecursePredicate_k__BackingField;
	
		// Properties
		public FindPredicate ShouldIncludePredicate { [CompilerGenerated] get; [CompilerGenerated] set; }
		public FindPredicate ShouldRecursePredicate { [CompilerGenerated] get; }
	
		// Nested types
		public delegate bool FindPredicate(ref FileSystemEntry entry); // TypeDefIndex: 3717; 0x00000000-0x00000000
	
		public delegate TResult FindTransform(ref FileSystemEntry entry); // TypeDefIndex: 3718; 0x00000000-0x00000000
	
		private sealed class DelegateEnumerator : FileSystemEnumerator<TResult> // TypeDefIndex: 3719
		{
			// Fields
			private readonly FileSystemEnumerable<TResult> _enumerable;
	
			// Constructors
			public DelegateEnumerator(FileSystemEnumerable<TResult> enumerable);
	
			// Methods
			protected override TResult TransformEntry(ref FileSystemEntry entry);
			protected override bool ShouldRecurseIntoEntry(ref FileSystemEntry entry);
			protected override bool ShouldIncludeEntry(ref FileSystemEntry entry);
		}
	
		// Constructors
		public FileSystemEnumerable(string directory, FindTransform transform, EnumerationOptions options = null);
	
		// Methods
		public IEnumerator<TResult> GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
	}
}
