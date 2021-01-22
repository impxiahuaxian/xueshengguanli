$(function () {
    $("#btnLogin").click(function () {
        var LoginName = $("#txtUserName").val();
        var LoginPwd = $("#txtUserPsd").val();

        if (LoginName == "") {
            alert("请输入您的用户名！");
            return false;
        }
        if (LoginPwd == "") {
            alert("请输入您的密码！");
            return false;
        }

        $.ajax({
            type: "post",
            url: "/Home/Login",
            data: { LoginName: LoginName, LoginPwd: LoginPwd },
            datatpye: "json",
            success: function (data) {
                if (data == false) {
                    alert("用户名或密码错误！");
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