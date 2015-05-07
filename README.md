# Behaviorals
Allows basic attatched behaviors in C# projects using generics

```C#
// First you will need a trigger enum:
public static class TriggerEnum {
  public static readonly int TriggerA = 0;
  public static readonly int TriggerB = 1;
}

// Make any class Behavioral by implementing IBehavioral:
public class MyBehavioredClass : IBehavioral<MyBehavioredClass> {
  public MultiMap<int, Behaviour<MyBehavioredClass>> Behaviours { get; } = new MultiMap<int, Behaviour<MyBehavioredClass>>()
  public Dictionary<string, object> AttachedProperties { get; } = new Dictionary<string, object>();
  public void Trigger(int trigger) {
    if (!Behaviours.ContainsKey(trigger)) return;
    foreach (var behaviourBase in Behaviours[trigger]) {
        behaviourBase.Action.Invoke(this);
    }
  }
  
  // Public property:
  public string Text { get; } = "MyText";
  
  // Now you can trigger any Behaviors as needed:
  public void ThrowsTriggerA() {
    Trigger(Triggers.TriggerA);
  }
  public void ThrowsTriggerB() {
    Trigger(Triggers.TriggerB);
  }
}

public static void main() {
  var behaviorA = new Behaviour<MyBehavioredClass>((MyBehavioredClass o) =>
  {
      Console.WriteLine($"{(string)o.AttachedProperties["prefix"]} Uppercase: {o.Text.ToUpper()}");
  });
  var behaviorB = new Behaviour<MyBehavioredClass>((MyBehavioredClass o) =>
  {
      Console.WriteLine($"{(string)o.AttachedProperties["prefix"]} Lowercase: {o.Text.ToLower()}");
  });

  var myClass = new MyBehavioredClass() {
    Behaviors = {{ Triggers.TriggerA, behaviorA },{ Triggers.TriggerB, behaviorB }},
    AttachedProperties = {{ "prefix", "Instance A" }}
  };
  
  myClass.ThrowsTriggerA();
  myClass.ThrowsTriggerB();
}

/*
Prints:
Instance A Uppercase: MYTEXT
Instance A Lowercase: mytext
*/
```
