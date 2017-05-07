<%@ Page Language="C#" AutoEventWireup="true" CodeFile="productEdit.aspx.cs" Inherits="user_productEdit" %>

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
    <td height="23" colspan="2"><div align="center" class="style3"><font color="#FFFFFF"><strong>产品管理</strong></font></div></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1">&nbsp;</td>
    <td width="75%" height="25"></a>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="添加产品" />
      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1" colspan="2">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            DeleteCommand="DELETE FROM [product] WHERE [id] = ?" 
            InsertCommand="INSERT INTO [product] ([id], [protitle], [projianjie], [projiage], [proxinhao], [proleibei], [procontent], [fabutime], [propic], [classid]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="SELECT * FROM [product]" 
            UpdateCommand="UPDATE [product] SET [protitle] = ?, [projianjie] = ?, [projiage] = ?, [proxinhao] = ?, [proleibei] = ?, [procontent] = ?, [fabutime] = ?, [propic] = ?, [classid] = ? WHERE [id] = ?">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="protitle" Type="String" />
                <asp:Parameter Name="projianjie" Type="String" />
                <asp:Parameter Name="projiage" Type="String" />
                <asp:Parameter Name="proxinhao" Type="String" />
                <asp:Parameter Name="proleibei" Type="String" />
                <asp:Parameter Name="procontent" Type="String" />
                <asp:Parameter Name="fabutime" Type="DateTime" />
                <asp:Parameter Name="propic" Type="String" />
                <asp:Parameter Name="classid" Type="Int32" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="id" Type="Int32" />
                <asp:Parameter Name="protitle" Type="String" />
                <asp:Parameter Name="projianjie" Type="String" />
                <asp:Parameter Name="projiage" Type="String" />
                <asp:Parameter Name="proxinhao" Type="String" />
                <asp:Parameter Name="proleibei" Type="String" />
                <asp:Parameter Name="procontent" Type="String" />
                <asp:Parameter Name="fabutime" Type="DateTime" />
                <asp:Parameter Name="propic" Type="String" />
                <asp:Parameter Name="classid" Type="Int32" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="id" DataSourceID="SqlDataSource1" Width="100%">
            <Columns>
                <asp:BoundField DataField="protitle" HeaderText="产品名称" 
                    SortExpression="protitle" />
                <asp:BoundField DataField="fabutime" HeaderText="发布时间" 
                    SortExpression="fabutime" />
                <asp:HyperLinkField DataNavigateUrlFields="id" 
                    DataNavigateUrlFormatString="Addpro.aspx?editpro={0}" Text="编辑" />
                <asp:CommandField ShowDeleteButton="True" />
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
