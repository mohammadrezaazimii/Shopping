<%@ Page Title="" Language="C#" MasterPageFile="~/ShoppingCart.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Shopping.UIL.Category" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="float:left; margin-top:70px">
                <table>
                    <tr>
                        <td>Category Code: </td>
                        <td>
                            <asp:Label ID="lblCode" runat="server" Text="Auto Code"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Category Name: </td>
                        <td>
                            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Category Status: </td>
                        <td>
                            <asp:RadioButtonList ID="rbstatus" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="True">Active</asp:ListItem>
                                <asp:ListItem Value="False">Deactive</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnReset" runat="server" Text="Reset" BackColor="#33CCFF" BorderStyle="None" Font-Bold="True" Font-Size="16px" Height="40px" Width="65px" OnClick="btnReset_Click" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" BackColor="#009900" BorderStyle="None" Font-Bold="True" Font-Size="16px" Height="40px" Width="65px" OnClick="btnSave_Click" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" BackColor="#FFCC00" BorderStyle="None" Font-Bold="True" Font-Size="16px" Height="40px" Width="65px" OnClick="btnUpdate_Click" Visible="false" />
                        </td>
                    </tr>

                </table>
            </div>
            <div style="float:right; text-align:center; margin-right:50px ; margin-top:50px">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:GridView ID="gridCategory" runat="server" AutoGenerateColumns="False" Width="459px" Height="268px" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowEditing="gridCategory_RowEditing" OnRowDeleting="gridCategory_RowDeleting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Category Name">
                            <ItemTemplate>
                                <asp:Label ID="lblcode" runat="server" Text='<% #Eval("catcode") %>' Visible="false" ></asp:Label>
                                <asp:Label ID="lblname" runat="server" Text='<% #Eval("catname") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category status">
                            <ItemTemplate>
                                <asp:Label ID="lblstatus" runat="server" Text='<% #Eval("catstatus") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Events">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" />
                                <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
