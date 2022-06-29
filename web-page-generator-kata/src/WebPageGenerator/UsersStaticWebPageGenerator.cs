using System.Collections.Generic;
using System.IO;

class UsersStaticWebPageGenerator
{
    public void generateFile(List<User> users)
    {
        // save resulting static html page
        StreamWriter fileWriter = new StreamWriter("./html/users.html", false);
        fileWriter.WriteLine("<!doctype html>");
        fileWriter.WriteLine("<html lang=\"en\">");
        fileWriter.WriteLine("<head>");
        fileWriter.WriteLine("<meta charset=\"utf-8\">");
        fileWriter.WriteLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">");

        fileWriter.WriteLine("<title>User biographies</title>");

        fileWriter.WriteLine("<!-- Bootstrap core CSS -->");
        fileWriter.WriteLine("<link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css\" integrity=\"sha384-9gVQ4dYFwwWSjIDZnLEWnxCjeSWFphJiwGPXr1jddIhOegiu1FwO5qRGvFXOdJZ4\" crossorigin=\"anonymous\">");

        fileWriter.WriteLine("<!-- Custom styles for this template -->");
        fileWriter.WriteLine("<link href=\"assets/cover.css\" rel=\"stylesheet\">");
        fileWriter.WriteLine("</head>");

        fileWriter.WriteLine("<body class=\"text-center\">");

        fileWriter.WriteLine("<div class=\"cover-container d-flex w-100 h-100 p-3 mx-auto flex-column\">");
        fileWriter.WriteLine("<header class=\"masthead mb-auto\">");
        fileWriter.WriteLine("<div class=\"inner\">");
        fileWriter.WriteLine("<h3 class=\"masthead-brand\">Users Biography</h3>");
        fileWriter.WriteLine("<nav class=\"nav nav-masthead justify-content-center\">");
        fileWriter.WriteLine("<a class=\"nav-link active\" href=\"#\">Home</a>");
        fileWriter.WriteLine("<a class=\"nav-link\" href=\"#\">Features</a>");
        fileWriter.WriteLine("<a class=\"nav-link\" href=\"#\">Contact</a>");
        fileWriter.WriteLine("</nav>");
        fileWriter.WriteLine("</div>");
        fileWriter.WriteLine("</header>");

        fileWriter.WriteLine("<main role=\"main\" class=\"inner cover\">");
        foreach (User user in users)
        {
            fileWriter.WriteLine("<h1 class=\"cover-heading\">" + user.Name + "</h1>\n");
			AddLabels(user, fileWriter);
            fileWriter.WriteLine("<p class=\"lead\">" + user.Biography + "</p>\n");
        }
        fileWriter.WriteLine("</main>");

        fileWriter.WriteLine("<footer class=\"mastfoot mt-auto\">");
        fileWriter.WriteLine("<div class=\"inner\">");
        fileWriter.WriteLine("<p>Sprout class kata created by Codium <a href=\"https://twitter.com/CodiumTeam\">@CodiumTeam</a>. Cover template for <a href=\"https://getbootstrap.com/\">Bootstrap</a>, by <a href=\"https://twitter.com/mdo\">@mdo</a>.</p>");
        fileWriter.WriteLine("</div>");
        fileWriter.WriteLine("</footer>");
        fileWriter.WriteLine("</div>");

        fileWriter.WriteLine("<!-- Bootstrap core JavaScript");
        fileWriter.WriteLine("        ================================================== -->");
        fileWriter.WriteLine("<!-- Placed at the end of the document so the pages load faster -->");
        fileWriter.WriteLine("<script src=\"https://code.jquery.com/jquery-3.3.1.slim.min.js\" integrity=\"sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo\" crossorigin=\"anonymous\"></script>");
        fileWriter.WriteLine("<script src=\"https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js\" integrity=\"sha384-cs/chFZiN24E4KMATLdqdvsezGxaGsi4hLGOzlXwp5UZB1LY//20VyM2taTB4QvJ\" crossorigin=\"anonymous\"></script>");
        fileWriter.WriteLine("<script src=\"https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js\" integrity=\"sha384-uefMccjFJAIv6A+rW+L4AHf99KvxDjWSu1z9VI8SKNVmz4sk7buKt/6v9KI65qnm\" crossorigin=\"anonymous\"></script>");
        fileWriter.WriteLine("</body>");
        fileWriter.WriteLine("</html>");

        fileWriter.Close();
    }

    private static void AddLabels(User user, StreamWriter fileWriter)
    {
        var communityManagerLabel = CommunityManagerLabel(user);
        fileWriter.WriteLine(communityManagerLabel);
    }

    private static string CommunityManagerLabel(User user)
    {
        if (user.Biography.Contains("community manager"))
        {
            return "<span class=\"badge badge-pill badge-danger\">Community manager</span>";
        }

        return "";
    }
}
