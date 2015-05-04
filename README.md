# Behaviorals
Allows basic attatched behaviors in C# projects using generics

```C#
// First you will need a trigger enum:
public enum TriggerEnum {
  TriggerA,
  TriggerB
}

// Make any class Behavioral by implementing IBehavioral:
public class MyBehavioredClass : IBehavioral<TriggerEnum, MyBehavioredClass> {
  public MultiMap<TTrigger, Behaviour<TriggerEnum, MyBehavioredClass>> Behaviours { get; } = new MultiMap<TTrigger, Behaviour<TriggerEnum, MyBehavioredClass>>()
  public Dictionary<string, object> AttachedProperties { get; } = new Dictionary<string, object>();
  public void Trigger(TriggerEnum trigger) {
    if (!Behaviours.ContainsKey(trigger)) return;
    foreach (var behaviourBase in Behaviours[trigger]) {
        behaviourBase.Action.Invoke(this);
    }
  }
  
  // Public property:
  public string Text { get; } = "MyText";
  
  // Now you can trigger any Behaviors as needed:
  public void ThrowsTriggerA() {
    Trigger(TriggerEnum.TriggerA);
  }
  public void ThrowsTriggerB() {
    Trigger(TriggerEnum.TriggerB);
  }
}

public static void main() {
  var behaviorA = new Behaviour<TriggerEnum, MyBehavioredClass>(o =>
  {
      Console.WriteLine($"{(string)o.AttachedProperties["prefix"]} Uppercase: {o.Text.ToUpper()}");
  });
  var behaviorB = new Behaviour<TriggerEnum, MyBehavioredClass>(o =>
  {
      Console.WriteLine($"{(string)o.AttachedProperties["prefix"]} Lowercase: {o.Text.ToLower()}");
  });

  var myClass = new MyBehavioredClass() {
    Behaviors = {{ TriggerEnum.TriggerA, behaviorA },{ TriggerEnum.TriggerB, behaviorB }},
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
