<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GuessTheNumber.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa det hemliga talet</title>
    <link rel="stylesheet" href="~/css/Style.css">
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <header id="header">
            <h1>Gissa det hemliga talet</h1>
        </header>           
        <main>
            <section>

                <%-- Presentation of guesses, also dynamicly adds restartbutton on game over. --%>
                <div id="guessesDiv">
                    <div>
                        <asp:Label ID="GuessesLabel" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="guessesSpacing">
                        <asp:Label ID="GuessStatusLabel" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <asp:Button ID="NewNumberButton" runat="server" Text="Slumpa nytt hemligt tal" Visible="false" OnClick="NewNumberButton_Click" CausesValidation="False"></asp:Button>
                    </div>
                </div>

                <%-- Input for guess with validation (int, range 1-100). --%>
                <div>
                <asp:Label ID="Label1" runat="server" Text="Ange ett tal mellan 1 och 100: " AssociatedControlID="NumberGuessTextBox"></asp:Label>
                <asp:TextBox ID="NumberGuessTextBox" runat="server" autofocus="autofocus"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Display="Dynamic" CssClass="field-validation-error" ControlToValidate="NumberGuessTextBox"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="*" CssClass="field-validation-error" ControlToValidate="NumberGuessTextBox" Display="Dynamic" MinimumValue="1" MaximumValue="100" Type="Integer"></asp:RangeValidator>
                </div>
                
                <%-- Button for sending guess. --%>
                <div>
                <asp:Button ID="GuessButton" runat="server" Text="Skicka gissning" CssClass="standardButton" OnClick="GuessButton_Click"></asp:Button>
                </div>

                <div style="clear: both;"></div>
            </section>
        </main>
    </div>
    </form>
</body>
</html>