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
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO.Enumeration
{
	public abstract class FileSystemEnumerator<TResult> : CriticalFinalizerObject, IEnumerator<TResult> // TypeDefIndex: 3714
	{
		// Fields
		private readonly string _originalRootDirectory;
		private readonly string _rootDirectory;
		private readonly EnumerationOptions _options;
		private readonly object _lock;
		private unsafe Interop.NtDll.FILE_FULL_DIR_INFORMATION* _entry;
		private TResult _current;
		private IntPtr _buffer;
		private int _bufferLength;
		private IntPtr _directoryHandle;
		private string _currentPath;
		private bool _lastEntryFound;
		[TupleElementNames(new string[2] {"Handle", "Path" })]
		private Queue<ValueTuple<IntPtr, string>> _pending;
	
		// Properties
		public TResult Current { get; }
		object IEnumerator.Current { get; }
	
		// Constructors
		public FileSystemEnumerator(string directory, EnumerationOptions options = null);
	
		// Methods
		private bool GetDataUWP();
		private IntPtr CreateRelativeDirectoryHandleUWP(ReadOnlySpan<char> relativePath, string fullPath);
		private void CloseDirectoryHandle();
		private IntPtr CreateDirectoryHandle(string path, bool ignoreNotFound = false /* Metadata: 0x0064F122 */);
		private bool ContinueOnDirectoryError(int error, bool ignoreNotFound);
		public bool MoveNext();
		private void FindNextEntry();
		private bool DequeueNextDirectory();
		private void InternalDispose(bool disposing);
		private bool GetData();
		private IntPtr CreateRelativeDirectoryHandle(ReadOnlySpan<char> relativePath, string fullPath);
		protected virtual bool ShouldIncludeEntry(ref FileSystemEntry entry);
		protected virtual bool ShouldRecurseIntoEntry(ref FileSystemEntry entry);
		protected abstract TResult TransformEntry(ref FileSystemEntry entry);
		protected virtual void OnDirectoryFinished(ReadOnlySpan<char> directory);
		protected virtual bool ContinueOnError(int error);
		private void DirectoryFinished();
		public void Reset();
		public void Dispose();
		protected virtual void Dispose(bool disposing);
		~FileSystemEnumerator();
	}
}
