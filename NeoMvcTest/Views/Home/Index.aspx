<%@ Page Language="C#" %>

<%
    var model = this.Model as ArrayList;
    
%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
    <div>
        <table>
            <%for (int i = 0; i < model.Count; i++)
              {
                  ListItem item = model[i] as ListItem;
            %>
            <tr>
                <td>
                    <%=item.Text %>
                </td>
                <td>
                    <%=item.Value %>
                </td>
            </tr>
            <%} %>
        </table>
    </div>
</body>
</html>
