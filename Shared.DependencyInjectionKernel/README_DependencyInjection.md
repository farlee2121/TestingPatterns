# Dependency Injection

Dependency Inversion is the D of the five SOLID priciples. Dependency injection is a popular way of
achieving dependency inversion.

Dependency injection turns function calls into configuration. Instead of instantiating the class you want to call,
you have a registry of forms mapped to dependencies. You specify the form of class you want, and the registry container
hands you an implementation.

In languages like C#, the 'form' is almost always specified using interfaces. Interfaces have the benefit of ensuring a
certain level of behavior and one class can satisfy many interfaces.

So, what's the deal. Why do we even want this? 

Academically, it breaks the dependency of the higher level class on the lower level class. You no longer are explictly 
tied to the details of low level concerns.

Practically, this
 - Allows us to write code top-down, simply writing in the interfaces of the next level of dependencies we need.
   This makes for less code re-work and allows us to test a flow without writing the whole dependency stack
 - Allows us to swap in different dependencies of equivalent purpose with only config change
   - E.g. you could completely switch storage paradigms based on execution environment 
 - Allows us to isolate code for testing