# CQRS Pattern

## Definition
Is a design pattern that separates the read and write operations of a system. Commands handle data modifications (like creating, updating, or deleting records), while queries handle data retrieval. By separating these operations, CQRS can optimize performance, scalability, and security.

## Use Case
### e-commerce
Commands: When customers place orders or update their profiles, these actions are sent as commands to the system, modifying data.

Queries: When customers browse products or view their order history, these actions are sent as queries to retrieve data.

By separating these operations, CQRS allows optimized handling of read-heavy operations like browsing products, without impacting the write-heavy operations like placing orders. This improves performance and scalability. 

## How to
Install following Nuget Packages 

`MediatR` to implement mediator pattern

`Microsoft.EntityFrameworkCore` for DB operations

I am assuming, you have already `Model`, `DbContext` and `Repository` classes defined

### Command
Create a CommandClass and inherit it from `IRequest<T>`. 

`public class AddProductCommand : IRequest<ProductModel>`

Now add CommandHandler class and inherit it from IRequestHandler<in T, out T>
Inject the Repository class and implement the Handle method.
`public class AddProductCommandHandler : IRequest<AddProductCommand, int>`

Now add controller and inject `IMediatr` class

In the program.cs
`builder.Services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssembly(System.Reflection.Assembly.GetExecutingAssembly()));`

## How to identify

If your domain is complex and has different models for reading and writing, CQRS can simplify the design.

If you have distinct security requirements for reads and writes, CQRS can help enforce these.

If you want to separate the business logic for reads and writes, CQRS provides a clear boundary between them.
