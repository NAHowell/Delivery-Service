﻿namespace _Delivery
{
    public class DeliveryContent
    {
        public string OrderDate {get; set;}
        public string Status {get; set;}
        public double ItemNumber {get; set;}
        public double Quantity {get; set;}
        public string Id {get; set;}


        public DeliveryContent() {}
        public DeliveryContent(string id) 
        {
            Id = id;
        }
        public DeliveryContent(string orderDate, string status, double itemNumber, double quantity, string id)
        {
            OrderDate = orderDate;
            Status = status;
            ItemNumber = itemNumber;
            Quantity = quantity;
            Id = id;
        }

    }
}