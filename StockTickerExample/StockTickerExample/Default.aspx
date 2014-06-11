<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="StockTickerExample._Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <h2>
           Stock Ticker Project</h2>
         <asp:ScriptManager ID="Scriptmanager1" runat="server" />
         <asp:Timer runat="server" ID="ctltimer" Enabled="false" Interval="3000" OnTick="OnTimerIntervalElaspse" />
         <asp:UpdatePanel runat="server" ID="pnlUpdate">
         <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ctltimer" EventName="Tick" />
         </Triggers>
         <ContentTemplate>
        <asp:GridView ID="GridView1" runat="server" Width="70%" 
            AutoGenerateColumns="false"
            BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None"
            BorderWidth="1px" CellPadding="3" CellSpacing="2" 
            OnRowUpdating="GridView1_RowUpdating">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
            <Columns>
                <asp:BoundField HeaderText="Symbol" DataField = "symbol" />
                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <%# GetPrice(Eval("id"), Eval("symbol"))%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    <p>
        Stock Symbol：<asp:TextBox ID="tbSym" runat="server"></asp:TextBox>
    </p>
    <p>
       <asp:TextBox ID="tbId" visible=false runat="server"></asp:TextBox>
    </p>
    <asp:Button ID="btnInsert" runat="server" Height="26px" OnClick="btnInsert_Click"
        Text="Add Symbol" Width="141px" />
 
</asp:Content>
