$(function () {
    $("#btnLogin").click(function () {
        var LoginName = $("#txtUserName").val();
        var LoginPwd = $("#txtUserPSD").val();
       
        if (LoginName == "") {
           alert("请输入您的账号！", "提示", "确定");
            return false;
        }
        if (LoginPwd == "") {
            alert("请输入您的密码！", "提示", "确定");
            return false;
        }
    
        $.ajax({
            type: "post",
            traditional: true,
            url: "/Home/Login",
            data: { LoginName: LoginName, LoginPwd: LoginPwd },
            datatpye: "json",
            success: function (data) {
                if (data == "9") {
                    alert("账号或密码错误！");
                    window.location = "/Home/Login";
                }
                else {
                    window.location = "/Work/Index";
                }
            }
        });
               
        

    });

    $("body").keydown(function () {
        if (event.keyCode == "13") {//keyCode=13是回车键
            $('#btnLogin').click();
        }
    });
});