<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wanzhan.aspx.cs" Inherits="user_wanzhan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <link href="../img/mycss.css" rel="stylesheet" type="text/css" />
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
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="id" 
           DataSourceID="SqlDataSource1" DefaultMode="Edit" Width="100%">
        <EditItemTemplate>
            <table align="center" bgcolor="#3A76AF" border="0" cellpadding="4" 
                cellspacing="1" width="98%">
                <tr>
                    <td colspan="2" height="23">
                        <div align="center" class="style3">
                            <font color="#FFFFFF"><strong>网站初始设置</strong></font></div>
                    </td>
                </tr>
                <tr bgcolor="#FFFFFF">
                    <td class="style1" height="25">
                        <div align="right">
                            公司名称：</div>
                    </td>
                    <td height="25" width="75%">
                        </a>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("gsname") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr bgcolor="#FFFFFF">
                    <td class="style1" height="25">
                        <div align="right">
                            公司总部：</div>
                    </td>
                    <td height="25">
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("zongbu") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr bgcolor="#FFFFFF">
                    <td class="style1" height="25">
                        <div align="right">
                            生产基地：</div>
                    </td>
                    <td height="25">
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("jidi") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr bgcolor="#FFFFFF">
                    <td class="style1" height="25">
                        <div align="right">
                            邮编：</div>
                    </td>
                    <td height="25">
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("youbian") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr bgcolor="#FFFFFF">
                    <td class="style1" height="25">
                        <div align="right">
                            传真：</div>
                    </td>
                    <td height="25">
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("chuanzheng") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr bgcolor="#FFFFFF">
                    <td class="style1" height="25">
                        <div align="right">
                            电话：</div>
                    </td>
                    <td height="25">
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("dianhua") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr bgcolor="#FFFFFF">
                    <td class="style1" height="25">
                        <div align="right">
                            地址：</div>
                    </td>
                    <td height="25">
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("dizhi") %>'></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
        </EditItemTemplate>
        <InsertItemTemplate>
            gsname:
            <asp:TextBox ID="gsnameTextBox" runat="server" Text='<%# Bind("gsname") %>' />
            <br />
            zongbu:
            <asp:TextBox ID="zongbuTextBox" runat="server" Text='<%# Bind("zongbu") %>' />
            <br />
            jidi:
            <asp:TextBox ID="jidiTextBox" runat="server" Text='<%# Bind("jidi") %>' />
            <br />
            dianhua:
            <asp:TextBox ID="dianhuaTextBox" runat="server" Text='<%# Bind("dianhua") %>' />
            <br />
            chuanzheng:
            <asp:TextBox ID="chuanzhengTextBox" runat="server" 
                Text='<%# Bind("chuanzheng") %>' />
            <br />
            youbian:
            <asp:TextBox ID="youbianTextBox" runat="server" Text='<%# Bind("youbian") %>' />
            <br />
            dizhi:
            <asp:TextBox ID="dizhiTextBox" runat="server" Text='<%# Bind("dizhi") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="插入" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="取消" />
        </InsertItemTemplate>
        <ItemTemplate>
            id:
            <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
            <br />
            gsname:
            <asp:Label ID="gsnameLabel" runat="server" Text='<%# Bind("gsname") %>' />
            <br />
            zongbu:
            <asp:Label ID="zongbuLabel" runat="server" Text='<%# Bind("zongbu") %>' />
            <br />
            jidi:
            <asp:Label ID="jidiLabel" runat="server" Text='<%# Bind("jidi") %>' />
            <br />
            dianhua:
            <asp:Label ID="dianhuaLabel" runat="server" Text='<%# Bind("dianhua") %>' />
            <br />
            chuanzheng:
            <asp:Label ID="chuanzhengLabel" runat="server" 
                Text='<%# Bind("chuanzheng") %>' />
            <br />
            youbian:
            <asp:Label ID="youbianLabel" runat="server" Text='<%# Bind("youbian") %>' />
            <br />
            dizhi:
            <asp:Label ID="dizhiLabel" runat="server" Text='<%# Bind("dizhi") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                CommandName="Edit" Text="编辑" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                CommandName="Delete" Text="删除" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                CommandName="New" Text="新建" />
        </ItemTemplate>
    </asp:FormView>
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
           ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
           DeleteCommand="DELETE FROM [wangzhan] WHERE [id] = ?" 
           InsertCommand="INSERT INTO [wangzhan] ([id], [gsname], [zongbu], [jidi], [dianhua], [chuanzheng], [youbian], [dizhi]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)" 
           ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
           SelectCommand="SELECT * FROM [wangzhan] WHERE ([id] = ?)" 
           UpdateCommand="UPDATE [wangzhan] SET [gsname] = ?, [zongbu] = ?, [jidi] = ?, [dianhua] = ?, [chuanzheng] = ?, [youbian] = ?, [dizhi] = ? WHERE [id] = ?">
           <SelectParameters>
               <asp:Parameter DefaultValue="1" Name="id" Type="Int32" />
           </SelectParameters>
           <DeleteParameters>
               <asp:Parameter Name="id" Type="Int32" />
           </DeleteParameters>
           <UpdateParameters>
               <asp:Parameter Name="gsname" Type="String" />
               <asp:Parameter Name="zongbu" Type="String" />
               <asp:Parameter Name="jidi" Type="String" />
               <asp:Parameter Name="dianhua" Type="String" />
               <asp:Parameter Name="chuanzheng" Type="String" />
               <asp:Parameter Name="youbian" Type="String" />
               <asp:Parameter Name="dizhi" Type="String" />
               <asp:Parameter Name="id" Type="Int32" />
           </UpdateParameters>
           <InsertParameters>
               <asp:Parameter Name="id" Type="Int32" />
               <asp:Parameter Name="gsname" Type="String" />
               <asp:Parameter Name="zongbu" Type="String" />
               <asp:Parameter Name="jidi" Type="String" />
               <asp:Parameter Name="dianhua" Type="String" />
               <asp:Parameter Name="chuanzheng" Type="String" />
               <asp:Parameter Name="youbian" Type="String" />
               <asp:Parameter Name="dizhi" Type="String" />
           </InsertParameters>
       </asp:SqlDataSource>
       <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="· 提交 ·" 
            Width="70px" />
    </form>
</body>
    

</html>
