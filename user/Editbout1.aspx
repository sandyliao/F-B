<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Editbout1.aspx.cs" Inherits="user_Editbout1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../img/mycss.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
        }
    </style>
</head>
<body bgcolor="#DEDDDD" text="#333333" link="#333333" vlink="#333333" alink="#333333" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
   <table width="98%"  border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#3A76AF">
  <tr> 
    <td height="28"> <span class="style12"><font color="#FFFFFF">&nbsp;→ 欢迎您的网站</font></span><font color="#FFFFFF"><span class="style12">后台管理系统</span></font></td>
    <td align="left"> <strong><span class="C02"><font color="#FFFFFF"></font></span></strong></td>
  </tr>
</table>
<br>
<hr align="center" width="98%" size="1" noshade>
<table width="98%"  border="0" align="center" cellpadding="4" cellspacing="1" bgcolor="#3A76AF">
  <tr> 
    <td height="23" colspan="2"><div align="center" class="style3"><font color="#FFFFFF"><strong>走进天之豪</strong></font></div></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1">
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>请选择</asp:ListItem>
            <asp:ListItem Value="9">企业资质</asp:ListItem>
            <asp:ListItem Value="10">企业荣誉</asp:ListItem>
        </asp:DropDownList>
      </td>
    <td width="75%" height="25"></a>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="添加文章" />
      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1" colspan="2">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" 
            Width="100%">
            <Columns>
                <asp:BoundField DataField="title" HeaderText="标题" SortExpression="title" />
                <asp:BoundField DataField="faburen" HeaderText="发布人" SortExpression="faburen" />
                <asp:BoundField DataField="time" HeaderText="发布时间" SortExpression="time" />
                <asp:HyperLinkField DataNavigateUrlFields="id" 
                    DataNavigateUrlFormatString="aboutxx.aspx?id={0}" HeaderText="编辑" 
                    Text="编辑" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            DeleteCommand="DELETE FROM [gscontent] WHERE [id] = ?" 
            InsertCommand="INSERT INTO [gscontent] ([id], [title], [faburen], [time], [content], [hit], [keywords], [classid]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="SELECT * FROM [gscontent] WHERE ([classid] = ?)" 
            UpdateCommand="UPDATE [gscontent] SET [title] = ?, [faburen] = ?, [time] = ?, [content] = ?, [hit] = ?, [keywords] = ?, [classid] = ? WHERE [id] = ?">
            <SelectParameters>
                <asp:Parameter DefaultValue="10" Name="classid" Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="faburen" Type="String" />
                <asp:Parameter Name="time" Type="DateTime" />
                <asp:Parameter Name="content" Type="String" />
                <asp:Parameter Name="hit" Type="Int32" />
                <asp:Parameter Name="keywords" Type="String" />
                <asp:Parameter Name="classid" Type="Int32" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="id" Type="Int32" />
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="faburen" Type="String" />
                <asp:Parameter Name="time" Type="DateTime" />
                <asp:Parameter Name="content" Type="String" />
                <asp:Parameter Name="hit" Type="Int32" />
                <asp:Parameter Name="keywords" Type="String" />
                <asp:Parameter Name="classid" Type="Int32" />
            </InsertParameters>
        </asp:SqlDataSource>
      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td class="style1">
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="SELECT * FROM [gscontent] WHERE ([classid] = ?)" 
            DeleteCommand="DELETE FROM [gscontent] WHERE [id] = ?" 
            InsertCommand="INSERT INTO [gscontent] ([id], [title], [faburen], [time], [content], [hit], [keywords], [classid], [jianjie]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)" 
            UpdateCommand="UPDATE [gscontent] SET [title] = ?, [faburen] = ?, [time] = ?, [content] = ?, [hit] = ?, [keywords] = ?, [classid] = ?, [jianjie] = ? WHERE [id] = ?">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="classid" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="faburen" Type="String" />
                <asp:Parameter Name="time" Type="DateTime" />
                <asp:Parameter Name="content" Type="String" />
                <asp:Parameter Name="hit" Type="Int32" />
                <asp:Parameter Name="keywords" Type="String" />
                <asp:Parameter Name="classid" Type="Int32" />
                <asp:Parameter Name="jianjie" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="id" Type="Int32" />
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="faburen" Type="String" />
                <asp:Parameter Name="time" Type="DateTime" />
                <asp:Parameter Name="content" Type="String" />
                <asp:Parameter Name="hit" Type="Int32" />
                <asp:Parameter Name="keywords" Type="String" />
                <asp:Parameter Name="classid" Type="Int32" />
                <asp:Parameter Name="jianjie" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
      </td>
    <td>
        </td>
  </tr>
  </table>
    </form>
</body>
</html>
