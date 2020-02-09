﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;

namespace TouristHelp
{
    public partial class Ticketing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var attractionId = Session["AttractionId"].ToString();
            Attraction newTix = new Attraction();
            newTix = newTix.GetAttractionDataById(attractionId);
            lbTicketName.Text = newTix.Name;
            lbTicketDesc.Text = newTix.Description;
            lblPrice.Text = newTix.Price.ToString();
        }
        protected void Btn_TypeSel(object sender, EventArgs e)
        {
          
        }
        protected void Btn_DecreaseQ(object sender, EventArgs e)
        {

        }
        protected void Btn_IncreaseQ(object sender, EventArgs e)
        {

        }
        protected void Btn_Buy(object sender, EventArgs e)
        {

        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void Package_Click(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged2(object sender, EventArgs e)
        {
            tbDate_PopupControlExtender.Commit(Calendar1.SelectedDate.ToShortDateString());
        }

        protected void Btn_MinQ(object sender, EventArgs e)
        {
            int current = Convert.ToInt32(tbQuantity.Text.ToString());
            if(current > 0)
            {
                string newQ = (current - 1).ToString();
                tbQuantity.Text = newQ;
            }
            
        }

        protected void Btn_AddQ(object sender, EventArgs e)
        {
            int current = Convert.ToInt32(tbQuantity.Text.ToString());
            string newQ = (current + 1).ToString();
            tbQuantity.Text = newQ;
        }

        protected void BtnBuy_Click(object sender, EventArgs e)
        {
            if (Session["tourist_id"] == null && Session["tourguide_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            else
            {

                try
                {
                    Label1.Text = Session["tourist_id"].ToString();
                }
                catch (NullReferenceException)
                {
                    Label1.Text = Session["tourguide_id"].ToString();
                }

            }
            var user_id = Convert.ToInt32(Session["tourist_id"]);
            string attName = lbTicketName.Text;
            string attDesc = lbTicketDesc.Text;
            double price = Convert.ToDouble(lblPrice.Text);
            DateTime expDate = Convert.ToDateTime(tbDate.Text);
            Random random = new Random();
            
            //check whether a code exists already
            int quantity = Convert.ToInt32(tbQuantity.Text);
            string code = random.Next(1000000, 9999999).ToString();
            Ticket ticket = new Ticket();
            List<String> codeList = ticket.GetCodes();
            while (true && codeList != null)
            {
                if (codeList.Contains(code))
                {
                    code = random.Next(1000000, 9999999).ToString();
                }
                else
                {
                    break;
                }
            }
            

            Cart cart = new Cart(attName, attDesc, price, quantity, user_id);
            cart.InsertCartTicket();

            Cart newCart = new Cart();
            newCart.GetCartId(attName, user_id);
            Ticket tkt = new Ticket(attName, attDesc, price, expDate, code, "not paid", user_id, newCart.productId);
            tkt.AddNewTicket();


            Response.Redirect("ShoppingCart.aspx");
        }
    }
}