------------------------------------------------------------
-- 0. СОЗДАНИЕ БАЗЫ И ПЕРЕКЛЮЧЕНИЕ В НЕЁ
------------------------------------------------------------
IF DB_ID(N'божечки') IS NULL
    CREATE DATABASE [божечки];
GO

USE [божечки];
GO

------------------------------------------------------------
-- 1. УДАЛЯЕМ ТАБЛИЦЫ, ЕСЛИ УЖЕ ЕСТЬ (ЧТОБЫ СКРИПТ ПОВТОРНО ИДЕМПОтЕНТНО ВЫПОЛНЯЛСЯ)
------------------------------------------------------------
IF OBJECT_ID(N'dbo.Order_Components', 'U') IS NOT NULL DROP TABLE dbo.Order_Components;
IF OBJECT_ID(N'dbo.Finances', 'U')         IS NOT NULL DROP TABLE dbo.Finances;
IF OBJECT_ID(N'dbo.Orders', 'U')           IS NOT NULL DROP TABLE dbo.Orders;
IF OBJECT_ID(N'dbo.Components', 'U')       IS NOT NULL DROP TABLE dbo.Components;
IF OBJECT_ID(N'dbo.Catalogs', 'U')         IS NOT NULL DROP TABLE dbo.Catalogs;
IF OBJECT_ID(N'dbo.Clients', 'U')          IS NOT NULL DROP TABLE dbo.Clients;
GO

------------------------------------------------------------
-- 2. СОЗДАНИЕ ТАБЛИЦ С IDENTITY
------------------------------------------------------------

-- Клиенты (добавлен password, phone теперь NULL)
CREATE TABLE [dbo].[Clients] (
    [id]        INT IDENTITY(1,1) NOT NULL,
    [full_name] NVARCHAR(150)  NOT NULL,
    [phone]     NVARCHAR(50)   NULL,
    [email]     NVARCHAR(100)  NOT NULL,
    [address]   NVARCHAR(200)  NOT NULL,
    [password]  VARCHAR(100)   NULL,
    CONSTRAINT PK_Clients PRIMARY KEY CLUSTERED (id)
);
GO

-- Каталог услуг
CREATE TABLE [dbo].[Catalogs] (
    [Id]          INT IDENTITY(1,1) NOT NULL,
    [name]        NVARCHAR(150)  NOT NULL,
    [type]        NVARCHAR(20)   NOT NULL,
    [description] NVARCHAR(MAX)  NOT NULL,
    [price]       DECIMAL(7, 2)  NOT NULL,
    CONSTRAINT PK_Catalogs PRIMARY KEY CLUSTERED (Id)
);
GO

-- Компоненты (склад)
CREATE TABLE [dbo].[Components] (
    [id]             INT IDENTITY(1,1) NOT NULL,
    [name]           NVARCHAR(100)   NOT NULL,
    [type]           NVARCHAR(50)    NOT NULL,
    [purchase_price] NUMERIC(10, 2)  NOT NULL,
    [retail_price]   NUMERIC(10, 2)  NOT NULL,
    [stock_quantity] INT             NOT NULL,
    CONSTRAINT PK_Components PRIMARY KEY CLUSTERED (id)
);
GO

-- Заказы
CREATE TABLE [dbo].[Orders] (
    [id]         INT IDENTITY(1,1) NOT NULL,
    [client_id]  INT            NOT NULL,
    [catalog_id] INT            NOT NULL,
    [date]       DATETIME       NOT NULL,
    [status]     NVARCHAR(50)   NOT NULL,
    [price]      NUMERIC(7, 2)  NOT NULL,
    CONSTRAINT PK_Orders PRIMARY KEY CLUSTERED (id)
);
GO

-- Финансовые операции по заказам
CREATE TABLE [dbo].[Finances] (
    [id]       INT IDENTITY(1,1) NOT NULL,
    [order_id] INT            NOT NULL,
    [type]     NVARCHAR(50)   NOT NULL,
    [price]    NUMERIC(7, 2)  NOT NULL,
    CONSTRAINT PK_Finances PRIMARY KEY CLUSTERED (id)
);
GO

