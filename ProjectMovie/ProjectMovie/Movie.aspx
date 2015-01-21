<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Movie.aspx.cs" Inherits="ProjectMovie.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 245px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>This is Movie page</p>

    <table class="auto-style1">
        <tr>
            <td>
                <asp:Label runat="server" ID="lblDate" Text="Select Date" ></asp:Label>
            </td>
            <td class="auto-style2">
                <table class="auto-style1">
                    <tr>
                        <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="157px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calendar.png" OnClick="ImageButton1_Click" Width="30px" />
                        </td>
                    </tr>
                </table>
            </td>
             <td>
              
                 <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False" OnDayRender="Calendar1_DayRender"></asp:Calendar>
              
            </td>
             <td>
              
               
            </td>
             <td>
              
            </td>
             <td>
              
                
            </td>
        </tr>
    </table>
    <br />

    <table class="auto-style1">
        
        
        <tr>
            <td>
                <asp:Label runat="server" ID="lb1" Text="Select Theatre Company" ></asp:Label>
            </td>
            <td>
                 <asp:Label runat="server" ID="lb2" Text="Select Sub Theatre " ></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="lb3" Text="Select Movie" ></asp:Label>
            </td>
            <td>
                 <asp:Label runat="server" ID="lb4" Text="Select Show Timings" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="DropDownList_Th_company" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_Th_company_SelectedIndexChanged">
                    <asp:ListItem>--select--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList_Sub_Th" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_Sub_Th_SelectedIndexChanged">
                    <asp:ListItem>--select--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList_Movie" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_Movie_SelectedIndexChanged">
                    <asp:ListItem>--select--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList_ShowTime" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_ShowTime_SelectedIndexChanged">
                    <asp:ListItem>--select--</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Check Availability" />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Buy Ticket" />
    <br />
    <br />
    <asp:Label ID="lblStstus" runat="server"></asp:Label>
</asp:Content>
