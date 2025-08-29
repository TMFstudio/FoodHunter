using Core;
using Core.Models;
using FoodHunter.Model;
using FoodHunter.Pages.Home;

namespace FoodHunter.Mapper
{
    public static class Mapper
    {
        #region Category
        public static CategoryModel ToModel(this Category category)
        {
            return new CategoryModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                DisplayOrder = category.DisplayOrder
            };
        }

        public static IEnumerable<CategoryModel> ToModelList(this IPagedList<Category> category)
        {
           return category.Select(x=>x.ToModel()).ToList();
        }
        public static Category ToEntity(this CategoryModel category)
        {
            return new Category
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                DisplayOrder = category.DisplayOrder
            };
        }
        #endregion

        #region Product

        public static ProductModel ToModel(this Product  product)
        {
            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CreateDate = product.CreateDate,
                ProductTypeName = product.ProductType.Name,
                Price = product.Price,
                Image = product.Image,
                ProductTypeId = product.ProductTypeId,
                DisplayOrder = product.DisplayOrder,
            };
        }

        public static IEnumerable<ProductModel> ToModelList(this IEnumerable<Product> products)
        {
            return products.Select(x => x.ToModel()).ToList();
        }
        public static Product ToEntity(this ProductModel  product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CreateDate = product.CreateDate,
                ProductTypeId = product.ProductTypeId,
                Image = product.Image,
                Price = product.Price,
                DisplayOrder = product.DisplayOrder
            };
        }

        #endregion

        #region ProductType
        public static ProductTypeModel ToModel(this ProductType productType)
        {
            return new ProductTypeModel
            {
                Id = productType.Id,
                Name = productType.Name,
            };
        }

        public static IEnumerable<ProductTypeModel> ToModelList(this IEnumerable<ProductType> productTypes)
        {
            return productTypes.Select(x => x.ToModel()).ToList();
        }
        public static ProductType ToEntity(this ProductTypeModel productType)
        {
            return new ProductType
            {
                Id = productType.Id,
                Name = productType.Name,
            };
        }

        #endregion

        #region ProductCategory

        public static ProductCategoryModel ToModel(this ProductCategory  productCategory)
        {
            return new ProductCategoryModel
            {
                Id = productCategory.Id,
                CategoryId = productCategory.CategoryId,
                ProductId = productCategory.ProductId,
            };
        }
        public static IEnumerable<ProductCategoryModel> ToModelList(this IEnumerable<ProductCategory> productCategory)
        {
            return productCategory.Select(x => x.ToModel()).ToList();
        }
        public static ProductCategory ToEntity(this ProductCategoryModel productCategory)
        {
            return new ProductCategory
            {
                Id = productCategory.Id,
                CategoryId = productCategory.CategoryId,
                ProductId = productCategory.ProductId,
            };
        }


        #endregion

        #region CustomerModel
        public static CustomerModel ToModel(this Customer customer)
        {
            return new CustomerModel
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                //not create mabe later !!!!
                CreatedOn = customer.CreatedOn,
                Email = customer.Email,
                IsActive = customer.IsActive,
                PhoneNumber = customer.PhoneNumber,
                UserName = customer.UserName,
                EmailConfirmed = customer.EmailConfirmed
            };
        }

        public static IEnumerable<CustomerModel> ToModelList(this IEnumerable<Customer> customers)
        {
            return customers.Select(x => x.ToModel()).ToList();
        }
        public static Customer ToEntity(this CustomerModel customer)
        {
            return new Customer
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                //not create mabe later !!!!
                CreatedOn = customer.CreatedOn,
                Email = customer.Email,
                IsActive = customer.IsActive,
                PhoneNumber = customer.PhoneNumber,
                UserName = customer.UserName,
                EmailConfirmed = customer.EmailConfirmed
            };
        }

        #endregion

        #region ShoppingCart
        public static ShoppingCartItemModel ToModel(this ShoppingCart  shoppingCart)
        {
            return new ShoppingCartItemModel
            {
                Id = shoppingCart.Id,
                 CustomerId = shoppingCart.ApplicationUserId,
                 ProductId= shoppingCart.ProductId,
                CreateOn = shoppingCart.CreateOn,
                ItemsCount = shoppingCart.Count,             
            };
        }

        public static IEnumerable<ShoppingCartItemModel> ToModelList(this IEnumerable<ShoppingCart> shoppingCarts)
        {
            return shoppingCarts.Select(x => x.ToModel()).ToList();
        }
        public static ShoppingCart ToEntity(this ShoppingCartItemModel shoppingCart)
        {
            return new ShoppingCart
            {
                Id = shoppingCart.Id,
                ApplicationUserId = shoppingCart.CustomerId,
                ProductId = shoppingCart.ProductId.Value,
                CreateOn=shoppingCart.CreateOn,
                Count = shoppingCart.ItemsCount
            };
        }

        #endregion

        #region Order
        public static OrderModel ToModel(this Order  order)
        {
            return new OrderModel
            {    Id=order.Id,
                CustomerId = order.CustomerId,
                 Count = order.Count,
                 Address= order.Address,
                OrderDate = order.OrderDate,
                PhoneNumber = order.PhoneNumber,             
                OrderTotal = order.OrderTotal,             
                PickUpName = order.PickUpName,             
                OrderStatusId = order.StatusId,             
                PickUpTime = order.PickUpTime,       
                TransactionId = order.TransactionId            
            };
        }

        public static IEnumerable<OrderModel> ToModelList(this IEnumerable<Order> orders)
        {
            return orders.Select(x => x.ToModel()).ToList();
        }
        public static Order ToEntity(this OrderModel order)
        {
            return new Order
            {
                CustomerId = order.CustomerId,
                Count = order.Count,
                Address = order.Address,
                OrderDate = order.OrderDate,
                PhoneNumber = order.PhoneNumber,
                OrderTotal = order.OrderTotal.Value,
                PickUpName = order.PickUpName,
                StatusId = order.OrderStatusId,
                PickUpTime = order.PickUpTime,
                TransactionId = order.TransactionId
            };
        }

        #endregion

        #region OrderItems
        public static OrderItemModel ToModel(this OrderItem  orderItem)
        {
            return new OrderItemModel
            {
                Id = orderItem.Id,
                Count = orderItem.Count,
                Name = orderItem.Name,
                OrderID = orderItem.OrderId,
                Price = orderItem.Price,
                ProductId = orderItem.ProductId
            };
        }
        public static IEnumerable<OrderItemModel> ToModelList(this IEnumerable<OrderItem> orderItems)
        {
            return orderItems.Select(x => x.ToModel()).ToList();
        }
        public static OrderItem ToEntity(this OrderItemModel orderItem)
        {
            return new OrderItem
            {
                Count = orderItem.Count,
                Name = orderItem.Name,
                OrderId = orderItem.OrderID,
                Price = orderItem.Price.Value,
                ProductId = orderItem.ProductId
            };
        }

        #endregion
    }
}
