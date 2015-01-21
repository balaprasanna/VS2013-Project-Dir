<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Buy Tickets.aspx.cs" Inherits="ProjectMovie.Buy_Tickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>This is Buy Tickets page</p>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowCommand="GridView2_RowCommand" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" EnableViewState="true" />
                    </ItemTemplate>
                </asp:TemplateField>
<asp:TemplateField><ItemTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" />
                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
                        <asp:CheckBox ID="CheckBox3" runat="server" />
                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
                        <asp:CheckBox ID="CheckBox4" runat="server" />
                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
                        <asp:CheckBox ID="CheckBox5" runat="server" />
                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
                        <asp:CheckBox ID="CheckBox6" runat="server" />
                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
                        <asp:CheckBox ID="CheckBox7" runat="server" />
                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
                        <asp:CheckBox ID="CheckBox8" runat="server" />
                    
</ItemTemplate>
</asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <br />
</asp:Content>
