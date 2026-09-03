/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal class ConstraintEnumerator // TypeDefIndex: 11222
	{
		// Fields
		private IEnumerator _tables; // 0x10
		private IEnumerator _constraints; // 0x18
		private Constraint _currentObject; // 0x20
	
		// Properties
		protected Constraint CurrentObject { get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Constructors
		public ConstraintEnumerator(DataSet dataSet); // 0x0000000181866260-0x00000001818662E0
	
		// Methods
		public bool GetNext(); // 0x0000000181866030-0x0000000181866260
		public Constraint GetConstraint(); // 0x00000001802F8630-0x00000001802F8640
		protected virtual bool IsValidCandidate(Constraint constraint); // 0x00000001802E7990-0x00000001802E79A0
	}
}
