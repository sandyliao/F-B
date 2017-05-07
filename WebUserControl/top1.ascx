<%@ Control Language="C#" AutoEventWireup="true" CodeFile="top1.ascx.cs" Inherits="WebUserControl_top" %>
   
<div class="top">
	<div class="topIndex">
		<div class="logo"><a href="#"><img src="img/zxgk.jpg" height="80px"; /></a></div>
		<div class="topIndexr">
			<div class="tel"><img src="images/tel.gif" /></div>
			<div class="navlist">
				<ul>
					<li><a href="~/index.aspx" runat="server"    >首页</a></li>
					<li id="gywm"  >
						<a href="guanyuwomen.aspx?id=7">关于我们</a>
						<div class="gywm">
							<p><a href="guanyuwomen.aspx?id=7">公司简介</a></p>
                            <hr  />
							<p><a href="guanyuwomen.aspx?id=37">业务介绍</a></p>
                            <hr  />
                            <p><a href="lianxiwomen.aspx">联系我们</a></p>
						</div>
					</li>
					<li><a href="touzilinian.aspx"   >组织机构</a></li>
					<li><a href="qixiachanpin.aspx"   >政策法规</a></li>                         
					<li><a href="hexintuandui.aspx"  >诚信认证</a></li> 
                    <li><a href="fuwuanli.aspx"  >认证案例</a></li>   					    
					<li><a href="xinwendongtai.aspx"  >信用评级</a></li>    
					<li><a href="kehuliuyan.aspx"   >诚信申请</a></li>
                    <li><a href="http://www.shcmsc.com/"target="_blank"   >成谋首页</a></li>
				</ul>
			</div>
		</div>
	</div>
</div>
<!-- flash 文件 -->


<div class="flash">
	<img  src="http://images.shcmsc.com/templates/renzheng/logo.jpg" width="980" height="198" />
    
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