-- Состав заказа (связь заказ–компоненты)
CREATE TABLE [dbo].[Order_Components] (
    [id]           INT IDENTITY(1,1) NOT NULL,
    [order_id]     INT NOT NULL,
    [component_id] INT NOT NULL,
    [quantity]     INT NOT NULL,
    CONSTRAINT PK_Order_Components PRIMARY KEY CLUSTERED (id)
);
GO

------------------------------------------------------------
-- 3. ВНЕШНИЕ КЛЮЧИ
------------------------------------------------------------
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT FK_Orders_Clients
    FOREIGN KEY (client_id) REFERENCES [dbo].[Clients](id);

ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT FK_Orders_Catalogs
    FOREIGN KEY (catalog_id) REFERENCES [dbo].[Catalogs](Id);

ALTER TABLE [dbo].[Finances]
ADD CONSTRAINT FK_Finances_Orders
    FOREIGN KEY (order_id) REFERENCES [dbo].[Orders](id);

ALTER TABLE [dbo].[Order_Components]
ADD CONSTRAINT FK_OrderComponents_Orders
    FOREIGN KEY (order_id) REFERENCES [dbo].[Orders](id);

ALTER TABLE [dbo].[Order_Components]
ADD CONSTRAINT FK_OrderComponents_Components
    FOREIGN KEY (component_id) REFERENCES [dbo].[Components](id);
GO

------------------------------------------------------------
-- 4. ЗАПОЛНЕНИЕ СПРАВОЧНИКОВ С IDENTITY_INSERT
------------------------------------------------------------

SET IDENTITY_INSERT [dbo].[Clients] ON;
INSERT INTO [dbo].[Clients] ([id], [full_name], [phone], [email], [address], [password])
VALUES 
    (1, N'Иванов Иван Иванович',        N'+7(999)123-45-67', N'ivanov@email.com',   N'г. Москва, ул. Пушкина, д. 10', NULL),
    (2, N'Петрова Анна Сергеевна',      N'+7(999)765-43-21', N'petrova@email.com',  N'г. Москва, ул. Лермонтова, д. 5', NULL),
    (3, N'Смирнов Алексей Викторович',  N'+7(900)111-22-33', N'smirnov@email.com',  N'г. Москва, пр-т Мира, д. 15', NULL),
    (4, N'Кузнецова Мария Александровна',N'+7(900)444-55-66',N'kuznecova@email.com',N'г. Москва, ул. Чехова, д. 2', NULL),
    (5, N'Соколов Дмитрий Николаевич',  N'+7(910)999-88-77', N'sokolov@email.com',  N'г. Москва, ул. Гоголя, д. 8', NULL);
SET IDENTITY_INSERT [dbo].[Clients] OFF;
GO

SET IDENTITY_INSERT [dbo].[Catalogs] ON;
INSERT INTO [dbo].[Catalogs] ([Id], [name], [type], [description], [price])
VALUES 
    (1, N'Сборка ПК "Базовая"',     N'Услуга', N'Профессиональная сборка компьютера из комплектующих заказчика без кабель-менеджмента. Включает базовую проверку на включение.', 2500.00),
    (2, N'Сборка ПК "Премиум"',     N'Услуга', N'Сборка ПК любой сложности. Включает идеальный кабель-менеджмент, обновление BIOS, настройку кривой вентиляторов и стресс-тест системы.', 5000.00),
    (3, N'Сборка ПК с СЖО',         N'Услуга', N'Сборка компьютера с установкой системы жидкостного охлаждения, проверка герметичности и стресс-тест.', 8500.00),
    (4, N'Установка Windows + Драйверы', N'Услуга', N'Установка ОС Windows, всех драйверов и базового набора программ.', 1500.00),
    (5, N'Комплексная настройка ПК',N'Услуга', N'Установка ОС, драйверов, антивируса, оптимизация автозагрузки и системных служб.', 3000.00),
    (6, N'Профилактическая чистка',N'Услуга', N'Полная разборка системного блока, очистка от пыли, замена термопасты на процессоре и видеокарте.', 2000.00),
    (7, N'Аппаратная диагностика', N'Услуга', N'Поиск неисправностей с использованием тестовых стендов и диагностических утилит.', 1000.00),
    (8, N'Скальпирование процессора', N'Услуга', N'Снятие крышки процессора и замена термоинтерфейса на жидкий металл.', 4500.00),
    (9, N'Апгрейд комплектующих',  N'Услуга', N'Замена процессора, памяти, видеокарты с консультацией по совместимости.', 1500.00),
    (10,N'Клонирование данных',    N'Услуга', N'Копирование системы и данных со старого диска на новый SSD без переустановки.', 2000.00);
