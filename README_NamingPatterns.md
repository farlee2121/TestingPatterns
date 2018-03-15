# Naming

Naming is one of the most important tasks you do as a programmer. Name determine how coders will percieve the decomposition of the system
, how easy it is to tell what code does, and how easy it is to find code for a specific need.

##Manager Naming:
 Managers should be named for the application flow they organize. For example, UserCheckoutManager is all the tools functions needed to 
help a user review their order and purchase.
Managers tend to not be centered on nouns, but on chunks of the UX (user experience). Manager are the head of your application.
If you were to get rid of all of your client (web apps, etc) and write a new one, you should only have to map manager methods to UI
components.

The functions in a manager should be named for the purpose they accomplish, not the data that they process.

#Engine Naming
Engines tend to be pretty easy to name. They generally have one computational purpose or one verb that they center around.

#Accessor Naming
Accessors are intrinsically tied to a data source. They can be used by many flows and tend to center around a data type.


#Variable Naming
You should be able to tell what a varible in intended for, not just it's type (though in some cases, like accessors, the type indicates sufficient purpose).
This prevents mistaken manipulation of a variable and clarifies intent for later modification.

You should also never reuse a variable. If you've changed the intent of the data, you should give it a new name to reflect the reason for the change.
For example, if you sort a list, re-assign it to a variable that declares it as sorted.