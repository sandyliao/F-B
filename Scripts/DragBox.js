// JavaScript Document

var Class = {
  create: function() {
    return function() {
      this.initialize.apply(this, arguments);
    }
  }
}
var closeImgSrc = './images/imgClose.gif';
var loadImgSrc = './images/loading.gif';
var minImgSrc = './images/imgMin.gif'
var loadHtmSrc = './loading.htm';

//var closeImgSrc = 'images/imgClose.gif';
//var loadImgSrc = 'images/loading.gif';
//var minImgSrc = 'images/imgMin.gif'
//var loadHtmSrc = 'loading.htm';
var mouseDown = false;
var DragBox = Class.create();
var iLeft,iTop;
var drag;


DragBox.prototype = {
	initialize: function(id,title,width,height,url,data){
		drag = this;
		this.Zindex = 1000;
		this.IE = true;
		this.dragObjArray = new Array();
		this.title = (typeof title != 'undefined' ? title : 'title');
		this.url = (typeof url != 'undefined' ? url : '');
		this.width = (typeof width != 'undefined' ? width : 300);
		this.height = (typeof height != 'undefined' ? height : 200);
		this.data = (typeof data != 'undefined' ? data : '<img src="'+loadImgSrc+'" border="0" />数据加载中....');
		this.frame = '<iframe id="'+id+'IFrame" name="'+id+'IFrame" class="dialogIFrame" style="width:100%; height:100%" frameborder="0" scroll="no" src="'+this.url+'"></iframe>';
		if(!drag.fullBox)this.createFullBox();
		document.documentElement.onmousemove = this.moveDargBox;
		document.documentElement.onmouseup = this.onMouseUp;
		document.documentElement.onmousedown = this.onMouseDown;
		document.documentElement.onselectstart = function() { return false; };
		document.documentElement.ondragstart = function() { return false; };
		//document.onmouseup = this.onMouseUp;
	},
	createDragElement:function(){
		this.Box = document.createElement("div");
		if(this.dragObjArray.length > 0){
			this.dragObjArray[this.dragObjArray.length] = this.Box;
		}
		else{
			this.dragObjArray[0] = this.Box;
		}
		//this.Box.onmousedown = this.onMouseDown;
		document.body.appendChild(this.Box);
		this.Box.id = this.element;
		this.Box.name = this.element;
		this.Box.setAttribute('DragFrame','true');
		this.Box.oncontextmenu = function(){return false};
		this.Box.className = 'dialog';
		this.createTitleBox(this.element);
		this.toCenter();
		var s = this.Box.style;
		s.position = "absolute";
//        s.position = "relative";
			s.left = '0px';
			s.top = '0px';

//          s.left = ((parseInt(document.body.offsetWidth)-parseInt(this.width))/2)+'px';
//			s.top = ((parseInt(document.body.offsetHeight)-parseInt(this.height))/2)+'px';		
			
			
			
//            s.left = (Math.round((document.body.scrollWidth-parseInt(this.width))/2)).toString()+"px";
//			s.top = (Math.round((document.body.scrollHeight-parseInt(this.height))/2)).toString()+"px";
//            s.top=(document.documentElement.scrollTop+(document.documentElement.clientHeight-this.Box.offsetHeight)/2)+"px";
//            s.left=(document.documentElement.scrollLeft+(document.documentElement.clientWidth-this.Box.offsetWidth)/2)+"px";

            //            alert(document.documentElement.scrollTop+'------'+document.documentElement.scrollLeft);
//            alert(s.left+'----------'+s.top);
               
			this.Zindex++;
			s.zIndex = this.Zindex;
			//s.display = 'none';
			s.width = this.width+'px';
			s.height = this.height+'px';
			s.cursor = "default";
			s.border = "1px solid #8ECAFF";
			s.background = '#fff';
			s.padding = '2px';
//			s.left=(parseInt(screen.width)-parseInt(s.width))/2-window.screenLeft;  
//			s.top=(parseInt(screen.height)-parseInt(s.height))/2-window.screenTop;			
			

	},
	createTitleBox:function(element){
		this.dragBox = document.createElement("div");
		this.dragBox.id = "Drag"+element;
		this.dragBox.oncontextmenu = function(){return false};
		//this.dragBox.documentSelectStartHandler = document.onselectstart;
		this.Box.appendChild(this.dragBox);
		this.dragBox.className ='dialogTitleBar';
		this.dragBox.innerHTML = '<span class="info">'+this.title+'</span>' + '<span class="close"><img src="'+minImgSrc+'" border="0" onclick="drag.pucker(this);" title="隐藏内容"> <img src="'+closeImgSrc+'" border="0" onclick="drag.hide(this);" title="关闭"></span>';
		this.dragBox.setAttribute('DragElement','true');
		this.createContent();
	},
	createContent:function(){
		this.contentBox = document.createElement("div");
		this.Box.appendChild(this.contentBox);
		this.contentBox.setAttribute('EContent','true');
		this.contentBox.id = this.element + "Content";
		this.contentBox.style.margin = '3px,0';
		this.contentBox.style.height = (this.height - 28)+'px';
		this.contentBox.style.background = '#fff';
		if(this.url!=''){
			this.contentBox.innerHTML = this.frame;
		}
		else{
			this.contentBox.innerHTML = this.data;
		}
	},
	toCenter:function(){
		
//		var l = (document.body.clientWidth / 2) - (drag.Box.style.width.replace('px','')/2);
//		var t = (document.body.clientHeight / 2) - (drag.Box.style.height.replace('px','')/2);
		
		 var t =(document.documentElement.scrollTop+((document.documentElement.clientHeight/2)-(drag.Box.style.height.replace('px','')/2)));
         var l=(document.documentElement.scrollLeft+((document.documentElement.clientWidth/2)-(drag.Box.style.width.replace('px','')/2)));

//         var t =(((document.documentElement.clientHeight/2)-(drag.Box.style.height.replace('px','')/2)));
//         var l=(((document.documentElement.clientWidth/2)-(drag.Box.style.width.replace('px','')/2)));   
		
		drag.Box.style.top = (t<0 ? 0 : t+'px');
		drag.Box.style.left = (l<0 ? 0 : l+'px');
		if(drag.dragObjArray.length>1){
			var ii = drag.dragObjArray.length * 20;
			l = l + ii;
			t = t + ii;
			drag.Box.style.top = (t<0 ? 0 : t+'px');
			drag.Box.style.left = (l<0 ? 0 : l+'px');
		}
		
	},
	createFullBox:function(){
		this.fullBox = document.createElement("div");
		document.body.appendChild(this.fullBox);
		this.fullBox.oncontextmenu = function(){return false};
		this.fullBox.onmouseup = this.onMouseUp;
		var fbs = this.fullBox.style;
		fbs.position = "absolute";
			fbs.left = '0px';
			fbs.top = '0px';
			fbs.width = document.body.offsetWidth+'px';
			fbs.height = document.body.offsetHeight +'px';
			fbs.background = '#aaa';
			fbs.display = 'none';
			fbs.zIndex = this.Zindex;
		if(navigator.appMinorVersion != '0'){
			this.fullBox.innerHTML = fullFirame;
		}
		drag.setStyle(this.fullBox,'opacity',0.3);
	},
	onMouseDown:function(ev){
		var ev = ev ? ev :window.event;
		var tagElement = ev.srcElement ? ev.srcElement : ev.target;
		if(tagElement.tagName=="SPAN") tagElement = tagElement.parentNode;
		if(tagElement.getAttribute('DragElement')=="true" && tagElement.parentNode!=null){
			drag.DragElement = (tagElement.parentNode.tagName != "DIV" ? tagElement :  tagElement.parentNode);
			drag.DragElement.className = 'DragBox';
			drag.DragElement.onselectstart = function() { return false; };
			drag.DragElement.ondragstart = function() { return false; };
			drag.mouse_x = ev.clientX;
			drag.mouse_y = ev.clientY;
			drag.el_x = drag.DragElement.style.left.replace('px','')/1;
			drag.el_y = drag.DragElement.style.top.replace('px','')/1;
			if(!drag.tempBox) drag.createTempBox();

			var s = drag.tempBox.style;
				s.position = "absolute";
				s.left = drag.DragElement.style.left;
				s.top = drag.DragElement.style.top;
				s.display = 'block';
				s.width = drag.DragElement.style.width;
				s.height = drag.DragElement.style.height;
				s.cursor = "move";
				s.border = "3px dotted #000066";
				s.background = '';
				//s.padding = '2px';
				s.zIndex = drag.DragElement.style.zIndex+2;
			drag.Zindex++;
			drag.DragElement.style.zIndex = drag.Zindex;

			var ts = drag.tBox.style;
				ts.position = "absolute";
				ts.left = 0;
				ts.top = 0;
				ts.display = 'block';
				ts.width =  document.body.offsetWidth+'px';
				ts.height =document.body.offsetHeight +'px';
				//ts.border = "1px dotted #fedcef";
				ts.background = '#FFFFFF';
				//ts.padding = '2px';
				ts.zIndex = drag.DragElement.style.zIndex+1;
			
			
		}
	},
	createTempBox :function(){
		if(!this.tempBox){
			this.tempBox = document.createElement("div");
			document.body.appendChild(this.tempBox);
			this.tempBox.oncontextmenu = function(){return false};
			this.tempBox.id = 'tempDiv';
			this.tempBox.name = 'tempDiv';
			drag.setStyle(this.tempBox,'opacity',0.6);

			this.tBox = document.createElement("div");
			document.body.appendChild(this.tBox);
			this.tBox.oncontextmenu = function(){return false};
			this.tBox.id = 'tDiv';
			this.tBox.name = 'tDiv';
			drag.setStyle(this.tBox,'opacity',0);
		}
	},
	moveDargBox:function(ev){
		var ev = ev ? ev :window.event;
		var tagElement = ev.srcElement ? ev.srcElement : ev.target;
		
		if(drag.DragElement!=null && drag.tempBox!=null && typeof(drag.DragElement)== 'object'){
			
			iLeft = (ev.clientX - drag.mouse_x + drag.el_x) ;
			iTop = (ev.clientY - drag.mouse_y + drag.el_y);
			eWidth = drag.DragElement.style.width.replace('px','')/1;
			if(iLeft>(50-eWidth)){
				iLeft = (ev.clientX - drag.mouse_x + drag.el_x) ;
			}
			else{
				iLeft = (50-eWidth);
			}
			if(iTop>0){
				iTop = (ev.clientY - drag.mouse_y + drag.el_y);
			}
			else{
				iTop = 0;
			}
			//window.status = iLeft +"," + iTop +','+document.body.offsetWidth +','+(40-drag.el_x);
			if(document.all){
				if(ev.button==1){
					drag.tempBox.style.left = iLeft +'px';
					drag.tempBox.style.top = iTop +'px';
					if(tagElement.tagName=="HTML"){
						drag.onMouseUp(ev);
					}
				}
				else{
					if(drag.DragElement){
						drag.onMouseUp();
					}
				}
			}
			else{
				drag.tempBox.style.left = iLeft +'px';
				drag.tempBox.style.top = iTop +'px';
				if(tagElement.tagName=="HTML"){
					drag.onMouseUp(ev);
				}
			}
			/*else{
				if(drag.DragElement){
					drag.onMouseUp();
				}
			}*/
		}
	},
	onMouseUp:function(ev){
		
		if(drag.DragElement && drag.tempBox){
			drag.DragElement.className = 'dialog';
			drag.DragElement.style.left = drag.tempBox.style.left;
			drag.DragElement.style.top = drag.tempBox.style.top;			
			if(drag.tempBox)drag.tempBox.style.display = 'none';
			if(drag.tBox)drag.tBox.style.display = 'none';				
		}
		if(drag.DragElement){
			drag.DragElement = false;
		}
		
		
	},
	show:function(url,data,title,width,height,element,num){
		/*Url　要调用的页面
		data  要显示的数据，如指定了Url则不显示Data的数据
		title重新指定拖动框的标题
		num　指定背景层的Z-index　
		width　给定拖动层的宽度
		height　给定拖动层的高度
		element　给定拖动层的Div的id号
		*/
		
		this.element = (typeof element != 'undefined' ? element : this.element);
		if(!drag.DragElement) drag.createDragElement();
		this.url = loadHtmSrc + '?url='+url;
		this.data = data;
		if(typeof title != 'undefined' && title !=''){
			this.title = title;
			this.dragBox.innerHTML = '<span class="info">'+this.title+'</span>' + '<span class="close"><img src="'+minImgSrc+'" border="0" onclick="drag.pucker(this);" title="隐藏内容"> <img src="'+closeImgSrc+'" border="0" onclick="drag.hide(this);" title="关闭"></span>';
		}
		this.width = (typeof width != 'undefined' ? width : this.width);
		this.height = (typeof height != 'undefined' ? height : this.height);
		this.frame = '<iframe id="'+this.element+'IFrame" name="'+this.element+'IFrame" class="dialogIFrame" style="width:100%; height:100%" frameborder="0" scrolling="auto" src="'+this.url+'"></iframe>';
		if(typeof(num)!="undefined" && num!=''){
			this.dragBox.innerHTML = '<span class="info">'+this.title+'</span>' + '<span class="close"><img src="'+minImgSrc+'" border="0" onclick="drag.pucker(this);" title="隐藏内容"> <a href="javascript:drag.ajustIndex('+num+');"></a><img src="'+closeImgSrc+'" border="0" onclick="drag.hide(this);" title="关闭"></span>';
		}
		if(typeof this.url != 'undefined' && this.url!= loadHtmSrc+'?url='){
			this.contentBox.innerHTML = this.frame;
		}
		else{
			this.contentBox.innerHTML = this.data;
		}
		var s = drag.Box.style;
		s.width = this.width+'px';
		s.height = this.height+'px';
		this.contentBox.style.height = (this.height - 28)+'px';
		this.toCenter();
		if(drag.fullBox) drag.fullBox.style.display = 'block';
	},
	hide:function(obj){
	
		if(typeof obj == 'undefined') return;
		if(typeof obj == 'string'){
			if($(obj)) $(obj).style.display = 'none';
			if(drag.fullBox) drag.fullBox.style.display = 'none';
			return;
		}
		var dragDiv = obj.parentNode.parentNode;
		if(dragDiv.getAttribute('DragElement')=="true" || dragDiv.getAttribute('DragFrame')=="true"){
			if(drag.dragObjArray.length>1){
				if(dragDiv.getAttribute('DragFrame')=="true"){
					dragDiv.parentNode.removeChild(dragDiv);
				}
				else{
					dragDiv.parentNode.parentNode.removeChild(dragDiv.parentNode);
				}
			}
			else{
				if(dragDiv.getAttribute('DragFrame')=="true"){
					dragDiv.parentNode.removeChild(dragDiv);
				}
				else{
					dragDiv.parentNode.parentNode.removeChild(dragDiv.parentNode);
				}
				if(drag.fullBox) drag.fullBox.style.display = 'none';
			}
			drag.dragObjArray.length = drag.dragObjArray.length -1;
		}
	},
	pucker:function(obj){
		var dragDiv = obj.parentNode.parentNode.parentNode;
		var els = dragDiv.childNodes;
		if(dragDiv.getAttribute('DragFrame')=="true"){
			for(var i =0; i<els.length;i++){
				if(els[i].getAttribute('EContent')=="true"){
					if(els[i].style.display == "none"){
						var theight = dragDiv.style.height.replace('px','')/1+els[i].style.height.replace('px','')/1+3;
						dragDiv.style.height = theight + "px";
						els[i].style.display = 'block';
					}
					else{
						var theight = dragDiv.style.height.replace('px','')/1-els[i].style.height.replace('px','')/1-3;
						dragDiv.style.height = theight + "px";
						els[i].style.display = 'none';
					}
				}
			}
		}
	},
	cancelSelectionEvent : function(){
		if(this.dragDropTimer>=0)return false;
		return true;
	},
	ajustIndex:function(num){
		var fbs = drag.fullBox.style;
		if(fbs.zIndex > num){
			fbs.zIndex = num-1;
		}
		else{
			fbs.zIndex = num+1;
		}
	},
	setStyle :function (el,property,val){
		if(typeof el != 'object') el=document.getElementById(el);
		switch(property){
			case 'opacity':
				if(el.filters){
					el.style.filter='alpha(opacity='+val*100+')';
					if(!el.currentStyle.hasLayout){
						el.style.zoom=1;
					}
				}else{
					el.style.opacity=val;
					el.style['-moz-opacity']=val;
					el.style['-khtml-opacity']=val;
				}
				break;
			default:
				el.style[property]=val;
		}
	}
}


