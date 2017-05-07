<%@ Control Language="C#" AutoEventWireup="true" CodeFile="zhongjian.ascx.cs" Inherits="WebUserControl_left" %>
<div class="content">
<div>	
<!--新闻动态-->
	<div class="contentL">
	
		<div class="news">
			<div class="tit">
				
				<span class="span2">
					新闻动态
				</span>
			</div>
			<div class="test">
            
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="AccessDataSource2" EnableModelValidation="True" Width="100%" 
                    CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                       
                          <asp:TemplateField HeaderText="新闻标题"  >
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <a href="xinwenneirong.aspx?id=<%#Eval("id") %>">
                         <%#Common.getLength(DataBinder.Eval(Container.DataItem, "title"), 10)%>
                       </a>
                    </ItemTemplate>
                </asp:TemplateField>
                        <asp:BoundField DataField="time" HeaderText="日期" DataFormatString="{0:yyyy-MM-dd}"   >
                        
                          <ItemStyle HorizontalAlign="Center" />
                          </asp:BoundField>
                        
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                <asp:AccessDataSource ID="AccessDataSource2" runat="server" 
                    DataFile="~/App_Data/access.mdb" 
                    SelectCommand="select top 6  * from newscontent  ORDER BY [time] DESC">
                </asp:AccessDataSource>
				  <%--     <ul>
                <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
             <li>
             <span class="span1"> <a href="xinwenneirong.aspx?id=<%#Eval("id") %>" title="<%#Eval("title")%>"><%#Eval("title") %></a></span>
             <span class="span2"><%#Eval("time").ToString().Substring(0,9) %></span>
             
             </li>  
            </ItemTemplate>
            </asp:Repeater>
            </ul> --%>
			</div>		
            <span class="span1"><a href="xinwendongtai.aspx"><img src="images/more.png" /></a></span>	
		</div>		
		
		
		
	</div>
	<!--关于我们-->
	<div class="contentR">
		<div class="aboutUs">
			<div class="tit">
				<span class="span1">关于我们</span>
				<span class="span2"><a href="guanyuwomen.aspx?id=7"><img src="images/more.png" /></a></span>
			</div>
			
			<div class="text">
			     <%= jianjie.ToString().Length > 250 ? jianjie.ToString().Substring(0,250) + "..." : jianjie%>
			</div>
		</div>
	</div> 
</div>
    <div class="blank25"></div>
<div>
   <!--诚信认证 -->
    <div class="contentL">
 
        <div class="tzln">
			    <div class="tit">
				    <img src="http://images.shcmsc.com/templates/renzheng/cxrz1.jpg"  width="315px" height="60px"/>
			    </div>
			    <div class="text">
			    <p> <span style="font-weight: bold;color: #CC0011;">诚信认证概述</span><br />
                            (一)中国电子商务协会是《中华人民共和国电子签名法》具体实施和推进机构。<br />
                            (二)中国电子商务协会是国家整规办和国资委联合授权的行业信用评价试点单位。<br />
                            (三)与国际权威第三方信用认证机构邓白氏合作，共同打造网络诚信。
                            </p>
			    </div>
                  <span class="span2"><a href="hexintuandui.aspx"><img src="images/more.png" /></a></span>
	    </div>


                            <div class="lay_canp">
			                       <div class="z_border">
				                        <div class="z_title"><b>指导单位与合作机构</b></div>
				                        <ul>
					                        <li><a href="http://www.miit.gov.cn" target="_blank"><img src="img/gyxxh.jpg"></a></li>
					                        <li><a href="http://www.mofcom.gov.cn/" target="_blank"><img src="img/swb.jpg"></a></li>
					                        <li><a href="http://www.sasac.gov.cn/" target="_blank"><img src="img/gyzc.jpg"></a></li>
					                        <li><a href="http://www.ndrc.gov.cn/" target="_blank"><img src="img/fgw.jpg"></a></li>
					                        <li><a href="hhttp://www.mps.gov.cn" target="_blank"><img src="img/gab.jpg"></a></li>
					                        <li><a href="http://www.saic.gov.cn/" target="_blank"><img src="img/gszj.jpg"></a></li>
					                        <li><a href="http://www.court.gov.cn/" target="_blank"><img src="img/wefcs.jpg"></a></li>
					                        <li><a href="http://www.mca.gov.cn/" target="_blank"><img src="img/ghgmzb.jpg"></a></li>
				                        </ul>
			                      </div>
		                   </div>






    </div>

    <div class="contentR">
    <!--信用评级-->
		<div class="tzln qxcp">
			<div class="tit" style="text-align: right">
				<img src="http://images.shcmsc.com/templates/renzheng/xypj2.jpg" width="305px" height="60px" />
			</div>
			<div class="text"> 
		           <%= qixiachanpin%>
			   </div>
             <span class="span2"><a href="xinwendongtai.aspx"><img src="images/more.png" /></a></span>
		</div>
		<!-- 政策法规-->
		   <div class="tzln hxtd">
			   <div class="tit" style="text-align: right">
				  <img src="http://images.shcmsc.com/templates/renzheng/dzsw3.jpg"  width="315px" height="60px"/>
			   </div>
			   <div class="text"> 
		           <%= hexintuandui%>
			   </div>
               <span class="span2"><a href="qixiachanpin.aspx"><img src="images/more.png" /></a></span>
		   </div>
    </div>

  </div>
</div>