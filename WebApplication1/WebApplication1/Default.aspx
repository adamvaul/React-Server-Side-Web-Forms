<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>React Demo</title>
</head>
<body>
    Page Content Here:
    <asp:Literal ID="PageContent" runat="server"></asp:Literal>


    <div id="content">
        <asp:Literal ID="app" runat="server"></asp:Literal>
    </div>


    <asp:PlaceHolder runat="server">
        <script src="Scripts/lib/react.js"></script>
        <script src="Scripts/lib/underscore.js"></script>
        <script src="Scripts/components/helloWorld.jsx"></script>
        <script src="Scripts/Tutorial.jsx"></script>
        <script type="text/javascript">
            <asp:Literal ID="litInitJS" runat="server" />
        </script>
    </asp:PlaceHolder>
    

</body>
</html>
