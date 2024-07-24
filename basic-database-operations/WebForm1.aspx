<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="basic_database_operations.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table>
            <tr>
                <td>First name</td>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Last name</td>
                <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>Number</td>
                <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BtnSubmit" runat="server" Text="Insert" OnClick="BtnSubmit_Click" />
                   
                    <asp:Button ID="BtnView" runat="server" Text="View" OnClick="btnView_Click"/>

                    <asp:Button ID="btnDeleteAll" runat="server" Text="Delete All" OnClick="btnDeleteAll_Click" />

                    <asp:Button ID="btnDeleteRow" runat="server" Text="Delete Row" OnClick="btnDeleteRow_Click" />

                </td>
            </tr>
            </table>

            <h2>GridView</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True"></asp:GridView>

            <h2>DataList</h2>
            <asp:DataList ID="DataList1" runat="server">
                <ItemTemplate>
                    <div>

                        <b>FirstName:</b> <%# Eval("FirstName") %> <br />
                        <b>LastName:</b> <%# Eval("LastName") %> <br />
                        <b>Number:</b> <%# Eval("Number") %> <br />
                    </div>
                </ItemTemplate>
            </asp:DataList>

            <h2>ListView</h2>
            <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>
                    <div>
                      
                        <b>FirstName:</b> <%# Eval("FirstName") %> <br />
                        <b>LastName:</b> <%# Eval("LastName") %> <br />
                        <b>Number:</b> <%# Eval("Number") %> <br />
                    </div>
                </ItemTemplate>
            </asp:ListView>

            <h2>Repeater</h2>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div>
                      
                        <b>FirstName:</b> <%# Eval("FirstName") %> <br />
                        <b>LastName:</b> <%# Eval("LastName") %> <br />
                        <b>Number:</b> <%# Eval("Number") %> <br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
