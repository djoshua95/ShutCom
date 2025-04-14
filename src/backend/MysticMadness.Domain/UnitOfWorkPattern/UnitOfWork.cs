using MysticMadness.Domain.Repository;
using MysticMadness.Model;
using MysticMadness.Model.Entities;

namespace MysticMadness.Domain.UnitOfWorkPattern;

public class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private IRepositoryBase<Attachment>? _attachmentRepository;
    public IRepositoryBase<Attachment> AttachmentRepository
    {
        get => _attachmentRepository ??= new RepositoryBase<Attachment>(_dbContext);
    }

    private IRepositoryBase<CartItem>? _cartItemRepository;
    public IRepositoryBase<CartItem> CartItemRepository
    {
        get => _cartItemRepository ??= new RepositoryBase<CartItem>(_dbContext);
    }

    private IRepositoryBase<Order>? _orderRepository;
    public IRepositoryBase<Order> OrderRepository
    {
        get => _orderRepository ??= new RepositoryBase<Order>(_dbContext);
    }

    private IRepositoryBase<OrderItem>? _orderItemRepository;
    public IRepositoryBase<OrderItem> OrderItemRepository
    {
        get => _orderItemRepository ??= new RepositoryBase<OrderItem>(_dbContext);
    }

    private IRepositoryBase<Product>? _productRepository;
    public IRepositoryBase<Product> ProductRepository
    {
        get => _productRepository ??= new RepositoryBase<Product>(_dbContext);
    }

    private IRepositoryBase<ProductAttachment>? _productAttachmentRepository;
    public IRepositoryBase<ProductAttachment> ProductAttachmentRepository
    {
        get => _productAttachmentRepository ??= new RepositoryBase<ProductAttachment>(_dbContext);
    }

    private IRepositoryBase<User>? _userRepository;
    public IRepositoryBase<User> UserRepository
    {
        get => _userRepository ??= new RepositoryBase<User>(_dbContext);
    }
}