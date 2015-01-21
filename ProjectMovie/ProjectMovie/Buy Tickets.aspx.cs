using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectMovie
{
    public partial class Buy_Tickets : System.Web.UI.Page
    {
        ProjectMovieFinalEntities context;
       static List<string> bookedSeats;

        Char[] ar = new Char[] { 'A', 'B', 'C', 'D', 'E' };
        protected void Page_Load(object sender, EventArgs e)
        {
            context = new ProjectMovieFinalEntities();
            if(!IsPostBack)
            {
                
                DataTable dt = new DataTable();
                dt.Columns.Add("col1", typeof(bool));
                dt.Columns.Add("col2", typeof(bool));
                dt.Columns.Add("col3", typeof(bool));
                dt.Columns.Add("col4", typeof(bool));
                dt.Columns.Add("col5", typeof(bool));
                dt.Columns.Add("col6", typeof(bool));
                dt.Columns.Add("col7", typeof(bool));
                dt.Columns.Add("col8", typeof(bool));


                for (int i = 0; i < 5; i++)
                {
                    var dr = dt.NewRow();
                    dr["col1"] = true;
                    dr["col2"] = true;
                    dr["col3"] = true;
                    dr["col4"] = true;
                    dr["col5"] = true;
                    dr["col6"] = true;
                    dr["col7"] = true;
                    dr["col8"] = true;

                    dt.Rows.Add(dr);
                }

                GridView2.DataSource = dt;
                GridView2.DataBind();

                int th_id = Convert.ToInt32(Session["TheaterId"]);
                int subTh_id = Convert.ToInt32(Session["SubTheaterId"]);
                string mov_id = Session["Mov_id"].ToString();
                int showtime_id = Convert.ToInt32(Session["showTime_id"]);
                DateTime selectedDate = Convert.ToDateTime(Session["SelectedBookingDate"]);
                List<Booking> bookedList = context.Bookings.Where(y => (y.Bk_Movie_id == mov_id) && (y.Bk_SubTh_id == subTh_id) && (y.BK_Time == selectedDate) && (y.BK_STDI_id == showtime_id)).ToList<Booking>();
               List<string> seatList = new List<string>();
               bookedSeats = new List<string>();
                for (int i = 0; i < bookedList.Count; i++)
                {
                  String seat = bookedList[i].BookingSeatInfo.Bk_SeatName;
                    bookedSeats.Add(seat);
                    convertSeatIntoRowsAndColum(seat);
                   
                  //  Label1.Text += "Seat infor s"+ bookedList[i].BookingSeatInfo.Bk_SeatName +"Seat infor e";
                    //convertSeatIntoRowsAndColum(seatList.Add(context.SeatGenerators.Where(y => y.Seat_id == (bookedList[i].BookingSeatInfo.Bk_SeatNo)).FirstOrDefault().Seat_Name));
                   // Booking b = bookedList[i].BookingSeatInfo.Bk_SeatNo;
                }
                
               
            }            
            if (!Session.IsNewSession)
            {
                Label1.Text += "\n" + (Session["TheaterId"]).ToString();
                Label1.Text += "\n" + (Session["SubTheaterId"]).ToString();
                Label1.Text += "\n" + (Session["Mov_id"]).ToString();
                Label1.Text += "\n" + (Session["showTime_id"]).ToString();
                Label1.Text += "\n" + (Session["SelectedBookingDate"]).ToString();
            }

        }

        public void convertSeatIntoRowsAndColum(String seatname)
        {
            //
            int row = 0 ;
            int col = 0;

            //char[] letterList = new char[] { 'A', 'B', 'C', 'D', 'E' };
            char[] ch = seatname.ToCharArray();
            char letter = ch[0];
            int number = int.Parse(ch[1].ToString());
            Label1.Text += "Seat s" + letter + ">>" + ch[1] + ">>" +(number); 

            if (letter == 'A')
            {
                row = 0;
                col = number;
            }
            if (letter == 'B')
            {
                row = 1;
                col = number;
            }
            if (letter == 'C')
            {
                row = 2;
                col = number;
            }
            if (letter == 'D')
            {
                row = 3;
                col = number;
            }
            if (letter == 'E')
            {
                row = 4;
                col = number;
            }

            selectSpecified(row, (col-1));

            Label1.Text += "Row s" + row.ToString() + ">> colmn" + col.ToString(); 
        }
        public void selectSpecified(int row, int cell)
        {
            cell++;

            if (cell == 1)
            {
                CheckBox a1 = (CheckBox)GridView2.Rows[row].Cells[(cell - 1)].FindControl("CheckBox" + cell);
                a1.Checked = true;
                a1.Enabled = false;
            }
            if (cell == 2)
            {
                CheckBox a2 = (CheckBox)GridView2.Rows[row].Cells[(cell - 1)].FindControl("CheckBox" + cell);
                a2.Checked = true;
                a2.Enabled = false;
            }
            if (cell == 3)
            {
                CheckBox a3 = (CheckBox)GridView2.Rows[row].Cells[(cell - 1)].FindControl("CheckBox" + cell);
                a3.Checked = true;
                a3.Enabled = false;
            }
            if (cell == 4)
            {
                CheckBox a4 = (CheckBox)GridView2.Rows[row].Cells[(cell - 1)].FindControl("CheckBox" + cell);
                a4.Checked = true;
                a4.Enabled = false;
            }
            if (cell == 5)
            {
                CheckBox a5 = (CheckBox)GridView2.Rows[row].Cells[(cell - 1)].FindControl("CheckBox" + cell);
                a5.Checked = true;
                a5.Enabled = false;
            }
            if (cell == 6)
            {
                CheckBox a6 = (CheckBox)GridView2.Rows[row].Cells[(cell - 1)].FindControl("CheckBox" + cell);
                a6.Checked = true;
                a6.Enabled = false;
            }
            if (cell == 7)
            {
                CheckBox a7 = (CheckBox)GridView2.Rows[row].Cells[(cell - 1)].FindControl("CheckBox" + cell);
                a7.Checked = true;
                a7.Enabled = false;
            }
            if (cell == 8)
            {
                CheckBox a8 = (CheckBox)GridView2.Rows[row].Cells[(cell - 1)].FindControl("CheckBox" + cell);
                a8.Checked = true;
                a8.Enabled = false;
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected List<string> filteredNewlySelectedSeats(List<string> allseat)
        {
            for(int i=0;i<bookedSeats.Count;i++){
                if (allseat.Contains(bookedSeats.ElementAt(i)))
                {
                    allseat.Remove(bookedSeats[i]);
                }
            }
            foreach (string s in allseat)
            {
                Label1.Text += "\n all seats" + s;
            }
            return allseat;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            

            List<string> allseats = new List<string>();
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                CheckBox a1 = (CheckBox)GridView2.Rows[i].Cells[0].FindControl("CheckBox1");
                CheckBox a2 = (CheckBox)GridView2.Rows[i].Cells[1].FindControl("CheckBox2");
                CheckBox a3 = (CheckBox)GridView2.Rows[i].Cells[2].FindControl("CheckBox3");
                CheckBox a4 = (CheckBox)GridView2.Rows[i].Cells[3].FindControl("CheckBox4");
                CheckBox a5 = (CheckBox)GridView2.Rows[i].Cells[4].FindControl("CheckBox5");
                CheckBox a6 = (CheckBox)GridView2.Rows[i].Cells[5].FindControl("CheckBox6");
                CheckBox a7 = (CheckBox)GridView2.Rows[i].Cells[6].FindControl("CheckBox7");
                CheckBox a8 = (CheckBox)GridView2.Rows[i].Cells[7].FindControl("CheckBox8");


                if (a1.Checked)
                {
                    //Label1.Text += "\n " + (i+1) + "1";
                    allseats.Add((ar[i] + "1").ToString());
                }
                if (a2.Checked)
                {
                    allseats.Add((ar[i] + "2").ToString());
                }
                if (a3.Checked)
                {
                    allseats.Add((ar[i] + "3").ToString());
                }
                if (a4.Checked)
                {
                    allseats.Add((ar[i] + "4").ToString());
                }
                if (a5.Checked)
                {
                    allseats.Add((ar[i] + "5").ToString());
                }
                if (a6.Checked)
                {
                    allseats.Add((ar[i] + "6").ToString());
                }
                if (a7.Checked)
                {
                    allseats.Add((ar[i] + "7").ToString());
                }
                if (a8.Checked)
                {
                    allseats.Add((ar[i] + "8").ToString());
                }
            }

          List<string> seatsRequestedForBooking = filteredNewlySelectedSeats(allseats);
          if (seatsRequestedForBooking.Count != 0)
              {
                  bookme(seatsRequestedForBooking);
                  Label2.Text = "Tickets booked successfully";      
              }

        }
        protected void bookme(List<string> seats)
        {
             int subTh_id = Convert.ToInt32(Session["SubTheaterId"]);
                string mov_id = Session["Mov_id"].ToString();
                int showtime_id = Convert.ToInt32(Session["showTime_id"]);
                DateTime selectedDate = Convert.ToDateTime(Session["SelectedBookingDate"]);

            int bkid =0;
            for(int i=0;i<seats.Count;i++){

            BookingSeatInfo bk_seat = new BookingSeatInfo();
            bk_seat.Bk_SeatName = seats[i];

          ///SeatGenerator st  = context.SeatGenerators.Where(y=>y.Seat_Name == seats[i]).First<SeatGenerator>();


            int seat_num = retriveseatno(seats[i]);
            bk_seat.Bk_SeatNo = seat_num;

            context.BookingSeatInfoes.Add(bk_seat);
            context.SaveChanges();
            bkid=bk_seat.Bookseat_id;

            Booking a = new Booking();
            a.Bk_Movie_id=mov_id;
            a.Bk_SubTh_id = subTh_id;
            a.BK_Time= selectedDate;
            a.BK_User="user";
            a.BK_Seat = bkid;
            a.BK_STDI_id= showtime_id;

            context.Bookings.Add(a);
            context.SaveChanges();
            }
            
            
        }
        public int retriveseatno(string seatname)
        { int num=0;

        int row = 0;
        int col = 0;

        //char[] letterList = new char[] { 'A', 'B', 'C', 'D', 'E' };
        char[] ch = seatname.ToCharArray();
        char letter = ch[0];
        int number = int.Parse(ch[1].ToString());
        //Label1.Text += "Seat s" + letter + ">>" + ch[1] + ">>" + (number);

        if (letter == 'A')
        {
            row = 0;
            col = number;
            
        }
        if (letter == 'B')
        {
            row = 1;
            col = number;
        }
        if (letter == 'C')
        {
            row = 2;
            col = number;
        }
        if (letter == 'D')
        {
            row = 3;
            col = number;
        }
        if (letter == 'E')
        {
            row = 4;
            col = number;
        }

        return ((8*row)+col); 
        }
    }
}