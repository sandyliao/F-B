<%@ Control Language="C#" AutoEventWireup="true" CodeFile="top.ascx.cs" Inherits="WebUserControl_top" %>
   
<div class="top">
	<div class="topIndex">
		<div class="logo"><a href="#"><img src="images/logo.gif" /></a></div>
		<div class="topIndexr">
			<div class="tel"><img src="images/tel.gif" /></div>
			<div class="navlist">
				<ul>
					<li><a href="~/index.aspx" runat="server"    >首页</a></li>
					<li id="gywm"  >
						<a href="guanyuwomen.aspx?id=7">关于我们</a>
						<div class="gywm">
							<p><a href="guanyuwomen.aspx?id=7">公司简介</a></p>
							<p><a href="guanyuwomen.aspx?id=37">业务介绍</a></p>
						</div>
					</li>
					<li><a href="touzilinian.aspx"   >投资理念</a></li>
					<li><a href="qixiachanpin.aspx"   >旗下产品</a></li>     
					<li><a href="hexintuandui.aspx"  >核心团队</a></li>    
					<li><a href="lianxiwomen.aspx"   >联系我们</a></li>      
					<li><a href="xinwendongtai.aspx"  >新闻动态</a></li>    
					<li><a href="kehuliuyan.aspx"   >客户留言</a></li>
				</ul>
			</div>
		</div>
	</div>
</div>
<!-- flash 文件 -->


<div class="flash">
		<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" width="980" height="198">
      <param name="movie" value="flash/top.swf" />
      <param name="quality" value="high" />
      <param name="WMode" value="Transparent" />
      <embed src="flash/top.swf" width="980" height="198" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" wmode="Transparent"></embed>
  </object>
</div>


<script type="text/javascript">
    $(function () {
        $("#gywm").hover(function () {
            $(".gywm").slideDown(100);
        }, function () {
            $(".gywm").slideUp(200);
        })
    })
   
  
</script>