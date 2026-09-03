/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public class FocusChangeDirection : IDisposable // TypeDefIndex: 4161
	{
		// Fields
		[CompilerGenerated]
		private static readonly FocusChangeDirection _unspecified_k__BackingField; // 0x00
		[CompilerGenerated]
		private static readonly FocusChangeDirection _none_k__BackingField; // 0x08
		[CompilerGenerated]
		private static readonly FocusChangeDirection _lastValue_k__BackingField; // 0x10
		private readonly int m_Value; // 0x10
	
		// Properties
		public static FocusChangeDirection unspecified { [CompilerGenerated] get; } // 0x00000001824953E0-0x0000000182495430 
		public static FocusChangeDirection none { [CompilerGenerated] get; } // 0x0000000182495390-0x00000001824953E0 
		protected static FocusChangeDirection lastValue { [CompilerGenerated] get; } // 0x0000000182495340-0x0000000182495390 
	
		// Constructors
		protected FocusChangeDirection(int value); // 0x00000001802F9040-0x00000001802F9070
		static FocusChangeDirection(); // 0x0000000182495220-0x0000000182495340
	
		// Methods
		public static implicit operator int(FocusChangeDirection fcd); // 0x0000000182495430-0x0000000182495440
		void IDisposable.Dispose(); // 0x00000001819D61B0-0x00000001819D61D0
		protected virtual void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		internal virtual void ApplyTo(FocusController focusController, Focusable f); // 0x00000001824951E0-0x0000000182495220
	}
}
