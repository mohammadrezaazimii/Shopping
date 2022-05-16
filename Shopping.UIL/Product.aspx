<%@ Page Title="" Language="C#" MasterPageFile="~/ShoppingCart.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Shopping.UIL.Product" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="float:left;margin:20px; margin-top:50px">
                    <table>
                        <tr>
                            <td>Product Code:</td>
                            <td>
                                <asp:Label ID="lblcode" runat="server" Text="Auto Code"></asp:Label>
                            </td>
                        </tr> 
                        <tr>
                            <td>Product Name:</td>
                            <td>
                                <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Product Status:</td>
                            <td>
                                <asp:RadioButtonList ID="rbstatus" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">Deactive</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                         <tr>
                            <td>Product Price:</td>
                            <td>
                                <asp:TextBox ID="txtprice" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Product Category:</td>
                            <td>
                                <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Product Image:</td>
                            <td>
                                <asp:FileUpload ID="fileUpload" runat="server" />
                                <asp:Label ID="imgpath" runat="server" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
                            </td>
                        </tr>
                    </table>

            </div>
            <div style="float:right;text-align:center;margin:20px;margin-top:50px">
                <asp:GridView ID="gridProduct" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowEditing="gridProduct_RowEditing" OnRowDeleting="gridProduct_RowDeleting">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:TemplateField HeaderText="Product Name">
                            <ItemTemplate>
                                <asp:Label ID="lblcode" runat="server" Text='<% #Eval("procode") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblname" runat="server" Text='<% #Eval("proname") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Status">
                            <ItemTemplate>
                                <asp:Label ID="lblstatus" runat="server" Text='<% #Eval("prostatus") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Price">
                            <ItemTemplate>
                                <asp:Label ID="lblprice" runat="server" Text='<% #Eval("proprice") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Category">
                            <ItemTemplate>
                                <asp:Label ID="lblcat" runat="server" Text='<% #Eval("procat") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Image">
                            <ItemTemplate>
                                <asp:Image ID="img" ImageUrl='<% #"~/ProductImage/" + Convert.ToString(Eval("proimage")) %>' Width="100px" Height="100px" runat="server" />
                           
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Events">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" />
                                <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="btnUpdate" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
