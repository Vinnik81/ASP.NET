using System.Linq;
using System.Text;

namespace HomeWork1_CV.Utility
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString()
        {
            var sb = new StringBuilder();
            sb.Append(@"<!DOCTYPE html>
<html lang='en'>
< head >
    < meta charset = 'utf-8' />
    < meta name = 'viewport' content = 'width=device-width, initial-scale=1.0' />
    < title > @ViewData['Title'] - HomeWork1_CV </ title >
    < link rel = 'stylesheet' href = '~/lib/bootstrap/dist/css/bootstrap.min.css' />
    < link rel = 'stylesheet' href = '~/css/site.css' />
</ head > 
<body>
<div class='text - left'>
    < h1 class='display-4'>Персональные данные</h1>
    <div class='name'>
        <h2>Имя: <i>@Model.Person.Name</i></h2>
        <h2>Фамилия: <i>@Model.Person.Surname</i></h2>
        <h4>Возраст: <i>@Model.Person.Age</i></h4>
        <h4>Дата рождения: <i>@Model.Person.DateOfBith</i></h4>
        <h4>Место родения: <i>@Model.Person.BirthPlace</i></h4>
    </div>
    
</div>
</body>
");
            return sb.ToString();
        }
    }
}
