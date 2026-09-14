/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class LoginPetRig : MonoBehaviour // TypeDefIndex: 1077
{
	// Fields
	[CompilerGenerated]
	private static LoginPetRig _Active_k__BackingField; // 0x00
	private const float FIT = 0.95f; // Metadata: 0x005EF3B4
	private const float FADE_IN = 0.25f; // Metadata: 0x005EF3B8
	private LoginPetRigData.Anim _a; // 0x20
	private RectTransform[] _rt; // 0x28
	private Image[] _img; // 0x30
	private string[] _sprite; // 0x38
	private Vector2[] _offset; // 0x40
	private int[] _parent; // 0x48
	private int[] _order; // 0x50
	private float[] _locRot; // 0x58
	private Vector2[] _locScale; // 0x60
	private Vector2[] _locMove; // 0x68
	private float[] _wRot; // 0x70
	private Vector2[] _wScale; // 0x78
	private Vector2[] _wPos; // 0x80
	private int _iCloud; // 0x88
	private int _iBody; // 0x8C
	private int _iHead; // 0x90
	private int _iEarL; // 0x94
	private int _iEarR; // 0x98
	private int _iArmL; // 0x9C
	private int _iArmR; // 0xA0
	private bool _built; // 0xA4
	private bool _low; // 0xA5
	private bool _paused; // 0xA6
	private float _lastT; // 0xA8

	// Properties
	public static LoginPetRig Active { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806639B0-0x00000001806639F0 0x00000001806639F0-0x0000000180663A90
	public int PartCount { get; } // 0x0000000180663A90-0x0000000180663AB0 
	public bool Built { get; } // 0x00000001803C6270-0x00000001803C6280 
	public bool IsReady { get; } // 0x0000000180663AB0-0x0000000180663B00 

	// Nested types
	private enum Role // TypeDefIndex: 1078
	{
		Other = 0,
		Cloud = 1,
		Body = 2,
		Head = 3,
		EarL = 4,
		EarR = 5,
		ArmL = 6,
		ArmR = 7
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass49_0 // TypeDefIndex: 1079
	{
		// Fields
		public List<LoginPetRigData.Part> parts; // 0x10
		public List<int> src; // 0x18

		// Constructors
		public __c__DisplayClass49_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal int _SortSiblings_b__0(int x, int y); // 0x0000000180668D60-0x0000000180668E60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass50_0 // TypeDefIndex: 1080
	{
		// Fields
		public Image captured; // 0x10

		// Constructors
		public __c__DisplayClass50_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BindArt_b__0(); // 0x0000000180668E60-0x0000000180668E70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass51_0 // TypeDefIndex: 1081
	{
		// Fields
		public Image img; // 0x10

		// Constructors
		public __c__DisplayClass51_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FadeIn_b__0(float a); // 0x0000000180668E70-0x0000000180668FC0
	}

	// Constructors
	public LoginPetRig(); // 0x00000001806686E0-0x0000000180668D60

	// Methods
	public static bool HasCoreArt(); // 0x0000000180663B00-0x0000000180663B90
	public static bool CoreArtMissing(); // 0x0000000180663B90-0x0000000180663C20
	private static bool ArtReady(string name); // 0x0000000180663C20-0x0000000180663D70
	private static bool Missing(string name); // 0x0000000180663D70-0x0000000180663DF0
	private bool HasRealSprite(int i); // 0x0000000180663DF0-0x0000000180663FF0
	public void Build(RectTransform box, LoginPetRigData data); // 0x0000000180663FF0-0x00000001806651D0
	private void Alloc(int m); // 0x00000001806651D0-0x0000000180665700
	private static Vector2 BoxSize(RectTransform box); // 0x0000000180665700-0x00000001806658A0
	private static Vector2 NormPivot(LoginPetRigData.Part p); // 0x00000001806658A0-0x0000000180665A30
	private RectTransform NewPart(Transform parent, string name); // 0x0000000180665A30-0x0000000180665FA0
	private void AssignRole(LoginPetRigData.Part p, int slot); // 0x0000000180665FA0-0x00000001806660C0
	private static Role RoleOf(LoginPetRigData.Part p); // 0x00000001806660C0-0x00000001806662A0
	private void SortSiblings(List<LoginPetRigData.Part> parts, List<int> src); // 0x00000001806662A0-0x0000000180666680
	private void BindArt(); // 0x0000000180666680-0x0000000180666A50
	private static void FadeIn(Image img); // 0x0000000180666A50-0x0000000180666E80
	public void Tick(float t, float dt); // 0x0000000180666E80-0x0000000180666EA0
	public void SetPaused(bool on); // 0x0000000180666EA0-0x0000000180666EB0
	public void SetLowTier(bool low); // 0x0000000180666EB0-0x0000000180666EE0
	public void ApplyRestPose(); // 0x0000000180666EE0-0x0000000180666EF0
	private void ApplyPose(float t); // 0x0000000180666EF0-0x0000000180666F00
	private void Pose(float t, bool rest); // 0x0000000180666F00-0x0000000180667C30
	private void SetRot(int i, float deg); // 0x0000000180667C30-0x0000000180667C70
	private static float Sin(float t, float period, float phase); // 0x0000000180667C70-0x0000000180667CB0
	private static float Tau(float period); // 0x0000000180667CB0-0x0000000180667CE0
	public void Dispose(); // 0x0000000180667CE0-0x0000000180668020
	private void Clear(); // 0x0000000180668020-0x0000000180668570
	private void OnDestroy(); // 0x0000000180668570-0x00000001806686E0
}