SET IDENTITY_INSERT [dbo].[Catalogs] OFF;
GO

SET IDENTITY_INSERT [dbo].[Components] ON;
INSERT INTO [dbo].[Components] 
    ([id], [name], [type], [purchase_price], [retail_price], [stock_quantity])
VALUES 
    -- Процессоры
    (1,  N'Intel Core i5-12400F',                 N'Процессор',        10000, 12300, 15),
    (2,  N'AMD Ryzen 5 7500F',                    N'Процессор',        12000, 15000, 20),
    (3,  N'Intel Core Ultra 7 265KF',             N'Процессор',        35000, 42000, 5),
    (4,  N'AMD Ryzen 7 7800X3D',                  N'Процессор',        32000, 38000, 8),
    (5,  N'AMD Ryzen 9 9900X',                    N'Процессор',        33000, 39800, 4),
    -- Материнские платы
    (6,  N'MSI PRO B760M-A DDR4 II',              N'Материнская плата',10000, 12800, 12),
    (7,  N'GIGABYTE B650M DS3H',                  N'Материнская плата',12000, 14500, 15),
    (8,  N'MSI B850 GAMING PLUS WIFI',            N'Материнская плата',17000, 20500, 7),
    (9,  N'ASUS TUF GAMING B650-PLUS WIFI',       N'Материнская плата',17500, 21000, 10),
    (10, N'ASUS ROG STRIX Z790-E GAMING',         N'Материнская плата',38000, 45000, 3),
    -- Видеокарты
    (11, N'Intel Arc B570 8 ГБ',                  N'Видеокарта',       17000, 20000, 14),
    (12, N'NVIDIA GeForce RTX 5060 8 ГБ',         N'Видеокарта',       29000, 35000, 25),
    (13, N'NVIDIA GeForce RTX 4060 8 ГБ',         N'Видеокарта',       27000, 32000, 11),
    (14, N'AMD Radeon RX 9070 XTX',               N'Видеокарта',       75000, 88000, 3),
    (15, N'NVIDIA GeForce RTX 5070 Ti 16 ГБ',     N'Видеокарта',       80000, 95000, 5),
    -- Оперативная память
    (16, N'Kingston FURY Beast DDR4 3200 16ГБ',   N'Оперативная память',3500, 4500, 30),
    (17, N'ADATA XPG Lancer DDR5 6000 32ГБ',      N'Оперативная память',9500,11500,20),
    (18, N'Team Group T-Create DDR5 6000 32ГБ',   N'Оперативная память',8500,10500,18),
    (19, N'G.Skill Trident Z5 DDR5 6400 32ГБ',    N'Оперативная память',11500,14000,10),
    (20, N'Kingston FURY Renegade DDR5 7200',     N'Оперативная память',13000,16000,8),
    -- Накопители
    (21, N'Kingston NV2 1 ТБ (PCIe 4.0)',         N'Накопитель',       5000, 6500, 25),
    (22, N'Samsung 980 PRO 1 ТБ (PCIe 4.0)',      N'Накопитель',       9000,11000,15),
    (23, N'WD Black SN850X 1 ТБ (PCIe 4.0)',      N'Накопитель',       10000,12500,12),
    (24, N'ADATA Legend 960 MAX 2 ТБ',            N'Накопитель',       12000,14500,9),
    (25, N'Crucial T700 2 ТБ (PCIe 5.0)',         N'Накопитель',       23000,28000,4),
    -- Блоки питания
    (26, N'Deepcool PK750D 750W',                 N'Блок питания',     5000, 6500, 20),
    (27, N'Deepcool GamerStorm PQ850G 850W',      N'Блок питания',     7000, 8900, 14),
    (28, N'MONTECH Century 850W',                 N'Блок питания',     7500, 9500, 16),
    (29, N'MSI MAG A850GL PCIE5 850W',            N'Блок питания',     9000,11000,10),
    (30, N'be quiet! Straight Power 12 1000W',    N'Блок питания',     18000,22000,5),
    -- Корпуса
    (31, N'Deepcool CC560 V2',                    N'Корпус',           4500, 5500, 18),
    (32, N'Deepcool CG530 4F',                    N'Корпус',           5500, 6700, 15),
    (33, N'Cougar Duoface Pro RGB',               N'Корпус',           6000, 7500, 12),
    (34, N'Montech AIR 903 MAX',                  N'Корпус',           7000, 8500, 10),
    (35, N'Lian Li Lancool 216',                  N'Корпус',           9000,11000,6);
