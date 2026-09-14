/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokiGuard.Audition
{
	public interface IAuditionHost // TypeDefIndex: 2546
	{
		// Properties
		CardData Card { get; }
		Transform OverlayRoot { get; }
		bool IsActive { get; }
	
		// Methods
		void OnAuditionPress(string dir);
		void OnAuditionTap(int elapsedMs);
		IEnumerator HideCenterCardCo();
	}
}
