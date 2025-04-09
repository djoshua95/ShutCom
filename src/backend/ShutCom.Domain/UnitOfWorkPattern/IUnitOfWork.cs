using ShutCom.Domain.Repository;
using ShutCom.Model.Entities;

namespace ShutCom.Domain.UnitOfWorkPattern;
public interface IUnitOfWork
{
    IRepositoryBase<Attachment> AttachmentRepository { get; }
    IRepositoryBase<CartItem> CartItemRepository { get; }
    IRepositoryBase<Order> OrderRepository { get; }
    IRepositoryBase<OrderItem> OrderItemRepository { get; }
    IRepositoryBase<Product> ProductRepository { get; }
    IRepositoryBase<ProductAttachment> ProductAttachmentRepository { get; }
    IRepositoryBase<User> UserRepository { get; }
}