namespace DG.Tweening;

[Extension]
public static class TweenExtensions
{

	[Extension]
	public static void Complete(Tween t) { }

	[Extension]
	public static void Complete(Tween t, bool withCallbacks) { }

	[Extension]
	public static int CompletedLoops(Tween t) { }

	[Extension]
	public static float Delay(Tween t) { }

	private static void DoGoto(Tween t, float to, bool andPlay, bool withCallbacks) { }

	[Extension]
	public static T Done(T t) { }

	[Extension]
	public static float Duration(Tween t, bool includeLoops = true) { }

	[Extension]
	public static float Elapsed(Tween t, bool includeLoops = true) { }

	[Extension]
	public static float ElapsedDelay(Tween t) { }

	[Extension]
	public static float ElapsedDirectionalPercentage(Tween t) { }

	[Extension]
	public static float ElapsedPercentage(Tween t, bool includeLoops = true) { }

	[Extension]
	public static void Flip(Tween t) { }

	[Extension]
	public static void ForceInit(Tween t) { }

	[Extension]
	public static void Goto(Tween t, float to, bool andPlay = false) { }

	[Extension]
	public static void GotoWaypoint(Tween t, int waypointIndex, bool andPlay = false) { }

	[Extension]
	public static void GotoWithCallbacks(Tween t, float to, bool andPlay = false) { }

	[Extension]
	public static bool IsActive(Tween t) { }

	[Extension]
	public static bool IsBackwards(Tween t) { }

	[Extension]
	public static bool IsComplete(Tween t) { }

	[Extension]
	public static bool IsInitialized(Tween t) { }

	[Extension]
	public static bool IsLoopingOrExecutingBackwards(Tween t) { }

	[Extension]
	public static bool IsPlaying(Tween t) { }

	[Extension]
	public static void Kill(Tween t, bool complete = false) { }

	[Extension]
	public static int Loops(Tween t) { }

	[Extension]
	public static void ManualUpdate(Tween t, float deltaTime, float unscaledDeltaTime) { }

	[Extension]
	public static Vector3[] PathGetDrawPoints(Tween t, int subdivisionsXSegment = 10) { }

	[Extension]
	public static Vector3 PathGetPoint(Tween t, float pathPercentage) { }

	[Extension]
	public static float PathLength(Tween t) { }

	[Extension]
	public static T Pause(T t) { }

	[Extension]
	public static T Play(T t) { }

	[Extension]
	public static void PlayBackwards(Tween t) { }

	[Extension]
	public static void PlayForward(Tween t) { }

	[Extension]
	public static void Restart(Tween t, bool includeDelay = true, float changeDelayTo = -1) { }

	[Extension]
	public static void Rewind(Tween t, bool includeDelay = true) { }

	[Extension]
	public static void SmoothRewind(Tween t) { }

	[Extension]
	public static void TogglePause(Tween t) { }

	[Extension]
	public static YieldInstruction WaitForCompletion(Tween t) { }

	[Extension]
	public static YieldInstruction WaitForElapsedLoops(Tween t, int elapsedLoops) { }

	[Extension]
	public static YieldInstruction WaitForKill(Tween t) { }

	[Extension]
	public static YieldInstruction WaitForPosition(Tween t, float position) { }

	[Extension]
	public static YieldInstruction WaitForRewind(Tween t) { }

	[Extension]
	public static Coroutine WaitForStart(Tween t) { }

}

