using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Core.Productos.Events;
using MediatR;

namespace Clean.Architecture.Core.Productos.Handlers;

public class ProductoEmailNotificationHandler : INotificationHandler<ProductoAddedEvent>
{
  // private readonly IEmailSender _emailSender;

  public Task Handle(ProductoAddedEvent notification, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
