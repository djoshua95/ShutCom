CREATE TABLE [Attachments] (
    [Id] int NOT NULL IDENTITY,
    [Link] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Type] int NOT NULL,
    [Format] nvarchar(max) NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    [LastUpdateDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Attachments] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Price] decimal(10,2) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Model] nvarchar(max) NULL,
    [CreationDate] datetime2 NOT NULL,
    [LastUpdateDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [MiddleName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [NickName] nvarchar(max) NOT NULL,
    [Age] int NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [PhoneNumber] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [ProductAttachments] (
    [ProductId] int NOT NULL,
    [AttachmentId] int NOT NULL,
    CONSTRAINT [PK_ProductAttachments] PRIMARY KEY ([ProductId], [AttachmentId]),
    CONSTRAINT [FK_ProductAttachments_Attachments_AttachmentId] FOREIGN KEY ([AttachmentId]) REFERENCES [Attachments] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductAttachments_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [CartItems] (
    [Id] int NOT NULL IDENTITY,
    [Quantity] int NOT NULL,
    [UserId] int NOT NULL,
    [ProductId] int NOT NULL,
    CONSTRAINT [PK_CartItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CartItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CartItems_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [OrderItems] (
    [Id] int NOT NULL IDENTITY,
    [Quantity] int NOT NULL,
    [ProductId] int NOT NULL,
    [OrderId] int NOT NULL,
    CONSTRAINT [PK_OrderItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_CartItems_ProductId] ON [CartItems] ([ProductId]);
GO


CREATE INDEX [IX_CartItems_UserId] ON [CartItems] ([UserId]);
GO


CREATE INDEX [IX_OrderItems_OrderId] ON [OrderItems] ([OrderId]);
GO


CREATE INDEX [IX_OrderItems_ProductId] ON [OrderItems] ([ProductId]);
GO


CREATE INDEX [IX_Orders_UserId] ON [Orders] ([UserId]);
GO


CREATE INDEX [IX_ProductAttachments_AttachmentId] ON [ProductAttachments] ([AttachmentId]);
GO



