namespace DG.Tweening;

public static class DOTweenCYInstruction
{
	internal class WaitForCompletion : CustomYieldInstruction
	{
		private readonly Tween t; //Field offset: 0x10

		public virtual bool keepWaiting
		{
			 get { } //Length: 51
		}

		public WaitForCompletion(Tween tween) { }

		public virtual bool get_keepWaiting() { }

	}

	internal class WaitForElapsedLoops : CustomYieldInstruction
	{
		private readonly Tween t; //Field offset: 0x10
		private readonly int elapsedLoops; //Field offset: 0x18

		public virtual bool keepWaiting
		{
			 get { } //Length: 62
		}

		public WaitForElapsedLoops(Tween tween, int elapsedLoops) { }

		public virtual bool get_keepWaiting() { }

	}

	internal class WaitForKill : CustomYieldInstruction
	{
		private readonly Tween t; //Field offset: 0x10

		public virtual bool keepWaiting
		{
			 get { } //Length: 30
		}

		public WaitForKill(Tween tween) { }

		public virtual bool get_keepWaiting() { }

	}

	internal class WaitForPosition : CustomYieldInstruction
	{
		private readonly Tween t; //Field offset: 0x10
		private readonly float position; //Field offset: 0x18

		public virtual bool keepWaiting
		{
			 get { } //Length: 98
		}

		public WaitForPosition(Tween tween, float position) { }

		public virtual bool get_keepWaiting() { }

	}

	internal class WaitForRewind : CustomYieldInstruction
	{
		private readonly Tween t; //Field offset: 0x10

		public virtual bool keepWaiting
		{
			 get { } //Length: 105
		}

		public WaitForRewind(Tween tween) { }

		public virtual bool get_keepWaiting() { }

	}

	internal class WaitForStart : CustomYieldInstruction
	{
		private readonly Tween t; //Field offset: 0x10

		public virtual bool keepWaiting
		{
			 get { } //Length: 49
		}

		public WaitForStart(Tween tween) { }

		public virtual bool get_keepWaiting() { }

	}


}

