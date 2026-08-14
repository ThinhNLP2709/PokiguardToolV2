namespace Unity.Properties.Internal;

internal class BoundsPropertyBag : ContainerPropertyBag<Bounds>
{
	private class CenterProperty : Property<Bounds, Vector3>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public CenterProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual Vector3 GetValue(ref Bounds container) { }

		public virtual void SetValue(ref Bounds container, Vector3 value) { }

	}

	private class ExtentsProperty : Property<Bounds, Vector3>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public ExtentsProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual Vector3 GetValue(ref Bounds container) { }

		public virtual void SetValue(ref Bounds container, Vector3 value) { }

	}


	public BoundsPropertyBag() { }

}

