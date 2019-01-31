<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testLayout.aspx.cs" Inherits="webpageClash.testLayout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        div.blueTable {
          font-family: Verdana, Geneva, sans-serif;
          border: 6px solid #535656;
          background-color: #535656;
          width: 100%;
          height: 200px;
          text-align: left;
          border-collapse: collapse;
        }
        .divTable.blueTable .divTableCell, .divTable.blueTable .divTableHead {
          border: 3px solid #AAAAAA;
          padding: 3px 4px;
        }
        .divTable.blueTable .divTableBody .divTableCell {
          font-size: 12px;
          color: #DFE7E7;
        }
        .divTable.blueTable .divTableRow:nth-child(even) {
          background: #717575;
        }
        .divTable.blueTable .divTableHeading {
          background: #535656;
          background: -moz-linear-gradient(top, #7e8080 0%, #646767 66%, #535656 100%);
          background: -webkit-linear-gradient(top, #7e8080 0%, #646767 66%, #535656 100%);
          background: linear-gradient(to bottom, #7e8080 0%, #646767 66%, #535656 100%);
          border-bottom: 0px solid #203044;
        }
        .divTable.blueTable .divTableHeading .divTableHead {
          font-size: 12px;
          font-weight: bold;
          color: #DFE7E7;
          border-left: 0px solid #D0E4F5;
        }
        .divTable.blueTable .divTableHeading .divTableHead:first-child {
          border-left: none;
        }

        .blueTable .tableFootStyle {
          font-size: 10px;
          font-weight: bold;
          color: #FFFFFF;
          background: #DFE7E7;
          background: -moz-linear-gradient(top, #e7eded 0%, #e2e9e9 66%, #DFE7E7 100%);
          background: -webkit-linear-gradient(top, #e7eded 0%, #e2e9e9 66%, #DFE7E7 100%);
          background: linear-gradient(to bottom, #e7eded 0%, #e2e9e9 66%, #DFE7E7 100%);
          border-top: 0px solid #444444;
        }
        .blueTable .tableFootStyle {
          font-size: 10px;
        }
        .blueTable .tableFootStyle .links {
	         text-align: right;
        }
        .blueTable .tableFootStyle .links a{
          display: inline-block;
          background: #535656;
          color: #FFFFFF;
          padding: 2px 8px;
          border-radius: 5px;
        }
        .blueTable.outerTableFooter {
          border-top: none;
        }
        .blueTable.outerTableFooter .tableFootStyle {
          padding: 3px 5px; 
        }
        /* DivTable.com */
        .divTable{ display: table; }
        .divTableRow { display: table-row; }
        .divTableHeading { display: table-header-group;}
        .divTableCell, .divTableHead { display: table-cell;}
        .divTableHeading { display: table-header-group;}
        .divTableFoot { display: table-footer-group;}
        .divTableBody { display: table-row-group;}
    </style>
</head>v
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick">
        </asp:Menu>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            <asp:ListItem>a</asp:ListItem>
            <asp:ListItem>b</asp:ListItem>
            <asp:ListItem Value="c"></asp:ListItem>
        </asp:CheckBoxList>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>

        <div class="divTable blueTable">
        <div class="divTableHeading">
        <div class="divTableRow">
        <div class="divTableHead">head1</div>
        <div class="divTableHead">head2</div>
        <div class="divTableHead">head3</div>
        <div class="divTableHead">head4</div>
        </div>
        </div>
        <div class="divTableBody">
        <div class="divTableRow">
        <div class="divTableCell">cell1_1</div><div class="divTableCell">cell2_1</div><div class="divTableCell">cell3_1</div><div class="divTableCell">cell4_1</div></div>
        <div class="divTableRow">
        <div class="divTableCell">cell1_2</div><div class="divTableCell">cell2_2</div><div class="divTableCell">cell3_2</div><div class="divTableCell">cell4_2</div></div>
        <div class="divTableRow">
        <div class="divTableCell">cell1_3</div><div class="divTableCell">cell2_3</div><div class="divTableCell">cell3_3</div><div class="divTableCell">cell4_3</div></div>
        <div class="divTableRow">
        <div class="divTableCell">cell1_4</div><div class="divTableCell">cell2_4</div><div class="divTableCell">cell3_4</div><div class="divTableCell">cell4_4</div></div>
        </div>
        </div>
        <div class="blueTable outerTableFooter"><div class="tableFootStyle"><div class="links"><a href="#">&laquo;</a> <a class="active" href="#">1</a> <a href="#">2</a> <a href="#">3</a> <a href="#">4</a> <a href="#">&raquo;</a></div></div></div>

    </form>
</body>
</html>
