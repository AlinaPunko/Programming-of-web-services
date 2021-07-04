<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Lab4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Lab4</title>
<script src="jquery.js"></script>
    <script>
        function getSum_Ajax() {
            const data = {
                x: parseInt($("#x").val()),
                y: parseInt($("#y").val())
            };
            $.ajax({
                url: "Simlex.asmx/sum_4",
                type: "GET",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: data,
                success: result => {
                    $("#result").val(result.d);
                },
                error: error => {
                    console.log(error);
                }
            })
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <input type="text" id="x"/>
                <input type="text" id="y"/>
                
    <input type="button" onclick="getSum_Ajax()" value="ajax" />
            </div>
            <div>
                <input type="text" id="result"/>
            </div>
        </div>
    </form>
</body>
</html>
