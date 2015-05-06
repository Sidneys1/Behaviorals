using System;
using System.Collections.Generic;

namespace Behaviorals {

	public interface IBehavioral<TSubclass> where TSubclass : IBehavioral<TSubclass> {

		MultiMap<int, Behaviour<TSubclass>> Behaviours { get; }

		Dictionary<string, object> AttachedProperties { get; }

		void Trigger(int trigger);
	}
}