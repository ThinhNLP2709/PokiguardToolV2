/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class HubAvatarNameFit : MonoBehaviour // TypeDefIndex: 2621
	{
		// Fields
		private const string N_HEADER = "PanelIconheader"; // Metadata: 0x005F25E8
		private const float BAND_OVERLAP = 0.35f; // Metadata: 0x005F25F8
		private UnityEngine.UI.Text _label; // 0x20
		private RectTransform _rt; // 0x28
		private RectTransform _cluster; // 0x30
		private Transform _header; // 0x38
		private bool _headerSearched; // 0x40
		private RectTransform _canvasRt; // 0x48
		private float _lastCanvasW; // 0x50
		private string _fullText; // 0x58
		private float _designCenterX; // 0x60
		private float _designCenterY; // 0x64
		private float _designHeight; // 0x68
		private int _designFont; // 0x6C
		private bool _bound; // 0x70
		[CompilerGenerated]
		private float _FittedWidth_k__BackingField; // 0x74
		[CompilerGenerated]
		private float _FittedLeft_k__BackingField; // 0x78
		[CompilerGenerated]
		private float _FittedRight_k__BackingField; // 0x7C
		[CompilerGenerated]
		private int _FittedFont_k__BackingField; // 0x80
		[CompilerGenerated]
		private bool _Ellipsized_k__BackingField; // 0x84
		private const string DECOR_PLATE = "vipNamePlate"; // Metadata: 0x005F25FC
	
		// Properties
		public static float VipBadgeScale { get; } // 0x0000000180C11F90-0x0000000180C11FF0 
		public float FittedWidth { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C11FF0-0x0000000180C12000 0x0000000180C12000-0x0000000180C12010
		public float FittedLeft { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C12010-0x0000000180C12020 0x0000000180C12020-0x0000000180C12030
		public float FittedRight { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C12030-0x0000000180C12040 0x0000000180C12040-0x0000000180C12050
		public int FittedFont { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6D80-0x00000001803C6D90 0x00000001803C6D90-0x00000001803C6DA0
		public bool Ellipsized { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C12050-0x0000000180C12060 0x0000000180C12060-0x0000000180C12070
	
		// Constructors
		public HubAvatarNameFit(); // 0x0000000180C14860-0x0000000180C14910
	
		// Methods
		public static HubAvatarNameFit Ensure(UnityEngine.UI.Text label); // 0x0000000180C12070-0x0000000180C12460
		private void OnEnable(); // 0x0000000180C12460-0x0000000180C12480
		private void LateUpdate(); // 0x0000000180C12480-0x0000000180C12650
		private void BindOnce(UnityEngine.UI.Text label); // 0x0000000180C12650-0x0000000180C12A60
		private static float PushOf(UnityEngine.UI.Text label); // 0x0000000180C12A60-0x0000000180C12B50
		public void Apply(); // 0x0000000180C12B50-0x0000000180C134F0
		private void FitOneLine(HubAvatarConfig.Cfg cfg, float avail); // 0x0000000180C134F0-0x0000000180C13930
		private float MeasureWidth(string s, int size); // 0x0000000180C13930-0x0000000180C13AE0
		private static string Ellipsize(string s, int keep, string tail); // 0x0000000180C13AE0-0x0000000180C13CC0
		private void RefreshVipPlate(); // 0x000000018028A320-0x000000018028A330
		private float PillLimit(Rect box, HubAvatarConfig.Cfg cfg); // 0x0000000180C13CC0-0x0000000180C140B0
		private Transform ResolveHeader(); // 0x0000000180C140B0-0x0000000180C14530
		private static Transform FindDeep(Transform root, string name); // 0x0000000180C14530-0x0000000180C147A0
		private static bool IsNameDecor(Transform node); // 0x0000000180C147A0-0x0000000180C14860
	}
}
