﻿using System;
using System.Collections.Generic;
using DataAccessLayer;
using Models;

namespace ServiceLayer
{
    public class OrderService : IOrderService
    {
        public IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public IEnumerable<Order> GetListOfOrders()
        {
            return Database.Orders.GetAll();
        }

        public Order GetInfo(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id работника", "");
            var employee = Database.Orders.Get(id.Value);
            if (employee == null)
                throw new ValidationException("Работника не найден", "");

            return employee;
        }
    }
}
