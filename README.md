## Use cases/scenarios

**Example table/entity**

TODO

**Values**

Map column in table/entity to value; use property name as key, value comes from extracting it from the entity 
`Expression<Func<T,V>>`

Provide fixed key; extract value from entity
`(string, Func<T, V>)`

Provide fixed key and fixed value
`(string, V)`


**Objects**

Fixed key; build object from builder
`(string, Action<Builder>)`

Extract key from entity's property mapped to a string; build object from builder
`(Func<T, string>, Action<Builder>)`

Take key from entity's property's name; build object from builder? Not sure what the use case is here
`(Expression<Func<T, V>>, Action<Builder>)`

**Typed objects**

Fixed key; build object from builder
`(string, Action<TypedBuilder>)`

Extract key from entity's property mapped to a string; build object from builder
`(Func<T, string>, Action<TypedBuilder>)`