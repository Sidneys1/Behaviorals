using System;

namespace Behaviorals {

	public class Behaviour<TSubclass> where TSubclass : IBehavioral<TSubclass> {
        public Behaviour(Action<TSubclass> action) {
			Action = action;
		}

		public Action<TSubclass> Action { get; protected set; }
	}
}