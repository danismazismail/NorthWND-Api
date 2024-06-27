using Microsoft.Identity.Client;
using MyApi.Core;
using MyApi.DAL.Interfaces;
using MyApi.Dtos.OrderProcessDTO;
using MyApi.EH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MyApi.DAL.Concrete
{


    public class OrderDAL : IOrderDAL
    {
        private readonly MyAppDbContext _myAppDbContext;
        public OrderDAL(MyAppDbContext myAppDbContext)
        {
            _myAppDbContext = myAppDbContext;

        }
        /// <summary>
        //sipariş nedemek ?
        //orders -order details  ve products
        //orders 1 kayıt , order details a çok kayıt, order details a eklenen kadar urunun products (stok) tan düşürülmesi.
        //dikkat edilecekler ne?
        //validation. => varsa log tablosu log kaydı alınmalı.
        //işler ters giderse bu api ne yapacak.
        //transaction rollback , bad request gibi bir hata mesajı dönülmeli. 

        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddOrderWithDetails(AddOrderDTO dto)
        {
            if (dto ==null || dto.OrderDetails==null || dto.OrderInfo==null)
            {
                return false;
            }
            bool returnValue = false;
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
              var addedOrder=      _myAppDbContext.Orders.Add(new Orders()
                    {
                        CustomerID = dto.OrderInfo.CustomerID,
                        EmployeeID = dto.OrderInfo.EmployeeID,
                        Freight = dto.OrderInfo.Freight,
                        OrderDate = dto.OrderInfo.OrderDate,
                        OrderID = dto.OrderInfo.OrderID,
                        RequiredDate = dto.OrderInfo.RequiredDate,
                        ShipAddress = dto.OrderInfo.ShipAdress,
                        ShipCity = dto.OrderInfo.ShipCity,
                        ShipCountry = dto.OrderInfo.ShipCountry,
                        ShipName = dto.OrderInfo.ShipName,
                        ShippedDate = dto.OrderInfo.ShippedDate,
                        ShipPostalCode = dto.OrderInfo.ShipPostalCode,
                        ShipRegion = dto.OrderInfo.ShipRegion,
                        ShipVia = dto.OrderInfo.ShipVia,
                    });
                    if (_myAppDbContext.SaveChanges() > 0)
                    {

                        foreach (OrderDetailDTO orderDetail in dto.OrderDetails)
                        {

                            _myAppDbContext.Order_Details.Add(new Order_Details()
                            {
                                Discount = orderDetail.Discount,
                                OrderID = addedOrder.Entity.OrderID,
                                ProductID = orderDetail.ProductID,
                                Quantity = orderDetail.Quantity,
                                UnitPrice = orderDetail.UnitPrice
                            });

                            //pro dan units in stok değerini bul quantitiy kadar düş.

                            var updateProduct = _myAppDbContext.Products.Where(a => a.ProductID == orderDetail.ProductID).SingleOrDefault();
                            updateProduct.UnitsInStock -= orderDetail.Quantity;
                            _myAppDbContext.SaveChanges();
                        }
                    }
                    else
                    {
                        throw new BLLEX("sistem hatası..");
                    }
                    tran.Complete();
                    returnValue = true;
                }
                catch (Exception ex)
                {
                    returnValue = false;
                }

            }

            return returnValue;
        }
    }
}
