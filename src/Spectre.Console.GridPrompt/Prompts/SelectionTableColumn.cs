namespace Spectre.Console;

public record SelectionTableColumn<T>(string Header, Func<T, string> ValueGetter, Action<TableColumn>? Configure = null);
