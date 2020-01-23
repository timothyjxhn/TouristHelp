﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TouristHelp
{
    public partial class TourGuideDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tourguidenameLabel2.Text = (string)Session["SSName"];
                tourguidedescriptionLabel2.Text = (string)Session["SSDescription"];
                tourguidelanguagesLabel2.Text = (string)Session["SSLanguages"];
            }
        }

        protected void RedirectBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TourDetailsPage.aspx");
        }
    }
}