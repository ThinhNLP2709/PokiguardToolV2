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

namespace System.Resources
{
	internal sealed class RuntimeResourceSet : ResourceSet, IEnumerable // TypeDefIndex: 3255
	{
		// Fields
		internal const int Version = 2; // Metadata: 0x0064EC2C
		private Dictionary<string, ResourceLocator> _resCache; // 0x28
		private ResourceReader _defaultReader; // 0x30
		private Dictionary<string, ResourceLocator> _caseInsensitiveTable; // 0x38
		private bool _haveReadFromReader; // 0x40
	
		// Constructors
		internal RuntimeResourceSet(string fileName); // 0x0000000181519F90-0x000000018151A100
		internal RuntimeResourceSet(Stream stream); // 0x0000000181519E70-0x0000000181519F90
	
		// Methods
		protected override void Dispose(bool disposing); // 0x0000000181518E80-0x0000000181518FD0
		public override IDictionaryEnumerator GetEnumerator(); // 0x0000000181519070-0x0000000181519080
		new IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181519070-0x0000000181519080
		private new IDictionaryEnumerator GetEnumeratorHelper(); // 0x0000000181518FD0-0x0000000181519070
		public override string GetString(string key); // 0x0000000181519C50-0x0000000181519CA0
		public override string GetString(string key, bool ignoreCase); // 0x0000000181519C10-0x0000000181519C50
		public override object GetObject(string key); // 0x0000000181519080-0x00000001815190A0
		public override object GetObject(string key, bool ignoreCase); // 0x0000000181519BF0-0x0000000181519C10
		private object GetObject(string key, bool ignoreCase, bool isString); // 0x00000001815190A0-0x0000000181519BF0
		private object ResolveResourceLocator(ResourceLocator resLocation, string key, Dictionary<string, ResourceLocator> copyOfCache, bool keyInWrongCase); // 0x0000000181519CA0-0x0000000181519E70
	}
}
