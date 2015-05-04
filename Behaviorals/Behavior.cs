using System;

namespace Behaviorals {

	public class Behaviour<TTrigger, TSubclass> where TTrigger : struct, IConvertible where TSubclass : IBehavioral<TTrigger, TSubclass> {

		public Behaviour(Action<TSubclass> action) {
			if (!typeof(TTrigger).IsEnum)
				throw new ArgumentException($"Generic parameter {nameof(TTrigger)} must be an enum");

			Action = action;
		}

		public Action<TSubclass> Action { get; protected set; }
	}
}