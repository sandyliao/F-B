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
   <!--投资理念 -->
    <div class="contentL">
 
        <div class="tzln">
			    <div class="tit">
				    <img src="images/tzln.jpg" />
			    </div>
			    <div class="text">
			        <%= touzilinian%>
			    </div>
                  <span class="span2"><a href="touzilinian.aspx"><img src="images/more.png" /></a></span>
	    </div>
    </div>

    <div class="contentR">
    <!--旗下产品-->
		<div class="tzln qxcp">
			<div class="tit">
				<img src="images/qxcp.jpg" />
			</div>
			<div class="text">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="AccessDataSource1" EnableModelValidation="True" Width="100%" 
                    CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                       
                          <asp:TemplateField HeaderText="产品名称">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <a href="qixiachanpin.aspx">
                           <%#DataBinder.Eval(Container.DataItem, "cpmc")%> </a>
                    </ItemTemplate>
                </asp:TemplateField>
                        <asp:BoundField DataField="clrq" HeaderText="成立日期" SortExpression="clrq" />
                       
                        <asp:BoundField DataField="gxrq" HeaderText="更新日期" SortExpression="ljzzl" />
                         <asp:BoundField DataField="jz" HeaderText="净值" SortExpression="jz" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                </asp:GridView>
                <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
                    DataFile="~/App_Data/access.mdb" 
                    SelectCommand="SELECT   a.cpmc, a.gxrq,iif(a.jz>a.jz1,a.jz,a.jz1) as jz,a.clrq FROM      (qxcp a INNER JOIN     (SELECT   TOP 4 MAX(id) AS id FROM      qxcp GROUP BY cpmc) b ON a.id = b.id) ">
                </asp:AccessDataSource>
                <span class="span2"><a href="qixiachanpin.aspx"><img src="images/more.png" /></a></span>
			<%--   <%= qixiachanpin.ToString().Length > 250 ? qixiachanpin.ToString().Substring(0, 250) + "..." : qixiachanpin%>--%>
			</div>
		</div>
		<!-- 核心团队-->
		<div class="tzln hxtd">
			<div class="tit" style="text-align: right">
				<img src="images/hxtd.jpg" />
			</div>
			<div class="text"> 
		         <%= hexintuandui%>
			</div>
                <span class="span2"><a href="hexintuandui.aspx"><img src="images/more.png" /></a></span>
		</div>
    </div>
    </div>
</div>