<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WebPages.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<script type="text/javascript">
    //get string
    function TestString() {
       WebPages.test.GetAjaxString("Rocky", TestStringRetrun);
    }
    function TestStringRetrun(res) {
        alert(res.value);
    }

    //get object.
    function TestObject() {
       WebPages.test.GetAjaxObject(TestObjectReturn);
    }

    function TestObjectReturn(res) {
        alert(res.value.Behaviour);
    }

    //get Datatable.
    function TestDatatable() {
       WebPages.test.GetAjaxDatatable(TestDatatableReturn);
    }

    function TestDatatableReturn(res) {
        var dt = res.value;
        alert("column0:" + dt.Rows[0].column0 + "\n column1:" + dt.Rows[0].column1);
    }

    //get List<String>
    function TestListString() {
       WebPages.test.GetAjaxListString(TestListStringReturn);
    }

    function TestListStringReturn(res) {
        var list = res.value;
        var str = "";
        for (var i = 0; i < list.length; i++) {
            str = str + list[i] + "\t";
        }
        alert("List:" + str);
    }

    //...get其他类推

    //set demo
    function SetObject() {
        var Obj = new Object();
        Obj.Behaviour = "Rocky...";
        Obj.Lev1 = 1;
        Obj.Lev2 = 2;
        Obj.IsAuto = true;
       WebPages.test.SetAjaxObj(Obj);
    }
</script>
<body>
   <form id="form1" runat="server">
    <div>
        Get something demo<br>
        <input type="button" value="TestString" onclick="TestString();"/>  
        <input type="button" value="TestObject" onclick="TestObject();"/>  
        <input type="button" value="TestDatable" onclick="TestDatatable();"/>  
        <input type="button" value="TestListString" onclick="TestListString();"/>
        <hr />
        Set something demo<br />
        <input type="button" value="SetObject" onclick="SetObject();"/>
    </div>
    </form>
</body>
</html>
