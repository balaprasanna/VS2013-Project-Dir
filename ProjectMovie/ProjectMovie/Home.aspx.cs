using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectMovie
{
    public partial class Movie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Random  r = new Random();
            int num = r.Next(3);
            imgSlide.ImageUrl = "~/Images/sample/big/img" + num + ".jpg";
        }
    }
} 