/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public abstract class SettingsDialog : MonoBehaviour // TypeDefIndex: 1216
{
	// Fields
	protected const float DIM_OVERSCAN = 600f; // Metadata: 0x005F0954
	protected RectTransform Box; // 0x20
	protected Image Frame; // 0x28
	protected CanvasGroup Group; // 0x30
	private Image _dim; // 0x38
	private Button _dimButton; // 0x40
	[CompilerGenerated]
	private bool _Locked_k__BackingField; // 0x48

	// Properties
	protected bool Locked { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806DAAE0-0x00000001806DAAF0 0x00000001806DAAF0-0x00000001806DAB00
	public bool IsOpen { get; } // 0x00000001806DAB00-0x00000001806DAC60 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass12_0 // TypeDefIndex: 1217
	{
		// Fields
		public bool tapOutsideCloses; // 0x10
		public SettingsDialog __4__this; // 0x18

		// Constructors
		public __c__DisplayClass12_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildShell_b__0(); // 0x00000001806DB8B0-0x00000001806DB8F0
	}

	// Constructors
	protected SettingsDialog(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	protected RectTransform BuildShell(Vector2 boxSize, float dimAlpha, bool tapOutsideCloses); // 0x00000001806DAC60-0x00000001806DB1F0
	public virtual void Show(); // 0x00000001806DB1F0-0x00000001806DB390
	public virtual void Hide(); // 0x00000001806DB390-0x00000001806DB5A0
	protected void RequestClose(); // 0x00000001806DB5A0-0x00000001806DB5C0
	protected void SetLocked(bool on); // 0x00000001806DB5C0-0x00000001806DB6D0
	[CompilerGenerated]
	private void _Hide_b__14_0(); // 0x00000001806DB6D0-0x00000001806DB8B0
}

