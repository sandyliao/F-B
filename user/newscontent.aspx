<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newscontent.aspx.cs" Inherits="user_newscontent" %>

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
    <td height="23" colspan="2"><div align="center" class="style3"><font color="#FFFFFF"><strong>文章管理</strong></font></div></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1">&nbsp;</td>
    <td width="75%" height="25"></a>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="添加产品" />
      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1" colspan="2">
<%--        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:mysqlconn1 %>" 
            DeleteCommand="DELETE FROM [newscontent] WHERE [id] = ?" 
            InsertCommand="INSERT INTO [newscontent] ([id], [title], [faburen], [time], [content], [hit], [keywords]) VALUES (?, ?, ?, ?, ?, ?, ?)" 
            ProviderName="<%$ ConnectionStrings:mysqlconn1.ProviderName %>" 
            SelectCommand="SELECT * FROM [newscontent]" 
            
            UpdateCommand="UPDATE [newscontent] SET [title] = ?, [faburen] = ?, [time] = ?, [content] = ?, [hit] = ?, [keywords] = ? WHERE [id] = ?">
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
            </InsertParameters>
        </asp:SqlDataSource>

--%>



        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:BoundField DataField="title" HeaderText="文章标题" 
                    SortExpression="title" />
                <asp:BoundField DataField="faburen" HeaderText="发布人" 
                    SortExpression="faburen" />
                <asp:BoundField DataField="time" HeaderText="发布时间" SortExpression="time" />
                <asp:HyperLinkField DataNavigateUrlFields="id" 
                    DataNavigateUrlFormatString="Addnews.aspx?editnews={0}" HeaderText="编辑" 
                    Text="编辑" />
            </Columns>
        </asp:GridView>




      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1" colspan="2">&nbsp;</td>
  </tr>
  </table>
    </form>
</body>
</html>
