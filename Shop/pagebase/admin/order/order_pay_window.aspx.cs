﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shop.Bussiness;
using Shop.Model;using DB.LebiShop;
using LB.Tools;

namespace Shop.Admin.order
{
    public partial class Order_Pay_window : AdminAjaxBase
    {
        protected Lebi_Order model;
        protected int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!EX_Admin.Power("order_status_ispaid", "订单支付"))
            {
                WindowNoPower();
            }
            id = RequestTool.RequestInt("id",0);
            string where = "id = " + id + "";
            if (!string.IsNullOrEmpty(EX_Admin.Project().Site_ids))
            {
                where += " and (Site_id in (" + EX_Admin.Project().Site_ids + "))";
            }
            if (!string.IsNullOrEmpty(EX_Admin.Project().Supplier_ids))
            {
                where += " and (Supplier_id in (" + EX_Admin.Project().Supplier_ids + "))";
            }
            model = B_Lebi_Order.GetModel(where);
            if (model == null)
                model = new Lebi_Order();
        }
    }
}