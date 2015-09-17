**Structural Design Patterns**
==========================

Shord descriptions and use examples for **Adapter , Composite  and Decorator** design patterns. In software engineering, structural design patterns are design patterns that ease the design by identifying a simple way to realize relationships between entities.


**Adapter pattern**
===============

1. **Intends**
--------------

Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.
Wrap an existing class with a new interface.
Impedance match an old component to a new system

    
2. **Description**
------------------

Reuse has always been painful and elusive. One reason has been the tribulation of designing something new, while reusing something old. There is always something not quite right between the old and the new. It may be physical dimensions or misalignment. It may be timing or synchronization. It may be unfortunate assumptions or competing standards.

It is like the problem of inserting a new three-prong electrical plug in an old two-prong wall outlet – some kind of adapter or intermediary is necessary.

![enter image description here](https://sourcemaking.com/files/v2/content/patterns/Adapter_realexample.svg)

 

3. **Structure**
================

Below, a legacy Rectangle component's display() method expects to receive "x, y, w, h" parameters. But the client wants to pass "upper left x and y" and "lower right x and y". This incongruity can be reconciled by adding an additional level of indirection – i.e. an Adapter object.
![enter image description here](https://sourcemaking.com/files/v2/content/patterns/Adapter_1-2x.png)

The Adapter could also be thought of as a "wrapper".
![enter image description here](https://sourcemaking.com/files/v2/content/patterns/Adapter-2x.png)

 4. **Example**
---------------

The Adapter pattern allows otherwise incompatible classes to work together by converting the interface of one class into an interface expected by the clients. Socket wrenches provide an example of the Adapter. A socket attaches to a ratchet, provided that the size of the drive is the same. Typical drive sizes in the United States are 1/2" and 1/4". Obviously, a 1/2" drive ratchet will not fit into a 1/4" drive socket unless an adapter is used. A 1/2" to 1/4" adapter has a 1/2" female connection to fit on the 1/2" drive ratchet, and a 1/4" male connection to fit in the 1/4" drive socket.
![enter image description here](https://sourcemaking.com/files/v2/content/patterns/Adapter_example1-2x.png)

**Check list**

Identify the players: the component(s) that want to be accommodated (i.e. the client), and the component that needs to adapt (i.e. the adaptee).
Identify the interface that the client requires.
Design a "wrapper" class that can "impedance match" the adaptee to the client.
The adapter/wrapper class "has a" instance of the adaptee class.
The adapter/wrapper class "maps" the client interface to the adaptee interface.
The client uses (is coupled to) the new interface

**Rules of thumb**


Adapter makes things work after they're designed; Bridge makes them work before they are.
Bridge is designed up-front to let the abstraction and the implementation vary independently. Adapter is retrofitted to make unrelated classes work together.
Adapter provides a different interface to its subject. Proxy provides the same interface. Decorator provides an enhanced interface.
Adapter is meant to change the interface of an existing object. Decorator enhances another object without changing its interface. Decorator is thus more transparent to the application than an adapter is. As a consequence, Decorator supports recursive composition, which isn't possible with pure Adapters.
Facade defines a new interface, whereas Adapter reuses an old interface. Remember that Adapter makes two existing interfaces work together as opposed to defining an entirely new one.

    using System;
    
      class MainApp
      {
        static void Main()
        {
          // Create adapter and place a request 
          Target target = new Adapter();
          target.Request();
    
          // Wait for user 
          Console.Read();
        }
      }
    
      // "Target" 
      class Target
      {
        public virtual void Request()
        {
          Console.WriteLine("Called Target Request()");
        }
      }
    
      // "Adapter" 
      class Adapter : Target
      {
        private Adaptee adaptee = new Adaptee();
    
        public override void Request()
        {
          // Possibly do some other work 
          // and then call SpecificRequest 
          adaptee.SpecificRequest();
        }
      }
    
      // "Adaptee" 
      class Adaptee
      {
        public void SpecificRequest()
        {
          Console.WriteLine("Called SpecificRequest()");
        }
      }

  
Output

     Called SpecificRequest()

## Composite Design Pattern ##

1. Intent
---------
Compose objects into tree structures to represent whole-part hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly.
Recursive composition
"Directories contain entries, each of which could be a directory."
1-to-many "has a" up the "is a" hierarchy

2. Problem
---------
Application needs to manipulate a hierarchical collection of "primitive" and "composite" objects. Processing of a primitive object is handled one way, and processing of a composite object is handled differently. Having to query the "type" of each object before attempting to process it is not desirable

3. Description
---------
Define an abstract base class (Component) that specifies the behavior that needs to be exercised uniformly across all primitive and composite objects. Subclass the Primitive and Composite classes off of the Component class. Each Composite object "couples" itself only to the abstract type Component as it manages its "children".

Use this pattern whenever you have "composites that contain components, each of which could be a composite".

Child management methods [e.g. addChild(), removeChild()] should normally be defined in the Composite class. Unfortunately, the desire to treat Primitives and Composites uniformly requires that these methods be moved to the abstract Component class. See the "Opinions" section below for a discussion of "safety" versus "transparency" issues.

4. Structure
---------
Composites that contain Components, each of which could be a Composite.
![enter image description here](https://sourcemaking.com/files/v2/content/patterns/Composite-2x.png)

Menus that contain menu items, each of which could be a menu.

Row-column GUI layout managers that contain widgets, each of which could be a row-column GUI layout manager.

Directories that contain files, each of which could be a directory.

Containers that contain Elements, each of which could be a Container.

5. Example
---------
The Composite composes objects into tree structures and lets clients treat individual objects and compositions uniformly. Although the example is abstract, arithmetic expressions are Composites. An arithmetic expression consists of an operand, an operator (+ - * /), and another operand. The operand can be a number, or another arithmetic expresssion. Thus, 2 + 3 and (2 + 3) + (4 * 6) are both valid expressions.

![enter image description here](https://sourcemaking.com/files/v2/content/patterns/Composite_example1-2x.png)

**Check list**

Ensure that your problem is about representing "whole-part" hierarchical relationships.
Consider the heuristic, "Containers that contain containees, each of which could be a container." For example, "Assemblies that contain components, each of which could be an assembly." Divide your domain concepts into container classes, and containee classes.
Create a "lowest common denominator" interface that makes your containers and containees interchangeable. It should specify the behavior that needs to be exercised uniformly across all containee and container objects.
All container and containee classes declare an "is a" relationship to the interface.
All container classes declare a one-to-many "has a" relationship to the interface.
Container classes leverage polymorphism to delegate to their containee objects.
Child management methods [e.g. addChild(), removeChild()] should normally be defined in the Composite class. Unfortunately, the desire to treat Leaf and Composite objects uniformly may require that these methods be promoted to the abstract Component class. See the Gang of Four for a discussion of these "safety" versus "transparency" trade-offs.

**Rules of thumb**
Composite and Decorator have similar structure diagrams, reflecting the fact that both rely on recursive composition to organize an open-ended number of objects.
Composite can be traversed with Iterator. Visitor can apply an operation over a Composite. Composite could use Chain of Responsibility to let components access global properties through their parent. It could also use Decorator to override these properties on parts of the composition. It could use Observer to tie one object structure to another and State to let a component change its behavior as its state changes.
Composite can let you compose a Mediator out of smaller pieces through recursive composition.
Decorator is designed to let you add responsibilities to objects without subclassing. Composite's focus is not on embellishment but on representation. These intents are distinct but complementary. Consequently, Composite and Decorator are often used in concert.
Flyweight is often combined with Composite to implement shared leaf nodes.

 

        using System;
    using System.Collections;
    
      class MainApp
      {
        static void Main()
        {
          // Create a tree structure 
          Composite root = new Composite("root");
          root.Add(new Leaf("Leaf A"));
          root.Add(new Leaf("Leaf B"));
    
          Composite comp = new Composite("Composite X");
          comp.Add(new Leaf("Leaf XA"));
          comp.Add(new Leaf("Leaf XB"));
    
          root.Add(comp);
          root.Add(new Leaf("Leaf C"));
    
          // Add and remove a leaf 
          Leaf leaf = new Leaf("Leaf D");
          root.Add(leaf);
          root.Remove(leaf);
    
          // Recursively display tree 
          root.Display(1);
    
          // Wait for user 
          Console.Read();
        }
      }
    
      // "Component" 
      abstract class Component
      {
        protected string name;
    
        // Constructor 
        public Component(string name)
        {
          this.name = name;
        }
    
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
      }
    
      // "Composite" 
      class Composite : Component
      {
        private ArrayList children = new ArrayList();
    
        // Constructor 
        public Composite(string name) : base(name) 
        {  
        }
    
        public override void Add(Component component)
        {
          children.Add(component);
        }
    
        public override void Remove(Component component)
        {
          children.Remove(component);
        }
    
        public override void Display(int depth)
        {
          Console.WriteLine(new String('-', depth) + name);
    
          // Recursively display child nodes 
          foreach (Component component in children)
          {
            component.Display(depth + 2);
          }
        }
      }
    
      // "Leaf" 
      class Leaf : Component
      {
        // Constructor 
        public Leaf(string name) : base(name) 
        {  
        }
    
        public override void Add(Component c)
        {
          Console.WriteLine("Cannot add to a leaf");
        }
    
        public override void Remove(Component c)
        {
          Console.WriteLine("Cannot remove from a leaf");
        }
    
        public override void Display(int depth)
        {
          Console.WriteLine(new String('-', depth) + name);
        }
      }

output 

        -root
    ---Leaf A
    ---Leaf B
    ---Composite X
    -----Leaf XA
    -----Leaf XB
    ---Leaf C

## Decorator Design Pattern##


1. Intent
---------
Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality.
Client-specified embellishment of a core object by recursively wrapping it.
Wrapping a gift, putting it in a box, and wrapping the box.

2 Problem
---------
You want to add behavior or state to individual objects at run-time. Inheritance is not feasible because it is static and applies to an entire class.

3. Description
---------
Suppose you are working on a user interface toolkit and you wish to support adding borders and scroll bars to windows. You could define an inheritance hierarchy like ...
![enter image description here](https://sourcemaking.com/files/v2/content/patterns/Decorator-2x.png)

But the Decorator pattern suggests giving the client the ability to specify whatever combination of "features" is desired.

        Widget* aWidget = new BorderDecorator(
      new HorizontalScrollBarDecorator(
        new VerticalScrollBarDecorator(
          new Window( 80, 24 ))));
	    aWidget->draw();

This flexibility can be achieved with the following design
![enter image description here](https://sourcemaking.com/files/v2/content/patterns/Decorator_-2x.png)

    Stream* aStream = new CompressingStream(
      new ASCII7Stream(
        new FileStream("fileName.dat")));
    aStream->putString( "Hello world" );

The solution to this class of problems involves encapsulating the original object inside an abstract wrapper interface. Both the decorator objects and the core object inherit from this abstract interface. The interface uses recursive composition to allow an unlimited number of decorator "layers" to be added to each core object.

Note that this pattern allows responsibilities to be added to an object, not methods to an object's interface. The interface presented to the client must remain constant as successive layers are specified.

Also note that the core object's identity has now been "hidden" inside of a decorator object. Trying to access the core object directly is now a problem.

4. Structure
---------
The client is always interested in CoreFunctionality.doThis(). The client may, or may not, be interested in OptionalOne.doThis() and OptionalTwo.doThis(). Each of these classes always delegate to the Decorator base class, and that class always delegates to the contained "wrappee" object.
![enter image description here](https://sourcemaking.com/files/v2/content/patterns/Decorator__1-2x.png)

5. Example
---------
The Decorator attaches additional responsibilities to an object dynamically. The ornaments that are added to pine or fir trees are examples of Decorators. Lights, garland, candy canes, glass ornaments, etc., can be added to a tree to give it a festive look. The ornaments do not change the tree itself which is recognizable as a Christmas tree regardless of particular ornaments used. As an example of additional functionality, the addition of lights allows one to "light up" a Christmas tree.

Another example: assault gun is a deadly weapon on it's own. But you can apply certain "decorations" to make it more accurate, silent and devastating.

![enter image description here](https://sourcemaking.com/files/v2/content/patterns/Decorator_example-2x.png)

Check list
Ensure the context is: a single core (or non-optional) component, several optional embellishments or wrappers, and an interface that is common to all.
Create a "Lowest Common Denominator" interface that makes all classes interchangeable.
Create a second level base class (Decorator) to support the optional wrapper classes.
The Core class and Decorator class inherit from the LCD interface.
The Decorator class declares a composition relationship to the LCD interface, and this data member is initialized in its constructor.
The Decorator class delegates to the LCD object.
Define a Decorator derived class for each optional embellishment.
Decorator derived classes implement their wrapper functionality - and - delegate to the Decorator base class.
The client configures the type and ordering of Core and Decorator objects.
Rules of thumb
Adapter provides a different interface to its subject. Proxy provides the same interface. Decorator provides an enhanced interface.
Adapter changes an object's interface, Decorator enhances an object's responsibilities. Decorator is thus more transparent to the client. As a consequence, Decorator supports recursive composition, which isn't possible with pure Adapters.
Composite and Decorator have similar structure diagrams, reflecting the fact that both rely on recursive composition to organize an open-ended number of objects.
A Decorator can be viewed as a degenerate Composite with only one component. However, a Decorator adds additional responsibilities - it isn't intended for object aggregation.
Decorator is designed to let you add responsibilities to objects without subclassing. Composite's focus is not on embellishment but on representation. These intents are distinct but complementary. Consequently, Composite and Decorator are often used in concert.
Composite could use Chain of Responsibility to let components access global properties through their parent. It could also use Decorator to override these properties on parts of the composition.
Decorator and Proxy have different purposes but similar structures. Both describe how to provide a level of indirection to another object, and the implementations keep a reference to the object to which they forward requests.
Decorator lets you change the skin of an object. Strategy lets you change the guts.

    using System;
    
      class MainApp
      {
        static void Main()
        {
          // Create ConcreteComponent and two Decorators 
          ConcreteComponent c = new ConcreteComponent();
          ConcreteDecoratorA d1 = new ConcreteDecoratorA();
          ConcreteDecoratorB d2 = new ConcreteDecoratorB();
    
          // Link decorators 
          d1.SetComponent(c);
          d2.SetComponent(d1);
    
          d2.Operation();
    
          // Wait for user 
          Console.Read();
        }
      }
    
      // "Component" 
      abstract class Component
      {
        public abstract void Operation();
      }
    
      // "ConcreteComponent" 
      class ConcreteComponent : Component
      {
        public override void Operation()
        {
          Console.WriteLine("ConcreteComponent.Operation()");
        }
      }
    
      // "Decorator" 
      abstract class Decorator : Component
      {
        protected Component component;
    
        public void SetComponent(Component component)
        {
          this.component = component;
        }
    
        public override void Operation()
        {
          if (component != null)
          {
            component.Operation();
          }
        }
      }
    
      // "ConcreteDecoratorA" 
      class ConcreteDecoratorA : Decorator
      {
        private string addedState;
    
        public override void Operation()
        {
          base.Operation();
          addedState = "New State";
          Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
      }
    
      // "ConcreteDecoratorB" 
      class ConcreteDecoratorB : Decorator
      {
        public override void Operation()
        {
          base.Operation();
          AddedBehavior();
          Console.WriteLine("ConcreteDecoratorB.Operation()");
        }
    
        void AddedBehavior()
        {
        }
      }

Output

    ConcreteComponent.Operation()
    ConcreteDecoratorA.Operation()
    ConcreteDecoratorB.Operation()