SET IDENTITY_INSERT [dbo].[Components] OFF;
GO

SET IDENTITY_INSERT [dbo].[Orders] ON;
INSERT INTO [dbo].[Orders] ([id], [client_id], [catalog_id], [date], [status], [price])
VALUES 
    (1, 1, 2, '2026-03-20 10:30:00', N'Завершен',        17500.00),
    (2, 2, 3, '2026-03-21 14:15:00', N'Завершен',         8500.00),
    (3, 3, 1, '2026-03-22 09:00:00', N'В работе',        10000.00),
    (4, 4, 2, '2026-03-23 16:45:00', N'Ожидает выдачи',  18000.00),
    (5, 5, 4, '2026-03-24 11:20:00', N'Завершен',         2500.00),
    (6, 1, 6, '2026-03-25 10:00:00', N'Отменен',             0.00);
SET IDENTITY_INSERT [dbo].[Orders] OFF;
GO

SET IDENTITY_INSERT [dbo].[Finances] ON;
INSERT INTO [dbo].[Finances] ([id], [order_id], [type], [price])
VALUES 
    (1, 1, N'Аванс (Безналичный)',   5000.00),
    (2, 1, N'Полная оплата (Карта)',12500.00),
    (3, 2, N'Полная оплата (Наличные)', 8500.00),
    (4, 3, N'Аванс (Наличные)',     10000.00),
    (5, 4, N'Аванс (Перевод)',       7000.00),
    (6, 4, N'Доплата за срочность',  1500.00),
    (7, 4, N'Окончательный расчет',  9500.00),
    (8, 5, N'Полная оплата (СБП)',   2500.00),
    (9, 6, N'Полная оплата (Карта)', 3000.00),
    (10,6, N'Возврат средств',      -3000.00);
SET IDENTITY_INSERT [dbo].[Finances] OFF;
GO

SET IDENTITY_INSERT [dbo].[Order_Components] ON;
INSERT INTO [dbo].[Order_Components] 
    ([id], [order_id], [component_id], [quantity])
VALUES 
    -- Заказ 1: сборка на Intel
    (1, 1, 1, 1),   -- i5-12400F
    (2, 1, 6, 1),   -- MSI PRO B760M-A
    (3, 1, 16,1),   -- RAM DDR4 16ГБ
    (4, 1, 26,1),   -- PSU 750W
    (5, 1, 31,1),   -- Корпус
    -- Заказ 2: сборка на AMD
    (6, 2, 2, 1),   -- Ryzen 5 7500F
    (7, 2, 7, 1),   -- GIGABYTE B650M
    (8, 2, 12,1),   -- RTX 5060
    (9, 2, 17,1),   -- RAM DDR5 32ГБ
    (10,2, 21,2),   -- Kingston NV2 1ТБ x2
    (11,2, 32,1),   -- Корпус
    -- Заказ 3: премиум
    (12,3, 4, 1),   -- Ryzen 7 7800X3D
    (13,3,10, 1),   -- ASUS ROG STRIX
    (14,3,15, 1),   -- RTX 5070 Ti
    (15,3,19, 1),   -- G.Skill Trident
    (16,3,30, 1),   -- be quiet! 1000W
    -- Заказ 4: апгрейд
    (17,4,13, 1),   -- RTX 4060
    (18,4,27, 1),   -- PQ850G
    -- Заказ 5: SSD
    (19,5,23, 1);   -- WD Black SN850X
SET IDENTITY_INSERT [dbo].[Order_Components] OFF;
GO