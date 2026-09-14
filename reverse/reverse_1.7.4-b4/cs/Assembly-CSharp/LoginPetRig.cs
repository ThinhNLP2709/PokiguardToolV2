/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class LoginPetRig : MonoBehaviour // TypeDefIndex: 1079
{
	// Fields
	[CompilerGenerated]
	private static LoginPetRig _Active_k__BackingField; // 0x00
	private const float FIT = 0.95f; // Metadata: 0x005F0781
	private const float FADE_IN = 0.25f; // Metadata: 0x005F0785
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
	public static LoginPetRig Active { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806653A0-0x00000001806653E0 0x00000001806653E0-0x0000000180665480
	public int PartCount { get; } // 0x0000000180665480-0x00000001806654A0 
	public bool Built { get; } // 0x00000001803C6F40-0x00000001803C6F50 
	public bool IsReady { get; } // 0x00000001806654A0-0x00000001806654F0 

	// Nested types
	private enum Role // TypeDefIndex: 1080
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
	private sealed class __c__DisplayClass49_0 // TypeDefIndex: 1081
	{
		// Fields
		public List<LoginPetRigData.Part> parts; // 0x10
		public List<int> src; // 0x18

		// Constructors
		public __c__DisplayClass49_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal int _SortSiblings_b__0(int x, int y); // 0x000000018066A750-0x000000018066A850
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass50_0 // TypeDefIndex: 1082
	{
		// Fields
		public Image captured; // 0x10

		// Constructors
		public __c__DisplayClass50_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BindArt_b__0(); // 0x000000018066A850-0x000000018066A860
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass51_0 // TypeDefIndex: 1083
	{
		// Fields
		public Image img; // 0x10

		// Constructors
		public __c__DisplayClass51_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FadeIn_b__0(float a); // 0x000000018066A860-0x000000018066A9B0
	}

	// Constructors
	public LoginPetRig(); // 0x000000018066A0D0-0x000000018066A750

	// Methods
	public static bool HasCoreArt(); // 0x00000001806654F0-0x0000000180665580
	public static bool CoreArtMissing(); // 0x0000000180665580-0x0000000180665610
	private static bool ArtReady(string name); // 0x0000000180665610-0x0000000180665760
	private static bool Missing(string name); // 0x0000000180665760-0x00000001806657E0
	private bool HasRealSprite(int i); // 0x00000001806657E0-0x00000001806659E0
	public void Build(RectTransform box, LoginPetRigData data); // 0x00000001806659E0-0x0000000180666BC0
	private void Alloc(int m); // 0x0000000180666BC0-0x00000001806670F0
	private static Vector2 BoxSize(RectTransform box); // 0x00000001806670F0-0x0000000180667290
	private static Vector2 NormPivot(LoginPetRigData.Part p); // 0x0000000180667290-0x0000000180667420
	private RectTransform NewPart(Transform parent, string name); // 0x0000000180667420-0x0000000180667990
	private void AssignRole(LoginPetRigData.Part p, int slot); // 0x0000000180667990-0x0000000180667AB0
	private static Role RoleOf(LoginPetRigData.Part p); // 0x0000000180667AB0-0x0000000180667C90
	private void SortSiblings(List<LoginPetRigData.Part> parts, List<int> src); // 0x0000000180667C90-0x0000000180668070
	private void BindArt(); // 0x0000000180668070-0x0000000180668440
	private static void FadeIn(Image img); // 0x0000000180668440-0x0000000180668870
	public void Tick(float t, float dt); // 0x0000000180668870-0x0000000180668890
	public void SetPaused(bool on); // 0x0000000180668890-0x00000001806688A0
	public void SetLowTier(bool low); // 0x00000001806688A0-0x00000001806688D0
	public void ApplyRestPose(); // 0x00000001806688D0-0x00000001806688E0
	private void ApplyPose(float t); // 0x00000001806688E0-0x00000001806688F0
	private void Pose(float t, bool rest); // 0x00000001806688F0-0x0000000180669620
	private void SetRot(int i, float deg); // 0x0000000180669620-0x0000000180669660
	private static float Sin(float t, float period, float phase); // 0x0000000180669660-0x00000001806696A0
	private static float Tau(float period); // 0x00000001806696A0-0x00000001806696D0
	public void Dispose(); // 0x00000001806696D0-0x0000000180669A10
	private void Clear(); // 0x0000000180669A10-0x0000000180669F60
	private void OnDestroy(); // 0x0000000180669F60-0x000000018066A0D0
}

