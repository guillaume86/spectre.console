using System.Text.Json;

namespace Spectre.Console.GridPrompt;

internal class Program
{
    public static void Main()
    {
        var favorites = AnsiConsole.Prompt(
            new TableMultiSelectionPrompt<string>()
                .UseConfigureTable(table => table
                    .SimpleHeavyBorder()
                    .BorderColor(Color.Yellow)
                    .Expand())
                .AddColumn("Name", fruit => fruit, c => c.Header("[bold]Name[/]"))
                .AddColumn("Nb letters", fruit => fruit.Length > 5 ? $"[red bold]{fruit.Length}[/]" : fruit.Length.ToString(), c => c.Header("[bold]Nb Letters[/]").RightAligned())
                .PageSize(10)
                .Title("What are your [green]favorite fruits[/]?")
                .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                .InstructionsText("[grey](Press [blue]<space>[/] to toggle a fruit, [green]<enter>[/] to accept)[/]")
                .AddChoiceGroup("Berries", new[]
                {
                        "Blackcurrant", "Blueberry", "Cloudberry",
                        "Elderberry", "Honeyberry", "Mulberry"
                })
                .AddChoices(new[]
                {
                        "Apple", "Apricot", "Avocado", "Banana",
                        "Cherry", "Cocunut", "Date", "Dragonfruit", "Durian",
                        "Egg plant",  "Fig", "Grape", "Guava",
                        "Jackfruit", "Jambul", "Kiwano", "Kiwifruit", "Lime", "Lylo",
                        "Lychee", "Melon", "Nectarine", "Orange", "Olive"
                }));

        var fruit = favorites.Count == 1 ? favorites[0] : null;
        if (string.IsNullOrWhiteSpace(fruit))
        {
            fruit = AnsiConsole.Prompt(
                new TableSelectionPrompt<string>()
                    .UseConfigureTable(table =>
                    {
                        table.SimpleHeavyBorder().Expand();
                    })
                    .AddColumn("Name", fruit => fruit)
                    .AddColumn("Nb letters", fruit => fruit.Length > 5 ? $"[red bold]{fruit.Length}[/]" : fruit.Length.ToString(), c => c.RightAligned())
                    .EnableSearch()
                    .Title("Ok, but if you could only choose [green]one[/]?")
                    .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                    .AddChoices(favorites));
        }

        AnsiConsole.MarkupLine("You selected: [yellow]{0}[/]", fruit);
    }

    //private static void Render(string title, IRenderable chart)
    //{
    //    AnsiConsole.Write(
    //        new Panel(chart)
    //            .Padding(1, 1)
    //            .Header(title));
    //}
}
