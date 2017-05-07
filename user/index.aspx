<%@ Page Language="C#" enableEventValidation="false"  AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="user_index" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>网站后台管理系统</title>
    <link href="../img/mycss.css" rel="stylesheet" type="text/css">
    <SCRIPT language="javascript" src="../img/softkeyboard.js"></SCRIPT>
     <style type="text/css">
         .style1
         {
             width: 371px;
         }
     </style>
</head>
<body bgcolor="#6DC0F0" >
    <form id="form1" runat="server">
   
   <table cellpadding=0 cellspacing=0 width=624 align=center >
   
            <tr>
                <td align=center width="624" >
                     <div style="background:url(../images/login.png) no-repeat left center;width:624px;height:413px;margin:0 auto;margin-top:100px;">
        
        <table width="100%" border="0" cellspacing="5" cellpadding="0" style="margin-top:70px">
                    <form method="POST" name="form1" action="zheng.asp?what=login">
                      <tr> 
                        <td align="right" class="style1"><strong>管理帐户：</strong></td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="userpass" Width="140px"></asp:TextBox>
                          </td>
                      </tr>
                      <tr> 
                        <td align="right" class="style1"><strong>登陆密码：</strong></td>
                        <td>
                            <asp:TextBox ID="txtUserPass" runat="server" CssClass="userpass" 
                                TextMode="Password" Width="140px"></asp:TextBox>
                          </td>
                      </tr>
                     
                      <tr> 
                        <td align="right" class="style1"><strong>验 证 码：</strong></td>
                        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr> 
                              <td width="80"> 
                                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="userpass" Width="73px"></asp:TextBox>
                              </td>
                              <td><img src="images.aspx" id="checkcode" name="checkcode" align="absBottom" /></td>
                            </tr>
                          </table></td>
                      </tr>
                      <tr> 
                        <td class="style1">　</td>
                        <td height="30"> <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/loginbutton.png"
                                onclick="ImageButton1_Click" />
                          </td>
                      </tr>
                    </form>
                  </table>
   </div>
 
                </td>
            </tr>
   
   
   </table>

  
       
       
    </form>
</body>
</html>