var fullFirame ='<iframe src="about:blank" style="position:absolute; visibility:inherit; top:0px; left:0px; width:100%; height:100%; z-index:-1; filter=\'progid:DXImageTransform.Microsoft.Alpha(style=0,opacity=1)\';"></iframe>';

document.write('<style type="text/css">');
document.write('html, body {padding:0px; margin:0px; height: 100%; width:100%;}');
document.write('.dialog {position:absolute; left:100px; top:100px; width:200px; background:#fff; border:1px solid #d4e3fd; padding:3px;}');
document.write('.dialogTitleBar {margin:2px 0px 3px 0px; text-align:left; padding:2px; background:#e6f0fd; border:1px solid #d4e3fd; cursor:move; height:16px}');
document.write('.dialogTitleBar span.info {float:left;	font-weight:bold;}');
document.write('.dialogTitleBar span.close {	float:right;cursor:pointer;margin-right:5px;text-align:right;}');
document.write('.dialogTitle {margin-top:5px;float:left;color:#333;font-weight:bold;font-size:12px;font-family:verdana,arial,sans-serif,"宋体";}');
document.write('.dialogTitleBtn {float:right; margin:2px 2px 2px 0px; width:20px; height:18px; border:1px solid #000000; background:#ffffff; font:12px/18px "Webdings"; color:#000000; text-decoration:none; text-align:center;}');
document.write('.dialogTitleBtn:hover {color:#8989bc; text-decoration:none;}.dialogContent {background:#fff;}');

document.write('.DragBox {background:#fcf0fd; border:1px solid #3887BA; padding:2px;}');
document.write('.DragBox .TitleBar {margin:0px; text-align:left; padding:2px; background:#e6f0fd; border:1px solid #3887BA; cursor:move; height:18px}');
document.write('.DragBox .TitleBar span.info {float:left;	font-weight:bold;}');
document.write('.DragBox .TitleBar span.close {	float:right;cursor:pointer;margin-right:5px;text-align:right;}');
document.write('.DragBox .Title {margin-top:5px;float:left;color:#333;font-weight:bold;font-size:12px;font-family:verdana,arial,sans-serif,"宋体";}');
document.write('.DragBox .TitleBtn {float:right; margin:2px 2px 2px 0px; width:20px; height:18px; border:1px solid #000000; background:#ffffff; font:12px/18px "Webdings"; color:#000000; text-decoration:none; text-align:center;}');
document.write('.DragBox .TitleBtn:hover {color:#8989bc; text-decoration:none;}.DragBox .Content {background:#fff;}');
document.write('</style>');