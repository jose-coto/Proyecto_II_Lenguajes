﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_II_WebApp
{
    public partial class UserControlNormativa : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public String DetalleNormativa
        {
            get { return tbDetalleNormativa.Text; }
            set { tbDetalleNormativa.Text = value; }
        }
    }
}