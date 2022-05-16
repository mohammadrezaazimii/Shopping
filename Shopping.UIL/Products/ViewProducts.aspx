<%@ Page Title="" Language="C#" MasterPageFile="~/ShoppingCart.Master" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="Shopping.UIL.Products.ViewProducts" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin:70px auto;">
                <asp:DataList ID="dlProduct" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" CellPadding="40" CellSpacing="30" GridLines="Both" Width="100%">
                    <ItemTemplate>
                        <table style="margin:0 auto;">
                            <tr>
                                <td colspan="2" class="auto-style1">
                                    <%--<asp:Label ID="lblcode" runat="server" Text='<% #Eval("procode") %>'></asp:Label>--%>
                                    <asp:Label ID="lblname" runat="server" Text='<% #Eval("proname") %>'></asp:Label>
                                      <asp:Label runat="server" Text=":نام محصول"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="auto-style1">
                                    <asp:Image ID="img" runat="server" Width="150px" Height="150px" ImageUrl='<% #"~/ProductImage/" + Convert.ToString(Eval("proimage")) %>' />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="auto-style1">
                                    <asp:Label ID="lblprice" runat="server" Text='<% #Eval("proprice") %>'></asp:Label>
                                      <asp:Label runat="server" Text=":قیمت"></asp:Label>
                                </td>
                            </tr>

                        </table>
                        

                  
                    </ItemTemplate>

                </asp:DataList>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</asp:Content>

