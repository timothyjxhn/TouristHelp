﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;

namespace TouristHelp
{
    public partial class AdminPageAddAttraction : System.Web.UI.Page
    {
        List<Attraction> acttList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadRepeater();
            }
        }

        private void loadRepeater()
        {
            Attraction actt = new Attraction();
            acttList = actt.ListAttraction();

            RepeaterAttraction.DataSource = acttList;
            RepeaterAttraction.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPageAddAttraction_2.aspx");
        }
    }
}