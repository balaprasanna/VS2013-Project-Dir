<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ProjectMovie.Movie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
    <script src="Scripts/jquery-1.8.2.js"></script>
    <script src="Scripts/jquery-1.8.2.min.js"></script>
  <script type="text/javascript" >
      var count = 0;
      setInterval("fun()",5000)
      function fun() {
          debugger;
         // generate random number
          var x = Math.floor((Math.random() * 3) + 1);
          var str = "/Images/sample/big/img"+ x +".jpg";
          $("#MainContent_imgSlide").attr("src", str);
      }
  </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   
<p>This is Home Page</p>
    <table class="auto-style1">
        <tr>
            <td>&nbsp;<asp:Image ID="imgSlide" runat="server" Height="300px" ImageUrl="~/Images/sample/big/img1.jpg" Width="1000px" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;
               
                Tabs goes here
                <br />
                <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
                <table class="auto-style1">
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Now Showing" />
                        </td>
                        <td>
                            <asp:Button ID="Button2" runat="server" Text="Comming Soon" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="GridView1" runat="server">
                    <Columns>
                        <asp:ImageField>
                        </asp:ImageField>
                    </Columns>
                </asp:GridView>
                <br />
                <asp:ListView ID="ListView1" runat="server">
                </asp:ListView>
            </td>
        </tr>
    </table>

</asp:Content>
