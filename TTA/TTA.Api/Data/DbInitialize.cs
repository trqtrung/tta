using System;
using System.Linq;
using TTA.Api.Models;

namespace TTA.Api.Data
{
    public class DbInitialize
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            //check if there is any client option
            if (context.Products.Any())
            {
                return;
            }

            var products = new Product[]
            {
                new Product{ Name="Kềm nhọn 7-inch Licota", Description="Licota Long Nose Plier 7-inch", Created = DateTime.Now},
                new Product{ Name="Kềm cắt 7-inch Licota", Description="Licota Heavy Cutter Plier 7-inch", Created = DateTime.Now},
                new Product{ Name="Kềm điện 7-inch Licota", Description="Licota Combination Plier 7-inch", Created=DateTime.Now}
            };

            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

            //check if there is any product record
            if (context.OptionLists.Any())
            {
                return;
            }

            var options = new OptionList[]
            {
                //e-commerce websites
                new OptionList{ Name="Lazada", Key="e-commerce-client", Value="lazada"},
                new OptionList{ Name="Shopee", Key="e-commerce-client",Value="shopee"},
                new OptionList{ Name="Sendo", Key="e-commerce-client",Value="sendo"},

                //shipping services
                new OptionList{ Name="Giao hàng nhanh (GHN)", Key="shipping-service",Value="ghn"},
                new OptionList{ Name="Giao hàng tiết kiệm (GHTK)", Key="shipping-service",Value="ghtk"},
                new OptionList{ Name="DHL", Key="shipping-service",Value="dhl"},
                new OptionList{ Name="Ninja Van", Key="shipping-service",Value="ninjavan"},

                //payment methods
                new OptionList{ Name="Cash on Delivery (COD)", Key="payment-method",Value="cod"},
                new OptionList{ Name="Cash", Key="payment-method",Value="cash"},
                new OptionList{ Name="Transfer", Key="payment-method",Value="transfer"},
                new OptionList{ Name="VISA", Key="payment-method",Value="visa"},

                //order stages
                new OptionList{ Name="New", Key="order-stage",Value="new"},
                new OptionList{ Name="Waiting for Confirmation", Key="order-stage",Value="waiting-confirm"},
                new OptionList{ Name="Confirmed", Key="order-stage",Value="confirmed"},
                new OptionList{ Name="Ready for Shipping", Key="order-stage",Value="ready-shipping" },
                new OptionList{ Name="Shipping", Key="order-stage",Value="shipping"},
                new OptionList{ Name="Delivered", Key="order-stage",Value="delivered"},
                new OptionList{ Name="Waiting for Payment", Key="order-stage",Value="waiting-payment"},
                new OptionList{ Name="Completed", Key="order-stage",Value="completed"},
                new OptionList{ Name="Cancelled", Key="order-stage",Value="cancelled"},
                new OptionList{ Name="Return", Key="order-stage",Value="return"},

                //order tracking types
                new OptionList{ Name="Shipping", Key="order-tracking-type",Value="shipping"},
                //new OptionList{ Name="Payment", Key="order-tracking-type",Value="payment"},
                new OptionList{ Name="Stage", Key="order-tracking-type",Value="stage"},

                //order shipping stages
                new OptionList{ Name="Ready for Shipping", Key="order-shipping",Value="ready-shipping"},
                new OptionList{ Name="Picked Up", Key="order-shipping",Value="picked"},
                new OptionList{ Name="Shipping", Key="order-shipping",Value="shipping"},
                new OptionList{ Name="Lost", Key="order-shipping",Value="lost"},
                new OptionList{ Name="Delivered", Key="order-shipping",Value="delivered"},
                new OptionList{ Name="Return", Key="order-shipping",Value="return"},
            };

            foreach(OptionList o in options)
            {
                context.OptionLists.Add(o);
            }
            context.SaveChanges();
        }
    }
}
