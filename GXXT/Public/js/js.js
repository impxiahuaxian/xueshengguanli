//头部微信与APP的图片出现
function headerImgS(){
    $('.header_one_box').find('.wx_hover').mouseover(function(){
        $(this).find('img').stop().animate({'height':'192px'});
    }).mouseleave(function(){
        $(this).find('img').stop().animate({'height':0});
    });
    $('.header_one_box').find('.app_hover').mouseover(function(){
        $(this).find('img').stop().animate({'height':'192px'});
    }).mouseleave(function(){
        $(this).find('img').stop().animate({'height':0});
    });
}

//船舶录入下拉框
function inputSelect(){
    $('.pages_search_choose').mouseover(function(){
        var len = $(this).find('.chooseDiv').find('a').length;
        var h1 = len*36 + (len-1);
        $(this).find('.chooseDiv').stop().animate({'height':h1+'px'});
        $(this).find('.chooseDiv').css({'borderWidth':'1px','box-shadow':'0 0 5px 1px #dedede'});
        $(this).find('.chooseDiv').find('a').each(function(){
            $(this).click(function(){
                var name = $(this).html();
                console.log(name);
                $(this).parent().prev().prev().val(name);
            })
        })
    }).mouseleave(function(){
        $(this).find('.chooseDiv').stop().animate({'height':0});
        $(this).find('.chooseDiv').css({'borderWidth':0,'box-shadow':'0 0 5px 1px #fff'});
    })
}

//banner图标居中显示
function ulWidth(){
    var w1 = ($('.picScroll-left1').find('.hd>ul').width())/2;
    $('.picScroll-left1').find('.hd>ul').css({'marginLeft':-w1+'px'});
    var w2 = ($('.picScroll-left2').find('.hd>ul').width())/2;
    $('.picScroll-left2').find('.hd>ul').css({'marginLeft':-w2+'px'});
}

//船源信息详情
function shipDetails(){
    $('.ship_details_box').find('table').find('a.table_select').click(function(){
        $('.ship_detail_pop_bg').css({'display':'block'});
        //$('.ship_detail_pop_box').css({'display':'block'});
    })
}
function shipDetailsHide(){
    $('.ship_detail_pop_box').find('.close').click(function(){
        $('.ship_detail_pop_bg').css({'display':'none'});
        $('.ship_detail_pop_box').css({'display':'none'});
    })
    $('.ship_detail_pop_bg').click(function(){
        $('.ship_detail_pop_bg').css({'display':'none'});
        $('.ship_detail_pop_box').css({'display':'none'});
    })
}

//常过码头选择
function pagesPierShow(){
    $('.pages_pier_bg').css({'display':'block'});
    $('.pages_pier_box').css({'display':'block'});
}
function pagesPierHide(){
    $('.pages_pier_bg').css({'display':'none'});
    $('.pages_pier_box').css({'display':'none'});
}

//意向到达港点选--关闭
function selectPierClose(){
    $('.pages_select_pier_list').find('a').click(function(){
        $(this).parent().css({'display':'none'});
    })
}
//意向到达港点选--点选
function selectPier() {
    $('.pages_pier_list').find('a').toggle(
        function () {
            $(this).addClass("hover");
        },
        function () {
            $(this).removeClass("hover");
        }
    )
}

