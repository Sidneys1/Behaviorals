using System;
using System.Collections.Generic;

namespace Behaviorals {

	public interface IBehavioral<TTrigger, TSubclass> where TTrigger : struct, IConvertible where TSubclass : IBehavioral<TTrigger, TSubclass> {

		MultiMap<TTrigger, Behaviour<TTrigger, TSubclass>> Behaviours { get; }

		Dictionary<string, object> AttachedProperties { get; }

		void Trigger(TTrigger trigger);
	}
}