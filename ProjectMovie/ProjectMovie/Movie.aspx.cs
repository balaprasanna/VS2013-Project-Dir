using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectMovie
{
    public partial class Home : System.Web.UI.Page
    {
        ProjectMovieFinalEntities context;
        protected void Page_Load(object sender, EventArgs e)
        {
           context = new ProjectMovieFinalEntities();
            if (!IsPostBack)
            {
              
                // code to populate the Dp1
                
                List<TheatreCompany> th_cp_list = context.TheatreCompanies.ToList<TheatreCompany>();
              if(th_cp_list.Count!=0){
                  foreach(TheatreCompany thcp in th_cp_list){
                      DropDownList_Th_company.Items.Add(thcp.Th_name);
                  }
              }
                
            }

        }

        protected void DropDownList_Th_company_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList_Sub_Th.Items.Clear();
            DropDownList_Sub_Th.Items.Add("--select--");

            if (DropDownList_Th_company.Text != "--select--")
            {
                // store the TheaterId in session
               int thid = context.TheatreCompanies.Where(y => y.Th_name == DropDownList_Th_company.Text).FirstOrDefault().Theater_id;
               Session["TheaterId"] =thid;

                List<SubTheatre> sb_th_list = context.SubTheatres.Where(x => x.TheatreCompanyBelongsTo == thid).ToList<SubTheatre>();
                if (sb_th_list.Count != 0)
                {
                    foreach (SubTheatre subth in sb_th_list)
                    {
                        DropDownList_Sub_Th.Items.Add(subth.SubTh_Name);
                    }
                }
            }
        }

        protected void DropDownList_Sub_Th_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList_Movie.Items.Clear();
            DropDownList_Movie.Items.Add("--select--");
            if (DropDownList_Sub_Th.Text != "--select--")
            {
                // store the SubTheaterId in session
                int sbthid = context.SubTheatres.Where(y => y.SubTh_Name == DropDownList_Sub_Th.Text).FirstOrDefault().SubTh_id;
                Session["SubTheaterId"] =sbthid;

                List<MovieTheatre> sb_th_list = context.MovieTheatres.Where(y => y.SubTh_id == sbthid).ToList<MovieTheatre>();
                 List<string> dup_string = new List<string>();
                 List<string> dupMoviename_string = new List<string>();
                foreach(MovieTheatre s in sb_th_list){
                dup_string.Add(s.Mov_id);
                dupMoviename_string.Add(s.MovieDetail.mov_title);
               
                }
                
                foreach (String movname in dupMoviename_string.Distinct().ToList())
                {

                    DropDownList_Movie.Items.Add(movname);
                   // label2.Text += "\n " + movname;
                } 
                    //.Where(x => x.SubTh_id == thid).ToList<SubTheatre>();
            }
        }

        protected void DropDownList_Movie_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           DropDownList_ShowTime.Items.Clear();
            DropDownList_ShowTime.Items.Add("--select--");
            if (DropDownList_Movie.Text != "--select--")
            {
                // store the MovId in session
                string mov_id = context.MovieDetails.Where(y => y.mov_title == DropDownList_Movie.Text).FirstOrDefault().mov_id;
                Session["Mov_id"] = mov_id;
                int sub_th_id =(Convert.ToInt32(Session["SubTheaterId"]));
                List<MovieTheatre> showLists = context.MovieTheatres.Where(y => ((y.Mov_id == mov_id) && (y.SubTh_id == sub_th_id))).ToList<MovieTheatre>();

                foreach (MovieTheatre s in showLists)
                {
                    DropDownList_ShowTime.Items.Add(s.ShowTimingsDetailsInfo.ShowTimeSlots_Screens);
                } 
            }
        }

        protected void DropDownList_ShowTime_SelectedIndexChanged(object sender, EventArgs e)
        {
           // DropDownList_ShowTime.Items.Clear();
           // DropDownList_ShowTime.Items.Add("--select--");
            if (DropDownList_ShowTime.Text != "--select--")
            {
                 int sub_th_id =(Convert.ToInt32(Session["SubTheaterId"]));
                 string mov_id =(Session["Mov_id"]).ToString();
                // store the ShowTimings in session
                 List<MovieTheatre> mvlist = context.MovieTheatres.Where(y => (y.Mov_id == mov_id) && (y.SubTh_id == sub_th_id) && ((y.ShowTimingsDetailsInfo.ShowTimeSlots_Screens) == DropDownList_ShowTime.Text)).ToList<MovieTheatre>();
                    //.Where(y => y.mov_title == DropDownList_Movie.Text).FirstOrDefault().mov_id;
                 if (mvlist.Count != 0)
                 {
                     Session["showTime_id"] = mvlist[0].ShowTimingsDetailsInfo_STDI_id;
                 }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblStstus.Text = "";

           int th_id= Convert.ToInt32(Session["TheaterId"]);
           int subTh_id = Convert.ToInt32(Session["SubTheaterId"]);
           string mov_id = Session["Mov_id"].ToString();
           int showtime_id = Convert.ToInt32(Session["showTime_id"]);

           DateTime time1 = Convert.ToDateTime("2015-01-20 00:00:00.000");
           DateTime time2 = Convert.ToDateTime("2015-01-21 00:00:00.000");

           DateTime selecteddate = Convert.ToDateTime(TextBox1.Text);

           List<Booking> bookedList = context.Bookings.Where(y => (y.Bk_Movie_id == mov_id) && (y.Bk_SubTh_id == subTh_id) && (y.BK_Time == selecteddate) && (y.BK_STDI_id == showtime_id)).ToList<Booking>();
           if (bookedList.Count == 40)
           {
               lblStstus.Text = "Tickets Sold out";
           }
           else
           {

               if (bookedList.Count == 0)
               {
                   lblStstus.Text = "40 Tickets Available";
               }
               else
               {
                   lblStstus.Text += "Tickets Booked " + (bookedList.Count);
                   lblStstus.Text += "\n Tickets Available " + (40 - (bookedList.Count));
                   //foreach(Booking b in bookedList){
                   //    lblStstus.Text += "Tickets Booked " + (b.BookingSeatInfo.Bookings.Count);
                   //    lblStstus.Text += "\n Tickets Available "+(40-(b.BookingSeatInfo.Bookings.Count));
                   //   // lblStstus.Text += b.BookingSeatInfo.Bk_SeatNo;
                   //}
               }
           }
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Buy Tickets.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
          
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            
            TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();
            Session["SelectedBookingDate"] = TextBox1.Text;
            Calendar1.Visible = false;
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime Now = DateTime.Now.Date;

            if (e.Day.Date < Now)
            {
                e.Cell.Enabled = false;
                e.Day.IsSelectable = false;
            }  
        }
    }
}