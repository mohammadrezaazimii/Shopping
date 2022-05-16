<%@ Page Title="" Language="C#" MasterPageFile="~/ShoppingCart.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="Shopping.UIL.User.SignIn" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table>
                    <tr>
                        <td colspan="2">
                            <h3>Sign In To Shopping Cart</h3>
                        </td>
                    </tr>
                     <tr>
                        <td>User Name</td>
                        <td>
                            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>Password</td>
                        <td>
                            <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td colspan="2">
                            <asp:Button ID="btnSignIn" runat="server" Text="Sign In" OnClick="btnSignIn_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
