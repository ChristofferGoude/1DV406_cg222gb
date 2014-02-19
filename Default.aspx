<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="css/StyleSheet.css" type="text/css" />
    <script src="js/JavaScript.js"></script>
    <title></title>
</head>
<body>
    <div id="wrapper">
        <img src="pics/title.png" width="500" height="250" alt="Guess the secret number!" />
        <form id="form1" runat="server">
            <div>
                <asp:Label ID="GuessLabel" runat="server" AssociatedControlID="GuessBox" Text="Ange ett heltal mellan 1 och 100"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="GuessBox" runat="server"></asp:TextBox>
                <asp:Button ID="GuessButton" runat="server" Text="Gissa!" OnClick="GuessButton_Click" />
                <asp:Button ID="RetryButton" runat="server" Text="Nytt försök!" Onclick="RetryButton_Click"/>
            </div>
            <div id="result" runat="server"></div>
            <div id="guesses" runat="server"></div>
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator1" 
                runat="server"
                ControlToValidate="GuessBox"
                ErrorMessage="Fältet får ej vara tomt! <br>">
            </asp:RequiredFieldValidator>
            <asp:RangeValidator 
                ID="RangeValidator1" 
                runat="server" 
                ControlToValidate="GuessBox"
                MinimumValue="1"
                MaximumValue="100"
                Type="Integer"
                ErrorMessage="Värdet måste ligga mellan 1 och 100!">
            </asp:RangeValidator>
        </form>
    </div>
</body>
</html>
