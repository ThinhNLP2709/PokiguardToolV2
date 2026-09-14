/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public sealed class GuardedEnumerator // TypeDefIndex: 527
{
	// Fields
	private readonly Stack<IEnumerator> _stack; // 0x10
	[CompilerGenerated]
	private object _Current_k__BackingField; // 0x18
	[CompilerGenerated]
	private Exception _Error_k__BackingField; // 0x20

	// Properties
	public object Current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018028EDE0-0x000000018028EDF0 0x00000001802B4F80-0x00000001802B4FE0
	public Exception Error { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8720-0x00000001802A8730 0x00000001802B4BC0-0x00000001802B4C20

	// Constructors
	public GuardedEnumerator(IEnumerator root); // 0x00000001803C0380-0x00000001803C04E0

	// Methods
	public bool MoveNext(); // 0x00000001803C04E0-0x00000001803C06D0
	public void Abort(); // 0x00000001803C06D0-0x00000001803C07A0
	private static void DisposeQuietly(IEnumerator e); // 0x00000001803C07A0-0x00000001803C0800
}

