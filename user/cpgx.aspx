<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cpgx.aspx.cs" Inherits="user_cpgx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../img/mycss.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {            text-align: left;
        }
        .style2
        {
            width: 168px;
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
<table width="100%"  border="0" align="center" cellpadding="4" cellspacing="1" bgcolor="#3A76AF">
  <tr> 
    <td height="23" colspan="2"><div align="center" class="style3"><font color="#FFFFFF"><strong>信托概述</strong></font></div></td>
  </tr>
    <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"><div align="right">产品名称：</div></td>
    <td width="75%" height="25"></a>
        <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="AccessDataSource1" DataTextField="cpmc" DataValueField="id" 
          
           >
        </asp:DropDownList>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
            DataFile="~/App_Data/access.mdb" 
            SelectCommand="SELECT [id], [cpmc] FROM [qxcp]"></asp:AccessDataSource>
        <asp:Button ID="Button1" runat="server" Text="查询" onclick="Button1_Click" />
      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1" colspan="2"> 
      
         
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True"   
            AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" 
            Width="100%" CellPadding="4" EnableModelValidation="True" 
            ForeColor="#333333" GridLines="None" HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
          

              
           <asp:BoundField DataField="xtmc" HeaderText="信托名称" 
                    SortExpression="xtmc" />
                <asp:BoundField DataField="xtlx" HeaderText="信托类型" 
                    SortExpression="xtlx" />
                <asp:BoundField DataField="xtjg" HeaderText="信托监管机构" 
                    SortExpression="xtjg" />
                <asp:BoundField DataField="str" HeaderText="受托人" 
                    SortExpression="str" />
                <asp:BoundField DataField="xtyh" HeaderText="信托保管银行" SortExpression="xtyh" />
                <asp:BoundField DataField="xtzh" HeaderText="信托认购帐户" SortExpression="xtzh" />
                <asp:BoundField DataField="zqjjs" HeaderText="证券经纪商" SortExpression="zqjjs" />
                <asp:BoundField DataField="tzgw" HeaderText="投资顾问" SortExpression="tzgw" />
                <asp:BoundField DataField="xtkh" HeaderText="信托客户对象" SortExpression="xtkh" />
               <asp:BoundField DataField="rgje" HeaderText="最低认购金额" SortExpression="rgje" /> 
               <asp:BoundField DataField="rgfl" HeaderText="最低费率" SortExpression="rgfl" /> 

                  <asp:BoundField DataField="fbq" HeaderText="资金封闭期" 
                    SortExpression="fbq" />
                <asp:BoundField DataField="kfq" HeaderText="开放日" 
                    SortExpression="kfq" />
                <asp:BoundField DataField="zjje" HeaderText="最低追加金额" 
                    SortExpression="zjje" />
                <asp:BoundField DataField="glfl" HeaderText="管理费率" 
                    SortExpression="glfl" />
                <asp:BoundField DataField="shfl" HeaderText="赎回费率" SortExpression="shfl" />
                <asp:BoundField DataField="fdglfl" HeaderText="浮动管理费率" SortExpression="fdglfl" />
                <asp:BoundField DataField="wddm" HeaderText="万德代码" SortExpression="wddm" />
                <asp:BoundField DataField="pbdm" HeaderText="彭博代码" SortExpression="pbdm" />
           

                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:TemplateField HeaderText="id" InsertVisible="False" SortExpression="id" 
                    Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" VerticalAlign="Middle" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            DeleteCommand="DELETE FROM [qxcp] WHERE [id] = ?" 
             
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="SELECT * FROM [qxcp]" 
            
            UpdateCommand="UPDATE qxcp SET cpmc = ?, jjjl = ?, clrq = ?, gxrq = ?, jz = ?, ljzzl = ?, bz = ?, jnzzl = ?, jz1 = ?, ljzzl1 = ?,
             xtmc = ?, xtlx = ?, str = ?, xtjg = ?, xtyh = ?, xtzh = ?, zqjjs = ?, tzgw = ?, xtkh = ?, rgje = ?, rgfl = ?, 
             fbq = ?, kfq = ?, zjje = ?, glfl = ?, shfl = ?, fdglfl = ?, wddm = ?, pbdm = ? WHERE (id = ?)">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="cpmc" Type="String" />
                 <asp:Parameter Name="jjjl" Type="String" />
                <asp:Parameter Name="clrq" Type="String" />
                <asp:Parameter Name="gxrq" Type="String" />
                <asp:Parameter Name="jz" Type="String" />
                <asp:Parameter Name="ljzzl" Type="String" />
                <asp:Parameter Name="bz" Type="String" />
                <asp:Parameter Name="jnzzl" Type="String" />
                <asp:Parameter Name="jz1" Type="String" />
                <asp:Parameter Name="ljzzl1" Type="String" />
                <asp:Parameter Name="xtmc" Type="String" />
                <asp:Parameter Name="xtlx" Type="String" />
                <asp:Parameter Name="str" Type="String" />
                <asp:Parameter Name="xtjg" Type="String" />
                <asp:Parameter Name="xtyh" Type="String" />
                <asp:Parameter Name="xtzh" Type="String" />
                <asp:Parameter Name="zqjjs" Type="String" />
                <asp:Parameter Name="tzgw" Type="String" />
                <asp:Parameter Name="xtkh" Type="String" />
                <asp:Parameter Name="rgje" Type="String" />
                <asp:Parameter Name="rgfl" Type="String" />
                <asp:Parameter Name="fbq" Type="String" />
                <asp:Parameter Name="kfq" Type="String" />
                <asp:Parameter Name="zjje" Type="String" />
                <asp:Parameter Name="glfl" Type="String" />
                <asp:Parameter Name="shfl" Type="String" />
                <asp:Parameter Name="fdglfl" Type="String" />
                <asp:Parameter Name="wddm" Type="String" />
                <asp:Parameter Name="pbdm" Type="String" /> 
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="id" Type="Int32" />
                <asp:Parameter Name="cpmc" Type="String" />
                 <asp:Parameter Name="jjjl" Type="String" />
                <asp:Parameter Name="clrq" Type="String" />
                <asp:Parameter Name="gxrq" Type="String" />
                <asp:Parameter Name="jz" Type="String" />
                <asp:Parameter Name="ljzzl" Type="String" />
                <asp:Parameter Name="bz" Type="String" />
                <asp:Parameter Name="jnzzl" Type="String" />
                <asp:Parameter Name="jz1" Type="String" />
                <asp:Parameter Name="ljzzl1" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
      </td>
  </tr>

  
  </table>
  <table width="100%"  align="center"  >
    <tr bgcolor="#FFFFFF"> 
  
      <td height="25" class="style1"> 信托名称： </td>
    <td height="25">
        <asp:TextBox ID="xtmctxt" runat="server"></asp:TextBox></td>
            <td height="25" class="style1"> 最低认购金额： </td>
    <td height="25">
        <asp:TextBox ID="rgjgtxt" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
    <tr bgcolor="#FFFFFF"> 
  
        <td height="25" class="style1"> 信托类型： </td>
    <td height="25">
        <asp:TextBox ID="xtlxtxt" runat="server"></asp:TextBox></td>
            <td height="25" class="style1"> 认购费率： </td>
    <td height="25">
        <asp:TextBox ID="rgfltxt" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
   <tr bgcolor="#FFFFFF"> 
  
       <td height="25" class="style1"> 信托监管机构： </td>
    <td height="25">
        <asp:TextBox ID="xtjg" runat="server"></asp:TextBox></td>
         <td height="25" class="style1"> 资金封闭期： </td>
    <td height="25">
        <asp:TextBox ID="fbq" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
    <tr bgcolor="#FFFFFF"> 
  
        <td height="25" class="style1"> 受托人： </td>
    <td height="25">
        <asp:TextBox ID="str" runat="server"></asp:TextBox></td>
            <td height="25" class="style1"> 开放日： </td>
    <td height="25">
        <asp:TextBox ID="kfr" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
     <tr bgcolor="#FFFFFF"> 
  
      <td height="25" class="style1"> 信托保管银行： </td>
    <td height="25">
        <asp:TextBox ID="xtyh" runat="server"></asp:TextBox></td>
            <td height="25" class="style1"> 最低追加金额： </td>
    <td height="25">
        <asp:TextBox ID="zjje" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
    <tr bgcolor="#FFFFFF"> 
  
      <td height="25" class="style1"> 信托认购帐户： </td>
    <td height="25">
        <asp:TextBox ID="xtzh" runat="server"></asp:TextBox></td>
            <td height="25" class="style1"> 管理费率： </td>
    <td height="25">
        <asp:TextBox ID="glfl" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
    <tr bgcolor="#FFFFFF"> 
     
         <td height="25" class="style1"> 证券经纪商： </td>
       <td height="25">
        <asp:TextBox ID="zqjjs" runat="server"></asp:TextBox></td>
            <td height="25" class="style1"> 赎回费率： </td>
    <td height="25">
        <asp:TextBox ID="shfl" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
    <tr bgcolor="#FFFFFF"> 
   
      <td height="25" class="style1"> 投资顾问： </td>
    <td height="25">
        <asp:TextBox ID="tzgw" runat="server"></asp:TextBox></td>
            <td height="25" class="style1"> 浮动管理费率： </td>
    <td height="25">
        <asp:TextBox ID="fdglfl" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
    <tr bgcolor="#FFFFFF"> 
    
       <td height="25" class="style1"> 信托客户对象： </td>
    <td height="25">
        <asp:TextBox ID="xtkh" runat="server"></asp:TextBox></td>
            <td height="25" class="style1"> 万德代码： </td>
    <td height="25">
        <asp:TextBox ID="wddm" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
    <tr bgcolor="#FFFFFF"> 
 
        <asp:TextBox ID="bztxt" runat="server" Height="58px" TextMode="MultiLine" 
            Width="287px"></asp:TextBox></td>
       <td height="25" class="style1"> 彭博代码：</td>
    <td height="25">
        <asp:TextBox ID="pbdm" runat="server"></asp:TextBox></td>
                <td height="25" class="style1"> &nbsp;<asp:Button ID="btnAdd" runat="server"  Text="提交" 
            Width="70px" onclick="btnAdd_Click" />
        </td>
    <td height="25">
        &nbsp;</td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr> 
  
  </table>
    </form>
</body>
</html>