//ajax提交
function ajaxPost(obj, action, data) {
    if (!action) {
        alert('缺少必要参数！');
        return false;
    }
    //保存按钮文字
    obj.attr('stop', obj.text());
    obj.text('操作中···');
    var post_url = 'ajax.php?a=' + action;
    $.ajax({
        url: post_url,
        type: 'POST',
        dataType: 'json',
        data: data,
        success: function(response) {
            if (response === null) {
                obj.text(obj.attr('stop'));
                obj.parent().children().attr('stop', '');
                alert('请稍后再试！');
                location = location;
                return false;
            }
            switch (response.status) {
                case '900001':
                    obj.text('操作成功');
                    //alert(response.info);
                    switch (action) {
                        case 'boats_delete':
                        case 'publish_boats':
                        case 'publish_ship':
                            location = 'boats_manage.php';
                        break;

                        case 'publish_goods':
                        case 'goods_delete':
                            location = 'goods_manage.php';
                        break;

                        case 'ship_delete':
                        case 'save_ship_msg':
                            if (data.admin) {
                                location = 'admin_boats_ship_manage.php';
                            }else{
                                location = 'boats_ship_manage.php';
                            }
                        break;

                        case 'save_info':
                            location = 'member_ucenter.php';
                        break;
                        case 'ship_transaction':
                        case 'ships_delete':
                            location = 'ships_manage.php';
                        break;

                        default:
                            location = 'index.php';
                    }
                    break;
                case '900900':
                    obj.text(obj.attr('stop'));
                    obj.attr('stop', '');
                    alert(response.info);
                    break;
                default:
                    obj.text(obj.attr('stop'));
                    obj.parent().children().attr('stop', '');
                    alert(response.info);
            }
        }
    });
}

    function inputShipInfo(options){
        var defaults = {
            port_list_arr:null,
            port_arr:null,
            port_list_value:null,
            port_value:null
        };
        var opts = $.extend(true,{},defaults, options);

        this.main = function(){
            this.portListDis();
            this.shipNationalityDis();
        }

        /**
         * 显示输出所有港口
         */
        this.portListDis = function(){
            var $_frequently_pass_port = $('#_frequently_pass_port');
            var $pages_select_pier_list = $('.pages_select_pier_list');

            var input_value_arr = [];
            var default_select_port_data = {}; // 默认选中的港口
            if($_frequently_pass_port.val()){
                var default_value = $_frequently_pass_port.val();
                var input_value_arr = default_value.substr(1,default_value.length-2).split('|');
            }

            var $ul = $('#_port_list .pages_pier_list ul');
            for(var list_k in opts.port_list_arr){
                var $li = $("<li></li>").appendTo($ul);
                var $span = $('<span></span>').appendTo($li);
                $span.text(opts.port_list_arr[list_k]);

                var $div = $('<div class="pages_pier_btn"></div>').appendTo($li);
                var this_city_port = opts.port_arr[list_k];
                for(var port_k in this_city_port){
                    var $a = $('<a href="javascript:void(0)"></a>').appendTo($div);
                    var port_key = list_k+port_k;
                    $a.text(this_city_port[port_k]).attr('port_key',port_key);
                    if($.inArray(port_key,input_value_arr) >= 0 ){
                        $a.addClass('hover');
                        default_select_port_data[port_key] = this_city_port[port_k];
                    }
                }
            }
            // 显示默认值
            fillSelectedPort(default_select_port_data);

            $ul.find('a').toggle(
                function () {
                    $(this).addClass("hover");
                },
                function () {
                    $(this).removeClass("hover");
                }
            );


            // 点击确定按钮
            $('#_selected_port').click(function(){
                var $selected_port = $ul.find('a.hover');
                var select_port_data = {};
                $selected_port.each(function(){
                    select_port_data[$(this).attr('port_key')] = $(this).text();
                });

                // 填充值
                fillInputValue();
                // 显示选中
                fillSelectedPort(select_port_data);
                $('.pages_pier_bg').css({'display':'none'});
                $('.pages_pier_box').css({'display':'none'});
            });
            // 点击关闭按钮
            $('#_selected_cancel').click(function(){
                var selected_key = [];
                $pages_select_pier_list.find('div.pages_select_pier_list_bottom').each(function(){
                    selected_key.push($(this).attr('port_key'));
                });
                $selected_port = $ul.find('a.hover');
                $selected_port.each(function(){
                    var this_port_key = $(this).attr('port_key');
                    if($.inArray(this_port_key,selected_key) < 0){
                        $(this).removeClass('hover');
                    }
                });
                $('.pages_pier_bg').css({'display':'none'});
                $('.pages_pier_box').css({'display':'none'});
            });


            // 点击X去除选择
            function removeSelectedPort(obj){
                var port_key = $(obj).parent().attr('port_key');
                $(obj).parent().remove();
                $ul.find('a[port_key="'+port_key+'"]').removeClass('hover');
                // 填充input值
                fillInputValue();
            }
            // 填充input值
            function fillInputValue(){
                var $selected_port = $ul.find('a.hover');
                var input_value ='';
                $selected_port.each(function(){
                    input_value += $(this).attr('port_key')+'|';
                });
                if(input_value){
                    input_value = '|'+input_value;
                    $_frequently_pass_port.val(input_value);
                }else{
                    $_frequently_pass_port.val('');
                }
            }

            // 填充选中的港口
            function fillSelectedPort(select_port_data){
                $pages_select_pier_list.empty();
                for(var selected_key in select_port_data){
                    var $content = $('<div class="pages_select_pier_list_bottom">\n    <em></em>\n    <a href="javascript:void(0)">×</a>\n</div>').appendTo($pages_select_pier_list);
                    $content.find('em').text(select_port_data[selected_key]).parent().attr('port_key',selected_key);
                    $content.find('a').click(function(){
                        removeSelectedPort(this);
                    });
                }
            }
        }

        this.shipNationalityDis = function(){
            var $port_area = $('#_ship_nationality [name="port_area"]');
            for(var list_k in opts.port_list_arr){
                var $option = $('<option></option>').appendTo($port_area);
                $option.val(list_k).text(opts.port_list_arr[list_k]);
            }

            // 关联港口地区选择
            var $port_name = $('#_ship_nationality [name="port_name"]');
            $port_area.change(function(e,v){
                if(v != undefined){
                    $(this).val(v);
                }
                var area_value = $(this).val();
                var port_name_arr = opts.port_arr[area_value];

                $port_name.html('<option value="" > 请选择 </option>');
                for(var name_k in port_name_arr){
                    var $option = $('<option></option>').appendTo($port_name);
                    $option.val(name_k).text(port_name_arr[name_k]);
                }
            });

            // 默认值
            if(opts.port_list_value){
                $port_area.trigger('change',opts.port_list_value);

                if(opts.port_value){
                    $port_name.val(opts.port_value);
                }
            }
        }
    }
