/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Activation
{
	[Serializable]
	internal class ContextLevelActivator : IActivator // TypeDefIndex: 2949
	{
		// Fields
		private IActivator m_NextActivator; // 0x10
	
		// Properties
		public IActivator NextActivator { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		public ContextLevelActivator(IActivator next); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public IConstructionReturnMessage Activate(IConstructionCallMessage ctorCall); // 0x00000001814D7CF0-0x00000001814D7F30
	}
}
