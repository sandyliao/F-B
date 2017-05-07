<%@ Page Language="C#" AutoEventWireup="true" CodeFile="about1.aspx.cs" Inherits="about1" %>
<%@ Register Src="~/WebUserControl/top.ascx" TagName="top" TagPrefix="cc1" %>
<%@ Register Src="~/WebUserControl/foot.ascx" TagName="foot" TagPrefix="cc2" %>
<%@ Register Src="~/WebUserControl/left.ascx" TagName="left" TagPrefix="cc3" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>云南天之豪装饰材料有限公司</title>
<meta name="keywords" content="天之豪,精工高晶板,吊顶,装饰,材料,公司" />
<meta name="description" content="云南天之豪装饰材料有限公司" />
<meta name="copyright" content="天之豪：公司" />
<link href="css/public.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server">
     <cc1:top ID="top" runat="server" />
   
<div class="main">
	<div class="main-leftneiye mar-top10">
        <div class="erjimulu-top">
           走进天之豪
        </div>
        <div class="erjijmulu-neirong">
        <ul>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
            <li><a href="about.aspx?id=<%#Eval("id") %>" title="<%#Eval("classname") %>"><%#Eval("classname") %></a></li>
            </ItemTemplate>
            </asp:Repeater>
        </ul>
        </div>
<cc3:left ID="left" runat="server" />
	</div>
<div class="main-rightneiye mar-top10">
	<div class="neiye-bj">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
        <div class="listneirong">
    </div>
    <div class="listneirong">
        <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>
         <ul>
    <li class="list-tupiankuang"><a href="aboutmore.aspx?id=<%#Eval("id") %>" title="<%#Eval("title") %>"><img alt="" src="<%#Eval("keywords") %>"  width="158px" height="105" /></a></li>
    <li class="list-biaoti"><a href="aboutmore.aspx?id=<%#Eval("id") %>"><%#Eval("title") %></a></li>
    <li class="list-xiangxi">
        　　 <%# Eval("jianjie")%></li>
    </ul>
        </ItemTemplate>
        </asp:Repeater>
   <webdiyer:aspnetpager ID="AspNetPager1" runat="server" CssClass="formfield" 
            CustomInfoClass="formbutton" 
            CustomInfoHTML="第&lt;font color='red'&gt;&lt;b&gt;%CurrentPageIndex%&lt;/b&gt;&lt;/font&gt;页 共%PageCount%&nbsp;页 %StartRecordIndex%-%EndRecordIndex%" 
            CustomInfoTextAlign="Center" FirstPageText="首页" horizontalalign="Center" 
            InputBoxStyle="width:19px" LastPageText="尾页" meta:resourceKey="AspNetPager1" 
            NextPageText="下一页" onpagechanged="AspNetPager1_PageChanged" PageSize="4" 
            PrevPageText="前一页" showcustominfosection="Left" ShowInputBox="Always" 
            ShowNavigationToolTip="True" style="FONT-SIZE: 14px" 
            SubmitButtonClass="formfield" SubmitButtonText="GO" width="506px">
        </webdiyer:aspnetpager>
    
    </div>
    
</div>
</div>
<cc2:foot ID="foot" runat="server" />
    </form>
</body>
</html>
